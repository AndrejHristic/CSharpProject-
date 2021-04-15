using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotomathDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnracunaj_Click(object sender, EventArgs e)
        {
            Expression str = new Expression(tbunos.Text);
            lblispis.Text = str.RešiPostfiks(str.InfiksUPostfiks()).ToString();
        }
    }
}
