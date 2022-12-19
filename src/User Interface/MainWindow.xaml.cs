using System.Windows;
using System.Windows.Media;
using HandyControl.Themes;
using Cache_Memory.Handlers;
using HandyControl.Data;

namespace User_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly PrijavaNaSistemHandler prijavaNaSistemHandler = new PrijavaNaSistemHandler();
        public MainWindow()
        {
            InitializeComponent();

            // tema GUI
            ThemeManager.Current.AccentColor = Brushes.DarkBlue;
        }

        private void prijavaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (prijavaNaSistemHandler.PrijavaHandle(username.Text, password.Password))
            {
                upozorenjeLabela.Text = "Prijava na sistem uspešna";
                upozorenjeLabela.Foreground = Brushes.Green;
            }
            else
            {
                upozorenjeLabela.Text = "Proverite unete podatke";
                upozorenjeLabela.Foreground = Brushes.Crimson;
            }
        }

        private void registracijaBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
