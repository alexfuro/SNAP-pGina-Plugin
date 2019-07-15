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
namespace pGina.Plugin.SNAP
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNFCKey_Click(object sender, EventArgs e)
        {
            byte[] NFCKeyAID = { 0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5 };
            txtBoxNFCKey.Text = readNFC(NFCKeyAID);
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
            byte[] PhoneKeyAID = { 0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5 };
            txtBoxPhoneKey.Text = readNFC(PhoneKeyAID);
        }
    }
}
