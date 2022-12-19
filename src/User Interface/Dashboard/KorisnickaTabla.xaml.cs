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
    }
}
