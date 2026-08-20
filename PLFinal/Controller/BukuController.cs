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
    public class BukuController
    {
        private BukuRepository _repository;

        public List<Buku> ReadByJudul(string judul)
        {
            // membuat objek collection
            List<Buku> list = new List<Buku>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByJudul(judul);
            }

            return list;
        }
        public List<Buku> ReadAll()
        {
            // membuat objek collection
            List<Buku> list = new List<Buku>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }

            return list;
        }


        public int Create(Buku bk)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Kode_buku))
            {
                MessageBox.Show("Kode Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Judul))
            {
                MessageBox.Show("Judul harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.Penerbit))
            {
                MessageBox.Show("Penerbit harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Pengarang))
            {
                MessageBox.Show("Pengarang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            
            if (string.IsNullOrEmpty(bk.Tahun))
            {
                MessageBox.Show("Tahun harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new BukuRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data buku berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data buku gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int Update(Buku bk)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Kode_buku))
            {
                MessageBox.Show("Kode Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Judul))
            {
                MessageBox.Show("Judul harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.Penerbit))
            {
                MessageBox.Show("Penerbit harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Pengarang))
            {
                MessageBox.Show("Pengarang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
           
            if (string.IsNullOrEmpty(bk.Tahun))
            {
                MessageBox.Show("Tahun harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Buku berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Buku gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Buku bk)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bk.Kode_buku))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Buku berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Buku gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
