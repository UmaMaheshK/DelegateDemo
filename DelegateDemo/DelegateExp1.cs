using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class DelegateExp1
    {
        public delegate void Del(string message);
        static void Main(string[] args)
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod;

            // Call the delegate.
            handler("Hello World");//Hello World

            MethodWithCallback(1, 2, handler);//The number is: 3

            MethodClass obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            //Both types of assignment are valid.
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;
            //remove Method1
            allMethodsDelegate -= d1;

            // copy AllMethodsDelegate while removing d2
            Del oneMethodDelegate = allMethodsDelegate - d2;

            int invocationCount = d1.GetInvocationList().GetLength(0);
        }
        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
    }
    public class MethodClass
    {
        public void Method1(string message) { }
        public void Method2(string message) { }
    }
}
