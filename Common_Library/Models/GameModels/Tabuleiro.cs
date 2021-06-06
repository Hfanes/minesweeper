using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Library.Models
{
    public class Tabuleiro
    {
        public CustomVector2 tamanhoTabuleiro { get; set; }
        public List<Painel> Grid { get; set; }
        public bool lost { get; set; }
        public bool won { get; set; }
        public bool hasPopulation { get; set; }
        public TipoDeJogo tipoDeJogo { get; set; }

        public Tabuleiro(int x, int y, TipoDeJogo tj)
        {
            this.tamanhoTabuleiro = new CustomVector2() { x = x, y = y };
            this.lost = false;
            this.won = false;
            this.hasPopulation = false; //se tem bombas 
            this.tipoDeJogo = tj;

            Grid = new List<Painel>();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Grid.Add(new Painel(i, j, false));
                }
            }
        }
    }
}
