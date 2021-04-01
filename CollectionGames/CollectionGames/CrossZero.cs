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
    public partial class CrossZero : Form
    {
        String[,] field = { {"", "", ""}, { "", "", "" }, { "", "", "" } };
        public CrossZero()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Application.OpenForms[0].BackColor;
            foreach (Label label in tableLayoutPanel1.Controls)
            {
                label.BackColor = Application.OpenForms[0].BackColor;
                //label.ForeColor = Application.OpenForms[0].BackColor;
            }
        }

        private void CrossZero_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form newForm = Application.OpenForms[0];
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Left = this.Left;
            newForm.Top = this.Top;
            newForm.Show();
        }

        private void CrossZero_BackColorChanged(object sender, EventArgs e)
        {
            //label1.BackColor = this.BackColor;
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if ((clickedLabel.Text == "") && (!GameOver()))
            {
                clickedLabel.Text = "X";
                int RowIndex = Convert.ToInt32(clickedLabel.Name.ToString().Remove(0, 5).Remove(1,1));
                int ColumnIndex = Convert.ToInt32(clickedLabel.Name.ToString().Remove(0, 5).Remove(0, 1));
                field[RowIndex, ColumnIndex] = "X";
                if (GameOver())
                {
                    MessageBox.Show("Win");
                    return;
                }
                else
                {
                    ComputerRunning();
                    if (GameOver())
                    {
                        MessageBox.Show("Loss");
                        return;
                    }
                    }
                if (Nobody())
                {
                    MessageBox.Show("Draw");
                    return;
                }
            }
        }

        private void ComputerRunning()
        {
            //нет ли выигрышных ходов
            //по строкам
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((field[i, j] == "0") && (field[i, j] == field[i, (j+1)%3]) && (field[i, (j+2)%3] == ""))
                    {
                        field[i, (j+2)%3] = "0";
                        string LabelName = "label" + i.ToString() + ((j+2)%3).ToString();
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }
            }

            //по столбцам
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((field[i, j] == "0") && (field[i, j] == field[(i + 1) % 3, j]) && (field[(i + 2) % 3, j] == ""))
                    {
                        field[(i + 2) % 3, j] = "0";
                        string LabelName = "label" + ((i + 2) % 3).ToString() + j.ToString();
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }
            }

            //по диагоналям
            if ((field[0, 0] == "0") && (field[0, 0] == field[1, 1]) && (field[2, 2] == ""))
            {
                field[2, 2] = "0";
                string LabelName = "label" + "2" + "2";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if ((field[1, 1] == "0") && (field[1, 1] == field[2, 2]) && (field[0, 0] == ""))
            {
                field[0, 0] = "0";
                string LabelName = "label" + "0" + "0";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if ((field[2, 0] == "0") && (field[2, 0] == field[1, 1]) && (field[0, 2] == ""))
            {
                field[0, 2] = "0";
                string LabelName = "label" + "0" + "2";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if ((field[0, 2] == "0") && (field[0, 2] == field[1, 1]) && (field[2, 0] == ""))
            {
                field[2, 0] = "0";
                string LabelName = "label" + "2" + "0";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            //не может ли игрок выиграть следующим ходом
            //по строкам
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((field[i, j] == "X") && (field[i, j] == field[i, (j+1)%3]) && (field[i, (j+2)%3] == ""))
                    {
                        field[i, (j+2)%3] = "0";
                        string LabelName = "label" + i.ToString() + ((j+2)%3).ToString();
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }
            }

            //по столбцам
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((field[i, j] == "X") && (field[i, j] == field[(i + 1) % 3, j]) && (field[(i + 2) % 3, j] == ""))
                    {
                        field[(i + 2) % 3, j] = "0";
                        string LabelName = "label" + ((i + 2) % 3).ToString() + j.ToString();
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }
            }

            //по диагоналям
            if ((field[0, 0] == "X") && (field[0, 0] == field[1, 1]) && (field[2, 2] == ""))
            {
                field[2, 2] = "0";
                string LabelName = "label" + "2" + "2";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if ((field[1, 1] == "X") && (field[1, 1] == field[2, 2]) && (field[0, 0] == ""))
            {
                field[0, 0] = "0";
                string LabelName = "label" + "0" + "0";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if ((field[2, 0] == "X") && (field[2, 0] == field[1, 1]) && (field[0, 2] == ""))
            {
                field[0, 2] = "0";
                string LabelName = "label" + "0" + "2";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if ((field[0, 2] == "X") && (field[0, 2] == field[1, 1]) && (field[2, 0] == ""))
            {
                field[2, 0] = "0";
                string LabelName = "label" + "2" + "0";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            //можно ли создать безвыходную ситуацию
            if (field[1, 1] != "0")
            {
                //если угловые точки и между 2-мя из них пустая клетка
                if ((field[0, 0] == "0") && (field[2, 2] == "0"))
                {
                    if ((field[1, 0] == "") && (field[2, 1] == "") && (field[2, 0] == ""))
                    {
                        field[2, 0] = "0";
                        string LabelName = "label" + "2" + "0";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                    if ((field[0, 1] == "") && (field[1, 2] == "") && (field[0, 2] == ""))
                    {
                        field[0, 2] = "0";
                        string LabelName = "label" + "0" + "2";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }

                if ((field[2, 0] == "0") && (field[0, 2] == "0"))
                {
                    if ((field[1, 0] == "") && (field[0, 1] == "") && (field[0, 0] == ""))
                    {
                        field[0, 0] = "0";
                        string LabelName = "label" + "0" + "0";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                    if ((field[1, 2] == "") && (field[2, 1] == "") && (field[2, 2] == ""))
                    {
                        field[2, 2] = "0";
                        string LabelName = "label" + "2" + "2";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }
            }
            else
            {
                //центральная точка и 2 угловые, между которыми пустая клетка
                if (field[0, 0] == "0")
                {
                    if ((field[1, 0] == "") && (field[2, 0] == ""))
                    {
                        field[2, 0] = "0";
                        string LabelName = "label" + "2" + "0";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                    if ((field[0, 1] == "") && (field[0, 2] == ""))
                    {
                        field[0, 2] = "0";
                        string LabelName = "label" + "0" + "2";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }

                if (field[0, 2] == "0")
                {
                    if ((field[0, 1] == "") && (field[0, 0] == ""))
                    {
                        field[0, 0] = "0";
                        string LabelName = "label" + "0" + "0";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                    if ((field[1, 2] == "") && (field[2, 2] == ""))
                    {
                        field[2, 2] = "0";
                        string LabelName = "label" + "2" + "2";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }

                if (field[2, 0] == "0")
                {
                    if ((field[1, 0] == "") && (field[0, 0] == ""))
                    {
                        field[0, 0] = "0";
                        string LabelName = "label" + "0" + "0";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                    if ((field[2, 1] == "") && (field[2, 2] == ""))
                    {
                        field[2, 2] = "0";
                        string LabelName = "label" + "2" + "2";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }

                if (field[2, 2] == "0")
                {
                    if ((field[2, 1] == "") && (field[2, 0] == ""))
                    {
                        field[2, 0] = "0";
                        string LabelName = "label" + "2" + "0";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                    if ((field[1, 2] == "") && (field[0, 2] == ""))
                    {
                        field[0, 2] = "0";
                        string LabelName = "label" + "0" + "2";
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                }
            }

            //сходить на одну из выгодных позиций
            if (field[1, 1] == "")
            {
                field[1, 1] = "0";
                string LabelName = "label" + "1" + "1";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if (field[0, 0] == "")
            {
                field[0, 0] = "0";
                string LabelName = "label" + "0" + "0";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if (field[2, 0] == "")
            {
                field[2, 0] = "0";
                string LabelName = "label" + "2" + "0";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if (field[0, 2] == "")
            {
                field[0, 2] = "0";
                string LabelName = "label" + "0" + "2";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            if (field[2, 2] == "")
            {
                field[2, 2] = "0";
                string LabelName = "label" + "2" + "2";
                tableLayoutPanel1.Controls[LabelName].Text = "0";
                return;
            }

            //ход на первую свободную позицию
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == "")
                    {
                        field[i, j] = "0";
                        string LabelName = "label" + i.ToString() + j.ToString();
                        tableLayoutPanel1.Controls[LabelName].Text = "0";
                        return;
                    }
                } 
            }
        }

        private Boolean GameOver()
        {
            if ((field[0, 0] != "") && (field[0, 0] == field[0, 1]) && (field[0, 0] == field[0, 2])) return true;

            if ((field[1, 0] != "") && (field[1, 0] == field[1, 1]) && (field[1, 0] == field[1, 2])) return true;

            if ((field[2, 0] != "") && (field[2, 0] == field[2, 1]) && (field[2, 0] == field[2, 2])) return true;

            if ((field[0, 0] != "") && (field[0, 0] == field[1, 0]) && (field[0, 0] == field[2, 0])) return true;

            if ((field[0, 1] != "") && (field[0, 1] == field[1, 1]) && (field[0, 1] == field[2, 1])) return true;

            if ((field[0, 2] != "") && (field[0, 2] == field[1, 2]) && (field[0, 2] == field[2, 2])) return true;

            if ((field[0, 0] != "") && (field[0, 0] == field[1, 1]) && (field[0, 0] == field[2, 2])) return true;

            if ((field[0, 2] != "") && (field[0, 2] == field[1, 1]) && (field[0, 2] == field[2, 0])) return true;

            return false;
        }

        private Boolean Nobody()
        {
            int count = 0;

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] != "")
                    {
                        count++; 
                    }
                }
            }

            if (count == 9) return true;

            return false;
        }
    }
}
