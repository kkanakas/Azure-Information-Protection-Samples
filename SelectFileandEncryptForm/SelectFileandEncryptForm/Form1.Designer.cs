namespace SelectFileandEncryptForm
{
    partial class fileEncrypt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePath = new System.Windows.Forms.TextBox();
            this.templateListBox = new System.Windows.Forms.ComboBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.clientid = new System.Windows.Forms.Label();
            this.clientidBox = new System.Windows.Forms.TextBox();
            this.getTemplateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(26, 39);
            this.filePath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(880, 29);
            this.filePath.TabIndex = 0;
            // 
            // templateListBox
            // 
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.Location = new System.Drawing.Point(26, 312);
            this.templateListBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(886, 32);
            this.templateListBox.TabIndex = 9;
            this.templateListBox.Text = "Press Get Templates button to populate this list and then select the template";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(997, 39);
            this.selectFileButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(218, 61);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(997, 286);
            this.encryptButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(224, 65);
            this.encryptButton.TabIndex = 10;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(22, 102);
            this.userName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(110, 25);
            this.userName.TabIndex = 2;
            this.userName.Text = "User Name";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(163, 89);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(561, 29);
            this.usernameBox.TabIndex = 3;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(28, 153);
            this.password.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(98, 25);
            this.password.TabIndex = 4;
            this.password.Text = "Password";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(163, 144);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(560, 29);
            this.passwordBox.TabIndex = 5;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(992, 430);
            this.exitButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(224, 57);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            // 
            // clientid
            // 
            this.clientid.AutoSize = true;
            this.clientid.Location = new System.Drawing.Point(28, 214);
            this.clientid.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.clientid.Name = "clientid";
            this.clientid.Size = new System.Drawing.Size(86, 25);
            this.clientid.TabIndex = 6;
            this.clientid.Text = "Client ID";
            // 
            // clientidBox
            // 
            this.clientidBox.Location = new System.Drawing.Point(165, 207);
            this.clientidBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clientidBox.Name = "clientidBox";
            this.clientidBox.Size = new System.Drawing.Size(558, 29);
            this.clientidBox.TabIndex = 7;
            // 
            // getTemplateButton
            // 
            this.getTemplateButton.Location = new System.Drawing.Point(997, 177);
            this.getTemplateButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.getTemplateButton.Name = "getTemplateButton";
            this.getTemplateButton.Size = new System.Drawing.Size(218, 66);
            this.getTemplateButton.TabIndex = 8;
            this.getTemplateButton.Text = "Get Templates";
            this.getTemplateButton.UseVisualStyleBackColor = true;
            this.getTemplateButton.Click += new System.EventHandler(this.getTemplateButton_Click);
            // 
            // fileEncrypt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1263, 510);
            this.Controls.Add(this.getTemplateButton);
            this.Controls.Add(this.clientidBox);
            this.Controls.Add(this.clientid);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.password);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.templateListBox);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.exitButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "fileEncrypt";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Select File and Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.ComboBox templateListBox;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label clientid;
        private System.Windows.Forms.TextBox clientidBox;
        private System.Windows.Forms.Button getTemplateButton;
    }
    //public class currentAdalAuth
    //{
    //    public string username { get; set; }
    //    public string password { get; set; }
    //}
}

