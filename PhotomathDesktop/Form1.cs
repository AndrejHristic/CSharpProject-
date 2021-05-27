using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PhotomathDesktop
{
    public partial class MathForma : Form
    {
        public MathForma()
        {        
            InitializeComponent();
            Inicijalizacija();
        }
        private void btnracunaj_Click(object sender, EventArgs e)//REMINDER: button size je 260,45
        {
            Expression str = new Expression(tbunos.Text);
            lblispis.Text = str.RešiPostfiks(str.InfiksUPostfiks()).ToString();
            string filename = "Izrazi.txt";
            using (StreamWriter writer = new StreamWriter(filename, append: true))
            {
                writer.WriteLine(str);
            }
            //FlowLayoutPanel a = new FlowLayoutPanel();
            //Button s = new Button();
            //a.Controls.Add(s);
            //proveravac ((4+3*4*53-3)*2-5-3)*3*2+1/2+2*(3-1)-2*2+16-4*3

            //lblispis.Text = str.IzracunajJednacinu();
        }
        public EventHandler OnClick()
        {
            //StackTrace stackTrace = new StackTrace();
            //stackTrace.GetFrame(1).GetMethod();
            return null;
        }
        private void Inicijalizacija()
        {
            string filename = "Izrazi.txt";
            using (StreamReader writer = new StreamReader(filename))
            {
                int n=File.ReadLines(filename).Count();
                Console.WriteLine("ono"+ n );


                for (int i = 0; i < n; i++)
                {
                    Button b = new Button();
                    Size s = new Size(260, 45);
                    b.Size = s;
                    b.Text = writer.ReadLine();
                    b.Click += B_Click;
                    

                    FLP.Controls.Add(b);
                }
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            tbunos.Text = b.Text;
        }
    }
}
