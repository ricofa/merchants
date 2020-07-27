using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Merchants.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Merchants.DAL
{
    public class MerchantsContext : DbContext
    {
        public MerchantsContext() : base("MerchantsContext")
        {
        }
        public System.Data.Entity.DbSet<Pelanggan> Pelanggans { get; set; }
        public System.Data.Entity.DbSet<Supplier> Suppliers { get; set; }
        public System.Data.Entity.DbSet<Karyawan> Karyawans { get; set; }
        public System.Data.Entity.DbSet<Cloth> Cloths { get; set; }
        public System.Data.Entity.DbSet<Faktur> Fakturs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MerchantsContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}