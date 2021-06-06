using Common_Library.Controllers;
using Common_Library.Models.Servidor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper_lab.Views
{
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
            Server server = new Server();
            string status = "";
            Top lb = server.GetLeaderBoard(ref status);
            EstadoLabel.Text = status;
            if (lb != null)
            {
                List<Jogador> joiner = new List<Jogador>();//joiner juntar facil e medio
                lb.Nivel.Where(nivel => nivel.Dificuldade == "Medio").ToList().ForEach(nivel => joiner.AddRange(nivel.Jogador));
                lb.Nivel.Where(nivel => nivel.Dificuldade == "Facil").ToList().ForEach(nivel => joiner.AddRange(nivel.Jogador));
                joiner.ForEach(jogador =>
                {
                    DateTime tempojogo = DateTime.Parse(jogador.Quando);
                    jogador.Quando = tempojogo.ToString("dd/MM/yyyy HH:mm");
                });
                DGV.DataSource = joiner;
            }
            else
            {
                MessageBox.Show("Não foi possivel ligar ao servidor\nPorfavor tente novamente mais tarde", "Problema de Rede", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                Menu m = new Menu();
                m.ShowDialog();
                this.Close();
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.ShowDialog();
            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.ShowDialog();
            this.Close();
        }
    }
}
