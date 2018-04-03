using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;



namespace randomformlol
{
    public partial class Calculator : Form
    {
        string LastFileName=string.Empty;
        double x;
        string p;
        int ope = 0;
        string equ = string.Empty;
        int page = 0;
        const int linesperpage = 55;
        public Calculator()
            
        {
            InitializeComponent();
            textBox1.Text = "0";
            this.KeyPress += Calculator_KeyPress;
            // this.KeyDown += Calculator_KeyDown1;
            this.KeyPreview = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                equals_typed();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            ProcessKey(c);
        }

        private void ProcessKey(char c)
        {
            switch (c)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':


                    number_type(c.ToString());
                    break;
                case '+':
                case '-':
                case '/':
                case 'x':
                case 'X':
                case '*':
                case '^':
                    op_type(c.ToString());
                    break;
                case '=':
                    equals_typed();

                    break;
                case (char)8:
                    backspace();
                    break;
                case '.':
                    periodclick();
                    break;

                default:
                    break;


            }
        }



        //private void button1_Click(object sender, EventArgs e)
        //{ 
        //button1.Text = (double.Parse(button1.Text)+1).ToString();
        //button1.Width = button1.Width + 1;
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            number_click(sender);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void buttonsubt_Click(object sender, EventArgs e)
        {
            op_click(sender);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void number_type(string num)
        {
            if (ope == 1)
            {
                equ += p;
                textBox1.Text = "";
                ope = 0;
            }
       


                if (textBox1.Text == "Error" || textBox1.Text == "0" || textBox1.Text == "Infinity")
                {
                    textBox1.Text = num;
                }
                else
                {
                    textBox1.Text += num;
                }
            
        }
        private void number_click(object sender) // function number click  
        {
            number_type(((Button)sender).Text);
            
        }
        private void op_type(string op)
        {
            if (ope == 1 && p != "")
            {

            }
            else
            {


                equ += textBox1.Text;
            }
            if (ope == 0 && p != "")
            {
                calculate();
            }
            try
            {


                x = double.Parse(textBox1.Text);
                p = op;
                // textBox1.Text = "0";
                ope = 1;
            }
            catch
            {
                textBox1.Text = "Error";
            }
        }
        private void op_click(object sender)// function operator click
        {
            op_type(((Button)sender).Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            number_click(sender);
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            op_click(sender);
        }
        private void equals_typed()
        {
            equ += textBox1.Text;
            calculate();
            equ += "=" + textBox1.Text;
            listBox1.Items.Add(equ);
            equ = "";
            listBox1.SelectedIndex = listBox1.Items.Count-1;
            listBox1.SelectedIndex = -1; 
        }
        private void buttoncl_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            p = "";
            x = 0;
            ope = 0;
        }
        private void calculate()
        {
            ope = 1;
            double a;
            if (textBox1.Text == "Error")
            {
                textBox1.Text = "0";
            }
            else if (p == "+")
            {
                a = x + double.Parse(textBox1.Text);
                textBox1.Text = a.ToString();
            }
            else if (p == "-")
            {
                a = x - double.Parse(textBox1.Text);
                textBox1.Text = a.ToString();
            }
            else if (p == "^")
            {
                a = Math.Pow(x, double.Parse(textBox1.Text));
                textBox1.Text = a.ToString();
            }
            else if (p == "X" || p =="x" || p == "*")
            {
                a = x * double.Parse(textBox1.Text);
                textBox1.Text = a.ToString();
            }
            else if (p == "/")
            {
                if (textBox1.Text == "0")
                {
                    textBox1.Text = "0";
                    p = "";
                    x = 0;
                    textBox1.Text = "Error";

                }
                else
                {

                    a = x / double.Parse(textBox1.Text);
                    textBox1.Text = a.ToString();
                }
            }
            else { a = double.Parse(textBox1.Text); } 
            p = "";
        }
        private void buttonequals_Click(object sender, EventArgs e)
        {
            equals_typed();
        }

        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            op_click(sender);
        }

        private void buttondivide_Click(object sender, EventArgs e)
        {
            op_click(sender);
        }
        private void backspace()
        {
            if (textBox1.Text != "0")
            {
                int g = textBox1.Text.Length;
                if (g <= 1 || textBox1.Text == "Infinity" || textBox1.Text == "Error")
                {
                    textBox1.Text = "0";
                }
                else
                {
                    textBox1.Text = textBox1.Text.Substring(0, g - 1);
                }
            }
            else
            {

            }
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            backspace();
        }

        private void button_peri_click(object sender, EventArgs e)
        {
            periodclick();
        }

        private void periodclick()
        {

            if (ope == 1)
            {
                equ += p;
                textBox1.Text = "0";
                ope = 0;
            }
            if (!textBox1.Text.Contains("."))
            {
                if (textBox1.Text == "Infinity" || textBox1.Text == "Error")
                {
                    textBox1.Text = "0";
                }
                textBox1.Text += ".";
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Document|*.txt";
            saveFileDialog1.Title = "Save as text Document...";
            saveFileDialog1.ShowDialog();
            var saveFileName = saveFileDialog1.FileName;
            // If the file name is not an empty string open it for saving.  
            if (saveFileName != "")
            {
                Save(saveFileName);
            }
        }

        private void Save(string saveFileName)
        {
            // Saves the Image via a FileStream created by the OpenFile method.
            LastFileName = saveFileName;
            using (var fs = new System.IO.StreamWriter(saveFileName, false))
            {
                foreach (String Line in listBox1.Items)
                {
                    fs.WriteLine(Line);
                }

                fs.Flush();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastFileName == "")
            {
                SaveAs();
            }
            else
            {
                Save(LastFileName);
            }
        }

        private void Exponent_Click(object sender, EventArgs e)
        {
            op_click(sender);
        }
        private void Print()
        {

            var pd = new PrintDialog();
            
            string s = string.Empty;
            page = 0;
            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                
                var n = 0;
                foreach (String Line in listBox1.Items)
                {
                    n++;
                    if (n > page * linesperpage && n <= (page + 1) * linesperpage)
                    {
                        if (n == linesperpage)
                        {


                            e1.HasMorePages = true;
                            page++;
                            break;
                        }

                        s += Line + "\n";
                    }
                    
                }

                e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                s = string.Empty;
            };
            pd.Document = p;
            pd.UseEXDialog = true;
            var result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {


                try
                {
                    var pp = new PrintPreviewDialog();
                    pp.Document = p;
                    if (pp.ShowDialog() == DialogResult.OK)
                    { 
                        p.Print();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occurred While Printing", ex);
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void load()
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Document|*.txt";
            openFileDialog1.Title = "Load a text Document...";
            openFileDialog1.ShowDialog();
            var openFileName = openFileDialog1.FileName;
            // If the file name is not an empty string open it for saving.  
            if (openFileName != "")
            {
                listBox1.Items.Clear();
                using (var fs = new System.IO.StreamReader(openFileName))
                {
                    while (!fs.EndOfStream)
                    {
                        var Line = fs.ReadLine();
                        foreach (var c in Line)
                        {
                            ProcessKey(c);
                        }
                        if (!Line.EndsWith("="))
                        {
                            ProcessKey('=');
                        }

                    }

                }
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load();
        }

        private void Rand_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int ra = rnd.Next(10000); // creates a number between 0 and 10,000
            number_type(ra.ToString());

            //textBox1.Text = ra.ToString();
            //int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
            //int card = rnd.Next(52);     // creates a number between 0 and 51
        }
    }
}
