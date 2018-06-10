using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    public class Nieruchomosc
    {
        public int ID { get; set; }
        public string Adres { get; set; }
        public float Powierzchnia { get; set; }
        public string Typ { get; set; }
        public int PracownikID { get; set; }
        public override string ToString()
        {
            return Adres + " | " + Typ + " | " + Powierzchnia;
        }
    }
}
