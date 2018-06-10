using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BazyDanych
{
    
        
    public class BazyDanychContext : DbContext
    {
        public BazyDanychContext() : base("ProjektBD8") { }

        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Nieruchomosc> Nieruchomosc { get; set; }
        public DbSet<Spotkanie> Spotkanie { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<Biuro> Biuro { get; set; }
        public DbSet<Dom> Dom { get; set; }
        public DbSet<Grunt> Grunt { get; set; }
        public DbSet<Hala> Hala { get; set; }
        public DbSet<Mieszkanie> Mieszkanie { get; set; }
        public DbSet<Umowa> Umowa { get; set; }
    } 
}
