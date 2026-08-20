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
    public partial class FrmMember : Form
    {
        private List<Member> listOfMember = new List<Member>();

        // deklarasi objek controller
        private MemberController controller;
        public FrmMember()
        {
            InitializeComponent();
            controller = new MemberController();
            InisialisasiListView();
            LoadDataMahasiswa();
        }
        private void InisialisasiListView()
        {
            lvwMember.View = System.Windows.Forms.View.Details;
            lvwMember.FullRowSelect = true;
            lvwMember.GridLines = true;
            lvwMember.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwMember.Columns.Add("Id", 91, HorizontalAlignment.Center);
            lvwMember.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMember.Columns.Add("Alamat", 130, HorizontalAlignment.Center);
            lvwMember.Columns.Add("No Hp", 140, HorizontalAlignment.Center);
        }
        private void LoadDataMahasiswa()
        {
            // kosongkan listview
            lvwMember.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfMember = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var mhs in listOfMember)
            {
                var noUrut = lvwMember.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Id);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Alamat);
                item.SubItems.Add(mhs.Telephone);
                // tampilkan data mhs ke listview
                lvwMember.Items.Add(item);
            }
        }
        private void OnCreateEventHandler(Member mhs)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfMember.Add(mhs);

            int noUrut = lvwMember.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mhs.Id);
            item.SubItems.Add(mhs.Nama);
            item.SubItems.Add(mhs.Alamat);
            item.SubItems.Add(mhs.Telephone);

            lvwMember.Items.Add(item);
        }

        // method event handler untuk merespon event OnUpdate,
        private void OnUpdateEventHandler(Member mhs)
        {
            // ambil index data mhs yang edit
            int index = lvwMember.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwMember.Items[index];
            itemRow.SubItems[1].Text = mhs.Id;
            itemRow.SubItems[2].Text = mhs.Nama;
            itemRow.SubItems[3].Text = mhs.Alamat;
            itemRow.SubItems[4].Text = mhs.Telephone;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmMemberEtry frmEntry = new FrmMemberEtry("Tambah Data Member", controller);

            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;

            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwMember.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Member mhs = listOfMember[lvwMember.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FrmMemberEtry frmEntry = new FrmMemberEtry("Edit Data Member", mhs, controller);

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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMember.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data member ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Member mhs = listOfMember[lvwMember.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(mhs);
                    if (result > 0) LoadDataMahasiswa();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data member belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            lvwMember.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfMember = controller.ReadByNama(txtNama.Text);

            // ekstrak objek mhs dari collection
            foreach (var mhs in listOfMember)
            {
                var noUrut = lvwMember.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Id);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Alamat);
                item.SubItems.Add(mhs.Telephone);

                // tampilkan data mhs ke listview
                lvwMember.Items.Add(item);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            lvwMember.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfMember = controller.ReadByNama(txtNama.Text);

            // ekstrak objek mhs dari collection
            foreach (var mhs in listOfMember)
            {
                var noUrut = lvwMember.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Id);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Alamat);
                item.SubItems.Add(mhs.Telephone);

                // tampilkan data mhs ke listview
                lvwMember.Items.Add(item);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (lvwMember.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data member ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Member mhs = listOfMember[lvwMember.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(mhs);
                    if (result > 0) LoadDataMahasiswa();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data member belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (lvwMember.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Member mhs = listOfMember[lvwMember.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FrmMemberEtry frmEntry = new FrmMemberEtry("Edit Data Member", mhs, controller);

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

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            FrmMemberEtry frmEntry = new FrmMemberEtry("Tambah Data Member", controller);

            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;

            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
