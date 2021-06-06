using Common_Library.Models;
using Common_Library.Models.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common_Library.Controllers
{
    public class TabuleiroLogic
    {
        public Tabuleiro Jogo { get; set; }
        public string UID { get; set; }

        public TabuleiroLogic(int x, int y, TipoDeJogo tj)
        {
            this.Jogo = new Tabuleiro(x, y, tj);
        }

        public void floodfill(int x, int y) 
        {
            Painel clicado = Jogo.Grid.First(painel => painel.pos.x == x && painel.pos.y == y);
            clicado.isClicked = true;
            List<Painel> blocosemvolta = Jogo.Grid.Where(painel => ((painel.pos.x == x + 1 && painel.pos.y == y + 1) || (painel.pos.x == x && painel.pos.y == y + 1) || (painel.pos.x == x - 1 && painel.pos.y == y + 1) || (painel.pos.x == x + 1 && painel.pos.y == y) || (painel.pos.x == x - 1 && painel.pos.y == y) || (painel.pos.x == x + 1 && painel.pos.y == y - 1) || (painel.pos.x == x && painel.pos.y == y - 1) || (painel.pos.x == x - 1 && painel.pos.y == y - 1)) && !painel.isClicked).ToList(); //e nao estao abertos, where retorna Ienumerable para a lista
            int contadorbombas = 0;
            foreach(Painel painel in blocosemvolta)
            {
                if (painel.hasMina)
                {
                    contadorbombas++;
                }
            }
            clicado.numVizinhosBomba = contadorbombas;
            if (contadorbombas == 0)
            {
                foreach(Painel painel in blocosemvolta)
                {
                    if (!painel.hasFlag && painel.numVizinhosBomba == 0)
                    {
                        floodfill(painel.pos.x, painel.pos.y);
                    }
                }
            }
        }
        public void GerarBombas(int numBombas, int x, int y)
        {
            try
            {
                Server server = new Server();
                Campo c = server.GetCampo(Jogo.tipoDeJogo, UID);
                c.Posicao.Where(p => p.Text == "-1").ToList().ForEach(pos =>
                  {
                      Jogo.Grid.First(painel => painel.pos.x == int.Parse(pos.Coluna) && painel.pos.y == int.Parse(pos.Linha)).hasMina = true;
                  });
            }
            catch (Exception)
            {
                Random rand = new Random();
                for (int i = 0; i < numBombas; i++)
                {
                    int newbombx = rand.Next(0, Jogo.tamanhoTabuleiro.x);
                    int newbomby = rand.Next(0, Jogo.tamanhoTabuleiro.y);
                    if (!(newbombx == x && newbomby == y))
                    {
                        Jogo.Grid.First(painel => painel.pos.x == newbombx && painel.pos.y == newbomby).hasMina = true;
                    }
                }
            }
            
        }
        public bool revelarCelula(int x, int y)
        {
            if (!this.Jogo.hasPopulation)
            {
                if(this.Jogo.tipoDeJogo == TipoDeJogo.Facil)
                {
                    this.GerarBombas(10, x, y);
                    this.Jogo.hasPopulation = true;
                }
                else if(this.Jogo.tipoDeJogo == TipoDeJogo.Medio)
                {
                    this.GerarBombas(40, x, y);
                    this.Jogo.hasPopulation = true;
                }
            }
            Painel clicado = this.Jogo.Grid.Find(painel => painel.pos.x == x && painel.pos.y == y);//find=first
            if (clicado.hasMina && !clicado.hasFlag)
            {
                this.Jogo.lost = true;
            }
            else if(!clicado.hasFlag)
            {
                if (!clicado.hasFlag)
                {
                    this.floodfill(clicado.pos.x, clicado.pos.y);
                }
            }
            if (HasFinished())
            {
                Jogo.won = true;
                return true;
            }
            else
            {
                Jogo.won = false;
                return false;
            }
        }

        public bool colocarFlag(int x, int y)//bool serve para saber se a flag foi posta ou tirada
        {
            Painel clicado = this.Jogo.Grid.Find(painel => painel.pos.x == x && painel.pos.y == y);
            if (!clicado.isClicked)
            {
                clicado.hasFlag = !clicado.hasFlag;
                return true; 
            }
            else
            {
                return false;
            }
        }
        public bool isFlag(int x, int y)
        {
            Painel clicado = this.Jogo.Grid.Find(painel => painel.pos.x == x && painel.pos.y == y);
            return clicado.hasFlag;
        }
        public bool HasFinished()
        {
            List<Painel> nonbombsleft = this.Jogo.Grid.Where(painel => !painel.hasMina && !painel.isClicked).ToList();
            //nonbomsleft é uma lista de blocos não abertos que não contem bombas
            return nonbombsleft.Count != 0 ? false : true;
        }
    }
}
