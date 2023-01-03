using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_UI.Moduli
{
    /// <summary>
    /// Interaction logic for Statistika.xaml
    /// </summary>
    public partial class Statistika : Page
    {
        public Statistika()
        {
            InitializeComponent();
        }

        private void prikazPodataka_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void kriterijumPretrage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kriterijumPretrage.SelectedIndex == 0)
            {
                if (unosId != null) { unosId.Clear(); unosId.IsEnabled = true; }
                if (mesecPotrosnje != null) mesecPotrosnje.IsEnabled = false; // sakrivanje cb za mesec
                if (labela != null) labela.Text = "User ID:          ";
            }
            else if (kriterijumPretrage.SelectedIndex == 1)
            {
                if (unosId != null) { unosId.Clear(); unosId.IsEnabled = true; }
                if (mesecPotrosnje != null)
                    mesecPotrosnje.IsEnabled = false; // sakrivanje cb za mesec
                if (labela != null)
                    labela.Text = "User Name:   ";
            }
            else if (kriterijumPretrage.SelectedIndex == 2)
            {
                if (unosId != null) { unosId.Clear(); unosId.IsEnabled = true; }
                if (mesecPotrosnje != null)
                    mesecPotrosnje.IsEnabled = false; // sakrivanje cb za mesec
                if (labela != null)
                    labela.Text = "Grad:             ";
            }
            else if (kriterijumPretrage.SelectedIndex == 3)
            {
                if (unosId != null) { unosId.Clear(); unosId.IsEnabled = false; }
                if (mesecPotrosnje != null)
                    mesecPotrosnje.IsEnabled = true; // sakrivanje cb za mesec
                if (labela != null)
                    labela.Text = "Mesec:            ";
            }
        }
    }
}
