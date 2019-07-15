using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pGina.Plugin.SNAP
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {

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
