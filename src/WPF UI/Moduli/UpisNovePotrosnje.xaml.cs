using Common.Implementations;
using Common.Interfaces;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WPF_UI.Moduli
{
    /// <summary>
    /// Interaction logic for UpisNovePotrosnje.xaml
    /// </summary>
    public partial class UpisNovePotrosnje : Page
    {
        private IWriter slanjeNaBafer = new Writer();
        public UpisNovePotrosnje()
        {
            InitializeComponent();
        }

        private void upisPotrosnjebtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            // slanjeNaBafer.ProsledjivanjePodatakaUBafer(.....);
            //Trace.WriteLine("pritisknuti");//
        }
    }
}
