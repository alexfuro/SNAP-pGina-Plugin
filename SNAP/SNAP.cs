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
        private static readonly string dbPath = @"C:\Program Files\pGina\Plugins\SNAP\nfc_unlock.db";
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
            string dbFolder = @"c:\Program Files\pGina\Plugins\SNAP";
            System.IO.Directory.CreateDirectory(dbFolder);

            SQLiteConnection.CreateFile(dbPath);

            string sql = @"CREATE TABLE Users(
                               UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                               DevId     TEXT  NOT NULL,
                               UserName  TEXT  NOT NULL,
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
        //This method will return the hash of a user token given
        //a userTOken via @params
        private string getUserToken(string devId)
        {
            string token = "";
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserToken From Users where DevId ='" + devId + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            token = ds.Tables[0].Rows[0]["UserToken"].ToString();

            con.Close();
            return token;
        }
        //This method will return the hash of a user pin given
        //a userToken via @params
        private string getUserPin(string userToken)
        {
            string pin = "";
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserPin From Users where UserToken ='" + userToken + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            pin = ds.Tables[0].Rows[0]["UserPin"].ToString();

            con.Close();
            return pin;
        }
        //This method will return the encrypted username given
        //a userToken via @params
        private string getUserName(string devId)
        {
            string userName = "";
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select UserName From Users where DevId ='" + devId + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            userName = ds.Tables[0].Rows[0]["UserName"].ToString();

            con.Close();
            return userName;
        }
        //This method will return the hash of a user pin given
        //a userToken via @params
        private Boolean validPin(string pinInput, string userToken)
        {
            string userPin = getUserPin(userToken);
            Boolean validPass = BCrypt.Net.BCrypt.Verify(pinInput, userPin);
            return validPass;
        }
        //This method will return the whether the devid has an account given
        private Boolean validDevId(string devid)
        {
            int found = 0;
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            da = new SQLiteDataAdapter("Select DevId From Users where DevId ='" + devid + "' limit 1", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Users");

            found = ds.Tables["Users"].Rows.Count;

            con.Close();
            if (found != 0)
                return true;
            return false;
        }
        //this method will get the devid from the nfc device
        private string readDevId() {
            CmdApdu uid = new CmdApdu();
            uid.CLA = 0xFF;
            uid.INS = 0xCA;
            uid.P1 = 0x01;
            uid.P2 = 0x00;
            uid.Le = 0x04;

            string devId = readNFC(uid);
            return devId;
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
        //this method will verify if the user token is associated with an account
        private Boolean verifyToken(string userTokenInput, string userToken) {
            return BCrypt.Net.BCrypt.Verify(userTokenInput, userToken);
        }
        
        //This method is what is in change of authenticating a user
        //@params receives session details like username and password
        //@return is a boolean value: true if conditions are satisfied, false otherwise
        public BooleanResult AuthenticateUser(SessionProperties properties)
        {
            //object that will passed to windows authentication
            UserInformation userInfo = properties.GetTrackedSingle<UserInformation>();
            //Aid selection for getting token from unlocked phone
            byte[] tokenAID = { 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0 };
            CmdApdu selectApplication = new CmdApdu();
            selectApplication.CLA = 0x00;
            selectApplication.INS = 0xA4;
            selectApplication.P1 = 0x04;
            selectApplication.P2 = 0x00;
            selectApplication.Data = tokenAID;
            selectApplication.Le = 0x00;
            string userTokenInput = readNFC(selectApplication);

            //get device id
            string devId = readDevId();
            //check if the devid is registered to any account
            if (validDevId(devId))
            {
                //get token info and verify
                string userToken = getUserToken(devId);
                Boolean validToken = verifyToken(userTokenInput, userToken);
                //get username via device id
                userInfo.Username = EncryptDecrypt.Decrypt(getUserName(devId));
                //check if the token is associated to an account
                if (validToken)
                {                    
                    //check if pincode matches db pincode with the same devid
                    if (validPin(userInfo.Password, userToken))
                    {
                        //get account details to send to winlogon
                        userInfo.Password = getUserPin(userToken);
                        // Successful authentication
                        DBLogger(userInfo.Username, "Sucessful Login");
                        return new BooleanResult() { Success = true };
                    }
                }
                // Authentication failure
                DBLogger(userInfo.Username, "Unsucessful Login attempt");
            }
            return new BooleanResult() { Success = false, Message = "Incorrect credentials." };
        }
        public void Configure()
        {
            Configuration myDialog = new Configuration();
            myDialog.ShowDialog();
        }
        //This method will insert a log message into the log table of the database
        //it receives via @params the string that is to be inserted
        //these logs are encrypted
        private void DBLogger(string user, string msg)
        {
            //establish connection to db
            con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            cmd = new SQLiteCommand();
            con.Open();
            cmd.Connection = con;

            //encrypt login details
            string encryptedTime = EncryptDecrypt.Encrypt(DateTime.Now.ToString());
            string encryptedMsg = EncryptDecrypt.Encrypt(msg);
            string encryptedUsr = EncryptDecrypt.Encrypt(user);
            cmd.CommandText = "INSERT INTO Logs(Date,User,Message) values ('" + encryptedTime + "','" + encryptedUsr + "','" + encryptedMsg + "')";

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }    
}
