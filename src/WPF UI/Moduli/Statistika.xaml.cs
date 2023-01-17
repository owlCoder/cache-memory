using IPC_Services;
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
            try
            {
                // Connection to interaction node
                InteractionNode INode = new InteractionNode();

                string[] data = new string[2];

                // read all data all read by criteria
                bool allData;

                if (kriterijumPretrage.SelectedIndex == 4)
                {
                    allData = true;
                    data[0] = "username";
                    data[1] = "username";
                }
                else
                {
                    allData = false;

                    // collect data from UI form
                    data = GetDataFromForm();
                }

                dataViewDb.ItemsSource = INode.ReaderINode.GetPodaciFromHistorical(
                    data[0],
                    data[1],
                    "",
                    allData
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Interaction IPC Service Node Inactive!\n\n" + ex.Message,
                    "Neaktivna komponenta",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private string[] GetDataFromForm()
        {
            try
            {
                string[] data = new string[2];

                if (kriterijumPretrage.SelectedIndex == 0)
                {
                    data[0] = "userId";

                    if (unosId.Text.Trim().Equals(""))
                    {
                        throw new ArgumentException();
                    }

                    data[1] = unosId.Text;
                }
                else if (kriterijumPretrage.SelectedIndex == 1)
                {
                    data[0] = "username";

                    if (unosId.Text.Trim().Equals(""))
                    {
                        throw new ArgumentException();
                    }

                    data[1] = unosId.Text;
                }
                else if (kriterijumPretrage.SelectedIndex == 2)
                {
                    data[0] = "userCity";

                    if (unosId.Text.Trim().Equals(""))
                    {
                        throw new ArgumentException();
                    }

                    data[1] = unosId.Text;
                }
                else if (kriterijumPretrage.SelectedIndex == 3)
                {
                    data[0] = "PotrosnjaMesec";
                    data[1] = mesecPotrosnje.Text;
                }
                else
                {
                    data[0] = data[1] = "username";
                }

                return data;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Uneli ste prazan ili pogrešan kriterujum pretrage!\n\n",
                    "Pogrešan kriterijum pretrage",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                string[] data = new string[2];
                data[0] = data[1] = "username";

                return data;
            }
        }

        private void kriterijumPretrage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (meniMesec != null)
                meniMesec.IsEnabled = false;

            if (kriterijumPretrage.SelectedIndex == 0)
            {
                if (unosId != null)
                {
                    unosId.Clear();
                    unosId.IsEnabled = true;
                }
                if (labela != null)
                    labela.Text = "User ID:          ";
            }
            else if (kriterijumPretrage.SelectedIndex == 1)
            {
                if (unosId != null)
                {
                    unosId.Clear();
                    unosId.IsEnabled = true;
                }

                if (labela != null)
                    labela.Text = "User Name:   ";
            }
            else if (kriterijumPretrage.SelectedIndex == 2)
            {
                if (unosId != null)
                {
                    unosId.Clear();
                    unosId.IsEnabled = true;
                }

                if (labela != null)
                    labela.Text = "Grad:             ";
            }
            else if (kriterijumPretrage.SelectedIndex == 3)
            {
                if (unosId != null)
                {
                    unosId.Clear();
                    unosId.IsEnabled = false;
                }
                if (labela != null)
                    labela.Text = "Mesec:            ";

                meniMesec.IsEnabled = true;
            }
            else if (kriterijumPretrage.SelectedIndex == 4)
            {
                if (unosId != null)
                {
                    unosId.Clear();
                    unosId.IsEnabled = false;
                }
            }
        }
    }
}
