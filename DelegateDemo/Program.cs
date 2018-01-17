using System;

namespace DelegateDemo
{
    public delegate void FirstDel();

    class Program
    {
        static void Main(string[] args)
        {
            Program g = new Program();
            g.NormalMethod();
            Method1();
            Method2();
            //Way 1
            FirstDel f = new FirstDel(new Program().NormalMethod);
            f();
            //Way 2
            f.Invoke();

            FirstDel f2 = new Program().NormalMethod;
            f2();
            Console.WriteLine(new string('*', 15));
            Console.WriteLine("MultCasting");
            Console.WriteLine(new string('*', 15));
            Console.WriteLine();

            FirstDel f3 = Method1;
            f3 += Method2;
            f3 += new Program().NormalMethod;
            f3 -= new Program().NormalMethod;
            f3();

        }

        public void NormalMethod()
        {
            Console.WriteLine("Normal Method");
        }

       public static void Method1()
        {
            Console.WriteLine("Method1");
        }
        static void Method2()
        {
            Console.WriteLine("Method2");
        }
    }
}
