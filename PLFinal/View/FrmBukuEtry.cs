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
    public partial class FrmBukuEtry : Form
    {
        public delegate void CreateUpdateEventHandler(Buku bk);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private BukuController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau 
        // update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Buku bk;
        public FrmBukuEtry()
        {
            InitializeComponent();
        }
        public FrmBukuEtry(string title, BukuController controller)
           : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }
        public FrmBukuEtry(string title, Buku obj, BukuController controller)
           : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;

            isNewData = false; // set status edit data
            bk = obj; // set objek mhs yang akan diedit

            // untuk edit data, tampilkan data lama
            txtK.Text = bk.Kode_buku;
            txtJ.Text = bk.Judul;
            txtPe.Text = bk.Penerbit;
            txtP.Text = bk.Pengarang;
            txtT.Text = bk.Tahun;


        }

       

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isNewData) bk = new Buku();

            // set nilai property objek mahasiswa yg diambil dari TextBox
            bk.Kode_buku = txtK.Text;
            bk.Judul = txtJ.Text;
            bk.Penerbit = txtPe.Text;
            bk.Pengarang = txtP.Text;
            bk.Tahun = txtT.Text;
            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(bk);

                if (result > 0) // tambah data berhasil
                {
                    OnCreate(bk); // panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya
                    txtK.Clear();
                    txtJ.Clear();
                    txtP.Clear();
                    txtP.Clear();
                    txtT.Clear();

                    txtK.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(bk);

                if (result > 0)
                {
                    OnUpdate(bk); // panggil event OnUpdate
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
