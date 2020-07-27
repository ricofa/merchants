using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchants.Models
{
    public partial class Pelanggan
    {
        public Pelanggan()
        {
            this.Fakturs = new HashSet<Faktur>();
        }
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Kelamin { get; set; }
        public string Pekerjaan { get; set; }

        public virtual ICollection<Faktur> Fakturs { get; set; }
    }
}