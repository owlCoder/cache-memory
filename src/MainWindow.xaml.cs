using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

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

        private void ShowMessage(string title, string msg)
        {
            this.ShowMessageAsync(title, msg);
        }

        private async void ShowLoginDialog(object sender, RoutedEventArgs e)
        {
            if (Database.Servisi.UserLogin.Korisnik != null)
            {
                ShowMessage("Informacija", "Već ste prijavljeni na sistem.\n\nMožete kreirati novi zapis ili pogledati postojeće zapise.");
            }
            else
            {
                // korisnik nije ulogovan, pokusavamo ga ulogovati
                //MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

                LoginDialogData result = await this.ShowLoginAsync("Prijava na sistem", "Unesite podatke za prijavu", new LoginDialogSettings { ColorScheme = MetroDialogOptions.ColorScheme, AffirmativeButtonText = " PRIJAVITE SE ", DialogButtonFontSize = 16 });

                if (result == null)
                {
                    ShowMessage("Prijava na sistem neuspešna", "Odustali ste od prijave na sistem.");
                }
                else
                {
                    string username = result.Username;
                    string password = result.Password;

                    Database.Servisi.UserLogin prijava = new Database.Servisi.UserLogin();
                    bool prijavaUspesna = prijava.LogIn(username, password);

                    if (prijavaUspesna) // prijava uspesna
                    {
                        ShowMessage("Prijava na sistem uspešna", "Možete unositi nove zapise i pregledati postojeće.");
                    }
                    else
                    {
                        ShowMessage("Prijava na sistem neuspešna", "Uneti podaci nisu validni ili korisnik ne postoji.");
                        throw new ArgumentException();
                    }
                }
            }
        }

        private async void registracijaTile_Click(object sender, RoutedEventArgs e)
        {
            if (Database.Servisi.UserLogin.Korisnik != null)
            {
                ShowMessage("Već ste prijavljeni na sistem", "Registracija je dostupna samo za nove korisnike.");
            }
            else
            {
                // registracija korisnika
                LoginDialogData result = await this.ShowLoginAsync("Registracija na sistem", "Unesite korisničko ime i lozinku", new LoginDialogSettings { ColorScheme = MetroDialogOptions.ColorScheme, AffirmativeButtonText = " Sledeći korak ", DialogButtonFontSize = 16 });

                if (result == null)
                {
                    ShowMessage("Registracija na sistem neuspešna", "Odustali ste od registracije na sistem.");
                    throw new ArgumentNullException();
                }
                else
                {
                    string username = result.Username;
                    string password = result.Password;

                    if (username == null || password == null)
                    {
                        ShowMessage("Registracija na sistem neuspešna", "Uneli ste nevalidne podatke.");
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        if (username.Trim().Equals(string.Empty) || password.Trim().Equals(string.Empty))
                        {
                            ShowMessage("Registracija na sistem neuspešna", "Uneli ste nevalidne podatke.");
                            throw new ArgumentException();
                        }
                        else
                        {
                            // username i password su korektni, mozemo nastaviti dalji unos podataka
                            var adresa = await this.ShowInputAsync("Registracija na sistem", "Unesite vašu adresu", new LoginDialogSettings { ColorScheme = MetroDialogOptions.ColorScheme, AffirmativeButtonText = " Sledeći korak ", DialogButtonFontSize = 16 });

                            if (adresa == null)
                            {
                                ShowMessage("Registracija na sistem neuspešna", "Odustali ste od registracije na sistem.");
                            }
                            else
                            {
                                // provera da li je uneta adresa prazna ili null
                                if (adresa.Trim().Equals(string.Empty))
                                {
                                    ShowMessage("Registracija na sistem neuspešna", "Uneli ste praznu adresu.");
                                    throw new ArgumentException();
                                }
                                else
                                {
                                    // registracija uspesna
                                    // sacuvane podatke proslediti konstruktoru za registraciju
                                    // i upisati u bazu podataka novu torku podataka
                                    Database.Servisi.UserRegister registracija = new Database.Servisi.UserRegister();
                                    bool registracijaUspesna = registracija.Register(username, password, adresa);

                                    Trace.WriteLine(username + " " + password + " " + adresa);

                                    if (registracijaUspesna) // registracija uspesna
                                    {
                                        ShowMessage("Registracija na sistem uspešna", "Možete unositi nove zapise i pregledati postojeće.");
                                    }
                                    else
                                    {
                                        ShowMessage("Registracija na sistem neuspešna", "Uneti podaci nisu validni ili korisnik ne postoji.");
                                        throw new ArgumentException();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
