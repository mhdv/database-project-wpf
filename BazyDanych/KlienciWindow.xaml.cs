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
    /// Interaction logic for KlienciWindow.xaml
    /// </summary>
    public partial class KlienciWindow : Window
    {

        public BindingList<Klient> KlientL = new BindingList<Klient>();

        public KlienciWindow()
        {
            InitializeComponent();

            // ADD LISTS AS SOURCES TO LISTBOXES
            KlientPreferencje.SelectedIndex = 0;
            KlientPreferencje.ItemsSource = new BindingList<string>() { "Mieszkania", "Domy", "Grunty", "Hale", "Biura" };
            WyborPreferencji.SelectedIndex = 0;
            WyborPreferencji.ItemsSource = new BindingList<string>() { "Brak", "Mieszkania", "Domy", "Grunty", "Hale", "Biura" };
            

            InitTabs();
        }
        void InitTabs()
        {
            
            // DISABLE NOT IMPLEMENTED TABS            
            KlientL.Clear();

            // KLIENT
            if (KlientFiltr.IsChecked == true)
            {
                KlientList.ItemsSource = KlientL;
                using (var ctx = new BazyDanychContext())
                {
                    var query = from b in ctx.Klient orderby b.ID select b;
                    
                    foreach (var item in query)
                    {
                        bool f = false, s = false, t = false;
                        if(CzyWiecej.IsChecked == true)
                        {
                            var isNumeric = int.TryParse(WiecejNiz.Text, out int l);
                            if (!isNumeric)
                            {
                                MessageBox.Show("Pole Wiecej niz musi byc liczba");
                                return;
                            }
                            if (item.IloscTransakcji > Int32.Parse(WiecejNiz.Text))
                            {
                                f = true;
                            }
                        }
                        else { f = true; }
                        if(WyborPreferencji.Text != "Brak")
                        {
                            if (item.Preferencje == WyborPreferencji.Text) s = true;
                        }
                        else { s = true; }
                        if (WiecejKupionych.IsChecked == true)
                        {
                            if (item.Kupione >= item.Sprzedane) t = true;
                        }
                        else if(WiecejSprzedanych.IsChecked == true)
                        {
                            if (item.Sprzedane >= item.Kupione) t = true;
                        }
                        else { t = true; }
                        if (f && s && t) KlientL.Add(item);
                    
                    }

                }
            }
            else
            {
                KlientList.ItemsSource = KlientL;
                using (var ctx = new BazyDanychContext())
                {
                    var query = from b in ctx.Klient orderby b.ID select b;
                    
                    foreach (var item in query)
                    {
                        KlientL.Add(item);
                    }
                }
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.IsEnabled = false;
            window.Show();
            this.Close();
        }

        private void KlientAdd_Click(object sender, RoutedEventArgs e)
        {
            if(KlientImie.Text == "" | KlientNazwisko.Text == "" | KlientAdres.Text == "" | KlientTelefon.Text == "")
            {
                MessageBox.Show("Proszę uzupełnić obowiązkowe pola");
                return;
            }
            var isNumericTelefon = int.TryParse(KlientTelefon.Text, out int m);
            if (!isNumericTelefon | KlientTelefon.Text.Length != 9)
            {
                MessageBox.Show("Niepoprawny numer telefonu");
                return;

            }
            if (KlientMail.Text != "" && !KlientMail.Text.Contains("@"))
            {
                MessageBox.Show("Niepoprawny adres email");
                return;
            }
            var isNumericKupione = int.TryParse(KlientKupione.Text, out int n);
            var isNumericSprzedane = int.TryParse(KlientSprzedane.Text, out int k);
            if(!isNumericKupione | !isNumericSprzedane)
            {
                MessageBox.Show("Pole transakcji musi być liczbą");
                return;
            }
            using (var ctx = new BazyDanychContext())
            {
                Klient tmp = new Klient { Imie = KlientImie.Text, Nazwisko = KlientNazwisko.Text, Telefon = KlientTelefon.Text, Adres = KlientAdres.Text, Mail = KlientMail.Text, IloscTransakcji = Int32.Parse(KlientKupione.Text)+ Int32.Parse(KlientSprzedane.Text), Typ = "Klient", Pracownik = KlientPracownik.Text, Sprzedane = Int32.Parse(KlientSprzedane.Text), Kupione = Int32.Parse(KlientKupione.Text), Preferencje = KlientPreferencje.Text };
                ctx.Osoba.Add(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void KlientRemove_Click(object sender, RoutedEventArgs e)
        {
            if(KlientL.Count > 0)
                using (var ctx = new BazyDanychContext())
                {
                    Klient tmp = new Klient { ID = KlientL.ElementAt<Klient>(KlientList.SelectedIndex).ID };
                    ctx.Osoba.Attach(tmp);
                    ctx.Osoba.Remove(tmp);
                    ctx.SaveChanges();
                }
            InitTabs();
        }

        private void KlientRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new BazyDanychContext())
            {
                foreach (var obj in KlientL)
                {
                    Klient tmp = obj;
                    ctx.Osoba.Attach(tmp);
                    ctx.Osoba.Remove(tmp);
                }
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void WiecejKupionych_Checked(object sender, RoutedEventArgs e)
        {
            WiecejSprzedanych.IsChecked = false;
        }

        private void WiecejSprzedanych_Checked(object sender, RoutedEventArgs e)
        {
            WiecejKupionych.IsChecked = false;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            InitTabs();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (KlientImie.Text == "" | KlientNazwisko.Text == "" | KlientAdres.Text == "" | KlientTelefon.Text == "")
            {
                MessageBox.Show("Proszę uzupełnić obowiązkowe pola");
                return;
            }
            var isNumericTelefon = int.TryParse(KlientTelefon.Text, out int m);
            if (!isNumericTelefon | KlientTelefon.Text.Length != 9)
            {
                MessageBox.Show("Niepoprawny numer telefonu");
                return;

            }
            if (KlientMail.Text != "" && !KlientMail.Text.Contains("@"))
            {
                MessageBox.Show("Niepoprawny adres email");
                return;
            }
            var isNumericKupione = int.TryParse(KlientKupione.Text, out int n);
            var isNumericSprzedane = int.TryParse(KlientSprzedane.Text, out int k);
            if (!isNumericKupione | !isNumericSprzedane)
            {
                MessageBox.Show("Pole transakcji musi być liczbą");
                return;
            }
            using (var ctx = new BazyDanychContext())
            {
                int tmpID = KlientL.ElementAt<Klient>(KlientList.SelectedIndex).ID;
                var result = ctx.Klient.SingleOrDefault(b => b.ID == tmpID);
                if (result != null)
                {
                    result.Imie = KlientImie.Text; result.Nazwisko = KlientNazwisko.Text;
                    result.Telefon = KlientTelefon.Text; result.Adres = KlientAdres.Text;
                    result.Mail = KlientMail.Text; result.IloscTransakcji = Int32.Parse(KlientKupione.Text) + Int32.Parse(KlientSprzedane.Text);
                    result.Typ = "Klient"; result.Pracownik = KlientPracownik.Text;
                    result.Sprzedane = Int32.Parse(KlientSprzedane.Text); result.Kupione = Int32.Parse(KlientKupione.Text);
                    result.Preferencje = KlientPreferencje.Text;
                    ctx.SaveChanges();
                }
            }
            InitTabs();
        }
    }
}
