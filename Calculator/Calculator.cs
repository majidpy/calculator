using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        public float n1 = 0, n2 = 0;
        public int oprClickCount = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            // all the textbox, button, etc are controls 
            // https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/controls-to-use-on-windows-forms
            // EventHandeler
            // https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-create-event-handlers-at-run-time-for-windows-forms
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Click += new EventHandler(btn_click);
                }
            }

        }
        
        //https://docs.microsoft.com/en-us/dotnet/framework/winforms/event-handlers-overview-windows-forms
        public void btn_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            

            if (isOperator(button))
            {
                if (oprClickCount == 0)
                {
                    oprClickCount++;
                    n1 = float.Parse(textBox1.Text);
                    textBox1.Text = " ";
                }
                else
                {
                    n2 = float.Parse(textBox1.Text);
                    float results = calc(n1, n2, button);
                    textBox1.Text = results.ToString();
                    n1 = results;
                }
                
                

            }
            else
            {
                if (!textBox1.Text.Contains("."))
                {
                    if (textBox1.Text.Equals("0") && !button.Text.Equals("."))
                    {
                        textBox1.Text = button.Text;
                    }
                    else
                    {
                        textBox1.Text += button.Text;
                    }
                    
                }
                else if (!button.Text.Equals("."))
                {
                    textBox1.Text += button.Text;
                }

            }

        }

        public bool isOperator(Button b)
        {
            if (b.Text == "+" || b.Text == "-" || b.Text == "X" ||
                b.Text == "/" || b.Text == "=")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float calc(float n1, float n2,  Button b)
        {
            float result = 0;
            switch (b.Text)
            {
                case "+":
                    result =  n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "X":
                    result = n1 * n2;
                    break;
                case "/":
                    result = n1 / n2;
                    break;

            }
            return result;
            
        }

    }
}
