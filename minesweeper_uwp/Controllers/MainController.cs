using Common_Library.Controllers;
using Common_Library.Models;
using Common_Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace minesweeper_uwp.Controllers
{
    public class MainController
    {
        private object form;
        public TipoDeJogo TJ;
        public bool Online;
        public string Username;
        public string UID;
        public void Inicialize(object form, TipoDeJogo TJ)
        {
            if (TJ == TipoDeJogo.Facil)
            {
                ((MSFácil)form).meuTabuleiro = new TabuleiroLogic(9, 9, TJ);
            }
            else
            {
                ((MSMedio)form).meuTabuleiro = new TabuleiroLogic(16, 16, TJ);
            }
            this.TJ = TJ;
            this.form = form;
            preencherGrid();
        }
        private void TemporizadorRefreshLabel_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - ((MSFácil)form).TempoInicial;
            if (TJ == TipoDeJogo.Facil)
            {
                ((MSFácil)form).textBlockTempo.Text = diff.ToString(@"mm\:ss");
            }
            else
            {
                ((MSMedio)form).textBlockTempo.Text = diff.ToString(@"mm\:ss");
            }

        }
        public void preencherGrid()
        {
            if (this.TJ == TipoDeJogo.Facil)
            {
                ((MSFácil)form).MainGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ((MSFácil)form).btnGrid = new Button[((MSFácil)form).meuTabuleiro.Jogo.tamanhoTabuleiro.x, ((MSFácil)form).meuTabuleiro.Jogo.tamanhoTabuleiro.y];
                int btncounter = 0;
                for (int i = 0; i < ((MSFácil)form).meuTabuleiro.Jogo.tamanhoTabuleiro.x; i++)
                {
                    for (int j = 0; j < ((MSFácil)form).meuTabuleiro.Jogo.tamanhoTabuleiro.y; j++)
                    {
                        Border border = new Border();
                        if(i != 0)
                        {
                            border.SetValue(Grid.RowProperty, i);
                        }
                        if (j != 0)
                        {
                            border.SetValue(Grid.ColumnProperty, j);
                        }
                        border.BorderThickness = new Thickness(1);
                        border.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 0, 0, 0));
                        ((MSFácil)form).btnGrid[i, j] = new Button();
                        ((MSFácil)form).btnGrid[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;
                        ((MSFácil)form).btnGrid[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                        ((MSFácil)form).btnGrid[i, j].Name = $"Button{btncounter}";
                        ((MSFácil)form).btnGrid[i, j].Content = "";
                        ((MSFácil)form).btnGrid[i, j].FontSize = 12;
                        ((MSFácil)form).btnGrid[i, j].Tapped += Form_MouseUp;
                        ((MSFácil)form).btnGrid[i, j].RightTapped += Form_RightTapped;
                        border.Child = ((MSFácil)form).btnGrid[i, j];
                        ((MSFácil)form).MainGrid.Children.Add(border);
                        btncounter++;
                    }
                }
            }
            else
            {
                ((MSMedio)form).MainGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ((MSMedio)form).btnGrid = new Button[((MSMedio)form).meuTabuleiro.Jogo.tamanhoTabuleiro.x, ((MSMedio)form).meuTabuleiro.Jogo.tamanhoTabuleiro.y];
                int btncounter = 0;
                for (int i = 0; i < ((MSMedio)form).meuTabuleiro.Jogo.tamanhoTabuleiro.x; i++)
                {
                    for (int j = 0; j < ((MSMedio)form).meuTabuleiro.Jogo.tamanhoTabuleiro.y; j++)
                    {
                        Border border = new Border();
                        if (i != 0)
                        {
                            border.SetValue(Grid.RowProperty, i);
                        }
                        if (j != 0)
                        {
                            border.SetValue(Grid.ColumnProperty, j);
                        }
                        border.BorderThickness = new Thickness(1);
                        border.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 0, 0, 0));
                        ((MSMedio)form).btnGrid[i, j] = new Button();
                        ((MSMedio)form).btnGrid[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;
                        ((MSMedio)form).btnGrid[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                        ((MSMedio)form).btnGrid[i, j].Name = $"Button{btncounter}";
                        ((MSMedio)form).btnGrid[i, j].Content = "";
                        ((MSMedio)form).btnGrid[i, j].FontSize = 12;
                        ((MSMedio)form).btnGrid[i, j].Tapped += Form_MouseUp;
                        ((MSMedio)form).btnGrid[i, j].RightTapped += Form_RightTapped;
                        border.Child = ((MSMedio)form).btnGrid[i, j];
                        ((MSMedio)form).MainGrid.Children.Add(border);
                        btncounter++;
                    }
                }
            }

        }

        private void Form_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            Button botaoClicado = (Button)sender;
            int x = (int)botaoClicado.Parent.GetValue(Grid.RowProperty);
            int y = (int)botaoClicado.Parent.GetValue(Grid.ColumnProperty);
            if (TJ == TipoDeJogo.Facil)
            {
                if (((MSFácil)form).meuTabuleiro.isFlag(x, y))
                {
                    bool proceed = ((MSFácil)form).meuTabuleiro.colocarFlag(x, y);
                    if (proceed)
                    {
                        ((MSFácil)form).flagcounter--;
                        ((MSFácil)form).textBoxFlagsCount.Text = (10 - ((MSFácil)form).flagcounter).ToString();
                        ((MSFácil)form).btnGrid[x, y].Content = "";
                    }
                }
                else if (((MSFácil)form).flagcounter != 10)
                {
                    bool proceed = ((MSFácil)form).meuTabuleiro.colocarFlag(x, y);
                    if (proceed)
                    {
                        ((MSFácil)form).flagcounter++;
                        ((MSFácil)form).textBoxFlagsCount.Text = (10 - ((MSFácil)form).flagcounter).ToString();
                        ((MSFácil)form).btnGrid[x, y].Content = "F";
                    }
                }
            }
            else
            {
                if (((MSMedio)form).meuTabuleiro.isFlag(x, y))
                {
                    bool proceed = ((MSMedio)form).meuTabuleiro.colocarFlag(x, y);
                    if (proceed)
                    {
                        ((MSMedio)form).flagcounter--;
                        ((MSMedio)form).textBoxFlagsCount.Text = (10 - ((MSMedio)form).flagcounter).ToString();
                        ((MSMedio)form).btnGrid[x, y].Content = "";
                    }
                }
                else if (((MSMedio)form).flagcounter != 10)
                {
                    bool proceed = ((MSMedio)form).meuTabuleiro.colocarFlag(x, y);
                    if (proceed)
                    {
                        ((MSMedio)form).flagcounter++;
                        ((MSMedio)form).textBoxFlagsCount.Text = (10 - ((MSMedio)form).flagcounter).ToString();
                        ((MSMedio)form).btnGrid[x, y].Content = "F";
                    }
                }
            }
        }

        private void Form_MouseUp(object sender, RoutedEventArgs e)
        {
            TabuleiroLogic TL;
            bool isFinished = false;
            try
            {
                Button botaoClicado = (Button)sender;
                int x = (int)botaoClicado.Parent.GetValue(Grid.RowProperty);
                int y = (int)botaoClicado.Parent.GetValue(Grid.ColumnProperty);
                if (TJ == TipoDeJogo.Facil)
                {
                    isFinished = ((MSFácil)form).meuTabuleiro.revelarCelula(x, y);
                    TL = ((MSFácil)form).meuTabuleiro;
                }
                else
                {
                    isFinished = ((MSMedio)form).meuTabuleiro.revelarCelula(x, y);
                    TL = ((MSFácil)form).meuTabuleiro;
                }
            }
            catch (Exception)
            {
                if (TJ == TipoDeJogo.Facil)
                {
                    TL = ((MSFácil)form).meuTabuleiro;
                }
                else
                {
                    TL = ((MSMedio)form).meuTabuleiro;
                }
            }
            if (!TL.Jogo.lost)
            {
                foreach(Painel painel in TL.Jogo.Grid)
                {
                    if(TJ == TipoDeJogo.Facil)
                    {
                        if (painel.isClicked)
                        {
                            switch (painel.numVizinhosBomba)
                            {
                                case 0:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 1:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "1";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 2:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "2";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 3:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "3";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 4:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "4";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 5:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "5";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 6:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "6";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 7:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "7";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 8:
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "8";
                                    ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                            }
                        }
                        else if (painel.hasFlag)
                        {
                            ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "F";
                        }
                        else
                        {
                            ((MSFácil)form).btnGrid[painel.pos.x, painel.pos.y].Content = "";
                        }
                    }
                    else
                    {
                        if (painel.isClicked)
                        {
                            switch (painel.numVizinhosBomba)
                            {
                                case 0:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 1:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "1";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 2:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "2";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 3:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "3";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 4:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "4";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 5:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "5";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 6:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "6";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 7:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "7";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                                case 8:
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "8";
                                    ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Background = new SolidColorBrush(Windows.UI.Color.FromArgb(1, 100, 100, 100));
                                    break;
                            }
                        }
                        else if (painel.hasFlag)
                        {
                            ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "F";
                        }
                        else
                        {
                            ((MSMedio)form).btnGrid[painel.pos.x, painel.pos.y].Content = "";
                        }
                    }
                }
            }
            else
            {
                //perdeu o jogo
                if(TJ == TipoDeJogo.Facil)
                {
                    TimeSpan TotalTime = DateTime.Now - ((MSFácil)form).TempoInicial;
                    foreach (Painel mina in ((MSFácil)form).meuTabuleiro.Jogo.Grid.Where(painel => painel.hasMina))
                    {
                        ((MSFácil)form).btnGrid[mina.pos.x, mina.pos.y].Content = "*";
                    }
                    var messbox = new MessageDialog("Perdeste! Tempo: " + TotalTime.ToString(@"mm\:ss") + "\nPretende reiniciar ou voltar ao menu?", "Aviso");
                    messbox.Commands.Add(new UICommand("Menu", (comm) => {
                        MainPage Menu = new MainPage();
                        ((MSFácil)form).Frame.Navigate(typeof(MainPage));
                    }));
                    messbox.Commands.Add(new UICommand("Voltar a Jogar", (comm) =>
                    {
                        BTNovoJogo_Click(null, null);
                    }));
                    messbox.DefaultCommandIndex = 1;//enter
                    messbox.CancelCommandIndex = 1;//escape
                    messbox.ShowAsync();
                }
                else
                {
                    TimeSpan TotalTime = DateTime.Now - ((MSMedio)form).TempoInicial;
                    foreach (Painel mina in ((MSMedio)form).meuTabuleiro.Jogo.Grid.Where(painel => painel.hasMina))
                    {
                        ((MSMedio)form).btnGrid[mina.pos.x, mina.pos.y].Content = "*";
                    }
                    var messbox = new MessageDialog("Perdeste! Tempo: " + TotalTime.ToString(@"mm\:ss") + "\nPretende reiniciar ou voltar ao menu?", "Aviso");
                    messbox.Commands.Add(new UICommand("Menu", (comm) => {
                        MainPage Menu = new MainPage();
                        ((MSMedio)form).Frame.Navigate(typeof(MainPage));
                    }));
                    messbox.Commands.Add(new UICommand("Voltar a Jogar", (comm) =>
                    {
                        BTNovoJogo_Click(null, null);
                    }));
                    messbox.DefaultCommandIndex = 1;
                    messbox.CancelCommandIndex = 1;
                    messbox.ShowAsync();
                }
            }
            if (isFinished)
            {
                //ganhou o jogo
                if (TJ == TipoDeJogo.Facil)
                {
                    TimeSpan TotalTime = DateTime.Now - ((MSFácil)form).TempoInicial;
                    if (Online)
                    {
                        Server server = new Server();
                        try
                        {
                            server.registoJogo(TJ, TotalTime, false, UID);
                        }
                        catch (Exception)
                        {
                            Online = false;
                            UID = string.Empty;
                            Username = string.Empty;
                        }
                    }
                    if (!Online)
                    {
                        ((MSFácil)form).UserRequest.Visibility = Visibility.Visible;
                        ((MSFácil)form).button1Menu.Tapped += (sndr, envt) =>
                        {
                            string usrname = ((MSFácil)form).textboxusername.Text;
                            SaveResult(Username, (int)TotalTime.TotalSeconds);
                            MainPage Menu = new MainPage();
                            ((MSFácil)form).Frame.Navigate(typeof(MainPage));
                        };
                        ((MSFácil)form).button1Newgame.Tapped += (sndr, evnt) =>
                        {
                            string usrname = ((MSFácil)form).textboxusername.Text;
                            SaveResult(Username, (int)TotalTime.TotalSeconds);
                            BTNovoJogo_Click(null, null);
                        };
                    }
                    else
                    {
                        SaveResult(Username, (int)TotalTime.TotalSeconds);
                        var messbox = new MessageDialog("Ganhas-te!!! Tempo: " + TotalTime.ToString(@"mm\:ss") + "\nPretende reiniciar ou voltar ao menu?", "Vitoria");
                        messbox.Commands.Add(new UICommand("Menu", (comm) => {
                            MainPage Menu = new MainPage();
                            ((MSFácil)form).Frame.Navigate(typeof(MainPage));
                        }));
                        messbox.Commands.Add(new UICommand("Voltar a Jogar", (comm) =>
                        {
                            BTNovoJogo_Click(null, null);
                        }));
                        messbox.DefaultCommandIndex = 1;
                        messbox.CancelCommandIndex = 1;
                        messbox.ShowAsync();
                    }
                }
                else
                {
                    TimeSpan TotalTime = DateTime.Now - ((MSMedio)form).TempoInicial;
                    if (Online)
                    {
                        Server server = new Server();
                        try
                        {
                            server.registoJogo(TJ, TotalTime, false, UID);
                        }
                        catch (Exception)
                        {
                            Online = false;
                            UID = string.Empty;
                            Username = string.Empty;
                        }
                    }
                    if (!Online)
                    {
                        ((MSMedio)form).UserRequest.Visibility = Visibility.Visible;
                        ((MSMedio)form).button1Menu.Tapped += (sndr, envt) =>
                        {
                            string usrname = ((MSMedio)form).textuserinput.Text;
                            SaveResult(Username, (int)TotalTime.TotalSeconds);
                            MainPage Menu = new MainPage();
                            ((MSMedio)form).Frame.Navigate(typeof(MainPage));
                        };
                        ((MSMedio)form).button1Newgame.Tapped += (sndr, evnt) =>
                        {
                            string usrname = ((MSMedio)form).textuserinput.Text;
                            SaveResult(Username, (int)TotalTime.TotalSeconds);
                            BTNovoJogo_Click(null, null);
                        };
                    }
                    else
                    {
                        SaveResult(Username, (int)TotalTime.TotalSeconds);
                        var messbox = new MessageDialog("Ganhas-te!!! Tempo: " + TotalTime.ToString(@"mm\:ss") + "\nPretende reiniciar ou voltar ao menu?", "Vitoria");
                        messbox.Commands.Add(new UICommand("Menu", (comm) => {
                            MainPage Menu = new MainPage();
                            ((MSMedio)form).Frame.Navigate(typeof(MainPage));
                        }));
                        messbox.Commands.Add(new UICommand("Voltar a Jogar", (comm) =>
                        {
                            BTNovoJogo_Click(null, null);
                        }));
                        messbox.DefaultCommandIndex = 1;
                        messbox.CancelCommandIndex = 1;
                        messbox.ShowAsync();
                    }
                }
            }
        }
        private void SaveResult(string usrname, int totalSegundo)
        {
            Top topplayer;
            bool toserialize = false;
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Scores.xml")))
            {
                StreamReader SR = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Scores.xml"));
                string xml = SR.ReadToEnd();
                SR.Close();
                XmlSerializer serializer = new XmlSerializer(typeof(Top));
                using (TextReader reader = new StringReader(xml))
                {
                    topplayer = (Top)serializer.Deserialize(reader);
                }
                if (TJ == TipoDeJogo.Facil)
                {
                    if (totalSegundo < topplayer.TopFacil || topplayer.TopFacil == -1)
                    {
                        topplayer.TopFacil = totalSegundo;
                        topplayer.NomeFacil = usrname;
                        toserialize = true;
                    }
                }
                else
                {
                    if (totalSegundo < topplayer.TopMedio || topplayer.TopMedio == -1)
                    {
                        topplayer.TopMedio = totalSegundo;
                        topplayer.NomeMedio = usrname;
                        toserialize = true;
                    }
                }
            }
            else
            {
                topplayer = new Top();
                if (TJ == TipoDeJogo.Facil)
                {
                    topplayer.TopFacil = totalSegundo;
                    topplayer.NomeFacil = usrname;
                    topplayer.TopMedio = -1;
                    topplayer.NomeMedio = "";
                    toserialize = true;
                }
                else
                {
                    topplayer.TopFacil = -1;
                    topplayer.NomeFacil = usrname;
                    topplayer.TopMedio = totalSegundo;
                    topplayer.NomeMedio = "";
                    toserialize = true;
                }
            }
            if (toserialize)
            {
                using (var writer = new System.IO.StreamWriter(Path.Combine(Environment.CurrentDirectory, "Scores.xml")))
                {
                    var serializer = new XmlSerializer(topplayer.GetType());
                    serializer.Serialize(writer, topplayer);
                    writer.Flush();
                }
            }
        }
        public void BTNovoJogo_Click(object sender, EventArgs e)
        {

            if (TJ == TipoDeJogo.Facil)
            {
                ((MSFácil)form).meuTabuleiro = new TabuleiroLogic(9, 9, TipoDeJogo.Facil);
                ((MSFácil)form).TempoInicial = DateTime.Now;
                ((MSFácil)form).MainGrid.Children.Clear();
                preencherGrid();
                ((MSFácil)form).MainGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ((MSFácil)form).flagcounter = 0;
                ((MSFácil)form).textBoxFlagsCount.Text = "10";
            }
            else
            {
                ((MSMedio)form).meuTabuleiro = new TabuleiroLogic(16, 16, TipoDeJogo.Facil);
                ((MSMedio)form).TempoInicial = DateTime.Now;
                ((MSMedio)form).MainGrid.Children.Clear();
                preencherGrid();
                ((MSMedio)form).flagcounter = 0;
                ((MSMedio)form).textBoxFlagsCount.Text = "40";
            }
            
        }
    }
}

