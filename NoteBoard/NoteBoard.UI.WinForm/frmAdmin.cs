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

        }

        private void FillUser()
        {
            List<User> users = _userController.GetAll();
            ListViewItem lvi;
            foreach (User item in users)
            {
                lstUsers.Items.Clear();
                lvi = new ListViewItem(item.FirstName);
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.UserName);
                lvi.SubItems.Add(item.IsActive ? "Aktif":"Pasif");
                lvi.Tag = item;
                lstUsers.Items.Add(lvi);
            }

        }
    }
}
