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
    
    public partial class frmLogin : Form
    {
        UserController _userController;
        PasswordController _passwordController;
        public frmLogin()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            User currentUser = _userController.GetByLogin(txtUsername.Text, txtPassword.Text);
            if (currentUser != null)
            {
                if (currentUser.UserRole == UserRole.Standart)
                {
                    frmMain frm = new frmMain();
                    //frm main ctorunda user göndericez
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    frmAdmin admin = new frmAdmin();
                    admin.Owner = this;
                    admin.Show();
                    this.Hide();
                }
            }

            else
            {
                MessageBox.Show("Böyle bir kullanıcı yok, kayıt olabilirsiniz.");
            }
        }
    }
}
