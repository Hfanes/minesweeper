using Common_Library.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace minesweeper_uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MSFácil : Page
    {
        public TabuleiroLogic meuTabuleiro;
        public Button[,] btnGrid;
        public DateTime TempoInicial;
        public int flagcounter = 0;
        public MSFácil()
        {
            this.InitializeComponent();
            App.mc.Inicialize(this, Common_Library.Models.TipoDeJogo.Facil);
        }

        private void buttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainPage Menu = new MainPage();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            TempoInicial = DateTime.Now;
            flagcounter = 0;
            textBoxFlagsCount.Text = "10";
            MainGrid.Visibility = Visibility.Visible;
            DispatcherTimer tempo = new DispatcherTimer();
            tempo.Interval = TimeSpan.FromSeconds(1);
            tempo.Tick += Tempo_Tick;
            tempo.Start();

        }

        private void Tempo_Tick(object sender, object e)
        {
            if (!meuTabuleiro.Jogo.lost && !meuTabuleiro.Jogo.won)
            {
                textBlockTempoCountFacil.Text = (DateTime.Now - TempoInicial).ToString(@"mm\:ss");
            }
            else
            {
                textBlockTempoCountFacil.Text = "";
            }
        }

        private void buttonDifMedio_Click(object sender, RoutedEventArgs e)
        {
            MSMedio medio = new MSMedio();
            this.Frame.Navigate(typeof(MSMedio));
        }

        private void buttonNovoJogo_Click(object sender, RoutedEventArgs e)
        {
            App.mc.BTNovoJogo_Click(sender, null);
        }
    }
}
