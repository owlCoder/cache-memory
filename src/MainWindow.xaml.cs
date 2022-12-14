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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using System.Diagnostics;
using MahApps.Metro.Controls.Dialogs;
using Database;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Tema aplikacije bazirana na trenutnoj Windows Temi
            ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithAppMode;
            ThemeManager.Current.SyncTheme();

            // konekcija sa bazom
            Database.Konekcija.CreateConnection konekcija = new Database.Konekcija.CreateConnection(@"evidention.db");
            
        }
        private void learnMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            // Prikaz poruke o programu
            this.ShowMessageAsync("Cache Memory", "Cache Memory je projekat iz predmeta Elementi Razvoja Softvera" +  
                                  " koji se sluša u V semestru na Fakultetu tehničkih nauka u Novom Sadu.\n\n" +
                                  "Aplikacija prikuplja podatke od korisnika o trenutnoj potrošnji toplotne energije ili o potrošnji" + 
                                  " u nekom od prethodnih perioda.\n\n" +
                                  "Moguća je pretraga podataka po određenim kriterijumima, unos podataka, filtriranje podataka.");
        }
        private void Git_Click(object sender, RoutedEventArgs e)
        {
            // Otvaranje projekta na GitHub-u u podrazumevanom pretraživaču
            Process.Start("https://www.github.com/owlCoder/cache-memory");
        }
    }
}
