using Common_Library.Controllers;
using Common_Library.Models.Servidor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace minesweeper_uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Perfil : Page
    {
        public Perfil()
        {
            this.InitializeComponent();
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

        private void buttonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Missing server connection to search
            textBlock2.Text = "Username:";
            textBlock1.Text = "Email:";
            textBlock3.Text = "Pais:";
            textBlock4.Text = "Jogos Ganhos:";
            textBlock5.Text = "Jogos Perdidos:";
            textBlock6.Text = "Melhor Tempo Fácil:";
            textBlock7.Text = "Melhor Tempo Médio:";
            textBlockUsername.Text = "";
            textBlockEmail.Text = "";
            textBlockPais.Text = "";
            textBlockJogosGanhos.Text = "";
            textBlockJogosPerdidos.Text = "";
            textBlockTempoFacil.Text = "";
            textBlockTempoMedio.Text = "";
            textBlock1.Visibility = Visibility.Visible;
            textBlock2.Visibility = Visibility.Visible;
            textBlock3.Visibility = Visibility.Visible;
            string username = textBox.Text;
            Server server = new Server();
            Profile profile = server.getPerfil(username);
            if (profile != null)
            {
                textBlockUsername.Text = profile.Nomeabreviado;
                textBlockEmail.Text = profile.Email;
                textBlockPais.Text = profile.Pais;
                textBlockJogosGanhos.Text = profile.Jogos.Ganhos;
                textBlockJogosPerdidos.Text = profile.Jogos.Perdidos;
                if (profile.Tempos != null)
                {
                    try
                    {
                        textBlockTempoFacil.Text = profile.Tempos.Facil;
                    }
                    catch { }
                    try
                    {
                        textBlockTempoMedio.Text = profile.Tempos.Medio;
                    }
                    catch { }
                }
                else
                {
                    textBlockTempoFacil.Text = "";
                    textBlockTempoMedio.Text = "";
                }
                try
                {
                    profile.Fotografia = profile.Fotografia.Replace("data:image/jpeg;base64,", "");
                    BitmapImage img = new BitmapImage();
                    using (var ms = new MemoryStream(Convert.FromBase64String(profile.Fotografia)))
                    {
                        byte[] imgarr = ms.ToArray();
                        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                        {
                            stream.AsStreamForWrite().Write(imgarr, 0, imgarr.Length);
                            img.SetSource(stream);
                        }
                    }
                    image.Source = img;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                var messbox = new MessageDialog("Não existe ligação a internet, não foi possivel ligar ao servidor ou o utilizador não existe", "Problema de Pesquisa");
                messbox.Commands.Add(new UICommand("Ok", (comm) => {

                }));
                messbox.CancelCommandIndex = 0;
                messbox.DefaultCommandIndex = 0;
                messbox.ShowAsync();
            }
        }

        private void buttonTop1_Click(object sender, RoutedEventArgs e)
        {
            Common_Library.Models.GameModels.Top topplayer;
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Scores.xml")))
            {
                StreamReader SR = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Scores.xml"));
                string xml = SR.ReadToEnd();
                SR.Close();
                XmlSerializer serializer = new XmlSerializer(typeof(Common_Library.Models.GameModels.Top));
                using (TextReader reader = new StringReader(xml))
                {
                    topplayer = (Common_Library.Models.GameModels.Top)serializer.Deserialize(reader);
                }
            }
            else
            {
                topplayer = new Common_Library.Models.GameModels.Top()
                {
                    NomeFacil = "",
                    NomeMedio = "",
                    TopFacil = 0,
                    TopMedio = 0
                };
            }
            textBlock4.Text = "Jogador Fácil:";
            textBlock5.Text = "Jogador Médio:";
            textBlock6.Text = "Tempo Fácil:";
            textBlock7.Text = "Tempo Médio:";
            textBlock1.Visibility = Visibility.Collapsed;
            textBlock2.Visibility = Visibility.Collapsed;
            textBlock3.Visibility = Visibility.Collapsed;
            textBlockUsername.Text = "";
            textBlockEmail.Text = "";
            textBlockPais.Text = "";
            textBlockJogosGanhos.Text = topplayer.NomeFacil;
            textBlockJogosPerdidos.Text = topplayer.NomeMedio;
            if (topplayer.TopFacil != -1)
            {
                textBlockTempoFacil.Text = TimeSpan.FromSeconds(double.Parse(topplayer.TopFacil.ToString())).ToString(@"mm\:ss");
            }
            else
            {
                textBlockTempoFacil.Text = "";
            }
            if (topplayer.TopMedio != -1)
            {
                textBlockTempoMedio.Text = TimeSpan.FromSeconds(double.Parse(topplayer.TopMedio.ToString())).ToString(@"mm\:ss");
            }
            else
            {
                textBlockTempoMedio.Text = "";
            }
        }
    }
}
