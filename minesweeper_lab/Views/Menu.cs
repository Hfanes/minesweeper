using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using minesweeper_lab.Views;


namespace minesweeper_lab
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            if (!Program.mc.Online)
            {
                label3.Text = "Offline";
            }
            else
            {
                label3.Text = "Login como:" + Program.mc.Username;
            }
        }

        private void BTJogar_Click(object sender, EventArgs e)
        {
            if (CBDificuldade.Text == "Fácil")
            {
                this.Hide(); //fechar o form menu
                MSFacil f = new MSFacil();
                f.ShowDialog();
                this.Close();
            }
            if(CBDificuldade.Text == "Médio")
            {
                this.Hide(); //fechar o form menu
                Medio f = new Medio();
                f.ShowDialog();
                this.Close();
            }
        }
    
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ajuda d = new Ajuda();
            d.ShowDialog();
            this.Close();
        }

        private void jogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void criarContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registar registo = new Registar();
            registo.ShowDialog();
            this.Close();
        }

        private void consultarPerfisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Perfil perfil = new Perfil();
            perfil.ShowDialog();
            this.Close();

        }

        private void leaderBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeaderBoard leaderboard = new LeaderBoard();
            try
            {
                leaderboard.ShowDialog();
            }
            catch (Exception) { }
            this.Close();
        }

        private void LoginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
