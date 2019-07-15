namespace pGina.Plugin.SNAP
{
    partial class UpdateUser
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
            this.btnPhoneKey = new System.Windows.Forms.Button();
            this.btnNFCKey = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtBoxPhoneKey = new System.Windows.Forms.TextBox();
            this.txtBoxNFCKey = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPhoneKey = new System.Windows.Forms.Label();
            this.lblNFCKey = new System.Windows.Forms.Label();
            this.lblCurrPass = new System.Windows.Forms.Label();
            this.txtBoxCurrPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPhoneKey
            // 
            this.btnPhoneKey.Location = new System.Drawing.Point(564, 62);
            this.btnPhoneKey.Name = "btnPhoneKey";
            this.btnPhoneKey.Size = new System.Drawing.Size(92, 34);
            this.btnPhoneKey.TabIndex = 27;
            this.btnPhoneKey.Text = "Scan Phone Key";
            this.btnPhoneKey.UseVisualStyleBackColor = true;
            this.btnPhoneKey.Click += new System.EventHandler(this.BtnPhoneKey_Click_1);
            // 
            // btnNFCKey
            // 
            this.btnNFCKey.Location = new System.Drawing.Point(564, 13);
            this.btnNFCKey.Name = "btnNFCKey";
            this.btnNFCKey.Size = new System.Drawing.Size(93, 31);
            this.btnNFCKey.TabIndex = 26;
            this.btnNFCKey.Text = "Scan NFC Key";
            this.btnNFCKey.UseVisualStyleBackColor = true;
            this.btnNFCKey.Click += new System.EventHandler(this.BtnNFCKey_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(545, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 53);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 51);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtBoxConfirmPass
            // 
            this.txtBoxConfirmPass.Location = new System.Drawing.Point(147, 271);
            this.txtBoxConfirmPass.Name = "txtBoxConfirmPass";
            this.txtBoxConfirmPass.PasswordChar = '*';
            this.txtBoxConfirmPass.Size = new System.Drawing.Size(388, 20);
            this.txtBoxConfirmPass.TabIndex = 24;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(147, 217);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPassword.TabIndex = 23;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(147, 122);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(388, 20);
            this.txtBoxUserName.TabIndex = 21;
            // 
            // txtBoxPhoneKey
            // 
            this.txtBoxPhoneKey.Location = new System.Drawing.Point(147, 70);
            this.txtBoxPhoneKey.Name = "txtBoxPhoneKey";
            this.txtBoxPhoneKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPhoneKey.TabIndex = 20;
            // 
            // txtBoxNFCKey
            // 
            this.txtBoxNFCKey.Location = new System.Drawing.Point(147, 15);
            this.txtBoxNFCKey.Name = "txtBoxNFCKey";
            this.txtBoxNFCKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxNFCKey.TabIndex = 19;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Location = new System.Drawing.Point(23, 274);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPass.TabIndex = 18;
            this.lblConfirmPass.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(23, 224);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(23, 129);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 16;
            this.lblUserName.Text = "User Name";
            // 
            // lblPhoneKey
            // 
            this.lblPhoneKey.AutoSize = true;
            this.lblPhoneKey.Location = new System.Drawing.Point(23, 77);
            this.lblPhoneKey.Name = "lblPhoneKey";
            this.lblPhoneKey.Size = new System.Drawing.Size(59, 13);
            this.lblPhoneKey.TabIndex = 15;
            this.lblPhoneKey.Text = "Phone Key";
            // 
            // lblNFCKey
            // 
            this.lblNFCKey.AutoSize = true;
            this.lblNFCKey.Location = new System.Drawing.Point(23, 22);
            this.lblNFCKey.Name = "lblNFCKey";
            this.lblNFCKey.Size = new System.Drawing.Size(49, 13);
            this.lblNFCKey.TabIndex = 14;
            this.lblNFCKey.Text = "NFC Key";
            // 
            // lblCurrPass
            // 
            this.lblCurrPass.AutoSize = true;
            this.lblCurrPass.Location = new System.Drawing.Point(24, 175);
            this.lblCurrPass.Name = "lblCurrPass";
            this.lblCurrPass.Size = new System.Drawing.Size(90, 13);
            this.lblCurrPass.TabIndex = 28;
            this.lblCurrPass.Text = "Current Password";
            // 
            // txtBoxCurrPass
            // 
            this.txtBoxCurrPass.Location = new System.Drawing.Point(147, 168);
            this.txtBoxCurrPass.Name = "txtBoxCurrPass";
            this.txtBoxCurrPass.PasswordChar = '*';
            this.txtBoxCurrPass.Size = new System.Drawing.Size(388, 20);
            this.txtBoxCurrPass.TabIndex = 22;
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 396);
            this.Controls.Add(this.txtBoxCurrPass);
            this.Controls.Add(this.lblCurrPass);
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
            this.Name = "UpdateUser";
            this.Text = "UpdateUser";
            this.Load += new System.EventHandler(this.UpdateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPhoneKey;
        private System.Windows.Forms.Button btnNFCKey;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBoxConfirmPass;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtBoxPhoneKey;
        private System.Windows.Forms.TextBox txtBoxNFCKey;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPhoneKey;
        private System.Windows.Forms.Label lblNFCKey;
        private System.Windows.Forms.Label lblCurrPass;
        private System.Windows.Forms.TextBox txtBoxCurrPass;
    }
}