using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int a = 10;
        int b = 1;
        string op = "+";
        double result = 11.0;
        Random rnd = new Random();

        private void buttonResult_Click(object sender, EventArgs e)
        {
            string strResult = textBoxResult.Text;
            string disp = "" + a + op + b + "=" + strResult + "";
            if (textBoxResult.Text == "")
            {
                disp += "未答题，正确答案为" + result;
            }
            else
            {
                double d = Math.Round(double.Parse(strResult), 2);

                if (d == result)
                    disp += "✔";
                else
                    disp += "❌，正确答案为" + result;
                listBoxResult.Items.Add(disp);
            }


        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            a = rnd.Next(10) + 1;
            b = rnd.Next(10) + 1;
            int c = rnd.Next(4);
            switch (c)
            {
                case 0:
                    op = "+";
                    result = a + b;
                    break;
                case 1:
                    op = "-";
                    result = a - b;
                    break;
                case 2:
                    op = "*";
                    result = a * b;
                    break;
                case 3:
                    op = "/";
                    result = Math.Round((double)a / b, 2);
                    break;
            }
            labelNumber1.Text = a.ToString();
            labelNumber2.Text = b.ToString();
            labelOperator.Text = op;
            textBoxResult.Text = "";
        }
    }

}
