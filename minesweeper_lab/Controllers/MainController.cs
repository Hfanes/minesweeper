using Common_Library.Controllers;
using Common_Library.Models;
using Common_Library.Models.GameModels;
using minesweeper_lab.Models;
using minesweeper_lab.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace minesweeper_lab.Controllers
{
    public class MainController
    {
        private GameForm form;
        public TipoDeJogo TJ;
        public bool Online;
        public string Username;
        public string UID;
        public void Inicialize(GameForm form, TipoDeJogo TJ)
        {
            if(TJ == TipoDeJogo.Facil)
            {
                form.meuTabuleiro = new TabuleiroLogic(9, 9, TJ);
            }
            else
            
            {
                form.meuTabuleiro = new TabuleiroLogic(16, 16, TJ);
            }
            form.meuTabuleiro.UID = Program.mc.UID;
            this.TJ = TJ;
            this.form = form;
            form.TemporizadorRefreshLabel = new Timer();
            form.TemporizadorRefreshLabel.Interval = 500;
            form.TemporizadorRefreshLabel.Tick += TemporizadorRefreshLabel_Tick;
            preencherGrid();
        }
        private void TemporizadorRefreshLabel_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - form.TempoInicial;//diferenca entre tempo atual e o inicial
            if(TJ== TipoDeJogo.Facil)
            {
                ((MSFacil)form).labelTempo.Text = diff.ToString(@"mm\:ss");
            }
            else
            {
                ((Medio)form).LBTMedio.Text = diff.ToString(@"mm\:ss");
            }
        }
        public void preencherGrid()
        {
            int buttonSize;
            if(this.TJ == TipoDeJogo.Facil)
            {
                buttonSize = ((MSFacil)form).panelFacil.Width / 9;
                ((MSFacil)form).panelFacil.Enabled = false;
            }
            else
            {
                buttonSize = ((Medio)form).panelMedio.Width / 16;
                ((Medio)form).panelMedio.Enabled = false;
            }
            form.btnGrid = new Button[form.meuTabuleiro.Jogo.tamanhoTabuleiro.x, form.meuTabuleiro.Jogo.tamanhoTabuleiro.y];
            for (int i = 0; i < form.meuTabuleiro.Jogo.tamanhoTabuleiro.x; i++)
            {
                for (int j = 0; j < form.meuTabuleiro.Jogo.tamanhoTabuleiro.y; j++)
                {
                    form.btnGrid[i, j] = new Button();
                    form.btnGrid[i, j].Height = buttonSize;
                    form.btnGrid[i, j].Width = buttonSize;
                    form.btnGrid[i, j].Font = new Font(form.btnGrid[i, j].Font.FontFamily, 12);
                    form.btnGrid[i, j].MouseUp += Form_MouseUp;
                    if(TJ == TipoDeJogo.Facil)
                    {
                        ((MSFacil)form).panelFacil.Controls.Add(form.btnGrid[i, j]);
                    }
                    else
                    {
                        ((Medio)form).panelMedio.Controls.Add(form.btnGrid[i, j]);
                    }
                    form.btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    form.btnGrid[i, j].Text = "";
                    form.btnGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            Button botaoClicado = (Button)sender;
            Point location = (Point)botaoClicado.Tag;
            int x = location.X;
            int y = location.Y;

            bool isFinished = false;

            if (e.Button == MouseButtons.Left)
            {
                isFinished = form.meuTabuleiro.revelarCelula(x, y);
            }
            else
            {
                if (form.meuTabuleiro.isFlag(x, y))//tirar flag (((vem um true))
                {
                    bool proceed = form.meuTabuleiro.colocarFlag(x, y); //proceed é sempre true a menos que nao seja possivel mexer no bloco
                    if (proceed)
                    {
                        form.flagcounter--;
                        if (TJ == TipoDeJogo.Facil)
                        {
                            ((MSFacil)form).labelFlags.Text = (10 - form.flagcounter).ToString();
                        }
                        else
                        {
                            ((Medio)form).labelFlagsMedio.Text = (40 - form.flagcounter).ToString();
                        }
                    }
                }
                else if (form.flagcounter != 10 )//colocar flag se ainda nao houverem 10 flags no tabuleiro
                {
                    bool proceed = form.meuTabuleiro.colocarFlag(x, y);
                    if (proceed)
                    {
                        form.flagcounter++;
                        if (TJ == TipoDeJogo.Facil)
                        {
                            ((MSFacil)form).labelFlags.Text = (10 - form.flagcounter).ToString();
                        }
                        else
                        {
                            ((Medio)form).labelFlagsMedio.Text = (40 - form.flagcounter).ToString();
                        }
                    }
                }
            }

            if (!form.meuTabuleiro.Jogo.lost)//se ainda nao perdeu o jogo
            {
                foreach (Painel painel in form.meuTabuleiro.Jogo.Grid)
                {
                    if (painel.isClicked)
                    {
                        form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImageLayout = ImageLayout.Stretch;
                        switch (painel.numVizinhosBomba)
                        {
                            case 0:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = null;
                                form.btnGrid[painel.pos.x, painel.pos.y].Text = "";
                                form.btnGrid[painel.pos.x, painel.pos.y].BackColor = Color.Gray;
                                break;
                            case 1:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open1;
                                break;
                            case 2:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open2;
                                break;
                            case 3:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open3;
                                break;
                            case 4:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open4;
                                break;
                            case 5:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open5;
                                break;
                            case 6:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open6;
                                break;
                            case 7:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open7;
                                break;
                            case 8:
                                form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.open8;
                                break;
                        }
                    }
                    else if (painel.hasFlag)
                    {
                        form.btnGrid[painel.pos.x, painel.pos.y].Text = "";
                        form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImageLayout = ImageLayout.Stretch;
                        form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.flag;
                    }
                    else
                    {
                        form.btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = null;
                    }
                }
            }
            else//se perdeu
            {
                form.TemporizadorRefreshLabel.Stop();
                TimeSpan TotalTime = DateTime.Now - form.TempoInicial;//tempo duraçao do jogo
                foreach (Painel mina in form.meuTabuleiro.Jogo.Grid.Where(painel => painel.hasMina))//revelar as minas
                {
                    form.btnGrid[mina.pos.x, mina.pos.y].Text = "";
                    form.btnGrid[mina.pos.x, mina.pos.y].BackgroundImageLayout = ImageLayout.Stretch;
                    form.btnGrid[mina.pos.x, mina.pos.y].BackgroundImage = Properties.Resources.mina;
                }
                if (Online)
                {
                    Server server = new Server();
                    try
                    {
                        server.registoJogo(TJ, TotalTime, false, UID);
                    }
                    catch (Exception ex)
                    {
                        Online = false;
                        UID = string.Empty;
                        Username = string.Empty;
                    }
                }
                var result = MessageBox.Show("Perdeste! Tempo: " + TotalTime.ToString(@"mm\:ss") + "\nPretende reiniciar ou voltar ao menu?", "Aviso", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                {
                    form.Hide();
                    Menu menu2 = new Menu();
                    menu2.ShowDialog();
                    form.Close();
                }
                else
                {
                    BTNovoJogo_Click(null, null);
                }
            }
            if (isFinished)//se ganhou
            {
                form.TemporizadorRefreshLabel.Stop();
                TimeSpan TotalTime = DateTime.Now - form.TempoInicial;
                int totalSegundo = TotalTime.Seconds;
                if (Online)
                {
                    Server server = new Server();
                    try
                    {
                        server.registoJogo(TJ, TotalTime, true, UID);
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
                    UserRequest UR = new UserRequest(TotalTime.ToString(@"mm\:ss"));
                    UR.MenuBTN.Click += (s, evnt) =>
                    {
                        SaveResult(UR.UserName.Text, totalSegundo);
                        UR.Close();
                        form.Hide();
                        Menu menu2 = new Menu();
                        menu2.ShowDialog();
                        form.Close();
                    };
                    UR.ReplayBTN.Click += (s, evnt) =>
                    {
                        SaveResult(UR.UserName.Text, totalSegundo);
                        UR.Close();
                        BTNovoJogo_Click(s, evnt);
                    };
                    UR.ShowDialog();
                }
                else//online
                {
                    UserRequest UR = new UserRequest(TotalTime.ToString(@"mm\:ss"));
                    UR.UserName.Enabled = false;
                    UR.UserName.Text = Username;
                    UR.MenuBTN.Click += (s, evnt) =>
                    {
                        SaveResult(Username, totalSegundo);
                        UR.Close();
                        form.Hide();
                        Menu menu2 = new Menu();
                        menu2.ShowDialog();
                        form.Close();
                    };
                    UR.ReplayBTN.Click += (s, evnt) =>
                    {
                        SaveResult(Username, totalSegundo);
                        UR.Close();
                        BTNovoJogo_Click(s, evnt);
                    };
                    UR.ShowDialog();
                }
            }
        }

        private void SaveResult(string usrname, int totalSegundo)//top offline
        {
            Top topplayer;
            bool toserialize = false;//so edita se for menor o valor ja guardado
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Scores.xml")))
            {
                StreamReader SR = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Scores.xml"));
                string xml = SR.ReadToEnd();
                SR.Close();
                XmlSerializer serializer = new XmlSerializer(typeof(Top));
                using (TextReader reader = new StringReader(xml))
                {
                    topplayer = (Top)serializer.Deserialize(reader);//vai passar de xml para objeto
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
            else//ficheiro nao existe
            {
                topplayer = new Top();
                if (TJ == TipoDeJogo.Facil)
                {
                    topplayer.TopFacil = totalSegundo;
                    topplayer.NomeFacil = usrname;
                    topplayer.TopMedio = -1;//sem score
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
                    var serializer = new XmlSerializer(topplayer.GetType());//=typeof(Top) gettype pede o tipo de topplayer que é Top
                    serializer.Serialize(writer, topplayer);//passas de objeto para xml
                    writer.Flush();//escrever os dados que estao no buffer
                }
            }
        }

        public void BTNovoJogo_Click(object sender, EventArgs e)
        {
            
            if (TJ == TipoDeJogo.Facil)
            {
                form.meuTabuleiro = new TabuleiroLogic(9, 9, TipoDeJogo.Facil);
                form.TempoInicial = DateTime.Now;
                ((MSFacil)form).panelFacil.Controls.Clear();
                preencherGrid();
                ((MSFacil)form).panelFacil.Enabled = true;
                ((MSFacil)form).flagcounter = 0;
                ((MSFacil)form).labelFlags.Text = "10";
            }
            else
            {
                form.meuTabuleiro = new TabuleiroLogic(16, 16, TipoDeJogo.Facil);
                form.TempoInicial = DateTime.Now;
                ((Medio)form).panelMedio.Controls.Clear();
                preencherGrid();
                ((Medio)form).panelMedio.Enabled = true;
                ((Medio)form).flagcounter = 0;
                ((Medio)form).labelFlagsMedio.Text = "40";
            }
            if (!form.TemporizadorRefreshLabel.Enabled)
            {
                form.TemporizadorRefreshLabel.Start();
            }
        }
    }
}
