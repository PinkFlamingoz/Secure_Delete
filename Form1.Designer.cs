namespace Secure_Delete
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip_main_menu = new MenuStrip();
            menu_ToolStripMenuItem = new ToolStripMenuItem();
            instructions_ToolStripMenuItem = new ToolStripMenuItem();
            exit_ToolStripMenuItem = new ToolStripMenuItem();
            groupBox_Selection = new GroupBox();
            numericUpDown_overwrite_passes = new NumericUpDown();
            button_s_delete = new Button();
            linkLabel_s_delete = new LinkLabel();
            progressBar_indicator = new ProgressBar();
            button_clear_logs = new Button();
            button_browse_file = new Button();
            button_erase_file = new Button();
            textBox_s_delete_file_path = new TextBox();
            textBox_normal_filepath = new TextBox();
            groupBox_logs = new GroupBox();
            richTextBox_logs = new RichTextBox();
            label_number_of_passes = new Label();
            label_file_to_delete = new Label();
            menuStrip_main_menu.SuspendLayout();
            groupBox_Selection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_overwrite_passes).BeginInit();
            groupBox_logs.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip_main_menu
            // 
            menuStrip_main_menu.Items.AddRange(new ToolStripItem[] { menu_ToolStripMenuItem });
            menuStrip_main_menu.Location = new Point(0, 0);
            menuStrip_main_menu.Name = "menuStrip_main_menu";
            menuStrip_main_menu.Padding = new Padding(8, 3, 0, 3);
            menuStrip_main_menu.Size = new Size(1091, 26);
            menuStrip_main_menu.TabIndex = 0;
            menuStrip_main_menu.Text = "menuStrip1";
            // 
            // menu_ToolStripMenuItem
            // 
            menu_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { instructions_ToolStripMenuItem, exit_ToolStripMenuItem });
            menu_ToolStripMenuItem.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menu_ToolStripMenuItem.Name = "menu_ToolStripMenuItem";
            menu_ToolStripMenuItem.Size = new Size(47, 20);
            menu_ToolStripMenuItem.Text = "Menu";
            // 
            // instructions_ToolStripMenuItem
            // 
            instructions_ToolStripMenuItem.Name = "instructions_ToolStripMenuItem";
            instructions_ToolStripMenuItem.Size = new Size(158, 22);
            instructions_ToolStripMenuItem.Text = "Instructions";
            instructions_ToolStripMenuItem.Click += Instructions_Tool_Strip_Menu_Item_Click;
            // 
            // exit_ToolStripMenuItem
            // 
            exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            exit_ToolStripMenuItem.Size = new Size(158, 22);
            exit_ToolStripMenuItem.Text = "Exit";
            exit_ToolStripMenuItem.Click += Exit_Tool_Strip_Menu_Item_Click;
            // 
            // groupBox_Selection
            // 
            groupBox_Selection.Controls.Add(label_file_to_delete);
            groupBox_Selection.Controls.Add(label_number_of_passes);
            groupBox_Selection.Controls.Add(numericUpDown_overwrite_passes);
            groupBox_Selection.Controls.Add(button_s_delete);
            groupBox_Selection.Controls.Add(linkLabel_s_delete);
            groupBox_Selection.Controls.Add(progressBar_indicator);
            groupBox_Selection.Controls.Add(button_clear_logs);
            groupBox_Selection.Controls.Add(button_browse_file);
            groupBox_Selection.Controls.Add(button_erase_file);
            groupBox_Selection.Controls.Add(textBox_s_delete_file_path);
            groupBox_Selection.Controls.Add(textBox_normal_filepath);
            groupBox_Selection.Dock = DockStyle.Top;
            groupBox_Selection.Location = new Point(0, 26);
            groupBox_Selection.Margin = new Padding(4);
            groupBox_Selection.Name = "groupBox_Selection";
            groupBox_Selection.Padding = new Padding(4);
            groupBox_Selection.Size = new Size(1091, 229);
            groupBox_Selection.TabIndex = 1;
            groupBox_Selection.TabStop = false;
            groupBox_Selection.Text = "Selection";
            // 
            // numericUpDown_overwrite_passes
            // 
            numericUpDown_overwrite_passes.Anchor = AnchorStyles.None;
            numericUpDown_overwrite_passes.Location = new Point(624, 86);
            numericUpDown_overwrite_passes.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_overwrite_passes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_overwrite_passes.Name = "numericUpDown_overwrite_passes";
            numericUpDown_overwrite_passes.Size = new Size(72, 26);
            numericUpDown_overwrite_passes.TabIndex = 8;
            numericUpDown_overwrite_passes.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button_s_delete
            // 
            button_s_delete.Anchor = AnchorStyles.None;
            button_s_delete.FlatStyle = FlatStyle.Flat;
            button_s_delete.Location = new Point(930, 28);
            button_s_delete.Margin = new Padding(4);
            button_s_delete.Name = "button_s_delete";
            button_s_delete.Size = new Size(148, 35);
            button_s_delete.TabIndex = 7;
            button_s_delete.Text = "SDelete";
            button_s_delete.UseVisualStyleBackColor = true;
            button_s_delete.Click += Select_SDelete_Location_Click;
            // 
            // linkLabel_s_delete
            // 
            linkLabel_s_delete.Anchor = AnchorStyles.None;
            linkLabel_s_delete.AutoSize = true;
            linkLabel_s_delete.Location = new Point(1006, 88);
            linkLabel_s_delete.Name = "linkLabel_s_delete";
            linkLabel_s_delete.Size = new Size(73, 21);
            linkLabel_s_delete.TabIndex = 6;
            linkLabel_s_delete.TabStop = true;
            linkLabel_s_delete.Text = "SDelete";
            linkLabel_s_delete.LinkClicked += Link_Label_S_Delete_Clicked;
            // 
            // progressBar_indicator
            // 
            progressBar_indicator.Anchor = AnchorStyles.None;
            progressBar_indicator.Location = new Point(13, 173);
            progressBar_indicator.Margin = new Padding(4);
            progressBar_indicator.Name = "progressBar_indicator";
            progressBar_indicator.Size = new Size(1065, 29);
            progressBar_indicator.TabIndex = 5;
            // 
            // button_clear_logs
            // 
            button_clear_logs.Anchor = AnchorStyles.None;
            button_clear_logs.FlatStyle = FlatStyle.Flat;
            button_clear_logs.Location = new Point(548, 28);
            button_clear_logs.Margin = new Padding(4);
            button_clear_logs.Name = "button_clear_logs";
            button_clear_logs.Size = new Size(148, 35);
            button_clear_logs.TabIndex = 4;
            button_clear_logs.Text = "Clear Logs";
            button_clear_logs.UseVisualStyleBackColor = true;
            button_clear_logs.Click += Button_Clear_Logs_Click;
            // 
            // button_browse_file
            // 
            button_browse_file.Anchor = AnchorStyles.None;
            button_browse_file.FlatStyle = FlatStyle.Flat;
            button_browse_file.Location = new Point(13, 28);
            button_browse_file.Margin = new Padding(4);
            button_browse_file.Name = "button_browse_file";
            button_browse_file.Size = new Size(148, 35);
            button_browse_file.TabIndex = 3;
            button_browse_file.Text = "Browse File";
            button_browse_file.UseVisualStyleBackColor = true;
            button_browse_file.Click += Select_File_Button_Click;
            // 
            // button_erase_file
            // 
            button_erase_file.Anchor = AnchorStyles.None;
            button_erase_file.FlatStyle = FlatStyle.Flat;
            button_erase_file.Location = new Point(392, 28);
            button_erase_file.Margin = new Padding(4);
            button_erase_file.Name = "button_erase_file";
            button_erase_file.Size = new Size(148, 35);
            button_erase_file.TabIndex = 2;
            button_erase_file.Text = "Erase File";
            button_erase_file.UseVisualStyleBackColor = true;
            // 
            // textBox_s_delete_file_path
            // 
            textBox_s_delete_file_path.Anchor = AnchorStyles.None;
            textBox_s_delete_file_path.Location = new Point(548, 125);
            textBox_s_delete_file_path.Margin = new Padding(4);
            textBox_s_delete_file_path.Name = "textBox_s_delete_file_path";
            textBox_s_delete_file_path.Size = new Size(530, 26);
            textBox_s_delete_file_path.TabIndex = 1;
            // 
            // textBox_normal_filepath
            // 
            textBox_normal_filepath.Anchor = AnchorStyles.None;
            textBox_normal_filepath.Location = new Point(13, 125);
            textBox_normal_filepath.Margin = new Padding(4);
            textBox_normal_filepath.Name = "textBox_normal_filepath";
            textBox_normal_filepath.Size = new Size(527, 26);
            textBox_normal_filepath.TabIndex = 0;
            // 
            // groupBox_logs
            // 
            groupBox_logs.Controls.Add(richTextBox_logs);
            groupBox_logs.Dock = DockStyle.Fill;
            groupBox_logs.Location = new Point(0, 255);
            groupBox_logs.Margin = new Padding(4);
            groupBox_logs.Name = "groupBox_logs";
            groupBox_logs.Padding = new Padding(4);
            groupBox_logs.Size = new Size(1091, 387);
            groupBox_logs.TabIndex = 2;
            groupBox_logs.TabStop = false;
            groupBox_logs.Text = "Logs";
            // 
            // richTextBox_logs
            // 
            richTextBox_logs.Dock = DockStyle.Fill;
            richTextBox_logs.Location = new Point(4, 23);
            richTextBox_logs.Margin = new Padding(4);
            richTextBox_logs.Name = "richTextBox_logs";
            richTextBox_logs.Size = new Size(1083, 360);
            richTextBox_logs.TabIndex = 0;
            richTextBox_logs.Text = "";
            // 
            // label_number_of_passes
            // 
            label_number_of_passes.Anchor = AnchorStyles.None;
            label_number_of_passes.AutoSize = true;
            label_number_of_passes.Location = new Point(392, 88);
            label_number_of_passes.Name = "label_number_of_passes";
            label_number_of_passes.Size = new Size(226, 21);
            label_number_of_passes.TabIndex = 9;
            label_number_of_passes.Text = "Enter number of passes :";
            // 
            // label_file_to_delete
            // 
            label_file_to_delete.Anchor = AnchorStyles.None;
            label_file_to_delete.AutoSize = true;
            label_file_to_delete.Location = new Point(13, 88);
            label_file_to_delete.Name = "label_file_to_delete";
            label_file_to_delete.Size = new Size(199, 21);
            label_file_to_delete.TabIndex = 10;
            label_file_to_delete.Text = "Browse file to delete";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 642);
            Controls.Add(groupBox_logs);
            Controls.Add(groupBox_Selection);
            Controls.Add(menuStrip_main_menu);
            Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip_main_menu;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            menuStrip_main_menu.ResumeLayout(false);
            menuStrip_main_menu.PerformLayout();
            groupBox_Selection.ResumeLayout(false);
            groupBox_Selection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_overwrite_passes).EndInit();
            groupBox_logs.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip_main_menu;
        private ToolStripMenuItem menu_ToolStripMenuItem;
        private ToolStripMenuItem instructions_ToolStripMenuItem;
        private ToolStripMenuItem exit_ToolStripMenuItem;
        private GroupBox groupBox_Selection;
        private Button button_erase_file;
        private TextBox textBox_s_delete_file_path;
        private TextBox textBox_normal_filepath;
        private ProgressBar progressBar_indicator;
        private Button button_clear_logs;
        private Button button_browse_file;
        private GroupBox groupBox_logs;
        private RichTextBox richTextBox_logs;
        private LinkLabel linkLabel_s_delete;
        private Button button_s_delete;
        private NumericUpDown numericUpDown_overwrite_passes;
        private Label label_file_to_delete;
        private Label label_number_of_passes;
    }
}