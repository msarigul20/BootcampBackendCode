using System;

namespace Day4Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> myStudentList = new MyDictionary<int, string>();
            myStudentList.Add(101,"Mustafa");
            myStudentList.Add(102, "Ali");
            myStudentList.Add(103, "Mehmet");
            myStudentList.Print();
            myStudentList.Add(104, "Ayşe");
            myStudentList.Print();
            Console.WriteLine("My List Value Numbers: " + myStudentList.valueCount);
            Console.WriteLine("My List Key Numbers: " + myStudentList.keyCount);
        }
    }
}
