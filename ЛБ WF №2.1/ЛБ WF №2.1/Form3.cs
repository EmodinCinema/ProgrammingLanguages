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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();
            for (int i = 100; i <= 999; ++i)
            {
                if (i % 6 == 0 && ((i / 100) + (i % 100 - i % 10) / 10 + (i % 10)) % 6 == 0)
                {
                    numbers.Add(i);
                }
            }
            label2.Text = "Ответ: " + string.Join(" ", numbers);
        }
    }
}
