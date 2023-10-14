using System.Diagnostics;

namespace Secure_Delete
{
    public partial class Form1 : Form
    {
        // Constants

        private const string SDELETE_URL = "https://docs.microsoft.com/en-us/sysinternals/downloads/sdelete";
        private readonly Secure_Deleter secure_deleter;

        // Constructor
        public Form1()
        {
            InitializeComponent();
            secure_deleter = new Secure_Deleter(richTextBox_logs, numericUpDown_overwrite_passes, progressBar_indicator, textBox_s_delete_file_path, textBox_normal_filepath);

            button_erase_file.Click += secure_deleter.Secure_Delete_File;

            this.FormClosed += On_Form_Closed;
        }

        // Functions -------------------------------------------------------------------------------------------------------------------------------------------------------

        // Events subscriptions ---------------------------------------------------------------------------------------------------
        // On form Close unsubscribe the events
        private void On_Form_Closed(object? sender, FormClosedEventArgs args)
        {
            if (sender is Form)
            {
                button_erase_file.Click -= secure_deleter.Secure_Delete_File;
                this.FormClosed -= On_Form_Closed;
            }
        }

        // Events subscriptions ---------------------------------------------------------------------------------------------------

        // Main select a file method ----------------------------------------------------------------------------------------------
        private static void Select_File(string title, TextBox text_box_to_update)
        {
            using var open_file_dialog = new OpenFileDialog
            {
                Title = title
            };

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                text_box_to_update.Text = open_file_dialog.FileName;
            }
        }

        // Select the file to be deleted
        private void Select_File_Button_Click(object sender, EventArgs args)
        {
            Select_File("Select a file to be deleted!", textBox_normal_filepath);
        }

        // Select the location of the sdelete
        private void Select_SDelete_Location_Click(object sender, EventArgs args)
        {
            Select_File("Select the location of SDelete!", textBox_s_delete_file_path);
        }

        // Main select a file method ----------------------------------------------------------------------------------------------

        // Exit the application
        private void Exit_Tool_Strip_Menu_Item_Click(object sender, EventArgs args)
        {
            Application.Exit();
        }

        // Instruction on how to use the application
        private void Instructions_Tool_Strip_Menu_Item_Click(object sender, EventArgs args)
        {
            MessageBox.Show($"We simply select the file that we want to delete then we have 2 options:\n" +
                            $"A: Use my method of secure delete (that works with filling the file with 0's and then it deletes it).\n" +
                            $"B: Use the Sdelete (I just added this option because I wanted to test it.).\n" +
                            $"NOTE: When using the Sdelete you must select it where you have unpacked it or simply use the source I have provided in the Sdelete folder.",
                            "Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Clear the logs and the progress bar
        private void Button_Clear_Logs_Click(object sender, EventArgs args)
        {
            richTextBox_logs.Text = string.Empty;
            progressBar_indicator.Value = 0;
        }

        // Link SDelete
        private void Link_Label_S_Delete_Clicked(object sender, LinkLabelLinkClickedEventArgs args)
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = SDELETE_URL,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Functions -------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}