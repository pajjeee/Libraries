using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFinal.Model.Entity
{
    public class Transaksi
    {
        public string Kode_Peminjaman { get; set; }
        public string Nama_Peminjam { get; set; }
        public string Id_Peminjaman { get; set; }
        public string Peminjaman { get; set; }
        public string Pengembalian { get; set; }
    }
}
