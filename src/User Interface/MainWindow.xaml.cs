using Cache_Memory.Handlers;
using HandyControl.Themes;
using System.Windows;
using System.Windows.Media;
using User_Interface.Dashboard;

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
                InteractiveLoginSaveHandler.SetAuthState(username.Text);

                // sakrivanje login prozora
                Hide();

                // novi prozor
                KorisnickaTabla dashboard = new KorisnickaTabla();
                dashboard.ShowDialog();

                Close(); // zatvaranje login prozora
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
