using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using EncryDecry;
using GS.Apdu;
using GS.PCSC;
using GS.Util.Hex;
using GS.SCard.Const;
using System.Security.Cryptography;

namespace pGina.Plugin.SNAP
{
    public partial class UpdateUser : Form
    {
        //Sqlite required datafields
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        //This is a path to the database with all user info
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\SNAP\nfc_unlock.db";

        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            if (hasDatabase())
                con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        }

        private Boolean hasDatabase()
        {
            return File.Exists(dbPath);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string readNFC(byte[] AID)
        {
            PCSCReader reader = new PCSCReader();
            string payload = "";

            try
            {
                reader.Connect();
                reader.ActivateCard(GS.SCard.Const.SCARD_SHARE_MODE.Exclusive, GS.SCard.Const.SCARD_PROTOCOL.Tx);

                CmdApdu selectApplication = new CmdApdu();
                selectApplication.CLA = 0x00;
                selectApplication.INS = 0xA4;
                selectApplication.P1 = 0x04;
                selectApplication.P2 = 0x00;
                selectApplication.Data = AID;
                selectApplication.Le = 0x00;

                RespApdu respApdu = reader.Exchange(selectApplication, 0x9000);

                if (respApdu.SW1SW2 == 0x9000)
                {
                    payload = EncryptDecrypt.Encrypt(Encoding.UTF8.GetString(respApdu.Data));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Disconnect();
            }
            return payload;
        }
        private Boolean checkPassword()
        {
            Boolean result = false;
            string hashedPass = "";
            string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select PassWord From Users where UserName ='"+ encUser + "'", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");
            hashedPass = ds.Tables[0].Rows[0]["PassWord"].ToString();

            con.Close();
            result = BCrypt.Net.BCrypt.Verify(txtBoxCurrPass.Text, hashedPass);
            return result;
        }
        private bool equalPass()
        {
            return txtBoxPassword.Text == txtBoxConfirmPass.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (hasDatabase()) {
                if (txtBoxUserName.Text != "")
                {
                    if (checkPassword())
                    {
                        cmd = new SQLiteCommand();
                        con.Open();
                        cmd.Connection = con;
                        //encrypt user name
                        string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);

                        if (txtBoxPhoneKey.Text != "") {

                            cmd.CommandText = "Update Users set PublicKey='" + txtBoxPhoneKey.Text + "' where UserName ='" + encUser + "'";

                            cmd.ExecuteNonQuery();
                        }
                        if (txtBoxPassword.Text != "" && txtBoxConfirmPass.Text != "" && equalPass()) {
                            //Create hash of password
                            string hashPass = BCrypt.Net.BCrypt.HashPassword(txtBoxPassword.Text);

                            cmd.CommandText = "Update Users set Password='" + hashPass + "' where UserName ='" + encUser + "'";
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                        
                        txtBoxPhoneKey.Text = "";
                        txtBoxUserName.Text = "";
                        txtBoxPassword.Text = "";
                        txtBoxConfirmPass.Text = "";
                        txtBoxCurrPass.Text = "";

                        MessageBox.Show("Success!");
                    }
                    else {
                        MessageBox.Show("Invalid credentials.");
                    }
                }
                else {
                    MessageBox.Show("User Name cannot be blank. Try again.");
                }
            }
        }

        private void BtnPhoneKey_Click_1(object sender, EventArgs e)
        {
            byte[] PhoneKeyAID = { 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0 };
            txtBoxPhoneKey.Text = readNFC(PhoneKeyAID);
        }

        private void TxtBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
