using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_8
{
    public partial class MainWindow : Window
    {
        //string leftOperand = "";
        //string operation = "";
        //string rightOperand = "";

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement i in Layout.Children) // Добавляет обработчик для всех кнопок
            {
                if (i is Button)
                {
                    ((Button)i).Click += Button_Click;
                }
            }
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string str = (string)((Button)e.OriginalSource).Content; // текст кнопки

        //    if (str == "C")
        //    {
        //        leftOperand = "";
        //        rightOperand = "";
        //        operation = "";
        //        textBlock.Text = "";
        //    }

        //    if (textBlock.Text.Length > 17)
        //        return;

        //    textBlock.Text += str;

        //    int num;
        //    bool isNumber = Int32.TryParse(str, out num);

        //    if (isNumber == true)
        //    {
        //        if (operation == "")
        //        {
        //            leftOperand += str;
        //        }
        //        else
        //        {
        //            rightOperand += str;
        //        }
        //    }
        //    else
        //    {
        //        if (str == "=")
        //        {
        //            Calculate();
        //            textBlock.Text = "";
        //            textBlock.Text += rightOperand;
        //            operation = "";
        //        }
        //        else if (str == "C")
        //        {
        //            leftOperand = "";
        //            rightOperand = "";
        //            operation = "";
        //            textBlock.Text = "";
        //        }
        //        else if (str == ".")
        //        {
        //            if (operation == "")
        //            {
        //                leftOperand += str;
        //            }
        //            else
        //            {
        //                rightOperand += str;
        //            }
        //        }
        //        else
        //        {
        //            if (rightOperand != "")
        //            {
        //                Calculate();
        //                leftOperand = rightOperand;
        //                rightOperand = "";
        //            }

        //            operation = str;
        //        }
        //    }
        //}

        //private void Calculate()
        //{
        //    double num1 = Double.Parse(leftOperand);
        //    double num2 = Double.Parse(rightOperand);

        //    switch (operation)
        //    {
        //        case "+":
        //            rightOperand = (num1 + num2).ToString();
        //            break;
        //        case "-":
        //            rightOperand = (num1 - num2).ToString();
        //            break;
        //        case "*":
        //            rightOperand = (num1 * num2).ToString();
        //            break;
        //        case "/":
        //            if (num2 == 0)
        //            {
        //                MessageBox.Show("Can't divide by 0");
        //                leftOperand = "";
        //                rightOperand = "";
        //                operation = "";
        //                textBlock.Text = "";
        //                return;
        //            }
        //            rightOperand = (num1 / num2).ToString();
        //            break;
        //        case "%":
        //            rightOperand = (num1 % num2).ToString();
        //            break;
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            string str1 = " ";
            string input = "";


            if (str == "=")
            {
                input = textBlock.Text;
                textBlock.Text = "";
                double result = RPN.Calculate(input);
                textBlock.Text = Convert.ToString(result);
            }
            else if (str == "C")
                textBlock.Text = "";
            else if(str == "DEL")
            {
                textBlock.Text = textBlock.Text.Remove(textBlock.Text.Length - 1);
            }
            else
                textBlock.Text += str;
        }
    }   
}
