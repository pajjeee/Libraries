using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLFinal.View
{
    public partial class MenuPerpustakaan : Form
    {
        public MenuPerpustakaan()
        {
            InitializeComponent();
        }

        

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tutup form menu
                this.Close();

                // Tampilkan form login
                Loginn loginForm = new Loginn();
                loginForm.ShowDialog();
                this.Close();


            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            FrmBuku data = new FrmBuku();
            data.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            FrmMember data = new FrmMember();
            data.Show();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            PeminjamanEntry data = new PeminjamanEntry();
            data.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Peminjaman data = new Peminjaman();
            data.Show();
        }

        private void MenuPerpustakaan_Load(object sender, EventArgs e)
        {

        }
    }
}
