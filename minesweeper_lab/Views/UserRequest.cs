using Common_Library.Controllers;
using Common_Library.Models;
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
    public partial class UserRequest : Form
    {
        public UserRequest(string displayTime)
        {
            InitializeComponent();
            WonLabel.Text = $"Ganhaste!!!\nTempo:{displayTime}";
        }
    }
}
