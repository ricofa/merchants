using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchants.Models
{
    public partial class Faktur
    {
        public int ID { get; set; }
        public DateTime Tanggal { get; set; }
        public string Jumlah { get; set; }
        public string Harga { get; set; }
        public string Pajak { get; set; }
        public string Total { get; set; }
        public int PelangganID { get; set; }
        public int KaoID { get; set; }
        public int KaryawanID { get; set; }

        public virtual Pelanggan Pelanggan { get; set; }
        public virtual Cloth Cloth { get; set; }
        public virtual Karyawan Karyawan { get; set; }
    }
}