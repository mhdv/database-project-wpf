using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Hala")]
    public class Hala : Nieruchomosc
    {
        public string TypHali { get; set; }
        public float Wysokosc { get; set; }
        public string Media { get; set; }
    }
}
