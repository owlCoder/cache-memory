using System;
using System.Windows;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void upisNovePotrosnjeBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("/Moduli/UpisNovePotrosnje.xaml", UriKind.Relative));
        }

        private void statistikaBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("/Moduli/Statistika.xaml", UriKind.Relative));
        }
    }
}
