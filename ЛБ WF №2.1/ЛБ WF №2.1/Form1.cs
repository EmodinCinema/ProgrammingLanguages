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
    public partial class Form1 : Form
    {
        public Form1()// Метод форма1
        {
            InitializeComponent();// Инициализируем форму// Инициализируем форму
        }
        private void button1_Click_1(object sender, EventArgs e)//Вызов метода button_click. sender- объектинициировавший событие, EwentArgs e- аргумент, хранящий информацию о событии.
        {
            Form form2 = new Form2();// Создаем объек даного класса
            form2.ShowDialog();// Для отображения формы на экране вызываем метод ShowDialog, который блокирует все формы, кроме той, что мы вызвали
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
