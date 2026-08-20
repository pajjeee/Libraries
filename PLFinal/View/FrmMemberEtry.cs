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
    public partial class FrmMemberEtry : Form
    {
        public delegate void CreateUpdateEventHandler(Member mhs);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private MemberController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau 
       // update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Member mhs;

        public FrmMemberEtry()
        {
            InitializeComponent();
        }

        public FrmMemberEtry(string title, MemberController controller)
           : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }

        // constructor untuk inisialisasi data ketika mengedit data
        public FrmMemberEtry(string title, Member obj, MemberController controller)
            : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;

            isNewData = false; // set status edit data
            mhs = obj; // set objek mhs yang akan diedit

            // untuk edit data, tampilkan data lama
            txtId.Text = mhs.Id;
            txtNama.Text = mhs.Nama;
            txtAlamat.Text = mhs.Alamat;
            txtTlp.Text = mhs.Telephone;

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) mhs = new Member();

            // set nilai property objek mahasiswa yg diambil dari TextBox
            mhs.Id = txtId.Text;
            mhs.Nama = txtNama.Text;
            mhs.Alamat = txtAlamat.Text;
            mhs.Telephone = txtTlp.Text;

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(mhs);

                if (result > 0) // tambah data berhasil
                {
                    OnCreate(mhs); // panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya
                    txtId.Clear();
                    txtNama.Clear();
                    txtAlamat.Clear();
                    txtTlp.Clear();

                    txtId.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(mhs);

                if (result > 0)
                {
                    OnUpdate(mhs); // panggil event OnUpdate
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
