using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchants.Models
{
    public partial class Cloth
    {
        public Cloth()
        {
            this.Fakturs = new HashSet<Faktur>();
        }
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Merk { get; set; }
        public string Stok { get; set; }
        public string Bahan { get; set; }
        public string Harga { get; set; }
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Faktur> Fakturs { get; set; }
    }
}