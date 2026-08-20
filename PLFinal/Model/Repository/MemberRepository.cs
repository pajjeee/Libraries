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
    public class MemberRepository
    {
        private SQLiteConnection _conn;

        public MemberRepository(DbContext context)
        {
            _conn = context.Conn;
        }
        public int Create(Member mhs)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Member (id, nama, alamat, telephone)
                           values (@id, @nama, @alamat, @telephone)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id", mhs.Id);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@alamat", mhs.Alamat);
                cmd.Parameters.AddWithValue("@telephone", mhs.Telephone);

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
        public int Update(Member mhs)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Member set nama = @nama, alamat = @alamat, telephone = @telephone
                           where id = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", mhs.Id);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@alamat", mhs.Alamat);
                cmd.Parameters.AddWithValue("@telephone", mhs.Telephone);

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

        public int Delete(Member mhs)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from Member
                           where id = @id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id", mhs.Id);

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
        public List<Member> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Member> list = new List<Member>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id, nama, alamat, telephone 
                               from Member 
                               order by nama";

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
                            Member mhs = new Member();
                            mhs.Id = dtr["id"].ToString();
                            mhs.Nama = dtr["nama"].ToString();
                            mhs.Alamat = dtr["alamat"].ToString();
                            mhs.Telephone = dtr["telephone"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(mhs);
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
        public List<Member> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Member> list = new List<Member>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id, nama, alamat, telephone 
                               from member 
                               where nama like @nama
                               order by nama";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama", "%" + nama + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Member mhs = new Member();
                            mhs.Id = dtr["id"].ToString();
                            mhs.Nama = dtr["nama"].ToString();
                            mhs.Alamat = dtr["alamat"].ToString();
                            mhs.Telephone = dtr["telephone"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(mhs);
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
