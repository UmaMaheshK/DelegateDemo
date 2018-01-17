using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    delegate int ArthDel(int a, int b);

    class DelegateWithParameters
    {
        static void Main(string[] args)
        {
            //CallingMethods(new Program().NormalMethod);
            ArthDel a = new ArthDel(Add);

            a += Sub;
            a += Mult;
            a += Mod;
            Console.WriteLine("Result := {0}", a(20, 10));

            a -= Sub;
            a -= Mult;
            a -= Mod;
            a -= Add;
            if (a != null)
            {
                a(30, 10);
            }

            //int count = a.GetInvocationList().GetLength(0);
            foreach (ArthDel item in a.GetInvocationList())
            {
                item(30, 10);
                Console.WriteLine("Testing...");
            }
        }

        static void CallingMethods(FirstDel del)
        {
            del();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Mult(int x, int y)
        {
            return x * y;
        }
        static int Sub(int x, int y)
        {
            return x - y;
        }
        static int Mod(int x, int y)
        {
            return x % y;
        }
    }
}
