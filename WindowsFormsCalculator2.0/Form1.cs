using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("0");
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText(",");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText(" + ");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText(" - ");
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText(" * ");
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText(" / ");
        }

        private void btnAllClean_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            rtbOutput.Undo();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string res = rtbOutput.Text;
            char[] sep = { ' ' };
            List<string> numb = new List<string>(res.Split(sep));

            //string[] numb = res.Split(sep); 
            // without building.
            int size = numb.Count;
            rtbOutput.AppendText(" = ");
            double result = 0;
            double sort = 0;

            if (numb.Count > 3) //сортировка 
            {
                //for (int k = 1; k < numb.Count - 1; k += 2)
                for (int k = 3; k < size; size -= 2)
                {
                    if (numb[k] == "*" || numb[k] == "/")
                    {
                        sort = Calculate(Convert.ToDouble(numb[k - 1]), Convert.ToDouble(numb[k + 1]), numb[k]);
                        string newSort = Convert.ToString(sort);
                        numb[k] = newSort;
                        numb.RemoveAt(k + 1);
                        numb.RemoveAt(k - 1);
                        
                    }
                }
            }

            for (int i = 0; i < numb.Count - 1; i += 2) 
            {
                if (i == 0)
                {
                    result = Calculate(Convert.ToDouble(numb[i]), Convert.ToDouble(numb[i + 2]), numb[i + 1]);
                }
                else
                {
                    result = Calculate(result, Convert.ToDouble(numb[i + 2]), numb[i + 1]);
                }
            }

            rtbOutput.AppendText(Convert.ToString(result));
        }

        public double Calculate(double a, double b, string operation)
        {
            double result;
            if (operation == "+")
            {
                result = a + b;
            }
            else if (operation == "-")
            {
                result = a - b;
            }
            else if (operation == "/")
            {
                result = a / b;
            }
            else
            {
                result = a * b;
            }

            return result;
        }
    }

}
