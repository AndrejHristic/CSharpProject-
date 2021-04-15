using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotomathDesktop
{
    class Expression
    {
        private string i;

        public string I
        {
            get { return i; }
            set { i = value; }
        }
        public Expression(string i)
        {
            this.i = i;
        }
        public static bool UporediOperatore(char x, char y)//> (da li je x bitnije)
        {
            if (x == '+' || x == '-')
            {
                return false;//nije veci
            }
            else
            {
                if (y == '*' || y == '/')
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static bool UporediOperatore2(char x, char y)//<= (da li je x manje bitno ili jednako bitno)
        {
            if (x == '+' || x == '-')
            {
                return true;
            }
            else
            {
                if (y == '*' || y == '/')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string InfiksUPostfiks()
        {
            string x = this.i;
            Stack<char> stek = new Stack<char>();
            char[] izraz = x.ToCharArray();
            List<char> pizraz = new List<char>();
            int i = 0;
            while (i < izraz.Length)
            {
                if (izraz[i] >= '0' && izraz[i] <= '9')
                {
                    if (izraz.Length - 1 != i && izraz[i + 1] >= '0' && izraz[i + 1] <= '9')
                    {
                        pizraz.Add(izraz[i]);
                    }
                    else
                    {
                        pizraz.Add(izraz[i]);
                        pizraz.Add(' ');
                    }
                }
                else if (izraz[i] == '(')
                {
                    stek.Push(izraz[i]);
                }
                else if (izraz[i] == ')')
                {
                    while (stek.Count > 0 && stek.Peek() != '(')
                    {
                        pizraz.Add(stek.Pop());
                    }
                    if (stek.Count == 0 || stek.Peek() != '(')
                    {
                        Console.WriteLine("problem1");
                    }
                    else
                    {
                        stek.Pop();
                    }
                }
                else if (izraz[i] == '+' || izraz[i] == '-' || izraz[i] == '*' || izraz[i] == '/')
                {
                    if (stek.Count == 0 || UporediOperatore(izraz[i], stek.Peek()))
                    {
                        stek.Push(izraz[i]);
                    }
                    else
                    {
                        while ((stek.Count > 0 && stek.Peek() != '(' && UporediOperatore2(izraz[i], stek.Peek())))
                        {
                            pizraz.Add(stek.Pop());
                        }
                        stek.Push(izraz[i]);
                    }
                }
                i++;
            }
            while (stek.Count != 0)
            {
                pizraz.Add(stek.Pop());
            }
            string pom = "";
            for (int k = 0; k < pizraz.Count; k++)
            {
                pom += pizraz[k];
            }
            return pom;
        }
        public int RešiPostfiks(string x)
        {
            Stack<int> stek = new Stack<int>();
            char[] izraz = x.ToCharArray();
            int i = 0;
            string broj = "";
            while (i < izraz.Length)
            {
                if (izraz[i] >= '0' && izraz[i] <= '9')
                {
                    if (izraz.Length - 1 != i && izraz[i + 1] >= '0' && izraz[i + 1] <= '9')
                    {
                        broj += izraz[i].ToString();
                    }
                    else
                    {
                        broj += izraz[i].ToString();
                        stek.Push(Convert.ToInt32(broj));
                        broj = "";
                    }
                }
                else if (izraz[i] == '+')
                {
                    int b = stek.Pop();
                    int a = stek.Pop();
                    stek.Push(a + b);
                }
                else if (izraz[i] == '-')//prvo b pa jer ako se malo bolje razmisli onaj na vrhu steka je na desnoj strani operacije, a onaj ispod njega na levoj
                {
                    int b = stek.Pop();
                    int a = stek.Pop();
                    stek.Push(a - b);
                }
                else if (izraz[i] == '*')
                {
                    int b = stek.Pop();
                    int a = stek.Pop();
                    stek.Push(a * b);
                }
                else if (izraz[i] == '/')
                {
                    int b = stek.Pop();
                    int a = stek.Pop();
                    stek.Push(a / b);
                }
                i++;
            }
            Console.WriteLine();
            return Convert.ToInt32(stek.Pop().ToString());
        }
    }
}
