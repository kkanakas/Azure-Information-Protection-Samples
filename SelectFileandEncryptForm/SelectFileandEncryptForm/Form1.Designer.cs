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
            this.filePath.Location = new System.Drawing.Point(14, 21);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(482, 20);
            this.filePath.TabIndex = 0;
            // 
            // templateListBox
            // 
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.Location = new System.Drawing.Point(14, 169);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(485, 21);
            this.templateListBox.TabIndex = 9;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(544, 21);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(119, 33);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(544, 155);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(122, 35);
            this.encryptButton.TabIndex = 10;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(12, 55);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(60, 13);
            this.userName.TabIndex = 2;
            this.userName.Text = "User Name";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(89, 48);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(308, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(15, 83);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(53, 13);
            this.password.TabIndex = 4;
            this.password.Text = "Password";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(89, 78);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(307, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(541, 233);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(122, 31);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            // 
            // clientid
            // 
            this.clientid.AutoSize = true;
            this.clientid.Location = new System.Drawing.Point(15, 116);
            this.clientid.Name = "clientid";
            this.clientid.Size = new System.Drawing.Size(47, 13);
            this.clientid.TabIndex = 6;
            this.clientid.Text = "Client ID";
            // 
            // clientidBox
            // 
            this.clientidBox.Location = new System.Drawing.Point(90, 112);
            this.clientidBox.Name = "clientidBox";
            this.clientidBox.Size = new System.Drawing.Size(306, 20);
            this.clientidBox.TabIndex = 7;
            // 
            // getTemplateButton
            // 
            this.getTemplateButton.Location = new System.Drawing.Point(544, 96);
            this.getTemplateButton.Name = "getTemplateButton";
            this.getTemplateButton.Size = new System.Drawing.Size(119, 36);
            this.getTemplateButton.TabIndex = 8;
            this.getTemplateButton.Text = "Get Templates";
            this.getTemplateButton.UseVisualStyleBackColor = true;
            this.getTemplateButton.Click += new System.EventHandler(this.getTemplateButton_Click);
            // 
            // fileEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 276);
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
            this.Name = "fileEncrypt";
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
}

