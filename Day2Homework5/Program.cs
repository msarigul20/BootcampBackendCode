using System;

namespace Day2Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c = 30;
            a = b;
            Console.WriteLine("a:" + a + " b:" + b + " c:" + c);
            Console.WriteLine("---");
            b = c;
            Console.WriteLine("a:" + a + " b:" + b + " c:" + c);
            Console.WriteLine("---");
            c = 40;
            Console.WriteLine("a:" + a + " b:" + b + " c:" + c);
            Console.WriteLine("---");
            a = c;
            Console.WriteLine("a:" + a + " b:" + b + " c:" + c);
            Console.WriteLine("---");

            //Yukarıdaki Kodun çıktısı nedir?
        }
    }
}
