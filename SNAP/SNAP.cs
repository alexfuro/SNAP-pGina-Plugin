using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using EncryDecry;
using pGina.Plugin.SNAP;
using pGina.Shared.Types;
using GS.Apdu;
using GS.PCSC;
using GS.Util.Hex;
using GS.SCard.Const;
using System.Security.Cryptography;

namespace SNAP
{
    public class SNAP : pGina.Shared.Interfaces.IPluginAuthentication,
                            pGina.Shared.Interfaces.IPluginConfiguration
    {
        //Generates a unique ID this is needed for pGina plugins
        private static readonly Guid m_uuid = new Guid("95D8F91A-DFA2-494D-A885-125C416E4E52");
        //This is a path to the database with all user info
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\NFCUnlock\DataBase\nfc_unlock.db";
        //An sqlLite conncection object
        private SQLiteConnection con;
        //An sqlLite command object
        private SQLiteCommand cmd;
        //A data sqlLite data adapter object
        private SQLiteDataAdapter da;

        //required getter methods
        public string Name
        {
            get { return "SNAP"; }
        }

        public string Description
        {
            get { return "This plugin handles authentication via NFC."; }
        }

        public Guid Uuid
        {
            get { return m_uuid; }
        }

        public string Version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        //required methods for plugins the framework handles them but they must be present
        public void Starting() { }
        public void Stopping() { }

        private Boolean hasDatabase()
        {
            return File.Exists(dbPath);
        }
        private void createDB()
        {
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
        //This method will return the hash of a user password given
        //a dev id via @params
        private string getUserPass(string userName)
        {
            string pass = "";
            string encUser = EncryptDecrypt.Encrypt(userName);
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select PassWord From Users where UserName ='" + encUser + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            pass = ds.Tables[0].Rows[0]["PassWord"].ToString();

            con.Close();
            return pass;
        }
        //This method will return the hash of a user pin given
        //a dev id via @params
        private string getUserPin(string userName)
        {
            string pass = "";
            string encUser = EncryptDecrypt.Encrypt(userName);
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserPin From Users where UserName ='" + encUser + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            pass = ds.Tables[0].Rows[0]["UserPin"].ToString();

            con.Close();
            return pass;
        }
        //This method will return the hash of a user devid given
        //a dev id via @params
        private string getDevId(string userName)
        {
            string pass = "";
            string encUser = EncryptDecrypt.Encrypt(userName);
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select DevId From Users where UserName ='" + encUser + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            pass = ds.Tables[0].Rows[0]["DevId"].ToString();

            con.Close();
            return pass;
        }
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
        private Boolean verifyToken(string token) {
            Boolean result = false;
            int found = 0;
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserToken From Users where UserName ='" + token + "'", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Tokens");
            found = ds.Tables["Tokens"].Rows.Count;

            if (found != 1)
                result = true;

            con.Close();
            return result;
        }
        
        //This method is what is in change of authenticating a user
        //@params receives session details like username and password
        //@return is a boolean value: true if conditions are satisfied, false otherwise
        public BooleanResult AuthenticateUser(SessionProperties properties)
        {
            UserInformation userInfo = properties.GetTrackedSingle<UserInformation>();
            byte[] tokenAID = { 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0 };
            CmdApdu selectApplication = new CmdApdu();
            selectApplication.CLA = 0x00;
            selectApplication.INS = 0xA4;
            selectApplication.P1 = 0x04;
            selectApplication.P2 = 0x00;
            selectApplication.Data = tokenAID;
            selectApplication.Le = 0x00;
            string newTokenPayload = readNFC(selectApplication);
            Boolean validToken = verifyToken(newTokenPayload);

            if (validToken) {
                string userPass = getUserPass(userInfo.Username);
                Boolean validPass = BCrypt.Net.BCrypt.Verify(userInfo.Password, userPass);
                if (validPass)
                {
                    // Successful authentication
                    return new BooleanResult() { Success = true };
                }
            }
            // Authentication failure
            return new BooleanResult() { Success = false, Message = "Incorrect credentials." };
        }
        public void Configure()
        {
            Configuration myDialog = new Configuration();
            myDialog.ShowDialog();
        }
    }
}
