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
            this.txtBoxPhoneKey = new System.Windows.Forms.TextBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPhoneKey = new System.Windows.Forms.Button();
            this.btn_Scan_Id = new System.Windows.Forms.Button();
            this.txtBoxDevId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxConfirmPin = new System.Windows.Forms.TextBox();
            this.txtBoxPin = new System.Windows.Forms.TextBox();
            this.lblConfirmPin = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPhoneKey
            // 
            this.lblPhoneKey.AutoSize = true;
            this.lblPhoneKey.Location = new System.Drawing.Point(22, 73);
            this.lblPhoneKey.Name = "lblPhoneKey";
            this.lblPhoneKey.Size = new System.Drawing.Size(59, 13);
            this.lblPhoneKey.TabIndex = 1;
            this.lblPhoneKey.Text = "Phone Key";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(22, 125);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // txtBoxPhoneKey
            // 
            this.txtBoxPhoneKey.Location = new System.Drawing.Point(146, 66);
            this.txtBoxPhoneKey.Name = "txtBoxPhoneKey";
            this.txtBoxPhoneKey.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPhoneKey.TabIndex = 3;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(146, 118);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(388, 20);
            this.txtBoxUserName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(395, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 51);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(544, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 53);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnPhoneKey
            // 
            this.btnPhoneKey.Location = new System.Drawing.Point(563, 58);
            this.btnPhoneKey.Name = "btnPhoneKey";
            this.btnPhoneKey.Size = new System.Drawing.Size(92, 34);
            this.btnPhoneKey.TabIndex = 4;
            this.btnPhoneKey.Text = "Scan Phone Key";
            this.btnPhoneKey.UseVisualStyleBackColor = true;
            this.btnPhoneKey.Click += new System.EventHandler(this.BtnPhoneKey_Click);
            // 
            // btn_Scan_Id
            // 
            this.btn_Scan_Id.Location = new System.Drawing.Point(564, 13);
            this.btn_Scan_Id.Name = "btn_Scan_Id";
            this.btn_Scan_Id.Size = new System.Drawing.Size(92, 34);
            this.btn_Scan_Id.TabIndex = 2;
            this.btn_Scan_Id.Text = "Scan Dev Id";
            this.btn_Scan_Id.UseVisualStyleBackColor = true;
            this.btn_Scan_Id.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtBoxDevId
            // 
            this.txtBoxDevId.Location = new System.Drawing.Point(147, 21);
            this.txtBoxDevId.Name = "txtBoxDevId";
            this.txtBoxDevId.Size = new System.Drawing.Size(388, 20);
            this.txtBoxDevId.TabIndex = 1;
            this.txtBoxDevId.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Device Id";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // txtBoxConfirmPin
            // 
            this.txtBoxConfirmPin.Location = new System.Drawing.Point(147, 218);
            this.txtBoxConfirmPin.Name = "txtBoxConfirmPin";
            this.txtBoxConfirmPin.PasswordChar = '*';
            this.txtBoxConfirmPin.Size = new System.Drawing.Size(388, 20);
            this.txtBoxConfirmPin.TabIndex = 8;
            // 
            // txtBoxPin
            // 
            this.txtBoxPin.Location = new System.Drawing.Point(147, 164);
            this.txtBoxPin.Name = "txtBoxPin";
            this.txtBoxPin.PasswordChar = '*';
            this.txtBoxPin.Size = new System.Drawing.Size(388, 20);
            this.txtBoxPin.TabIndex = 7;
            // 
            // lblConfirmPin
            // 
            this.lblConfirmPin.AutoSize = true;
            this.lblConfirmPin.Location = new System.Drawing.Point(23, 221);
            this.lblConfirmPin.Name = "lblConfirmPin";
            this.lblConfirmPin.Size = new System.Drawing.Size(60, 13);
            this.lblConfirmPin.TabIndex = 18;
            this.lblConfirmPin.Text = "Confirm Pin";
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(23, 171);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(22, 13);
            this.lblPin.TabIndex = 17;
            this.lblPin.Text = "Pin";
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 337);
            this.Controls.Add(this.txtBoxConfirmPin);
            this.Controls.Add(this.txtBoxPin);
            this.Controls.Add(this.lblConfirmPin);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.btn_Scan_Id);
            this.Controls.Add(this.txtBoxDevId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPhoneKey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.txtBoxPhoneKey);
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
        private System.Windows.Forms.TextBox txtBoxPhoneKey;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPhoneKey;
        private System.Windows.Forms.Button btn_Scan_Id;
        private System.Windows.Forms.TextBox txtBoxDevId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxConfirmPin;
        private System.Windows.Forms.TextBox txtBoxPin;
        private System.Windows.Forms.Label lblConfirmPin;
        private System.Windows.Forms.Label lblPin;
    }
}