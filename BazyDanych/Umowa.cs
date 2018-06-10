using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Umowa")]
    public class Umowa: Spotkanie
    {
        public string Typ { get; set; }
        public float Prowizja { get; set; }
        public int NieruchomoscID { get; set; }
        public override string ToString()
        {
            return Typ + " | " + Miejsce + " | " + Termin;
        }
    }
}
