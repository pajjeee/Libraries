using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLFinal.Model.Entity;
using PLFinal.Controller;

namespace PLFinal.View
{
    public partial class PeminjamanEntry : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Transaksi pjm);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private TransaksiController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atauupdate)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Transaksi pjm;
        // constructor default
        public PeminjamanEntry()
        {
            InitializeComponent();
        }
        public PeminjamanEntry(string title, TransaksiController controller)
       : this()
        {
            this.Text = title;
            this.controller = controller;
        }
        public PeminjamanEntry(string title, Transaksi obj, TransaksiController
       controller)
        : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = false; // set status edit data
            pjm = obj; // set objek mhs yang akan diedit
                         // untuk edit data, tampilkan data lama
            txtKode.Text = pjm.Kode_Peminjaman;
            txtNama.Text = pjm.Nama_Peminjam;
            txtId.Text = pjm.Id_Peminjaman;
            txtPeminjaman.Text = pjm.Peminjaman;
            txtPengembalian.Text = pjm.Pengembalian;
            
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            controller = new TransaksiController();

            if (isNewData) pjm = new Transaksi();

            pjm.Kode_Peminjaman = txtKode.Text;
            pjm.Nama_Peminjam = txtNama.Text;
            pjm.Id_Peminjaman = txtId.Text;
            pjm.Peminjaman = txtPeminjaman.Text;
            pjm.Pengembalian = txtPengembalian.Text;

            int result = 0;
            if (isNewData)
            {

                result = controller.Create(pjm);
                if (result > 0)
                {
                    OnCreate?.Invoke(pjm);
                    txtKode.Clear();
                    txtNama.Clear();
                    txtId.Clear();
                    txtPeminjaman.Clear();
                    txtPengembalian.Clear();

                    txtKode.Focus();

                }
            }
            else
            {

                result = controller.Update(pjm);
                if (result > 0)
                {
                    OnUpdate?.Invoke(pjm);

                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void PeminjamanEntry_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
