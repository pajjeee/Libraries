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
    public class TransaksiRepository
    {
        private SQLiteConnection _conn;

        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Transaksi pjm)
        {
            int result = 0;

            string sql = @"insert into Transaksi (kode, nama, id, peminjaman, pengembalian)
                            values (@kode, @nama, @id, @peminjaman, @pengembalian)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@kode", pjm.Kode_Peminjaman);
                cmd.Parameters.AddWithValue("@nama", pjm.Nama_Peminjam);
                cmd.Parameters.AddWithValue("@id", pjm.Id_Peminjaman);
                cmd.Parameters.AddWithValue("@peminjaman", pjm.Peminjaman);
                cmd.Parameters.AddWithValue("@pengembalian", pjm.Pengembalian);
                

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int Update(Transaksi pjm)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Transaksi set nama = @nama, id = @id, peminjaman = @peminjaman, pengembalian = @pengembalian
                           where kode = @kode";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
               
                cmd.Parameters.AddWithValue("@nama", pjm.Nama_Peminjam);
                cmd.Parameters.AddWithValue("@id", pjm.Id_Peminjaman);
                cmd.Parameters.AddWithValue("@peminjaman", pjm.Peminjaman);
                cmd.Parameters.AddWithValue("@pengembalian", pjm.Pengembalian);
                cmd.Parameters.AddWithValue("@kode", pjm.Kode_Peminjaman);

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

        public int Delete(Transaksi pjm)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from transaksi where kode = @kode";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode", pjm.Kode_Peminjaman);

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


        public List<Transaksi> ReadAll()
        {
            List<Transaksi> list = new List<Transaksi>();

            try
            {
                string sql = @"select kode, nama, id, peminjaman, pengembalian from transaksi order by kode";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Transaksi pjm = new Transaksi();
                            pjm.Kode_Peminjaman = dtr["kode"].ToString();
                            pjm.Nama_Peminjam = dtr["nama"].ToString();
                            pjm.Id_Peminjaman = dtr["id"].ToString();
                            pjm.Peminjaman = dtr["peminjaman"].ToString();
                            pjm.Pengembalian = dtr["pengembalian"].ToString();
                            

                            list.Add(pjm);
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
        public List<Transaksi> ReadByNama(string nm)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Transaksi> list = new List<Transaksi>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kode, nama, id, peminjaman, pengembalian 
                               from Transaksi 
                               where nama like @nama
                               order by nama";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nm));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Transaksi pjm = new Transaksi();
                            pjm.Kode_Peminjaman = dtr["kode"].ToString();
                            pjm.Nama_Peminjam = dtr["nama"].ToString();
                            pjm.Id_Peminjaman = dtr["id"].ToString();
                            pjm.Pengembalian = dtr["peminjaman"].ToString();
                            pjm.Pengembalian = dtr["pengembalian"].ToString();
                            

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(pjm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }

    }
}
