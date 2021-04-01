using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionGames
{

    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Play_Click_1(object sender, EventArgs e)
        {
            Form newForm = new MetchingGame();
            newForm.Owner = this;
            newForm.Left = this.Left;
            newForm.Top = this.Top;
            newForm.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Authors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nikita Gorinov.");
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Form newForm = new Settings();
            newForm.Owner = this;
            newForm.Left = this.Left;
            newForm.Top = this.Top;
            newForm.Show();
            this.Hide();
        }

        private void Menu_BackColorChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor= ((this.BackColor == Color.Black) ? Color.Wheat : Color.Black);
            textBox1.BackColor = this.BackColor;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            BackColor = Properties.Settings.Default.BackColor;
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.BackColor = BackColor;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form newForm = new CrossZero();
            newForm.Owner = this;
            newForm.Left = this.Left;
            newForm.Top = this.Top;
            newForm.Show();
            this.Hide();
        }
    }
}

