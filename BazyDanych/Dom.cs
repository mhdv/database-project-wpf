using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Dom")]
    public class Dom: Nieruchomosc
    {
        public string TypDomu { get; set; }
        public int Pokoje { get; set; }
        public string Garaz { get; set; }
        public float PowierzchniaZabudowy { get; set; }
    }
}
