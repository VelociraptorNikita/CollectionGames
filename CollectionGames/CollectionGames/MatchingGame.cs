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
    public partial class MetchingGame : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "h", "h", "b", "b", "v", "v", "Q", "Q", "@", "@"
        };

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public MetchingGame()
        {
            InitializeComponent();
            AssignIconsToSquares();
            tableLayoutPanel1.BackColor = Application.OpenForms[0].BackColor;
            foreach (Label label in tableLayoutPanel1.Controls)
            {
                label.BackColor = Application.OpenForms[0].BackColor;
                label.ForeColor = Application.OpenForms[0].BackColor;
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;
            Color newColor;



            newColor = (clickedLabel.BackColor == Color.Black) ? Color.Wheat : Color.Black;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == newColor)
                    return;

                if(firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = newColor;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = newColor;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("You have matched all the pictures!", "Congratulate!");
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form newForm = Application.OpenForms[0];
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Left = this.Left;
            newForm.Top = this.Top;
            newForm.Show();
        }

        private void Game_BackColorChanged(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
        }
    }
}
