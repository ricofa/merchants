using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchants.Models
{
    public partial class Karyawan
    {
        public Karyawan()
        {
            this.Fakturs = new HashSet<Faktur>();
        }
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Status { get; set; }
        public string Telepon { get; set; }
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Faktur> Fakturs { get; set; }
    }
}