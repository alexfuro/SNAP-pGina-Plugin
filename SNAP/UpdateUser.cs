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
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
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
        //this method will open a reader instance and read the nfc device with
        //cmd as its input and the command to run. it will return a string of the result.
        //@params cmd - the command to run
        private string readNFC(CmdApdu cmd)
        {
            PCSCReader reader = new PCSCReader();
            string payload = "";

            try
            {
                reader.Connect();
                reader.ActivateCard(GS.SCard.Const.SCARD_SHARE_MODE.Exclusive, GS.SCard.Const.SCARD_PROTOCOL.Tx);

                RespApdu respApdu = reader.Exchange(cmd, 0x9000);

                if (respApdu.SW1SW2 == 0x9000)
                {
                    payload = Encoding.UTF8.GetString(respApdu.Data);
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
        private Boolean checkPin()
        {
            Boolean result = false;
            string hashedPin = "";
            string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserPin From Users where UserName ='"+ encUser + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");
            hashedPin = ds.Tables[0].Rows[0]["UserPin"].ToString();

            con.Close();
            result = BCrypt.Net.BCrypt.Verify(txtBoxCurrPin.Text, hashedPin);
            return result;
        }
        private bool equalPin()
        {
            return txtBoxPin.Text == txtBoxConfirmPin.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (hasDatabase()) {
                if (txtBoxUserName.Text != "")
                {
                    if (checkPin())
                    {
                        cmd = new SQLiteCommand();
                        con.Open();
                        cmd.Connection = con;
                        //encrypt user name
                        string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);

                        if (txtBoxPhoneKey.Text != "" && txtBoxDevId.Text != "") {

                            cmd.CommandText = "Update Users set UserToken='" + txtBoxPhoneKey.Text + "', DevId='" + txtBoxDevId.Text + "' where UserName ='" + encUser + "'";

                            cmd.ExecuteNonQuery();
                        }
                        
                        if (txtBoxPin.Text != "") {
                            //Create hash of pin
                            string hashPin = BCrypt.Net.BCrypt.HashPassword(txtBoxPin.Text);

                            cmd.CommandText = "Update Users set UserPin='" + hashPin + "' where UserName ='" + encUser + "'";
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();

                        txtBoxPhoneKey.Text = "";
                        txtBoxDevId.Text = "";
                        txtBoxUserName.Text = "";
                        txtBoxPin.Text = "";
                        txtBoxConfirmPin.Text = "";
                        txtBoxCurrPin.Text = "";

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
            //Aid selection for getting token from unlocked phone
            byte[] tokenAID = { 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0 };
            CmdApdu selectApplication = new CmdApdu();
            selectApplication.CLA = 0x00;
            selectApplication.INS = 0xA4;
            selectApplication.P1 = 0x04;
            selectApplication.P2 = 0x00;
            selectApplication.Data = tokenAID;
            selectApplication.Le = 0x00;
            txtBoxPhoneKey.Text = readNFC(selectApplication);
        }

        private void TxtBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Scan_Id_Click(object sender, EventArgs e)
        {
            CmdApdu uid = new CmdApdu();
            uid.CLA = 0xFF;
            uid.INS = 0xCA;
            uid.P1 = 0x01;
            uid.P2 = 0x00;
            uid.Le = 0x04;

            string devId = readNFC(uid);
            txtBoxDevId.Text = devId;
        }
    }
}
