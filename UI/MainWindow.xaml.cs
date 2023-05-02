using Common;
using Reader;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using Writer;

namespace UI
{
    public partial class MainWindow : Window
    {
        string[] kriterijumiPregleda = { "rbr", "korisnickoIme", "grad", "mesec", "svi" };
        int izabraniKriterijum = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpisPotrosnjebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rbr = Int32.Parse(idMerenja.Text.Trim());
                string kime = korIme.Text.Trim();
                string adr = adresa.Text.Trim();
                string gr = grad.Text.Trim();
                int idb = Int32.Parse(idBrojila.Text.Trim());
                decimal pot = decimal.Parse(potrosnja.Text.Trim());
                string mes = mesec.Text.Trim();

                Podatak podatak = new Podatak(rbr, kime, adr, gr, idb, pot, mes);

                // Slanje podatka na Dumping Buffer
                ChannelFactory<IWriter> kanal = new ChannelFactory<IWriter>("Writer");
                IWriter proxy = kanal.CreateChannel();

                if (proxy.ProsledjivanjePodatkaNaDumpingBuffer(podatak))
                {
                    MessageBox.Show("Podaci o potrošnji poslati Dumping Buffer-u!", "Uspešan prijem podataka", MessageBoxButton.OK, MessageBoxImage.Information);
                    idBrojila.Clear();
                    potrosnja.Clear();
                    mesec.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Podatak koji ste uneli već postoji Dumping Buffer-u!", "Postojeći podatak", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Niste uneli broj!\nPokušajte ponovo sa unosom validnih vrednosti za polja potrošnja, id brojila i/ili redni broj merenja!", "Greška u unosu broja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show("ERROR: " + exp.Message, "Greška prilikom prikupljanja podataka", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OcistiFormuBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult odabrao = MessageBox.Show("Da li želite da očistite polja forme?", "Čiščenje forme?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (odabrao == MessageBoxResult.Yes)
            {
                idMerenja.Clear();
                korIme.Clear();
                adresa.Clear();
                grad.Clear();
                idBrojila.Clear();
                potrosnja.Clear();
                mesec.SelectedIndex = 0;
            }
        }

        private void PregledBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChannelFactory<IReader> kanal = new ChannelFactory<IReader>("Reader");
                IReader proxy = kanal.CreateChannel();

                if (kriterijumiPregleda[izabraniKriterijum].Equals("mesec"))
                {
                    dataViewDb.ItemsSource = proxy.ProcitajPodatkeIzHistorical(kriterijumiPregleda[izabraniKriterijum], mesecPregled.Text);
                    dataViewDb.Items.Refresh();
                }
                else if (kriterijumiPregleda[izabraniKriterijum].Equals("svi"))
                {
                    dataViewDb.ItemsSource = proxy.ProcitajPodatkeIzHistorical(null, null, true);
                    dataViewDb.Items.Refresh();
                }
                else
                {
                    if (kriterijum.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Niste uneli nijednu vrednost u polje za kriterijum pretrage!", "Loše popunjena forma za pregled", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        dataViewDb.ItemsSource = proxy.ProcitajPodatkeIzHistorical(kriterijumiPregleda[izabraniKriterijum], kriterijum.Text);
                        dataViewDb.Items.Refresh();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("ERROR: " + exp.Message, "Greška prilikom čitanja podataka", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void OcistiBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult odabrao = MessageBox.Show("Da li želite da očistite polja forme vezana za pregled?", "Čiščenje forme?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (odabrao == MessageBoxResult.Yes)
            {
                izbor.SelectedIndex = 0;
                kriterijum.Clear();
                mesecPregled.SelectedIndex = 0;
                dataViewDb.ItemsSource = new List<Podatak>();
                dataViewDb.Items.Refresh();
            }
        }

        private void Izbor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (izbor.SelectedItem != null)
            {
                izabraniKriterijum = izbor.SelectedIndex;

                if (izbor.SelectedIndex == 3)
                {
                    if (mesecPregled != null && kriterijum != null)
                    {
                        mesecPregled.Visibility = Visibility.Visible;
                        mesecPregled.SelectedIndex = 0;
                        kriterijum.Clear();
                        kriterijum.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    if (mesecPregled != null && kriterijum != null)
                    {
                        mesecPregled.Visibility = Visibility.Hidden;
                        mesecPregled.SelectedIndex = 0;
                        kriterijum.Clear();
                        kriterijum.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}
