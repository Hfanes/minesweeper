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
    public sealed partial class MSMedio : Page
    {
        public TabuleiroLogic meuTabuleiro;
        public Button[,] btnGrid;
        public DateTime TempoInicial;
        public int flagcounter = 0;
        public MSMedio()
        {
            this.InitializeComponent();
            App.mc.Inicialize(this, Common_Library.Models.TipoDeJogo.Medio);
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
            textBoxFlagsCount.Text = "40";
            MainGrid.Visibility = Visibility.Visible;
            DispatcherTimer tempo = new DispatcherTimer();
            tempo.Interval = TimeSpan.FromSeconds(1);
            tempo.Tick += Tempo_Tick1;
            tempo.Start();
        }

        private void Tempo_Tick1(object sender, object e)
        {
            if (!meuTabuleiro.Jogo.lost && !meuTabuleiro.Jogo.won)
            {
                textBlockTempoCountMedio.Text = (DateTime.Now - TempoInicial).ToString(@"mm\:ss");
            }
            else
            {
                textBlockTempoCountMedio.Text = "";
            }
        }

        private void buttonDifFacil_Click(object sender, RoutedEventArgs e)
        {
            MSFácil facil = new MSFácil();
            this.Frame.Navigate(typeof(MSFácil));
        }
    }
}
