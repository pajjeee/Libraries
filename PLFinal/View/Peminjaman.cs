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
    public partial class Peminjaman : Form
    {
        private List<Transaksi> listOfTransaksi = new List<Transaksi>();

        private TransaksiController controller;
        public Peminjaman()
        {
            InitializeComponent();
           
            controller = new TransaksiController();
            InisialisasiListView();
            LoadDataLaporanTransaksi();

        }
        private void InisialisasiListView()
        {
            lvwPeminjaman.View = System.Windows.Forms.View.Details;
            lvwPeminjaman.FullRowSelect = true;
            lvwPeminjaman.GridLines = true;
            lvwPeminjaman.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("ID_Buku", 91, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("Judul_Buku", 190, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("Nama", 79, HorizontalAlignment.Left);
            lvwPeminjaman.Columns.Add("Tgl Peminjaman", 80, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("tgl Pengembalian", 100, HorizontalAlignment.Left);
            

        }
        private void LoadDataLaporanTransaksi()
        {
            lvwPeminjaman.Items.Clear();

            listOfTransaksi = controller.ReadAll();

            foreach (var pjm in listOfTransaksi)
            {
                var noUrut = lvwPeminjaman.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pjm.Kode_Peminjaman);
                item.SubItems.Add(pjm.Nama_Peminjam);
                item.SubItems.Add(pjm.Id_Peminjaman);
                item.SubItems.Add(pjm.Peminjaman);
                item.SubItems.Add(pjm.Pengembalian);
               


                lvwPeminjaman.Items.Add(item);
            }
        }
        private void OnCreateEventHandler(Transaksi pjm)
        {

            listOfTransaksi.Add(pjm);
            int noUrut = lvwPeminjaman.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(pjm.Kode_Peminjaman);
            item.SubItems.Add(pjm.Nama_Peminjam);
            item.SubItems.Add(pjm.Id_Peminjaman);
            item.SubItems.Add(pjm.Peminjaman);
            item.SubItems.Add(pjm.Pengembalian);
            lvwPeminjaman.Items.Add(item);
        }

        private void OnUpdateEventHandler(Transaksi pjm)
        {

            int index = lvwPeminjaman.SelectedIndices[0];

            ListViewItem itemRow = lvwPeminjaman.Items[index];
            itemRow.SubItems[1].Text = pjm.Kode_Peminjaman;
            itemRow.SubItems[2].Text = pjm.Nama_Peminjam;
            itemRow.SubItems[3].Text = pjm.Id_Peminjaman;
            itemRow.SubItems[4].Text = pjm.Peminjaman;
            itemRow.SubItems[5].Text = pjm.Pengembalian;
            
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            controller = new TransaksiController();
            PeminjamanEntry frmTransaksi = new PeminjamanEntry("Tambah Data Peminjaman", controller);

            frmTransaksi.OnCreate += OnCreateEventHandler;

            frmTransaksi.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPeminjaman.SelectedItems.Count > 0)
            {
                Transaksi pjm = listOfTransaksi[lvwPeminjaman.SelectedIndices[0]];

                PeminjamanEntry frmTransaksi = new PeminjamanEntry("Edit Data Transaksi", pjm, controller);

                frmTransaksi.OnCreate += OnUpdateEventHandler;

                frmTransaksi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

            if (lvwPeminjaman.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data transaksi ingin dihapus?", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    Transaksi pjm = listOfTransaksi[lvwPeminjaman.SelectedIndices[0]];

                    var result = controller.Delete(pjm);
                    if (result > 0) LoadDataLaporanTransaksi();
                }
            }
            else
            {
                MessageBox.Show("Data transaksi belum dipilih!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DisplayFilteredList(List<Transaksi> filteredlist)
        {
            lvwPeminjaman.Items.Clear();

            foreach (var pjm in filteredlist)
            {
                var noUrut = lvwPeminjaman.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pjm.Kode_Peminjaman);
                item.SubItems.Add(pjm.Nama_Peminjam);
                item.SubItems.Add(pjm.Id_Peminjaman);
                item.SubItems.Add(pjm.Peminjaman);
                item.SubItems.Add(pjm.Pengembalian);
                lvwPeminjaman.Items.Add(item);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            lvwPeminjaman.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfTransaksi = controller.ReadByNama(txtNama.Text);

            // ekstrak objek mhs dari collection
            foreach (var pjm in listOfTransaksi)
            {
                var noUrut = lvwPeminjaman.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pjm.Kode_Peminjaman);
                item.SubItems.Add(pjm.Nama_Peminjam);
                item.SubItems.Add(pjm.Id_Peminjaman);
                item.SubItems.Add(pjm.Peminjaman);
                item.SubItems.Add(pjm.Pengembalian);
                lvwPeminjaman.Items.Add(item);
            }
        }

        private void lvwPeminjaman_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
