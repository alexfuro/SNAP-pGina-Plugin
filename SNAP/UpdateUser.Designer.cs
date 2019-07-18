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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBoxPin = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtBoxPhoneKey = new System.Windows.Forms.TextBox();
            this.lblNewPin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPhoneKey = new System.Windows.Forms.Label();
            this.lblCurrPass = new System.Windows.Forms.Label();
            this.txtBoxCurrPin = new System.Windows.Forms.TextBox();
            this.btn_Scan_Id = new System.Windows.Forms.Button();
            this.txtBoxDevId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxConfirmPin = new System.Windows.Forms.TextBox();
            this.lblConfirmPin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPhoneKey
            // 
            this.btnPhoneKey.Location = new System.Drawing.Point(568, 74);
            this.btnPhoneKey.Name = "btnPhoneKey";
            this.btnPhoneKey.Size = new System.Drawing.Size(92, 34);
            this.btnPhoneKey.TabIndex = 22;
            this.btnPhoneKey.Text = "Scan Phone Key";
            this.btnPhoneKey.UseVisualStyleBackColor = true;
            this.btnPhoneKey.Click += new System.EventHandler(this.BtnPhoneKey_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(549, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 53);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(403, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 51);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtBoxPin
            // 
            this.txtBoxPin.Location = new System.Drawing.Point(151, 277);
            this.txtBoxPin.Name = "txtBoxPin";
            this.txtBoxPin.PasswordChar = '*';
            this.txtBoxPin.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPin.TabIndex = 26;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(151, 229);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPassword.TabIndex = 25;
            this.txtBoxPassword.TextChanged += new System.EventHandler(this.TxtBoxPassword_TextChanged);
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(151, 134);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(388, 20);
            this.txtBoxUserName.TabIndex = 23;
            // 
            // txtBoxPhoneKey
            // 
            this.txtBoxPhoneKey.Location = new System.Drawing.Point(151, 82);
            this.txtBoxPhoneKey.Name = "txtBoxPhoneKey";
            this.txtBoxPhoneKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPhoneKey.TabIndex = 21;
            // 
            // lblNewPin
            // 
            this.lblNewPin.AutoSize = true;
            this.lblNewPin.Location = new System.Drawing.Point(27, 280);
            this.lblNewPin.Name = "lblNewPin";
            this.lblNewPin.Size = new System.Drawing.Size(47, 13);
            this.lblNewPin.TabIndex = 18;
            this.lblNewPin.Text = "New Pin";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(27, 236);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(27, 141);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 16;
            this.lblUserName.Text = "User Name";
            // 
            // lblPhoneKey
            // 
            this.lblPhoneKey.AutoSize = true;
            this.lblPhoneKey.Location = new System.Drawing.Point(27, 89);
            this.lblPhoneKey.Name = "lblPhoneKey";
            this.lblPhoneKey.Size = new System.Drawing.Size(59, 13);
            this.lblPhoneKey.TabIndex = 15;
            this.lblPhoneKey.Text = "Phone Key";
            // 
            // lblCurrPass
            // 
            this.lblCurrPass.AutoSize = true;
            this.lblCurrPass.Location = new System.Drawing.Point(28, 187);
            this.lblCurrPass.Name = "lblCurrPass";
            this.lblCurrPass.Size = new System.Drawing.Size(59, 13);
            this.lblCurrPass.TabIndex = 28;
            this.lblCurrPass.Text = "Current Pin";
            // 
            // txtBoxCurrPin
            // 
            this.txtBoxCurrPin.Location = new System.Drawing.Point(151, 180);
            this.txtBoxCurrPin.Name = "txtBoxCurrPin";
            this.txtBoxCurrPin.PasswordChar = '*';
            this.txtBoxCurrPin.Size = new System.Drawing.Size(388, 20);
            this.txtBoxCurrPin.TabIndex = 24;
            // 
            // btn_Scan_Id
            // 
            this.btn_Scan_Id.Location = new System.Drawing.Point(568, 26);
            this.btn_Scan_Id.Name = "btn_Scan_Id";
            this.btn_Scan_Id.Size = new System.Drawing.Size(92, 34);
            this.btn_Scan_Id.TabIndex = 30;
            this.btn_Scan_Id.Text = "Scan Dev Id";
            this.btn_Scan_Id.UseVisualStyleBackColor = true;
            this.btn_Scan_Id.Click += new System.EventHandler(this.Btn_Scan_Id_Click);
            // 
            // txtBoxDevId
            // 
            this.txtBoxDevId.Location = new System.Drawing.Point(151, 34);
            this.txtBoxDevId.Name = "txtBoxDevId";
            this.txtBoxDevId.Size = new System.Drawing.Size(388, 20);
            this.txtBoxDevId.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Device Id";
            // 
            // txtBoxConfirmPin
            // 
            this.txtBoxConfirmPin.Location = new System.Drawing.Point(152, 319);
            this.txtBoxConfirmPin.Name = "txtBoxConfirmPin";
            this.txtBoxConfirmPin.PasswordChar = '*';
            this.txtBoxConfirmPin.Size = new System.Drawing.Size(388, 20);
            this.txtBoxConfirmPin.TabIndex = 33;
            // 
            // lblConfirmPin
            // 
            this.lblConfirmPin.AutoSize = true;
            this.lblConfirmPin.Location = new System.Drawing.Point(28, 322);
            this.lblConfirmPin.Name = "lblConfirmPin";
            this.lblConfirmPin.Size = new System.Drawing.Size(60, 13);
            this.lblConfirmPin.TabIndex = 32;
            this.lblConfirmPin.Text = "Confirm Pin";
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 444);
            this.Controls.Add(this.txtBoxConfirmPin);
            this.Controls.Add(this.lblConfirmPin);
            this.Controls.Add(this.btn_Scan_Id);
            this.Controls.Add(this.txtBoxDevId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxCurrPin);
            this.Controls.Add(this.lblCurrPass);
            this.Controls.Add(this.btnPhoneKey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxPin);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.txtBoxPhoneKey);
            this.Controls.Add(this.lblNewPin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPhoneKey);
            this.Name = "UpdateUser";
            this.Text = "UpdateUser";
            this.Load += new System.EventHandler(this.UpdateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPhoneKey;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBoxPin;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtBoxPhoneKey;
        private System.Windows.Forms.Label lblNewPin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPhoneKey;
        private System.Windows.Forms.Label lblCurrPass;
        private System.Windows.Forms.TextBox txtBoxCurrPin;
        private System.Windows.Forms.Button btn_Scan_Id;
        private System.Windows.Forms.TextBox txtBoxDevId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxConfirmPin;
        private System.Windows.Forms.Label lblConfirmPin;
    }
}