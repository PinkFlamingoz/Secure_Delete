using System.Diagnostics;

namespace Secure_Delete
{
    public class Secure_Deleter
    {
        // Constants

        private const string FSUTIL = "fsutil.exe"; // Utility to manage file systems and disks.
        private const int BUFFER_SIZE = 512; // The size of the buffer, typically a sector on a hard drive.
        private const int SDELETE_PASS_COUNT = 4; // Number of overwrite passes when using SDelete tool.
        private const int PROGRESS_INCREMENT = 100; // Progress bar increment value.

        // Variables

        private string[] hard_links = Array.Empty<string>();

        // UI controls from the form.

        private readonly RichTextBox log_box;
        private readonly NumericUpDown numeric_up_down_passes;
        private readonly ProgressBar progress_bar_indicator;
        private readonly TextBox text_box_sdelete_file_path;
        private readonly TextBox text_box_file_to_delete;

        // Constructor
        public Secure_Deleter(RichTextBox log_box, NumericUpDown numeric_up_down_passes, ProgressBar progress_bar_indicator, TextBox text_box_sdelete_file_path, TextBox text_box_file_to_delete)
        {
            this.log_box = log_box;
            this.numeric_up_down_passes = numeric_up_down_passes;
            this.progress_bar_indicator = progress_bar_indicator;
            this.text_box_sdelete_file_path = text_box_sdelete_file_path;
            this.text_box_file_to_delete = text_box_file_to_delete;
        }

        // Main delete functions --------------------------------------------------------------------------------------------------

        // Shared helper functions --------------------------------

        // Log a message
        private void Log(string message)
        {
            log_box.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
        }

        // Checks if a file is in use by another process
        private static bool Is_File_Locked(string filename)
        {
            try
            {
                using var file = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException e)
            {
                const int ERROR_SHARING_VIOLATION = -2147024864;
                if (e.HResult == ERROR_SHARING_VIOLATION)
                {
                    return true;
                }
                throw;  // If it's not the specific 'sharing violation' error, re-throw the exception.
            }
            return false;
        }

        // Shared helper functions --------------------------------

        // Confirm if you want to delete the file
        private static bool Confirm_File_Deletion(string filename)
        {
            DialogResult user_confirmation = MessageBox.Show($"Are you sure you want to erase this file {filename}?", "Continue", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return user_confirmation != DialogResult.Cancel;
        }

        // Sets file attributes to "normal" to facilitate its deletion
        private void Prepare_File_For_Deletion(string filename)
        {
            try
            {
                File.SetAttributes(filename, FileAttributes.Normal);
            }
            catch (UnauthorizedAccessException)
            {
                Log("Permission denied. Ensure you have sufficient privileges to modify this file.");
            }
            catch (FileNotFoundException)
            {
                Log("File not found. Ensure the file path is correct.");
            }
            catch (IOException args)
            {
                Log($"Error setting file attributes: {args.Message}");
            }
        }

        // Execute command ----------------------------------------

        // Process the output
        private void Process_Output(bool redirect_output, string command, Process external_process)
        {
            if (redirect_output)
            {
                var output = external_process.StandardOutput.ReadToEnd();

                Log($"Command Output: {output}");

                external_process.WaitForExit();

                if (command == FSUTIL)
                {
                    hard_links = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();
                }

                Log(output);
            }
            else
            {
                external_process.WaitForExit();
            }
        }

        // Executes shell commands, useful for invoking external tools like SDelete or fsutil
        private void Execute_Command(string command, string arguments, bool redirect_output)
        {
            using var external_process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = arguments,
                    Verb = "runas",
                    UseShellExecute = false,
                    RedirectStandardOutput = redirect_output,
                    CreateNoWindow = redirect_output
                }
            };

            external_process.Start();
            Process_Output(redirect_output, command, external_process);
        }

        // Execute command ----------------------------------------

        // Handle the hard links
        private void Handle_Hard_Links(string filename)
        {
            Log("Fetching hard links...");
            Execute_Command(FSUTIL, $"hardlink list \"{filename}\"", true);

            List<string> hard_link_paths = new();
            foreach (string s in hard_links)
            {
                string full_path = s; // since s is already the full path
                if (full_path != filename && File.Exists(full_path))
                {
                    hard_link_paths.Add(full_path);
                }
            }

            // Now, let's assume you've securely deleted the original file's content.
            // After that, delete all the hard links.
            foreach (var link_path in hard_link_paths)
            {
                File.Delete(link_path);
                Log($"Deleted hard link: {link_path}");
            }
        }

