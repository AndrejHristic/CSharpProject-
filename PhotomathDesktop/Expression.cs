using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotomathDesktop
{
    class Expression
    {
        struct Celina
        {
           public string celina;
           public bool imaNEpoznatu;
        }
        enum strana { leva, desna };


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


        public bool UporediOperatore(char x, char y)//> (da li je x bitnije)
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
        public bool UporediOperatore2(char x, char y)//<= (da li je x manje bitno ili jednako bitno)
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
        public string InfiksUPostfiks(string a)
        {
            string x = a;
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
        public override string ToString()
        {
            return i;
        }

        /*public string IzracunajJednacinu()
        {
            char[] jednacina = this.i.ToCharArray();
            List<Celina> levaStrana = new List<Celina>();// nepoznate
            List<Celina> desnaStrana = new List<Celina>();// poznate tj. konstante
            int i;
            strana switcher = strana.leva;
            Celina c;
            c.celina="";
            c.imaNEpoznatu = false;

            //PRVI DEO: CEPKANJE U CELINE
            
            for (i = 0; i < jednacina.Length; i++)
            {
                if(jednacina[i]=='=')
                {
                    if(i==0)
                    {
                        Console.WriteLine("greska: znak jednako na pocetku!");
                        break;
                    }
                    Console.WriteLine($"vrednost iteratora pri manjanju strane: {i}");
                    if (switcher == strana.leva)
                    {
                        levaStrana.Add(c);
                    }
                    else
                    {
                        desnaStrana.Add(c);
                    }
                    c.celina = "";
                    c.imaNEpoznatu = false;
                    switcher = strana.desna;

                }
                else if(jednacina[i] >= '0' && jednacina[i] <= '9')
                {
                    if(jednacina.Length - 1 == i)
                    {
                        c.celina += jednacina[i];
                        if (switcher == strana.leva)
                        {
                            levaStrana.Add(c);
                        }
                        else
                        {
                            desnaStrana.Add(c);
                        }
                        c.celina = "";
                        Console.WriteLine("kraj");
                        break;
                    }
                    if (jednacina[i + 1] >= '0' && jednacina[i + 1] <= '9')
                    {
                        c.celina+=jednacina[i];
                        continue;
                    }
                    else
                    {
                        c.celina += jednacina[i];
                    }    
                }
                else if (jednacina[i] == '+' || jednacina[i] == '-')
                {
                    if(i!=0)
                    {
                        if(switcher==strana.leva)
                        {
                            levaStrana.Add(c);
                        }
                        else
                        {
                            desnaStrana.Add(c);
                        }    
                        c.celina = "";
                        c.imaNEpoznatu = false;
                    }
                    c.celina += jednacina[i];
                }
                else if (jednacina[i] == '*' || jednacina[i] == '/')
                {
                    if (i == 0)
                    {
                        Console.WriteLine("greska: operator * ili / na pocetku");
                        break;
                    }
                    if(c.celina=="")
                    {
                        Console.WriteLine("greska: operator pokusava da bude pocetak celine");
                    }
                    c.celina += jednacina[i];
                }
                else if (jednacina[i] >= 'a' && jednacina[i] <= 'z')
                {
                    if (jednacina.Length - 1 == i)
                    {
                        c.celina += jednacina[i];
                        c.imaNEpoznatu = true;
                        if (switcher == strana.leva)
                        {
                            levaStrana.Add(c);
                        }
                        else
                        {
                            desnaStrana.Add(c);
                        }
                        c.celina = "";
                        Console.WriteLine("kraj");
                        break;
                    }
                    c.celina += jednacina[i];
                    c.imaNEpoznatu = true;
                }
            }
            Console.WriteLine("leva");
            for (int j = 0; j < levaStrana.Count; j++)
            {
                Console.WriteLine(levaStrana[j].celina);
            }
            Console.WriteLine("desna");
            for (int j = 0; j < desnaStrana.Count; j++)
            {
                Console.WriteLine(desnaStrana[j].celina);
            }

            //DRUGI DEO: SREĐIVANJE STRANA (NA LEVU CELINE SA X-om, A NA DESNU BEZ)

            for (i = 0; i < desnaStrana.Count; i++)
            {
                if(desnaStrana[i].imaNEpoznatu)
                {
                    levaStrana.Add(desnaStrana[i]);
                    desnaStrana.RemoveAt(i);
                }
            }
            for (i = 0; i < levaStrana.Count; i++)
            {
                if (!levaStrana[i].imaNEpoznatu)
                {
                    desnaStrana.Add(levaStrana[i]);
                    levaStrana.RemoveAt(i);
                }
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("leva");
            for (int j = 0; j < levaStrana.Count; j++)
            {
                Console.WriteLine(levaStrana[j].celina);
            }
            Console.WriteLine("desna");
            for (int j = 0; j < desnaStrana.Count; j++)
            {
                Console.WriteLine(desnaStrana[j].celina);
            }

            //TREĆI DEO: IZVLAČENJE X-a SA LEVE STRANE I RAČUNANJE IZRAZA SA DESNE STRANE

            string exp="";
            for (i = 0; i < desnaStrana.Count; i++)
            {
                exp += desnaStrana[i].celina;
            }
            int ds=RešiPostfiks(InfiksUPostfiks(exp));
            exp = "";
            for (i = 0; i < levaStrana.Count; i++)
            {
                exp += levaStrana[i].celina;
            }
            //var exp.ToCharArray();
            //for (i = 0; i < ; i++)
           // {

           // }
            






            return "";
        }*/
    }
}
