namespace Adalfileencrypt
{
    partial class AdalFileEncrypt
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
            this.getTeamplatesBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.filpathBox = new System.Windows.Forms.TextBox();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getTeamplatesBtn
            // 
            this.getTeamplatesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getTeamplatesBtn.Location = new System.Drawing.Point(25, 34);
            this.getTeamplatesBtn.Name = "getTeamplatesBtn";
            this.getTeamplatesBtn.Size = new System.Drawing.Size(1111, 116);
            this.getTeamplatesBtn.TabIndex = 0;
            this.getTeamplatesBtn.Text = "Get Templates";
            this.getTeamplatesBtn.UseVisualStyleBackColor = true;
            this.getTeamplatesBtn.Click += new System.EventHandler(this.getTeamplatesBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 204);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(1111, 40);
            this.comboBox1.TabIndex = 1;
            // 
            // filpathBox
            // 
            this.filpathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filpathBox.Location = new System.Drawing.Point(25, 286);
            this.filpathBox.Name = "filpathBox";
            this.filpathBox.ReadOnly = true;
            this.filpathBox.Size = new System.Drawing.Size(839, 39);
            this.filpathBox.TabIndex = 2;
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileBtn.Location = new System.Drawing.Point(904, 263);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(232, 79);
            this.selectFileBtn.TabIndex = 3;
            this.selectFileBtn.Text = "Select File";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            // 
            // encryptBtn
            // 
            this.encryptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptBtn.Location = new System.Drawing.Point(25, 377);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(560, 89);
            this.encryptBtn.TabIndex = 4;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(635, 377);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(501, 89);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // AdalFileEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 563);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.filpathBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.getTeamplatesBtn);
            this.Name = "AdalFileEncrypt";
            this.Text = "Select File and Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTeamplatesBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox filpathBox;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

