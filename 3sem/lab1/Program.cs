using System;
using System.IO;

namespace lab1
{   

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            SetOfFractions set = new SetOfFractions();
            set.add(new RationalFraction(1, 5));
            set.add(new RationalFraction(1, 5));
            set.add(new RationalFraction(1, 5));
            set.add(new RationalFraction(12, 5));
            set.add(new RationalFraction(1, 10));
            Console.WriteLine(set.countLessThan(new RationalFraction(1, 100)));
            Console.WriteLine(set.countMoreThan(new RationalFraction(1, 100)));
            Console.WriteLine(set.countLessThan(new RationalFraction(1, 100)));
            Console.WriteLine(set.countMoreThan(new RationalFraction(1, 100)));
            set.add(new RationalFraction(4, 32));
            set.add(new RationalFraction(1, 3));
            Console.WriteLine(set.countLessThan(new RationalFraction(1, 100)));
            Console.WriteLine(set.countMoreThan(new RationalFraction(1, 100)));
            Console.WriteLine(set.countMoreThan(new RationalFraction(1, 100)));

            StreamReader sr = new StreamReader("input.txt");
            SetOfFractions setFromFile = new SetOfFractions(sr);
            Console.WriteLine(setFromFile.countLessThan(new RationalFraction(1, 100)));
            Console.WriteLine(setFromFile.countMoreThan(new RationalFraction(1, 100)));
            Console.WriteLine(setFromFile.countLessThan(new RationalFraction(1, 100)));
            Console.WriteLine(setFromFile.countMoreThan(new RationalFraction(1, 100)));

            Polinom firstPolinom = new Polinom(setFromFile);
            Polinom secondPolinom = new Polinom(set);
            Polinom resPolinom = firstPolinom + secondPolinom;
            string strPolinom = resPolinom.ToString();
            Console.WriteLine(strPolinom);
        }
    }
}
