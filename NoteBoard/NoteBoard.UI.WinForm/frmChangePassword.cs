using NoteBoard.BLL;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteBoard.UI.WinForm
{
    public partial class frmChangePassword : Form
    {
        PasswordController _passwordController;
        Password _pass;
        public frmChangePassword(Password Pass)
        {
            InitializeComponent();
            _pass = Pass;
            _passwordController = new PasswordController();
        }

        private void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != _pass.PasswordText)
            {
                MessageBox.Show("Şifreniz Yanlış!");
                return;
            }
            else if (txtNewPassword.Text != txtReNewPassword.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor!");
                return;
            }
            Password newPassword = new Password();
            newPassword.PasswordText = txtReNewPassword.Text;
            newPassword.UserID = _pass.UserID;

            try
            {
                bool result = _passwordController.Add(newPassword);
                if (result)
                {
                    MessageBox.Show("Şifreniz Güncellendi.");
                }
                else
                { MessageBox.Show("Şifreniz Güncellenmedi.");}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FrmChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
