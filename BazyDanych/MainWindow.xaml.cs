using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BazyDanych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            using (var ctx = new BazyDanychContext())
            {
                //var query = from b in ctx.Osoba orderby b.ID select b;

                //foreach (var item in query)
                //{
                    BazaDanychLbl.Text = "Nazwa bazy: ProjektBD \n" +
                                         "Struktura tablic: \n" +
                                         "  │\n  ├  Osoba\n  │      ├ Pracownik\n" +
                                         "  │      └ Klient\n  │\n  ├  Nieruchomość\n" +
                                         "  │      ├ Grunt\n  │      ├ Hala\n" +
                                         "  │      ├ Mieszkanie\n  │      ├ Dom\n" +
                                         "  │      └ Biuro\n  │\n  ├  Umowa\n  │\n" +
                                         "  └  Spotkanie";
                //}

            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow window = new AddWindow();
            this.IsEnabled = false;
            window.Show();
            this.Close();
            
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            KlienciWindow window = new KlienciWindow();
            this.IsEnabled = false;
            window.Show();
            this.Close();
        }

        private void UmowyBtn_Click(object sender, RoutedEventArgs e)
        {
            UmowyWindow window = new UmowyWindow();
            this.IsEnabled = false;
            window.Show();
            this.Close();
        }
    }
}
