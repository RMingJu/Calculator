using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cal
{
    public partial class Form1 : Form
    {
        double firstNum = 0;
        double secNum = 0;
        double result;
        String operation;
        
        
        public Form1()
        {
            InitializeComponent();
            
        }




        //
        //數字
        //
        private void Number_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            //起始值是0，先清掉才給輸入值
            if (numberBox.Text == "0")
                numberBox.Clear();
            //得到結果後，再按按鈕時要先將numberBox的值清掉才給輸入值
            if (numberBox.Text == result + "")
                numberBox.Clear();
            numberBox.Text += bt.Text;
            label1.Focus();
        }

        private void Number_point_Click(object sender, EventArgs e)
        {

            if (numberBox.Text == result + "" && numberBox.Text !="0")
                numberBox.Clear();
            numberBox.Text += Number_point.Text;
        }
        //
        //清除
        //
        private void clean_button_Click(object sender, EventArgs e)
        {
            showBox.Clear();
            numberBox.Clear();
            firstNum = 0;
            secNum = 0;
        }

        //計算規則
        private void operation_rule(String oper)
        {
            switch (operation)
            {
                case "-":
                    result = firstNum -= double.Parse(numberBox.Text);
                    showBox.Text += numberBox.Text + oper;
                    numberBox.Clear();
                    numberBox.Text = firstNum + "";
                    operation = oper;
                    break;
                case "*":
                    result = firstNum *= double.Parse(numberBox.Text);
                    showBox.Text += numberBox.Text + oper;
                    numberBox.Clear();
                    numberBox.Text = firstNum + "";
                    operation = oper;
                    break;
                case "/":
                    result = firstNum /= double.Parse(numberBox.Text);
                    showBox.Text += numberBox.Text + oper;
                    numberBox.Clear();
                    numberBox.Text = firstNum + "";
                    operation = oper;
                    break;
                case "+":
                    operation = oper;
                    result = firstNum += double.Parse(numberBox.Text);
                    showBox.Text += numberBox.Text + oper;
                    numberBox.Clear();
                    numberBox.Text = firstNum + "";
                    break;
            }
            
        }
        //
        //四則運算子
        //
        private void add_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(numberBox.Text))
            {
                //初始進入
                if (firstNum == 0)
                {
                    operation = "+";
                    firstNum = double.Parse(numberBox.Text);
                    numberBox.Clear();
                    showBox.Text += firstNum + operation;
                }
                //沒有按"等於"又繼續按下運算符號時由此進入
                else
                {
                    //判別上一次的運算符號為何，先算完firstNum後，再給他本次的運算符號供給下一個數字使用
                    operation_rule("+");
                }
            }

            label1.Focus();
        }

        private void less_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(numberBox.Text))
            {
                //初始進入
                if (firstNum == 0)
                {
                    operation = "-";
                    firstNum = double.Parse(numberBox.Text);
                    numberBox.Clear();
                    showBox.Text += firstNum + operation;
                }
                //沒有按"等於"又繼續按下運算符號時由此進入
                else
                {
                    //判別上一次的運算符號為何，先算完firstNum後，再給他本次的運算符號供給下一個數字使用
                    operation_rule("-");

                }
            }
            label1.Focus();
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(numberBox.Text))
            {
                //初始進入
                if (firstNum == 0)
                {
                    operation = "*";
                    firstNum = double.Parse(numberBox.Text);
                    numberBox.Clear();
                    showBox.Text += firstNum + operation;
                }
                //沒有按"等於"又繼續按下運算符號時由此進入
                else
                {
                    //判別上一次的運算符號為何，先算完firstNum後，再給他本次的運算符號供給下一個數字使用
                    operation_rule("*");

                }
            }
            label1.Focus();
        }

        private void except_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(numberBox.Text))
            {
                //初始進入
                if (firstNum == 0)
                {
                    operation = "/";
                    firstNum = double.Parse(numberBox.Text);
                    numberBox.Clear();
                    showBox.Text += firstNum + operation;
                }
                //沒有按"等於"又繼續按下運算符號時由此進入
                else
                {
                    //判別上一次的運算符號為何，先算完firstNum後，再給他本次的運算符號供給下一個數字使用
                    operation_rule("/");

                }
            }
            label1.Focus();
        }

        private void equal_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(numberBox.Text))
            {
                //存取第二個個數字
                secNum = double.Parse(numberBox.Text);


                switch (operation)
                {
                    case "+":
                        result = firstNum + secNum;
                        numberBox.Clear();
                        break;
                    case "-":
                        result = firstNum - secNum;
                        numberBox.Clear();
                        break;
                    case "*":
                        result = firstNum * secNum;
                        numberBox.Clear();
                        break;
                    case "/":
                        result = firstNum / secNum;
                        numberBox.Clear();
                        break;
                }

                showBox.Clear();
                numberBox.Text = result + "";
                firstNum = 0;
                secNum = 0;
              
                
            }
            label1.Focus();
        }

        private void back_button_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(numberBox.Text))
            {
                numberBox.Text = numberBox.Text.Substring(0, numberBox.Text.Length - 1);
            }
            label1.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //數字鍵 0~9(96~105)
            if (e.KeyValue >= 96 && e.KeyValue <= 105)
            {    //0~9(96~105)
                int a = e.KeyValue % 96;
                Number_Click(this.Controls["Number_" + a], null);
            }
            else
            {
                switch (e.KeyValue)
                {
                    case 107:
                        add_button_Click(add_button, null);
                        break;
                    case 109:
                        less_button_Click(less_button, null);
                        break;
                    case 106:
                        multiply_button_Click(multiply_button, null);
                        break;
                    case 111:
                        except_button_Click(except_button, null);
                        break;
                    case 13:
                        equal_button_Click(equal_button, null);
                        break;
                    case 110:
                        Number_point_Click(Number_point, null);
                        break;
                    case 8:
                        back_button_Click(back_button, null);
                        break;
                }
            }

            //label1.Text = e.KeyValue + "";


        }
    }
}
