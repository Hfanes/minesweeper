using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.AI.MachineLearning;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace minesweeper_uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            if (!App.mc.Online)
            {
                textBlockStatus.Text = "Offline";
            }
            else
            {
                textBlockStatus.Text = "Login como:" + App.mc.Username;
            }

        }

        private void buttonFacil_Click(object sender, RoutedEventArgs e)
        {
            MSFácil facil = new MSFácil();         
            this.Frame.Navigate(typeof(MSFácil));
        }

        private void buttonMedio_Click(object sender, RoutedEventArgs e)
        {
            MSMedio medio = new MSMedio();
            this.Frame.Navigate(typeof(MSMedio));
        }
        
        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        
        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            Ajuda Menu = new Ajuda();
            this.Frame.Navigate(typeof(Ajuda));
        }

        private void buttonRegistar_Click(object sender, RoutedEventArgs e)
        {
            Registar registar = new Registar();
            this.Frame.Navigate(typeof(Registar));
        }

        private void buttonLeaderBoard_Click(object sender, RoutedEventArgs e)
        {
            LeaderBoard leaderBoard = new LeaderBoard();
            this.Frame.Navigate(typeof(LeaderBoard));
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Frame.Navigate(typeof(Login));
        }

        private void buttonPerfil_Click(object sender, RoutedEventArgs e)
        {
            //Perfil perfil = new Perfil();
            this.Frame.Navigate(typeof(Perfil));
        }
    }
}
