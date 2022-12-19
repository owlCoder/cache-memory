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
using System.Windows.Shapes;
using Cache_Memory.Handlers;

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
                InteractiveLoginSaveHandler.SetAuthState(usernameReg.Text);
                upozorenjeLabelaReg.Text = "Registracija na sistem uspešna";
                upozorenjeLabelaReg.Foreground = Brushes.Green;
            }
            else
            {
                upozorenjeLabelaReg.Text = "Proverite unete podatke";
                upozorenjeLabelaReg.Foreground = Brushes.Crimson;
            }
        }
    }
}
