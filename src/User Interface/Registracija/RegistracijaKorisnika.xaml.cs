using Cache_Memory.Handlers;
using System.Windows;
using System.Windows.Media;

namespace User_Interface.Registracija
{
    /// <summary>
    /// Interaction logic for RegistracijaKorisnika.xaml
    /// </summary>
    public partial class RegistracijaKorisnika : Window
    {
        private static readonly RegistracijaNaSistemHandler rgh = new RegistracijaNaSistemHandler();
        public RegistracijaKorisnika()
        {
            InitializeComponent();
        }

        private void prijavaBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void registracijaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rgh.RegistracijaHandle(usernameReg.Text, passwordReg.Password, adresaReg.Text))
            {
                //InteractiveLoginSaveHandler.SetAuthState(usernameReg.Text);
                MessageBox.Show("Registracija na sistem uspešna!\n\nMožete se sada prijaviti sa novim nalogom kako bi nastavili dalji rad sa programom.", "Registracija na sistem", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                upozorenjeLabelaReg.Text = "Proverite unete podatke";
                upozorenjeLabelaReg.Foreground = Brushes.Crimson;
            }
        }
    }
}
