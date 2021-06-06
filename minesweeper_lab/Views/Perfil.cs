using Common_Library.Controllers;
using Common_Library.Models.GameModels;
using Common_Library.Models.Servidor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace minesweeper_lab.Views
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();

        }

        private void top1ToolStripMenuItem_Click(object sender, EventArgs e)
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
            label6.Text = "Jogador Fácil:";
            label7.Text = "Jogador Médio:";
            label5.Text = "Tempo Fácil:";
            label8.Text = "Tempo Médio:";
            label3.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = topplayer.NomeFacil;
            label13.Text = topplayer.NomeMedio;
            if(topplayer.TopFacil != -1)
            {
                label14.Text = TimeSpan.FromSeconds(double.Parse(topplayer.TopFacil.ToString())).ToString(@"mm\:ss");
            }
            else
            {
                label14.Text = "";
            }
            if(topplayer.TopMedio != -1)
            {
                label15.Text = TimeSpan.FromSeconds(double.Parse(topplayer.TopMedio.ToString())).ToString(@"mm\:ss");
            }
            else
            {
                label15.Text = "";
            }
        }

        private void BTPesquisar_Click(object sender, EventArgs e)
        {
            label3.Text = "Username:";
            label2.Text = "Email:";
            label4.Text = "Pais:";
            label6.Text = "Jogos Ganhos:";
            label7.Text = "Jogos Perdidos:";
            label5.Text = "Melhor Tempo Fácil:";
            label8.Text = "Melhor Tempo Médio:";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label3.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            string username = textBox1.Text;
            Server server = new Server();
            Profile profile = server.getPerfil(username);
            if(profile != null)//se encontrou ao perfil
            {
                label9.Text = profile.Nomeabreviado;
                label10.Text = profile.Email;
                label11.Text = profile.Pais;
                label12.Text = profile.Jogos.Ganhos;
                label13.Text = profile.Jogos.Perdidos;
                if (profile.Tempos != null)//se tem tempo
                {
                    label14.Text = profile.Tempos.Facil;
                    label15.Text = profile.Tempos.Medio;
                }
                else
                {
                    label14.Text = "";
                    label15.Text = "";
                }
                try
                {
                    profile.Fotografia = profile.Fotografia.Replace("data:image/jpeg;base64,","");
                    using (var ms = new MemoryStream(Convert.FromBase64String(profile.Fotografia)))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch(Exception)
                {
                }  
            }
            else
            {
                MessageBox.Show("Não existe ligação a internet, não foi possivel ligar ao servidor ou o utilizador não existe", "Problema de Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
