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
using Common_Library.Models;
using minesweeper_lab.Controllers;
using minesweeper_lab.Models;

namespace minesweeper_lab.Views
{
    public partial class MSFacil : GameForm
    {
        public MSFacil()
        {
            InitializeComponent();
            Program.mc.Inicialize(this, TipoDeJogo.Facil);
        }

        private void BTSair_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

       private void definiçõesToolStripMenuItem_Click(object sender, EventArgs e)
       {
          this.Hide(); //fechar o form menu
          Menu m = new Menu();
          m.ShowDialog();
          this.Close();
       }

        private void BTPlay_Click(object sender, EventArgs e)
        {
            panelFacil.Enabled = true;
            BTPlay.Enabled = false;
            TempoInicial = DateTime.Now;
            TemporizadorRefreshLabel.Start();
        }

        public void BTNovoJogo_Click(object sender, EventArgs e)
        {
            Program.mc.BTNovoJogo_Click(sender, e);
        }

        private void dificuldadeMédiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemporizadorRefreshLabel.Stop();
            this.Hide(); //fechar o form menu
            Medio m = new Medio();
            m.ShowDialog();
            this.Close();
        }

        private void BTNovoJogo_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                ReadyToReveal = true;
            }
            else if(e.Button == MouseButtons.Right && ReadyToReveal)
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
    }
}
