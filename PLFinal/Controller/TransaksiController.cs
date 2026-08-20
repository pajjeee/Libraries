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
    public class TransaksiController
    {
        private TransaksiRepository _repository;


        public List<Transaksi> ReadByNama(string nm)
        {
            // membuat objek collection
            List<Transaksi> list = new List<Transaksi>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new TransaksiRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nm);
            }

            return list;
        }
        public List<Transaksi> ReadAll()
        {
            List<Transaksi> list = new List<Transaksi>();

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);

                list = _repository.ReadAll();
            }

            return list;
        }

        public int Create(Transaksi pjm)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pjm.Kode_Peminjaman))
            {
                MessageBox.Show("Kode Peminjaman harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pjm.Nama_Peminjam))
            {
                MessageBox.Show("Nama Peminjam harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pjm.Id_Peminjaman))
            {
                MessageBox.Show("ID Peminjaman harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(pjm.Peminjaman))
            {
                MessageBox.Show(" harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(pjm.Pengembalian))
            {
                MessageBox.Show(" harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

           

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new TransaksiRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(pjm);
            }

            if (result > 0)
            {
                MessageBox.Show("Data peminjaman berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data peminjaman gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Update(Transaksi pjm)
        {
            int result = 0;

            if (string.IsNullOrEmpty(pjm.Kode_Peminjaman) || string.IsNullOrEmpty(pjm.Peminjaman) ||
                string.IsNullOrEmpty(pjm.Nama_Peminjam) || string.IsNullOrEmpty(pjm.Pengembalian) ||
                string.IsNullOrEmpty(pjm.Id_Peminjaman))
            {
                MessageBox.Show("Semua kolom harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                result = _repository.Update(pjm);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Peminjaman berhasil diupdate!", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Peminjaman gagal diupdate!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Transaksi pjm)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pjm.Kode_Peminjaman))
            {
                MessageBox.Show("Kode Peminjaman harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new TransaksiRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(pjm);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Peminjaman berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Peminjaman gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
