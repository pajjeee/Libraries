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
    public partial class FrmBuku : Form
    {
        private List<Buku> listOfBuku = new List<Buku>();

        // deklarasi objek controller
        private BukuController controller;
        public FrmBuku()
        {
            InitializeComponent();
            controller = new BukuController();
            InisialisasiListView();
            LoadDataBuku();
        }
        private void InisialisasiListView()
        {
            lvwBuku.View = System.Windows.Forms.View.Details;
            lvwBuku.FullRowSelect = true;
            lvwBuku.GridLines = true;
            lvwBuku.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Kode", 91, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Judul", 200, HorizontalAlignment.Left);
            lvwBuku.Columns.Add("Penerbit", 80, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Pengarang", 80, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Tahun", 80, HorizontalAlignment.Center);
        }
        private void LoadDataBuku()
        {
            // kosongkan listview
            lvwBuku.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfBuku = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var bk in listOfBuku)
            {
                var noUrut = lvwBuku.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.Kode_buku);
                item.SubItems.Add(bk.Judul);
                item.SubItems.Add(bk.Penerbit);
                item.SubItems.Add(bk.Pengarang);
                item.SubItems.Add(bk.Tahun);
                // tampilkan data mhs ke listview
                lvwBuku.Items.Add(item);
            }
        }
        private void OnCreateEventHandler(Buku bk)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfBuku.Add(bk);

            int noUrut = lvwBuku.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(bk.Kode_buku);
            item.SubItems.Add(bk.Judul);
            item.SubItems.Add(bk.Penerbit);
            item.SubItems.Add(bk.Pengarang);
            item.SubItems.Add(bk.Tahun);

            lvwBuku.Items.Add(item);
        }

        // method event handler untuk merespon event OnUpdate,
        private void OnUpdateEventHandler(Buku bk)
        {
            // ambil index data mhs yang edit
            int index = lvwBuku.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwBuku.Items[index];
            itemRow.SubItems[1].Text = bk.Kode_buku;
            itemRow.SubItems[2].Text = bk.Judul;
            itemRow.SubItems[3].Text = bk.Penerbit;
            itemRow.SubItems[4].Text = bk.Pengarang;
            itemRow.SubItems[5].Text = bk.Tahun;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmBukuEtry frmEn = new FrmBukuEtry("Tambah Data Buku", controller);

            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEn.OnCreate += OnCreateEventHandler;

            // tampilkan form entry mahasiswa
            frmEn.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBuku.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Buku bk = listOfBuku[lvwBuku.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FrmBukuEtry frmEntry = new FrmBukuEtry("Edit Data Buku",bk , controller);

                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmEntry.OnUpdate += OnUpdateEventHandler;

                // tampilkan form entry mahasiswa
                frmEntry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwBuku.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data member ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Buku bk = listOfBuku[lvwBuku.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(bk);
                    if (result > 0) LoadDataBuku();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data member belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        

        private void btnC_Click(object sender, EventArgs e)
        {
            lvwBuku.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfBuku = controller.ReadByJudul(txtJudul.Text);

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfBuku)
            {
                var noUrut = lvwBuku.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.Kode_buku);
                item.SubItems.Add(bk.Judul);
                item.SubItems.Add(bk.Penerbit);
                item.SubItems.Add(bk.Pengarang);
                item.SubItems.Add(bk.Tahun);

                lvwBuku.Items.Add(item);
            }
        }

        private void txtJudul_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
