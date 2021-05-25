using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛБ_WF__2._2
{
    public partial class Form2 : Form
    {
        public Form2(bool showButton)
        {
            InitializeComponent();
            button2.Visible = showButton;// Присвоение значения кнопкам из формы1 в форму2 
            button1.Visible = !(showButton);
            if (showButton) this.Text = "Задание 18";
            if (!(showButton)) this.Text = "Задание 3";
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.MaxLength = 1;
            Char num = e.KeyChar;

            if (!(num > 49 && num < 58) && num != 8)
            {
                e.Handled = true;
            }
            if (num == 13)
            {
                textBox2.Focus();
            }
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.MaxLength = 1;// Ограничивает ввод максимального количества символов
            Char num = e.KeyChar; 

            if (!(num > 49 && num < 58) && num != 8)
            {
                e.Handled = true;
            }
            if (num == 13 && button1.Visible)
            {
                button1_Click(sender, e);
            }
            if (num == 13 && button2.Visible)
            {
                button2_Click(sender, e);
            }
        }
        
        // Задание 3
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                short m = short.Parse(textBox1.Text);
                short k = short.Parse(textBox2.Text);

                dataGridView1.RowCount = m;// Свойство, получает число строк отображаемых в элементе управления
                dataGridView1.ColumnCount = k;// Свойство получает число столбцов
                int[,] mas = new int[m,k];
                Random random = new Random();
                int min = mas[0, 0], summin = 0, sumplus = 0;
                for (int y = 0; y < m; ++y)
                {
                    for (int x = 0; x < k; ++x)
                    {
                        mas[y, x] = random.Next(-50, 60);
                        dataGridView1.Rows[y].Cells[x].Value = mas[y,x];
                        if (min > mas[y, x])
                        {
                            min = mas[y, x];
                            label4.Text = $"Минимальный элемент = {min} строка {y + 1} столбец {x + 1}";
                        }
                        if (mas[y, x] < 0) summin += mas[y, x];
                        else sumplus += mas[y, x];
                      
                    }
                    label5.Text = $"Сумма положительных = {sumplus} \nСумма отрицательных={summin}";
                }
            }
            catch 
            {
                MessageBox.Show("M и K целые числа 1< K <10", "Неверный ввод!");
                
            }
        }

        // Задание 18
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                short m = short.Parse(textBox1.Text);
                short k = short.Parse(textBox2.Text);

                dataGridView1.RowCount = m;
                dataGridView1.ColumnCount = k;
                int[,] mas = new int[m, k];
                Random random = new Random();
                for (int y = 0; y < m; y++)
                {
                    int x = 0;
                    while(x < k)
                    {
                        mas[y, x] = random.Next(-25, 40);
                        dataGridView1.Rows[y].Cells[x].Value = mas[y, x];
                        x++;
                    }
                }
                label4.Text = "";
                for (int x = 0; x < k; x++)
                {
                    int y = 0;
                    while (y < m)
                    {
                        if (mas[y, x] < 0)
                        {
                            label4.Text += $"\nПервое отрицательное в столбце {x + 1}={mas[y, x]} строка {y + 1}";
                            break;
                        }
                        ++y;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("M и K целые числа 1< M < 10, 1 < K < 10", "Неверный ввод!");
                
            }

        }
    }
}
