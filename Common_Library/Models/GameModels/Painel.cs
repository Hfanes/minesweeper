using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Library.Models
{
    public class Painel
    {
        public CustomVector2 pos { get; set; }
        public int numVizinhosBomba { get; set; }
        public bool hasMina { get; set; }
        public bool isClicked { get; set; }
        public bool hasFlag { get; set; }

        public Painel(int x, int y, bool hasMina)
        {
            pos = new CustomVector2() { x = x, y = y };
            this.numVizinhosBomba = 0;
            this.hasMina = hasMina;
            this.isClicked = false;
            this.hasFlag = false;
        }
    }
}
