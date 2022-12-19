using System;
using System.Windows;

namespace User_Interface.Dashboard
{
    /// <summary>
    /// Interaction logic for KorisnickaTabla.xaml
    /// </summary>
    public partial class KorisnickaTabla : Window
    {
        public KorisnickaTabla()
        {
            InitializeComponent();

            naslov.Text = "Howdy, " + Cache_Memory.DataTransferObject.TrenutniKorisnik.PrijavljeniKorisnik.TrenutniKorisnik.Username + "!";
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Close();
            mw.ShowDialog();
        }

        private void dodajBrojilo_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dodajPotrosnjuBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void poGraduRb_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void poMesecuRb_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void poKorisnikuRb_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void poBrojilu_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
