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
    public partial class frmMain : Form
    {
        User _user;
        PasswordController _passwordController;
        NoteController _noteController;

        public frmMain(User user)
        {
            InitializeComponent();
            _passwordController = new PasswordController();
            _user = user;
            _noteController = new NoteController();

        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password pass = _passwordController.GetActivePassword(_user.UserID);
            frmChangePassword frm = new frmChangePassword(pass);
            frm.Owner = this;
            frm.Show();
            this.Close();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void FillNotes()
        {
            listBox1.Items.Clear();
            List<Note> notes = _noteController.GetNotesByUser(_user.UserID);
            //Doğum günüm kutlu olsun bari :)
            listBox1.DisplayMember = "Title";
            listBox1.ValueMember = "NoteID";
            listBox1.DataSource = notes;
            //listBox1.SelectedIndex = -1;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FillNotes();
        }

        private void AddNote()
        {
            Note note = new Note();
            note.Title = txtTitle.Text;
            note.Content = txtContent.Text;
            note.UserID = _user.UserID;

            bool result = _noteController.Add(note);
            if (result)
            {
                MessageBox.Show("Notunuz başarıyla eklendi!");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Notunuz kaydedilmedi.");
            }
        }
        private void UpdateNote()
        {
            int noteID = (int)listBox1.SelectedValue;
            Note selected = _noteController.GetByID(noteID);
            selected.Title = txtTitle.Text;
            selected.Content = txtTitle.Text;

            bool result = _noteController.Update(selected);
            if (result)
            {
                MessageBox.Show("Güncellendi");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Güncellenemedi.");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                AddNote();
            }
            else
            {
                UpdateNote();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Not seçiniz");
                return;
            }
            int noteID =(int) listBox1.SelectedValue;
            Note selected = _noteController.GetByID(noteID);
            bool result = _noteController.Delete(selected);
            if (result)
            {
                MessageBox.Show("Not başarıyla silindi");
                FillNotes();
            }
            else
            {
                MessageBox.Show("Not Silinemedi.");
            }
        }
    }
}
