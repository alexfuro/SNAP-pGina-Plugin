using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GS.Apdu;
using GS.PCSC;
using GS.Util.Hex;
using GS.SCard.Const;
using EncryDecry;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;

namespace pGina.Plugin.SNAP
{
    public partial class CreateUser : Form
    {
        //Sqlite required datafields
        SQLiteConnection con;
        SQLiteCommand cmd;
        
        //This is a path to the database with all user info
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\SNAP\nfc_unlock.db";

        public CreateUser()
        {
            InitializeComponent();
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        }

        private bool equalPins() {
            return txtBoxPin.Text == txtBoxConfirmPin.Text;
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

        private void BtnPhoneKey_Click(object sender, EventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (hasDatabase())
            {
                bool equalPinCodes = equalPins();
                if (equalPinCodes)
                {
                    if (txtBoxPhoneKey.Text != "" && txtBoxDevId.Text != "")
                    {
                        if (txtBoxUserName.Text != "")
                        {
                            cmd = new SQLiteCommand();
                            con.Open();
                            cmd.Connection = con;

                            //encrypt user name
                            string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);

                            //Create hash of pin
                            string hashPin = BCrypt.Net.BCrypt.HashPassword(txtBoxPin.Text);

                            //Create hash of userToken
                            string hashToken = BCrypt.Net.BCrypt.HashPassword(txtBoxPhoneKey.Text);

                            cmd.CommandText = "insert into Users(DevId,UserName,UserToken,UserPin) values ('" +
                                    txtBoxDevId.Text + "','" + encUser + "','" + hashToken + "','" + hashPin + "')";

                            cmd.ExecuteNonQuery();
                            con.Close();

                            txtBoxPhoneKey.Text = "";
                            txtBoxDevId.Text = "";
                            txtBoxUserName.Text = "";
                            txtBoxPin.Text = "";
                            txtBoxConfirmPin.Text = "";

                            MessageBox.Show("Success!");
                        }
                        else
                        {
                            MessageBox.Show("User name cannot be blank!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was a problem with the key or ID. Please scan again.");
                    }
                }
                else
                {
                    MessageBox.Show("Pins do not match. Try again!");
                    txtBoxPin.Text = "";
                    txtBoxConfirmPin.Text = "";
                }

            }
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
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
        private Boolean hasDatabase()
        {
            return File.Exists(dbPath);
        }
    }
}
