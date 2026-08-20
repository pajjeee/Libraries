using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu;
namespace PLFinal.View
{
    public partial class Loginn : Form
    {
        public Loginn()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Login Berhasil!");
                MenuPerpustakaan menu = new MenuPerpustakaan();
                menu.Show();
                this.Hide();
            }
            else if ((txtUsername.Text == "") && (txtPassword.Text == ""))
            {
                MessageBox.Show("Username dan password tidak boleh kosong");
            }
            else
            {
                MessageBox.Show("Password yang anda masukkan salah");
            }
        }

        private void CheckPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Loginn_Load(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
