using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLFinal.Model.Entity;
using PLFinal.Model.Repository;
using PLFinal.Model.Context;
namespace PLFinal.Controller
{
    public class MemberController
    {
        private MemberRepository _repository;

        public List<Member> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Member> list = new List<Member>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MemberRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }

            return list;
        }
        public List<Member> ReadAll()
        {
            // membuat objek collection
            List<Member> list = new List<Member>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MemberRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }

            return list;
        }


        public int Create(Member mhs)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Id))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(mhs.Telephone))
            {
                MessageBox.Show("No Telephone harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new MemberRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data member berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data member gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int Update(Member mhs)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Id))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(mhs.Telephone))
            {
                MessageBox.Show("No Telephone harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MemberRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data mmember berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data member gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Member mhs)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Id))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MemberRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data member berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data member gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
