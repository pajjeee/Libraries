using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PLFinal.Model.Entity;
using PLFinal.Model.Context;

namespace PLFinal.Model.Repository
{
    public class BukuRepository
    {
        private SQLiteConnection _conn;

        public BukuRepository(DbContext context)
        {
            _conn = context.Conn;
        }
        public int Create(Buku bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Buku (kodebuku, judul, penerbit, pengarang, tahun)
                           values (@kodebuku, @judul, @penerbit, @pengarang, @tahun)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kodebuku", bk.Kode_buku);
                cmd.Parameters.AddWithValue("@judul", bk.Judul);
                cmd.Parameters.AddWithValue("@penerbit", bk.Penerbit);
                cmd.Parameters.AddWithValue("@pengarang", bk.Pengarang);
                cmd.Parameters.AddWithValue("@tahun", bk.Tahun);
                

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }
        public int Update(Buku bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Buku set judul = @judul, penerbit = @penerbit, pengarang = @pengarang, tahun = @tahun
                           where kodebuku = @kodebuku";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@kodebuku", bk.Kode_buku);
                cmd.Parameters.AddWithValue("@judul", bk.Judul);
                cmd.Parameters.AddWithValue("@penerbit", bk.Penerbit);
                cmd.Parameters.AddWithValue("@pengarang", bk.Pengarang);
                cmd.Parameters.AddWithValue("@tahun", bk.Tahun);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Buku bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from Buku
                           where kodebuku = @kodebuku";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kodebuku", bk.Kode_buku);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }
        public List<Buku> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Buku> list = new List<Buku>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kodebuku, judul, penerbit, pengarang, tahun 
                               from Buku 
                               order by judul";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Buku bk = new Buku();
                            bk.Kode_buku = dtr["kodebuku"].ToString();
                            bk.Judul = dtr["judul"].ToString();
                            bk.Penerbit = dtr["penerbit"].ToString();
                            bk.Pengarang = dtr["pengarang"].ToString();
                            bk.Tahun = dtr["tahun"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(bk);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }
        public List<Buku> ReadByJudul(string judul)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Buku> list = new List<Buku>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kodebuku, judul, penerbit, pengarang, tahun 
                               from Buku
                               where judul like @judul
                               order by judul";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@judul", "%" + judul + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Buku bk = new Buku();
                            bk.Kode_buku = dtr["kodebuku"].ToString();
                            bk.Judul = dtr["judul"].ToString();
                            bk.Penerbit = dtr["penerbit"].ToString();
                            bk.Pengarang = dtr["pengarang"].ToString();
                            bk.Tahun = dtr["tahun"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(bk);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByJudul error: {0}", ex.Message);
            }

            return list;
        }
    }
}
