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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Menu m = new Menu();
            m.ShowDialog();
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Server servidor = new Server();
            try
            {
                Program.mc.UID = servidor.login(TBusername.Text, TBpassword.Text);
                if(string.IsNullOrEmpty(Program.mc.UID))
                {
                    MessageBox.Show("Username ou password errada", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Program.mc.Online = true;
                    Program.mc.Username = TBusername.Text;
                    this.Hide();
                    Menu m = new Menu();
                    m.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel estabelecer ligação ao servidor\nPor favor tente mais tarde", "Erro de Ligação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
