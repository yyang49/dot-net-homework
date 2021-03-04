using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Caculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("×");
            comboBox1.Items.Add("÷");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2, num3 = 0;
            try
            {
                num1 = double.Parse(textBox1.Text);
                num2 = double.Parse(textBox2.Text);
            }
            catch (System.FormatException)
            {
                result.Text = "数字错误";
                return;
            }
            switch (comboBox1.Text)
            {
                case "+":
                    num3 = num1 + num2;
                    break;
                case "-":
                    num3 = num1 - num2;
                    break;
                case "×":
                    num3 = num1 * num2;
                    break;
                case "÷":
                    if (num2 == 0)
                    {
                        result.Text = "除数不能为0";
                        return;
                    }
                    num3 = num1 / num2;
                    break;
            }
            result.Text = num3.ToString();
        }

        private void result_Click(object sender, EventArgs e)
        {

        }
    }
}
