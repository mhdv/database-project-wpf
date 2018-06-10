using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    [Table("Klient")]
    public class Klient: Osoba
    {
        public string Pracownik { get; set; }
        public int Sprzedane { get; set; }
        public int Kupione { get; set; }
        public string Preferencje { get; set; }

        public override string ToString()
        {
            //return "Imie: " + Imie +"\t Nazwisko: " + Nazwisko;
            return Imie + " | " + Nazwisko + " | K:" + Kupione.ToString() + " | S:" + Sprzedane.ToString() + " | " + Preferencje;
        }
    }

}
