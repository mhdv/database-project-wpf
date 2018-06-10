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
    /// Interaction logic for UmowyWindow.xaml
    /// </summary>
    public partial class UmowyWindow : Window
    {

        public BindingList<Klient> KlientL = new BindingList<Klient>();
        public BindingList<Pracownik> PracownikL = new BindingList<Pracownik>();
        public BindingList<Umowa> UmowaL = new BindingList<Umowa>();
        public BindingList<Nieruchomosc> NieruchomoscL = new BindingList<Nieruchomosc>();

        public UmowyWindow()
        {
            InitializeComponent();
            InitTabs();
        }

        private void InitTabs()
        {
            // INIT NIERUCHOMOSCI
            NieruchomoscL.Clear();
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Nieruchomosc orderby b.ID select b;

                foreach (var item in query)
                {
                    NieruchomoscL.Add(item);
                }
            }

            // INIT LIST BOXES
            Nieruchomosci.SelectedIndex = 0;
            Nieruchomosci.ItemsSource = NieruchomoscL;
            TypUmowy.SelectedIndex = 0;
            TypUmowy.ItemsSource = new BindingList<string>() { "Kupno", "Sprzedaz", "Wynajem" };

            // DISABLE NOT IMPLEMENTED TABS            
            KlientL.Clear();
            PracownikL.Clear();
            UmowaL.Clear();

            // INIT LISTS
            KlientList.ItemsSource = KlientL;
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Klient orderby b.ID select b;

                foreach (var item in query)
                {
                    KlientL.Add(item);
                }
            }

            PracownikList.ItemsSource = PracownikL;
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Pracownik orderby b.ID select b;

                foreach (var item in query)
                {
                    PracownikL.Add(item);
                }
            }

            UmowaList.ItemsSource = UmowaL;
            using (var ctx = new BazyDanychContext())
            {
                var query = from b in ctx.Umowa orderby b.ID select b;

                foreach (var item in query)
                {
                    UmowaL.Add(item);
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

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {

            if (KlientList.SelectedIndex < 0) KlientList.SelectedIndex = 0;
            if (PracownikList.SelectedIndex < 0) PracownikList.SelectedIndex = 0;
            if (Nieruchomosci.SelectedIndex < 0) Nieruchomosci.SelectedIndex = 0;
            int klientID = KlientL.ElementAt<Klient>(KlientList.SelectedIndex).ID;
            int pracownikID = PracownikL.ElementAt<Pracownik>(PracownikList.SelectedIndex).ID;
            int nieruchomoscID = NieruchomoscL.ElementAt<Nieruchomosc>(Nieruchomosci.SelectedIndex).ID;
            var isNumericProwizja = int.TryParse(WysokoscProwizji.Text, out int n);
            if (!isNumericProwizja)
            {
                MessageBox.Show("Pole prowizji musi być liczbą");
                return;
            }
            if(Data.Text == "")
            {
                MessageBox.Show("Podaj datę");
                return;
            }
            using (var ctx = new BazyDanychContext())
            {
                Umowa tmp = new Umowa { Cel = "Umowa", KlientID = klientID, PracownikID = pracownikID, Miejsce = Miejsce.Text, NieruchomoscID = nieruchomoscID, Prowizja = Int32.Parse(WysokoscProwizji.Text), Termin = Data.Text, Typ = TypUmowy.Text };
                ctx.Spotkanie.Add(tmp);
                ctx.SaveChanges();
            }
            InitTabs();
        }

        private void UsunBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UmowaL.Count > 0)
                using (var ctx = new BazyDanychContext())
                {
                    Umowa tmp = new Umowa { ID = UmowaL.ElementAt<Umowa>(UmowaList.SelectedIndex).ID };
                    ctx.Spotkanie.Attach(tmp);
                    ctx.Spotkanie.Remove(tmp);
                    ctx.SaveChanges();
                }
            InitTabs();
        }

        private void EdytujBtn_Click(object sender, RoutedEventArgs e)
        {
            if (KlientList.SelectedIndex < 0) KlientList.SelectedIndex = 0;
            if (PracownikList.SelectedIndex < 0) PracownikList.SelectedIndex = 0;
            if (Nieruchomosci.SelectedIndex < 0) Nieruchomosci.SelectedIndex = 0;
            int klientID = KlientL.ElementAt<Klient>(KlientList.SelectedIndex).ID;
            int pracownikID = PracownikL.ElementAt<Pracownik>(PracownikList.SelectedIndex).ID;
            int nieruchomoscID = NieruchomoscL.ElementAt<Nieruchomosc>(Nieruchomosci.SelectedIndex).ID;
            var isNumericProwizja = int.TryParse(WysokoscProwizji.Text, out int n);
            if (!isNumericProwizja)
            {
                MessageBox.Show("Pole prowizji musi być liczbą");
                return;
            }

            if (Data.Text == "")
            {
                MessageBox.Show("Podaj datę");
                return;
            }
            using (var ctx = new BazyDanychContext())
            {
                if (UmowaList.SelectedIndex < 0) UmowaList.SelectedIndex = 0;
                int tmpID = UmowaL.ElementAt<Umowa>(UmowaList.SelectedIndex).ID;
                var result = ctx.Umowa.SingleOrDefault(b => b.ID == tmpID);
                if (result != null)
                {
                    result.Cel = "Umowa"; result.Typ = TypUmowy.Text;
                    result.KlientID = klientID; result.PracownikID = pracownikID;
                    result.Prowizja = Int32.Parse(WysokoscProwizji.Text); result.Termin = Data.Text;
                    result.Miejsce = Miejsce.Text; result.NieruchomoscID = nieruchomoscID;
                    ctx.SaveChanges();
                }
            }
            InitTabs();
        }
    }
}
