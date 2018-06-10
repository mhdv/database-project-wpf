using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BazyDanych
{
    /// <summary>
    /// Logika interakcji dla klasy AddWindow.xaml
    /// </summary>


    public partial class AddWindow : Window
    {
        
        public BindingList<Klient> KlientL = new BindingList<Klient>();
        public BindingList<Pracownik> PracownikL = new BindingList<Pracownik>();
        public BindingList<Biuro> BiuroL = new BindingList<Biuro>();
        

        public AddWindow()
        {
            InitializeComponent();
            InitTabs();
        }

        void InitTabs()
        {
            // DISABLE NOT IMPLEMENTED TABS
            DomTab.IsEnabled = false;
            GruntTab.IsEnabled = false;
            HalaTab.IsEnabled = false;
            MieszkanieTab.IsEnabled = false;
            SpotkanieTab.IsEnabled = false;
            UmowaTab.IsEnabled = false;
            
            KlientL.Clear();
            PracownikL.Clear();
            BiuroL.Clear();

            // ADD LISTS AS SOURCES TO LISTBOXES\
            
            // KLIENT
            KlientList.ItemsSource = KlientL;
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Klient orderby b.ID select b;

                foreach (var item in query)
                {
                    KlientL.Add(item);
                }

            }
            // PRACOWNIK
            PracownikList.ItemsSource = PracownikL;
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Pracownik orderby b.ID select b;

                foreach (var item in query)
                {
                    PracownikL.Add(item);
                }

            }
            // BIURO
            BiuroList.ItemsSource = BiuroL;
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Biuro orderby b.ID select b;

                foreach (var item in query)
                {
                    BiuroL.Add(item);
                }

            }
            
        }
        /*
         * using (var ctx = new BazyDanychContext())
            {
                if (tableList.SelectedIndex == 0) // OSOBA
                {
                    Osoba tmpTask = new Osoba { Imie = ImieLbl.Text, Nazwisko = NazwiskoLbl.Text, Telefon = TelefonLbl.Text, Adres = AdresLbl.Text, Mail = MailLbl.Text, IloscTransakcji = Int32.Parse(IloscLbl.Text), Typ = TypList.Text };
                    ctx.Osoba.Add(tmpTask);
                }
                else if (tableList.SelectedIndex == 1) // KLIENT
                {
                    Klient tmpTask = new Klient { Pracownik = ImieLbl.Text, Sprzedane = Int32.Parse(NazwiskoLbl.Text), Kupione = Int32.Parse(TelefonLbl.Text), Preferencje = AdresLbl.Text };
                    ctx.Klient.Add(tmpTask);
                }

                ctx.SaveChanges();
            }*/

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.IsEnabled = false;
            window.Show();
            this.Close();
        }
        
        private void KlientAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                Klient tmp = new Klient { Imie = KlientImie.Text, Nazwisko = KlientNazwisko.Text, Telefon = KlientTelefon.Text, Adres = KlientAdres.Text, Mail = KlientMail.Text, IloscTransakcji = Int32.Parse(KlientIloscTransakcji.Text), Typ = "Klient", Pracownik = KlientPracownik.Text, Sprzedane = Int32.Parse(KlientSprzedane.Text), Kupione = Int32.Parse(KlientKupione.Text), Preferencje = KlientPreferencje.Text };
                ctx.Osoba.Add(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void PracownikAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                Pracownik tmp = new Pracownik { Imie = PracownikImie.Text, Nazwisko = PracownikNazwisko.Text, Telefon = PracownikTelefon.Text, Adres = PracownikAdres.Text, Mail = PracownikMail.Text, IloscTransakcji = Int32.Parse(PracownikIloscTransakcji.Text), Typ = "Klient", Stanowisko = PracownikStanowisko.Text, Wynagrodzenie = float.Parse(PracownikWynagrodzenie.Text), Dostepnosc = PracownikDostepnosc.Text, DniUrlopu = Int32.Parse(PracownikDniUrlopu.Text) };
                ctx.Osoba.Add(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void BiuroAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                Biuro tmp = new Biuro { Adres = BiuroAdres.Text, Powierzchnia = float.Parse(BiuroPowierzchnia.Text), Typ = "Biuro", PracownikID = Int32.Parse(BiuroPracownik.Text), TypBiura = BiuroTyp.Text, Stanowiska = Int32.Parse(BiuroStanowiska.Text), Parking = BiuroParking.Text };
                ctx.Nieruchomosc.Add(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void KlientRemove_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                Klient tmp = new Klient { ID = KlientL.ElementAt<Klient>(KlientList.SelectedIndex).ID };
                ctx.Osoba.Attach(tmp);
                ctx.Osoba.Remove(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void PracownikRemove_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                Pracownik tmp = new Pracownik { ID = PracownikL.ElementAt<Pracownik>(PracownikList.SelectedIndex).ID };
                ctx.Osoba.Attach(tmp);
                ctx.Osoba.Remove(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void BiuroRemove_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                Biuro tmp = new Biuro { ID = BiuroL.ElementAt<Biuro>(BiuroList.SelectedIndex).ID };
                ctx.Nieruchomosc.Attach(tmp);
                ctx.Nieruchomosc.Remove(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }
    }
}
