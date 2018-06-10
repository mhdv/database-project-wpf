using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Grunt")]
    public class Grunt : Nieruchomosc
    {
        public string TypGruntu { get; set; }
        public string Przeznaczenie { get; set; }
    }
}
