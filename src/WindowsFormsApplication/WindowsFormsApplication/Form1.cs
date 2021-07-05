using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private string Name;
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            if (WebBrowser != null)
            {
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileOpen.ShowDialog() == DialogResult.OK)
            {
                WebBrowser.Navigate("about:blank");
                Name = FileOpen.FileName;
                WebBrowser.Navigate(Name);
                //Form f = new Form1();
                //f.Size.Width += 100;
                panel1.Visible = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

        }

        private void rezult_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double X = Convert.ToDouble(textBox1.Text);
                double Y = Convert.ToDouble(textBox2.Text);
                if ((Y > -1 && Y < 1 && X < 0 && X > -1) || (Math.Pow(X, 2) + Math.Pow(Y, 2) < 1))
                {
                    MessageBox.Show("Точка попапла в область", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatusLabel1.Text = "Результат: точка попала в область";
                }else if ((Y == -1 && X <= 0 && X >= -1) || (X == -1 && Y >= -1 && Y <= 1) || (Y == 1 && X <= 0 && X >= -1) || (Math.Pow(X, 2) + Math.Pow(Y, 2) == 1 && X > 0))
                {
                    MessageBox.Show("Точка попапла на границу области", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatusLabel1.Text = "Результат: точка попала на границу области";
                }else 
                {
                    MessageBox.Show("Точка оказалась за границей области", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatusLabel1.Text = "Результат: точка оказалась за границей области";
                }
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Мусурина Анна Сергевна ПКсп-118 Вариант 11", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
