using Common_Library.Controllers;
using Common_Library.Models.Servidor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class LeaderBoard : Page
    {
        public LeaderBoard()
        {
            this.InitializeComponent();
            Server server = new Server();
            string status = "";
            Top lb = server.GetLeaderBoard(ref status);
            textBlock1.Text = status;
            if (lb != null)
            {
                List<Jogador> joiner = new List<Jogador>();
                lb.Nivel.Where(nivel => nivel.Dificuldade == "Medio").ToList().ForEach(nivel => joiner.AddRange(nivel.Jogador));
                lb.Nivel.Where(nivel => nivel.Dificuldade == "Facil").ToList().ForEach(nivel => joiner.AddRange(nivel.Jogador));
                joiner.ForEach(jogador =>
                {
                    DateTime tempojogo = DateTime.Parse(jogador.Quando);
                    jogador.Quando = tempojogo.ToString("dd/MM/yyyy HH:mm");
                });
                leaderboard.ItemsSource = joiner;
            }
            else
            {
                var messbox = new MessageDialog("Não foi possivel conectar ao servidor\nPor favor tente mais tarde", "Erro de ligação ao servidor");
                messbox.Commands.Add(new UICommand("Menu", (comm) => { //equivalente a uma funçao
                    MainPage Menu = new MainPage();
                    try
                    {
                        this.Frame.Navigate(typeof(MainPage));
                    }
                    catch { }
                }));
                messbox.CancelCommandIndex = 0;
                messbox.DefaultCommandIndex = 0;
                messbox.ShowAsync(); //nao espera ate ser concluida
            }
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void buttonMenu_Click_1(object sender, RoutedEventArgs e)
        {
            MainPage Menu = new MainPage();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            MainPage Menu = new MainPage();
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
