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
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        //This is a path to the database with all user info
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\SNAP\nfc_unlock.db";

        public CreateUser()
        {
            InitializeComponent();
        }

        private Boolean hasDatabase()
        {
            return File.Exists(dbPath);
        }
        private void createDB()
        {
            SQLiteConnection.CreateFile(dbPath);

            string sql = @"CREATE TABLE Users(
                               UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                               UserName  TEXT  NOT NULL,
                               PassWord  TEXT  NOT NULL,
                               PublicKey TEXT  NOT NULL);
                            CREATE TABLE Logs(
                                LogId INTEGER PRIMARY KEY AUTOINCREMENT,
                                Date TEXT NOT NULL,
                                User TEXT NOT NULL,
                                Message TEXT DEFAULT NULL);
                            CREATE TABLE Tokens(
                                Token TEXT NOT NULL);";
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private bool equalPass() {
            return txtBoxPassword.Text == txtBoxConfirmPass.Text;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string readNFC(byte [] AID) {
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
                    payload = EncryptDecrypt.Encrypt(HexFormatting.DumpAscii(respApdu.Data));
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
            byte[] PhoneKeyAID = { 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0 };
            txtBoxPhoneKey.Text = readNFC(PhoneKeyAID);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool equalPasswords = equalPass();
            if (equalPasswords && txtBoxPassword.Text != "")
            {
                if (txtBoxPhoneKey.Text != "")
                {
                    if (txtBoxUserName.Text != "")
                    {
                        cmd = new SQLiteCommand();
                        con.Open();
                        cmd.Connection = con;

                        //encrypt user name
                        string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);

                        //Create hash of password
                        string hashPass = BCrypt.Net.BCrypt.HashPassword(txtBoxPassword.Text);

                        cmd.CommandText = "insert into Users(PublicKey,UserName,PassWord) values ('" +
                                txtBoxPhoneKey.Text + "','" + encUser + "','" + hashPass + "')";

                        cmd.ExecuteNonQuery();
                        con.Close();

                        txtBoxPhoneKey.Text = "";
                        txtBoxUserName.Text = "";
                        txtBoxPassword.Text = "";
                        txtBoxConfirmPass.Text = "";

                        MessageBox.Show("Success!");
                    }
                    else {
                        MessageBox.Show("User name cannot be blank!");
                    }
                }
                else {
                    MessageBox.Show("There was a problem with the key. Please scan again.");
                }
            }
            else {
                MessageBox.Show("passwords do not match. Try again!");
                txtBoxPassword.Text = "";
                txtBoxConfirmPass.Text = "";
            }
            
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            if (!hasDatabase())
                createDB();
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        }
    }
}
