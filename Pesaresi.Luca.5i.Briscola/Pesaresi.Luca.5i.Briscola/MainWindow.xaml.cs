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
using System.Threading;
using System.Runtime.InteropServices;

namespace Pesaresi.Luca._5i.Briscola
{
    /// <summary>
    /// Logica di interazione per Introduzione.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool MostraConfig = true;
        private void txtGiocatore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Gioca();
        }

        void Gioca()
        {
            bool MostraPunti;
            if (cbPunti.IsChecked == true)
                MostraPunti = true;
            else
                MostraPunti = false;

            if (txtGiocatore.Text.Trim() != "")
            {
                Hide();
                FinestraGioco gioco = new FinestraGioco(txtGiocatore.Text, MostraPunti);
                gioco.Show();
            }
        }

        private void btnGioca_Click(object sender, RoutedEventArgs e)
        {
            Gioca();
        }


        private void FinestraAccesso_Loaded(object sender, RoutedEventArgs e)
        {
            cbPunti.Opacity = 0;
        }
        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            if (MostraConfig == true)
            {
                cbPunti.Opacity = 100;
                MostraConfig = false;
            }
            else
            {
                cbPunti.Opacity = 0;
                MostraConfig = true;
            }

        }

        public void Rigioca()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void FinestraAccesso_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}