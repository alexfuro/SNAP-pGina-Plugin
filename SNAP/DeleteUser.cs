using EncryDecry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pGina.Plugin.SNAP
{
    public partial class DeleteUser : Form
    {
        //Sqlite required datafields
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        //This is a path to the database with all user info
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\SNAP\nfc_unlock.db";

        public DeleteUser()
        {
            InitializeComponent();
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        }
        private Boolean hasDatabase()
        {
            return File.Exists(dbPath);
        }
        private Boolean checkPin()
        {
            Boolean result = false;
            string hashedPin = "";
            string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserPin From Users where UserName ='" + encUser + "'", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");
            hashedPin = ds.Tables[0].Rows[0]["UserPin"].ToString();

            con.Close();
            result = BCrypt.Net.BCrypt.Verify(txtBoxCurrPin.Text, hashedPin);
            return result;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtBoxUserName.Text != "" && txtBoxCurrPin.Text != "" && hasDatabase() && checkPin())
            {
                cmd = new SQLiteCommand();
                con.Open();
                cmd.Connection = con;
                //encrypt user name
                string encUser = EncryptDecrypt.Encrypt(txtBoxUserName.Text);
                cmd.CommandText = "delete from Users where UserName='" + encUser + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                txtBoxUserName.Text = "";
                txtBoxCurrPin.Text = "";
                MessageBox.Show("Success!");
            }
            else {
                MessageBox.Show("Insufficient or incorrect data. Try again.");
            }
        }
    }
}
