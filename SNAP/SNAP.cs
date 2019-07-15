using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pGina.Plugin.SNAP;
using pGina.Shared.Types;

namespace SNAP
{
    public class SNAP : pGina.Shared.Interfaces.IPluginAuthentication,
                            pGina.Shared.Interfaces.IPluginConfiguration
    {
        //Generates a unique ID this is needed for pGina plugins
        private static readonly Guid m_uuid = new Guid("95D8F91A-DFA2-494D-A885-125C416E4E52");
        
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
        //This method is what is in change of authenticating a user
        //@params receives session details like username and password
        //@return is a boolean value: true if conditions are satisfied, false otherwise
        public BooleanResult AuthenticateUser(SessionProperties properties)
        {
            UserInformation userInfo = properties.GetTrackedSingle<UserInformation>();

            if (userInfo.Username.Contains("hello") && userInfo.Password.Contains("pGina"))
            {
                // Successful authentication
                return new BooleanResult() { Success = true };
            }
            // Authentication failure
            return new BooleanResult() { Success = false, Message = "Incorrect username or password." };
        }
        public void Configure()
        {
            Configuration myDialog = new Configuration();
            myDialog.ShowDialog();
        }
    }
}
