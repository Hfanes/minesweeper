using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common_Library.Controllers;
using Common_Library.Models;

namespace minesweeper_lab.Views
{
    public partial class Registar : Form
    {
        private string imagepath { get; set; }
        public Registar()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); //fechar o form menu
            Menu m = new Menu();
            m.ShowDialog();
            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTRegistar_Click(object sender, EventArgs e)
        {
            Server servidor = new Server();
            string imgb64 = "data:image/jpeg;base64,";
            using (Image image = Image.FromFile(imagepath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    imgb64 += base64String;
                }
            }
            Regex verifyemail = new Regex("([a-zA-Z0-9]{1,})@([a-zA-Z0-9]{1,})\\.([a-zA-Z]{1,})");
            if(!string.IsNullOrEmpty(TBNome.Text) && !string.IsNullOrEmpty(TBUsername.Text) && !string.IsNullOrEmpty(TBPassword.Text) && !string.IsNullOrEmpty(TBEmail.Text) && !string.IsNullOrEmpty(CBPais.Text) && !string.IsNullOrEmpty(imagepath))
            {
                if (verifyemail.IsMatch(TBEmail.Text))
                {
                    try
                    {
                        Program.mc.UID = servidor.registar(TBNome.Text, TBUsername.Text, TBPassword.Text, TBEmail.Text, imgb64, CBPais.Text);
                        Program.mc.Online = true;
                        Program.mc.Username = TBUsername.Text;
                        DialogResult DR = MessageBox.Show("Registo comcluido com sucesso", "Registo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (DR == DialogResult.OK)
                        {
                            this.Hide();
                            Menu mm = new Menu();
                            mm.ShowDialog();
                            this.Close();
                        }
                    }
                    catch (Exception)
                    {
                        DialogResult DR = MessageBox.Show("Não foi possivel estabelecer ligação com o servidor\nPor favor tente novamente mais tarde", "Erro de ligação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (DR == DialogResult.OK)
                        {
                            this.Hide();
                            Menu mm = new Menu();
                            mm.ShowDialog();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O Email não é valido", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Não é possivel concluir o registo pois existem campos em branco", "Registo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhotoLoad_Click(object sender, EventArgs e)
        {
            DialogResult DR = OpenFileDiag.ShowDialog();
            OpenFileDiag.Filter = "Image Files(*.jpg; *.jpeg)|.jpg; *.jpeg";
            if (DR == DialogResult.OK)
            {
                imagepath = OpenFileDiag.FileName;
                ImageBox.Image = new Bitmap(imagepath);
                ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
