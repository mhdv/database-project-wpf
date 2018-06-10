using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Mieszkanie")]
    public class Mieszkanie : Nieruchomosc
    {
        public int Pokoje { get; set; }
        public int Pietro { get; set; }
        public string Garaz { get; set; }
    }
}
