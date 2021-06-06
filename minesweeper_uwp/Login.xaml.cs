using Common_Library.Controllers;
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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void buttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainPage menu = new MainPage();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            Server servidor = new Server();
            try
            {
                App.mc.UID = servidor.login(textBoxUsername.Text, textBoxPassword.Password);
                if (string.IsNullOrEmpty(App.mc.UID))
                {
                    var messbox = new MessageDialog("Username ou password errada", "Erro de login");
                    messbox.Commands.Add(new UICommand("Ok", (comm) => {

                    }));
                    messbox.CancelCommandIndex = 0;
                    messbox.DefaultCommandIndex = 0;
                    messbox.ShowAsync();
                }
                else
                {
                    App.mc.Online = true;
                    App.mc.Username = textBoxUsername.Text;
                    MainPage Menu = new MainPage();
                    this.Frame.Navigate(typeof(MainPage));
                }
            }
            catch (Exception)
            {
                var messbox = new MessageDialog("Não foi possivel conectar ao servidor\nPor favor tente mais tarde", "Erro de ligação ao servidor");
                messbox.Commands.Add(new UICommand("Menu", (comm) => {
                    MainPage Menu = new MainPage();
                    this.Frame.Navigate(typeof(MainPage));
                }));
                messbox.CancelCommandIndex = 0;
                messbox.DefaultCommandIndex = 0;
                messbox.ShowAsync();
            }
        }
    }
}
