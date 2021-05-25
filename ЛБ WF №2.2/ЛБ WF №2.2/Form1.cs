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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2(false);
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2(true);
            form2.ShowDialog();
        }
    }
}
