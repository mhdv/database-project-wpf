using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Spotkanie")]
    public class Spotkanie
    {
        public int ID { get; set; }
        public string Cel { get; set; }
        public string Termin { get; set; }
        public string Miejsce { get; set; }
        public int PracownikID { get; set; }
        public int KlientID { get; set; }
    }
}
