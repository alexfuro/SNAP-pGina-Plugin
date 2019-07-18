using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace pGina.Plugin.SNAP
{
    public partial class Configuration : Form
    {
        //Sqlite required datafields
        SQLiteConnection con;
        SQLiteCommand cmd;

        //This is a path to the database with all user info
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\SNAP\nfc_unlock.db";

        public Configuration()
        {
            InitializeComponent();
        }
        private Boolean hasDatabase()
        {
            return File.Exists(dbPath);
        }
        private void createDB()
        {
            string dbFolder = @"c:\Program Files\pGina\Plugins\SNAP";
            System.IO.Directory.CreateDirectory(dbFolder);

            SQLiteConnection.CreateFile(dbPath);

            string sql = @"CREATE TABLE Users(
                               UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                               DevId     TEXT  NOT NULL,
                               UserName  TEXT  NOT NULL,
                               PassWord  TEXT  NOT NULL,
                               UserToken TEXT  NOT NULL,
                               UserPin   TEXT  NOT NULL);
                           CREATE TABLE Logs(
                               LogId INTEGER PRIMARY KEY AUTOINCREMENT,
                               Date TEXT NOT NULL,
                               User TEXT NOT NULL,
                               Message TEXT DEFAULT NULL);";
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            if (!hasDatabase())
                createDB();
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        }

        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser myDialog = new CreateUser();
            myDialog.ShowDialog();
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUser myDialog = new UpdateUser();
            myDialog.ShowDialog();
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser myDialog = new DeleteUser();
            myDialog.ShowDialog();
        }
    }
}
