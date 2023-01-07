using Common_Class_Library.Implementations;
using IPC_Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_UI.Moduli
{
    public partial class UpisNovePotrosnje : Page
    {

        public UpisNovePotrosnje()
        {
            InitializeComponent();
        }

        private void upisPotrosnjebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Send data to Writer Component
                InteractionNode INode = new InteractionNode();

                // collect data from UI form
                ModelData data = GetDataFromForm();

                // send data to writer component
                if (data != null)
                    INode.WriterINode.DataPassThrough(data);
                else
                    return;

                // clear some fields
                brojiloId.Clear();
                potrosenoKw.Clear();
                mesecPotrosnje.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Interaction IPC Service Node Inactive!\n\n" + ex.Message, "Neaktivna komponenta", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private ModelData GetDataFromForm()
        {
            try
            {
                int uid = Int32.Parse(userId.Text);
                string username = userName.Text;
                string useraddr = userAddress.Text;
                string usercity = userCity.Text;
                string bid = brojiloId.Text;
                decimal potroseno = Decimal.Parse(potrosenoKw.Text);
                string mesec = mesecPotrosnje.Text;

                return new ModelData(uid, username, useraddr, usercity, bid, potroseno, mesec);
            }
            catch (Exception)
            {
                MessageBox.Show("Uneti podaci nisu validni!\nPopunite formu ponovo!", "Greška prilikom prikupljanja podataka", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
            }
        }
    }
}
