using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCEvidencijadodatnogobrazovanja.Models
{
    public class EvidencijaDbContext : DbContext
    { 
        public EvidencijaDbContext(): base("name=EvidencijaDbContext")


        {

    }

    
        public DbSet<Student> Students { get; set; }
        public DbSet<Ustanova> Ustanovas { get; set; }
    }
}