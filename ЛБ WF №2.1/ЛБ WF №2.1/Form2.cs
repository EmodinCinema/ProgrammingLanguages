using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛБ_WF__2._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
            if (number == 13)
            {
                button1_Click(sender, e);// Передаем значение в метод button1_Click
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)// Создаем событие (в textBox) KeyPress, который работает при нажатии пробела, клавиши Backspase, если фокус находится в элементе управления
        {
           char number=e.KeyChar;// e.KeyChar заносит в нашу переменную символ введённой клавиши
            if (!Char.IsDigit(number) && number !=8 && number != 45 && number !=44)// !Char.IsDigit(number)- если символ из из переменной numbers не относится к категории десятичных чисел. Но можем использовать ещё BS-8, "-"-45, ","-44
            {
                e.Handled = true;// тогда не обрабатывать введённый символ и не вносить его в textBox
            }
            if (number == 13)// CR-13
            {
                textBox2.Focus();// Ввод выражение в строку сразу после запуска
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try// Конструкция try..catch..finally
            {
                double x = double.Parse(textBox1.Text), answer = 0;
                int n = int.Parse(textBox2.Text), i = 1;
                while (i<=n)
                {
                    answer += Math.Pow(x, i) / Factorial(i);
                    i++;
                }
                button1.Text ="Ответ: " + answer.ToString();
            }
            catch 
            {
                MessageBox.Show("Поля \"Введите x\" и \"Введите n\" должны быть заполнены числовым значением", "Неверный ввод!");// Вывод сообщения в классе
            }
        }
        static int Factorial(int i)
        {
            if (i == 0) return 1;
            else return i * Factorial(i - 1);
        }
    }
}
