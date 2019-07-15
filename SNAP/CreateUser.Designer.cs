namespace pGina.Plugin.SNAP
{
    partial class CreateUser
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
            this.lblNFCKey = new System.Windows.Forms.Label();
            this.lblPhoneKey = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtBoxNFCKey = new System.Windows.Forms.TextBox();
            this.txtBoxPhoneKey = new System.Windows.Forms.TextBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNFCKey = new System.Windows.Forms.Button();
            this.btnPhoneKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNFCKey
            // 
            this.lblNFCKey.AutoSize = true;
            this.lblNFCKey.Location = new System.Drawing.Point(24, 21);
            this.lblNFCKey.Name = "lblNFCKey";
            this.lblNFCKey.Size = new System.Drawing.Size(49, 13);
            this.lblNFCKey.TabIndex = 0;
            this.lblNFCKey.Text = "NFC Key";
            // 
            // lblPhoneKey
            // 
            this.lblPhoneKey.AutoSize = true;
            this.lblPhoneKey.Location = new System.Drawing.Point(24, 76);
            this.lblPhoneKey.Name = "lblPhoneKey";
            this.lblPhoneKey.Size = new System.Drawing.Size(59, 13);
            this.lblPhoneKey.TabIndex = 1;
            this.lblPhoneKey.Text = "Phone Key";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(24, 128);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 176);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Location = new System.Drawing.Point(24, 226);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPass.TabIndex = 4;
            this.lblConfirmPass.Text = "Confirm Password";
            // 
            // txtBoxNFCKey
            // 
            this.txtBoxNFCKey.Location = new System.Drawing.Point(148, 14);
            this.txtBoxNFCKey.Name = "txtBoxNFCKey";
            this.txtBoxNFCKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxNFCKey.TabIndex = 5;
            // 
            // txtBoxPhoneKey
            // 
            this.txtBoxPhoneKey.Location = new System.Drawing.Point(148, 69);
            this.txtBoxPhoneKey.Name = "txtBoxPhoneKey";
            this.txtBoxPhoneKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPhoneKey.TabIndex = 6;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(148, 121);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(388, 20);
            this.txtBoxUserName.TabIndex = 7;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(148, 169);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPassword.TabIndex = 8;
            // 
            // txtBoxConfirmPass
            // 
            this.txtBoxConfirmPass.Location = new System.Drawing.Point(148, 223);
            this.txtBoxConfirmPass.Name = "txtBoxConfirmPass";
            this.txtBoxConfirmPass.PasswordChar = '*';
            this.txtBoxConfirmPass.Size = new System.Drawing.Size(388, 20);
            this.txtBoxConfirmPass.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(386, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 51);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(546, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 53);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnNFCKey
            // 
            this.btnNFCKey.Location = new System.Drawing.Point(565, 12);
            this.btnNFCKey.Name = "btnNFCKey";
            this.btnNFCKey.Size = new System.Drawing.Size(93, 31);
            this.btnNFCKey.TabIndex = 12;
            this.btnNFCKey.Text = "Scan NFC Key";
            this.btnNFCKey.UseVisualStyleBackColor = true;
            this.btnNFCKey.Click += new System.EventHandler(this.BtnNFCKey_Click);
            // 
            // btnPhoneKey
            // 
            this.btnPhoneKey.Location = new System.Drawing.Point(565, 61);
            this.btnPhoneKey.Name = "btnPhoneKey";
            this.btnPhoneKey.Size = new System.Drawing.Size(92, 34);
            this.btnPhoneKey.TabIndex = 13;
            this.btnPhoneKey.Text = "Scan Phone Key";
            this.btnPhoneKey.UseVisualStyleBackColor = true;
            this.btnPhoneKey.Click += new System.EventHandler(this.BtnPhoneKey_Click);
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 353);
            this.Controls.Add(this.btnPhoneKey);
            this.Controls.Add(this.btnNFCKey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxConfirmPass);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.txtBoxPhoneKey);
            this.Controls.Add(this.txtBoxNFCKey);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPhoneKey);
            this.Controls.Add(this.lblNFCKey);
            this.Name = "CreateUser";
            this.Text = "CreateUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNFCKey;
        private System.Windows.Forms.Label lblPhoneKey;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtBoxNFCKey;
        private System.Windows.Forms.TextBox txtBoxPhoneKey;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxConfirmPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNFCKey;
        private System.Windows.Forms.Button btnPhoneKey;
    }
}