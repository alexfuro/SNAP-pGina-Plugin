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
            this.lblPhoneKey = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtBoxPhoneKey = new System.Windows.Forms.TextBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPhoneKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPhoneKey
            // 
            this.lblPhoneKey.AutoSize = true;
            this.lblPhoneKey.Location = new System.Drawing.Point(22, 28);
            this.lblPhoneKey.Name = "lblPhoneKey";
            this.lblPhoneKey.Size = new System.Drawing.Size(59, 13);
            this.lblPhoneKey.TabIndex = 1;
            this.lblPhoneKey.Text = "Phone Key";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(22, 80);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(22, 128);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Location = new System.Drawing.Point(22, 178);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPass.TabIndex = 4;
            this.lblConfirmPass.Text = "Confirm Password";
            // 
            // txtBoxPhoneKey
            // 
            this.txtBoxPhoneKey.Location = new System.Drawing.Point(146, 21);
            this.txtBoxPhoneKey.Name = "txtBoxPhoneKey";
            this.txtBoxPhoneKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPhoneKey.TabIndex = 7;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(146, 73);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(388, 20);
            this.txtBoxUserName.TabIndex = 9;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(146, 121);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPassword.TabIndex = 10;
            // 
            // txtBoxConfirmPass
            // 
            this.txtBoxConfirmPass.Location = new System.Drawing.Point(146, 175);
            this.txtBoxConfirmPass.Name = "txtBoxConfirmPass";
            this.txtBoxConfirmPass.PasswordChar = '*';
            this.txtBoxConfirmPass.Size = new System.Drawing.Size(388, 20);
            this.txtBoxConfirmPass.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 232);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 51);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(544, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 53);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnPhoneKey
            // 
            this.btnPhoneKey.Location = new System.Drawing.Point(563, 13);
            this.btnPhoneKey.Name = "btnPhoneKey";
            this.btnPhoneKey.Size = new System.Drawing.Size(92, 34);
            this.btnPhoneKey.TabIndex = 8;
            this.btnPhoneKey.Text = "Scan Phone Key";
            this.btnPhoneKey.UseVisualStyleBackColor = true;
            this.btnPhoneKey.Click += new System.EventHandler(this.BtnPhoneKey_Click);
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 290);
            this.Controls.Add(this.btnPhoneKey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxConfirmPass);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.txtBoxPhoneKey);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPhoneKey);
            this.Name = "CreateUser";
            this.Text = "CreateUser";
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPhoneKey;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtBoxPhoneKey;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxConfirmPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPhoneKey;
    }
}