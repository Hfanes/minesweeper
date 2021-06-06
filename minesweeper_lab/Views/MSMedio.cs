using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common_Library.Controllers;
using minesweeper_lab.Views;
using Common_Library.Models;
using minesweeper_lab.Models;

namespace minesweeper_lab
{
    public partial class Medio : GameForm
    {
        public Medio()
        {
            InitializeComponent();
            Program.mc.Inicialize(this, TipoDeJogo.Medio);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.ShowDialog();
            this.Close();

        }

        private void BTMJogar_Click(object sender, EventArgs e)
        {
            panelMedio.Enabled = true;
            BTMJogar.Enabled = false;
            TempoInicial = DateTime.Now;
            TemporizadorRefreshLabel.Start();
        }

        private void BTMNovojogo_Click(object sender, EventArgs e)
        {
            Program.mc.BTNovoJogo_Click(sender, e);
        }

        private void BTMSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BTNovoJogo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                ReadyToReveal = true;
            }
            else if (e.Button == MouseButtons.Right && ReadyToReveal)
            {
                foreach (Painel painel in meuTabuleiro.Jogo.Grid.Where(painel => painel.hasMina))
                {
                    btnGrid[painel.pos.x, painel.pos.y].Text = "";
                    btnGrid[painel.pos.x, painel.pos.y].BackgroundImageLayout = ImageLayout.Stretch;
                    btnGrid[painel.pos.x, painel.pos.y].BackgroundImage = Properties.Resources.mina;
                    ReadyToReveal = false;
                }
            }
            else
            {
                ReadyToReveal = false;
            }
        }

        private void dificuladadeMédioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemporizadorRefreshLabel.Stop();
            this.Hide();
            MSFacil m = new MSFacil();
            m.ShowDialog();
            this.Close();

        }
    }
}