        // Use SDelete --------------------------------------------

        // Check if the user provided the sdelete file
        private bool Is_SDelete_Available()
        {
            return File.Exists(text_box_sdelete_file_path.Text);
        }

        // Accept the eula from sdelete
        private void Accept_SDelete_Eula(string sdeletePath)
        {
            Execute_Command(sdeletePath, "/accepteula", false);
        }

        // Use the SDelete method
        private void Execute_SDelete(string filename)
        {
            // Delete the file with SDelete
            Execute_Command(text_box_sdelete_file_path.Text, $"-p {SDELETE_PASS_COUNT} {filename}", true);

            // Zero the free space on the drive
            string driveLetter = filename[..3];
            Execute_Command(text_box_sdelete_file_path.Text, $"-z {driveLetter}", false);

            Log($"Secure deletion completed for {filename}");
        }

        // Main Function for using the sdelete method
        private void Use_SDelete(string filename)
        {
            Accept_SDelete_Eula(text_box_sdelete_file_path.Text);
            Execute_SDelete(filename);
        }

        // Use SDelete --------------------------------------------

        // Use custom delete --------------------------------------

        // Create a file stream
        private static Stream Create_File_Stream(string filename)
        {
            return new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.None, BUFFER_SIZE, FileOptions.RandomAccess | FileOptions.WriteThrough);
        }

        // Calculate sectors
        private double Calculate_Sectors(string filename)
        {
            if (!File.Exists(filename))
            {
                Log($"File {filename} not found in Calculate_Sectors.");
                return 0;
            }

            return Math.Ceiling(new FileInfo(filename).Length / 512.0);
        }

        // Overwrite the file stream
        private void Overwrite_File_Stream(string filename, double sectors, byte[] zero_buffer, Stream input_stream)
        {
            double progress_increment_per_sector = (double)PROGRESS_INCREMENT / sectors;

            for (int sectors_written = 0; sectors_written < sectors; sectors_written++)
            {
                double accumulated_progress = (sectors_written + 1) * progress_increment_per_sector;
                progress_bar_indicator.Value = Math.Min((int)Math.Round(accumulated_progress), 100);
                input_stream.Write(zero_buffer, 0, BUFFER_SIZE);
            }

            Log($"Completed overwrite pass for {filename}");
        }

        // Handle error
        private void Handle_Error(string error_message)
        {
            Log($"Error: {error_message}");
            MessageBox.Show($"An error occurred: {error_message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Use the custom delete method
        private void Delete_File_Contents(string filename)
        {
            var sectors = Calculate_Sectors(filename);

            Log($"Calculated sectors: {sectors}");
            if (sectors == 0)
            {
                Log($"File {filename} is empty. Skipping overwrite process.");
                return;
            }

            byte[] zero_buffer = new byte[BUFFER_SIZE];
            int overwrite_passes = (int)numeric_up_down_passes.Value;

            using Stream input_stream = Create_File_Stream(filename);
            for (int pass = 0; pass < overwrite_passes; pass++)
            {
                Log($"Starting overwrite pass {pass + 1} of {overwrite_passes}...");

                try
                {
                    Overwrite_File_Stream(filename, sectors, zero_buffer, input_stream);
                }
                catch (Exception args)
                {
                    Handle_Error(args.Message);
                    input_stream.Close();
                    return;
                }
            }

            input_stream.SetLength(0); // Delete the file after all passes are done
            input_stream.Close(); // Close the stream

            Log($"File {filename} has been securely deleted.");
        }

        // Use custom delete --------------------------------------

        // Main Delete Function
        public void Secure_Delete_File(object? sender, EventArgs args)
        {
            progress_bar_indicator.Value = 0;

            string filename = text_box_file_to_delete.Text;

            if (!Confirm_File_Deletion(filename))
            {
                return;
            }

            if (!File.Exists(filename))
            {
                Log("The target file does not exist. Please ensure the path is valid.");

                return;
            }

            if (Is_File_Locked(filename))
            {
                Log($"The file {filename} is currently being used by another process. Please close any applications that might be using it and try again.");
                return;
            }

            Prepare_File_For_Deletion(filename);
            Log($"File {filename} prepared for deletion.");

            if (Is_SDelete_Available())
            {
                Use_SDelete(filename);
            }
            else
            {
                Delete_File_Contents(filename);
            }
            Handle_Hard_Links(filename);
            progress_bar_indicator.Value = 100;
        }

        // Main delete functions --------------------------------------------------------------------------------------------------
    }
}