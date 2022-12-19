using System.Windows;
using System.Windows.Media;
using HandyControl.Themes;
using Cache_Memory.Handlers;
using HandyControl.Data;
using System.Diagnostics;

namespace User_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly PrijavaNaSistemHandler prijavaNaSistemHandler = new PrijavaNaSistemHandler();
        private string trenutniKorisnik;

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
                InteractiveLoginSaveHandler.SetAuthState(username.Text);
                upozorenjeLabela.Text = "Prijava na sistem uspešna";
                upozorenjeLabela.Foreground = Brushes.Green;
                
                //Trace.WriteLine(Cache_Memory.DataTransferObject.TrenutniKorisnik.PrijavljeniKorisnik.TrenutniKorisnik.UserId); 
            }
            else
            {
                upozorenjeLabela.Text = "Proverite unete podatke";
                upozorenjeLabela.Foreground = Brushes.Crimson;
            }
        }

        private void registracijaBtn_Click(object sender, RoutedEventArgs e)
        {
            Registracija.RegistracijaKorisnika win = new Registracija.RegistracijaKorisnika();
            win.ShowDialog();
        }
    }
}
