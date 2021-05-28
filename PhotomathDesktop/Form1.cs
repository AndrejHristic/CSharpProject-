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
            string pp = "";
            lblispis.Text = str.RešiPostfiks(str.InfiksUPostfiks(),out pp).ToString();
            if(pp=="error")
            {
                lblispis.Text = "undefined";
                return;
            }    
            string filename = "Izrazi.txt";
            using (StreamWriter writer = new StreamWriter(filename, append: true))
            {
                writer.WriteLine(str);
            }
            Button b = new Button();
            Size s = new Size(260, 45);
            b.Size = s;
            b.Text = str.ToString();
            b.Click += B_Click;
            FLP.SuspendLayout();
            FLP.Controls.Add(b);
            FLP.Controls.SetChildIndex(b, 0);
            FLP.ResumeLayout();

            //FlowLayoutPanel a = new FlowLayoutPanel();
            //Button s = new Button();
            //a.Controls.Add(s);
            //proveravac ((4+3*4*53-3)*2-5-3)*3*2+1/2+2*(3-1)-2*2+16-4*3

            //lblispis.Text = str.IzracunajJednacinu();
        }

        private void Inicijalizacija()
        {
            string filename = "Izrazi.txt";
            using (StreamReader reader = new StreamReader(filename))
            {
                int n=File.ReadLines(filename).Count();
                Console.WriteLine("ono"+ n );

                
                for (int i = 0; i < n; i++)
                {
                    Button b = new Button();
                    Size s = new Size(260, 45);
                    b.Size = s;
                    b.Text = reader.ReadLine();
                    if(b.Text=="")
                    {
                        continue;
                    }
                    b.Click += B_Click;

                    FLP.SuspendLayout();
                    FLP.Controls.Add(b);
                    FLP.Controls.SetChildIndex(b, 0);
                    FLP.ResumeLayout();
                }
            }
        }
        private void Brisac()
        {
            FLP.Controls.Clear();
            string filename = "Izrazi.txt";
            using (StreamWriter writer = new StreamWriter(filename, append: false))
            {
                writer.WriteLine("");
            }
        }
        private void B_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            tbunos.Text = b.Text;
        }

        private void btnobriši_Click(object sender, EventArgs e)
        {
            const string message ="Da li želite da izbrišete celu istoriju?";
            const string caption = "Potvrda";
            var result = MessageBox.Show(message, caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Brisac();
            }
        }
    }
}
