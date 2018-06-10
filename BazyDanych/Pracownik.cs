using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Pracownik")]
    public class Pracownik: Osoba
    {
        public string Stanowisko { get; set; }
        public string Dostepnosc { get; set; }
        public float Wynagrodzenie { get; set; }
        public int DniUrlopu { get; set; }

        public override string ToString()
        {
            return Imie + " | " + Nazwisko + " | " + Stanowisko;
        }
    }
}
