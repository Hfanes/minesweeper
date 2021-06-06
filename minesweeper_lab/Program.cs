using minesweeper_lab.Controllers;
using minesweeper_lab.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper_lab
{
    static class Program
    {
        public static MainController mc { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //controllers
            mc = new MainController();
            

            Application.Run(new Menu());
        }
    }
}
