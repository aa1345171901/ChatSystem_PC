using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 数据库实训
{
    public partial class 计算器 : Form
    {
        double a = 0;    
        double b = 0;    //记录先输入的数字
        bool c = false; //判断textBox是否为空
        string d;       //记录运算符
        public 计算器()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor(@"F:\visual studio 2017 Project\Projects\数据库实训\素材\鼠标2.ico");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("lllll啦啦啦啦啦");
        }

        private void button12_Click(object sender, EventArgs e)//1
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "1";
        }

        private void button11_Click(object sender, EventArgs e)//2
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "2";
        }

        private void button10_Click(object sender, EventArgs e)//3
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)//4
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)//5
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)//6
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "6";
        }

        private void button1_Click_1(object sender, EventArgs e)//7
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)//8
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)//9
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "0";
            if (d == "/")
            {
                textBox1.Clear();
                MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)//+
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "+";
        }

        private void button5_Click(object sender, EventArgs e)//-
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "-";
        }

        private void button9_Click(object sender, EventArgs e)//*
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "*";
        }

        private void button13_Click(object sender, EventArgs e)///
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "/";
        }

        private void button20_Click(object sender, EventArgs e)//平方
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "x2";
        }

        private void button19_Click(object sender, EventArgs e)//开方
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "sqrt";
        }

        private void button18_Click(object sender, EventArgs e)//log
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "log";
        }

        private void button17_Click(object sender, EventArgs e)//ln
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "ln";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            switch (d)
            {
                case "+":a = b + double.Parse(textBox1.Text);break;
                case "-":a = b - double.Parse(textBox1.Text);break;
                case "*":a = b * double.Parse(textBox1.Text);break;
                case "/":a = b / double.Parse(textBox1.Text);break;
                case "x2":a = b * double.Parse(textBox1.Text);break;
                case "sqrt":a = Math.Sqrt(b);break;
                case "log":a = Math.Log(double.Parse(textBox1.Text),b);break;
                case "ln":a = Math.Log(b,Math.E);break;
                default:
                    break;
            }
            textBox1.Text = a + "";
            c = true;
        }

        private void button15_Click(object sender, EventArgs e)//c
        {
            textBox1.Text = "";
        }
    }
}
