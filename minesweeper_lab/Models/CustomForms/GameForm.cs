using Common_Library.Controllers;
using minesweeper_lab.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper_lab.Models
{
    public class GameForm : Form
    {
        public TabuleiroLogic meuTabuleiro;
        public Button[,] btnGrid;
        public DateTime TempoInicial;
        public Timer TemporizadorRefreshLabel;
        public int flagcounter = 0;
        public bool ReadyToReveal = false;
    }
}
