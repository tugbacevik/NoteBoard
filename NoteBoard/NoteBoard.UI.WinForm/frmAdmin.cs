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
    public partial class frmAdmin : Form
    {
        UserController _userController;
        public frmAdmin()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            FillUser();
        }

        private void FillUser()
        {
            lstUsers.Items.Clear();
            List<User> users = _userController.GetAll();
            ListViewItem lvi;
            foreach (User item in users)
            {
                lvi = new ListViewItem(item.FirstName);
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.UserName);
                lvi.SubItems.Add(item.IsActive ? "Aktif" : "Pasif");
                lvi.Tag = item;
                lstUsers.Items.Add(lvi);
            }

        }

        private void LstUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                ListViewItem selected = lstUsers.SelectedItems[0];
                User selectedUser = selected.Tag as User;

                if (!selectedUser.IsActive)
                    //Bu if'i teklemeye calış "Aktiflik durumunu değiştirmek istiyormusunuz?"
                {
                    DialogResult result = MessageBox.Show("Bu kullanıcıyı onaylıyormusunuz?", "Onay", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        selectedUser.IsActive = true;
                        _userController.Update(selectedUser);
                        FillUser();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bu kullanıcıyı kara listeye almak istiyor musunuz?", "Onay", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        selectedUser.IsActive = false;
                        _userController.Update(selectedUser);
                        FillUser();
                    }
                }  
            }
        }

        private void FrmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
