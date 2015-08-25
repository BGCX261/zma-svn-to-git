using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zicore.MinecraftAdmin.Admins;
using System.Security.Cryptography;
using MinecraftWrapper;

namespace Vitt.Andre.MinecraftAdmin.Dialogs
{
    public partial class UpdateWebUser : Form
    {
        public UpdateWebUser(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        User user = null;

        private void btApply_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                user.WebUsername = tbWebUsername.Text;
                user.PasswordHash = HashProvider.GetHash(tbPassword.Text,HashProvider.SHA256);
                UserCollectionSingletone.GetInstance().Save();
                Close();
            }
        }

        private bool Message(String message)
        {
            lblMessage.Text = message;
            return false;
        }

        private bool ValidateInput()
        {
            if (String.IsNullOrWhiteSpace(tbWebUsername.Text))
                return Message("Username must not be empty!");
            if (String.IsNullOrWhiteSpace(tbPassword.Text))
                return Message("Password must not be empty!");
            if ((tbPassword.Text != tbPasswordCheck.Text))
                return Message("The passwords are not equal!");
            if ((tbPassword.Text.Length < 8))
                return Message("Password length must above 8 or equal");
            return true;
        }
        
    }
}
