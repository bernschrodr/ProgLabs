using System;
using System.Collections.Generic;
using System.IO;

namespace lab1
{
    public class RationalFraction
    {

        private int numerator, denominator;
        private double doubleValue;
        public RationalFraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.doubleValue = (double)numerator / denominator;
        }

        public int Numerator
        {
            private set => numerator = value;
            get => numerator;
        }
        public int Denominator
        {
            private set => denominator = value;

            get => denominator;
        }

        public double DoubleValue
        {
            get => doubleValue;
            private set => doubleValue = value;

        }

        public override bool Equals(Object obj)
        {
            return this.denominator.Equals(((RationalFraction)obj).denominator)
               && this.numerator.Equals(((RationalFraction)obj).numerator);
        }

        public override int GetHashCode()
        {
            return this.doubleValue.GetHashCode();
        }

        public override string ToString()
        {
            return numerator.ToString() + '/' + denominator.ToString() + ' ';
        }

        public static RationalFraction operator +(RationalFraction firstFraction, RationalFraction secondFraction)
        {
            int resNumerator,resDenominator;
            resDenominator = firstFraction.Denominator * secondFraction.Denominator;
            resNumerator = firstFraction.Numerator * resDenominator / firstFraction.Denominator 
            + secondFraction.Numerator * resDenominator / secondFraction.Denominator;

            return new RationalFraction(resNumerator,resDenominator);
        }




    }

    public class SetOfFractions
    {
        HashSet<RationalFraction> set;
        public HashSet<RationalFraction> Set
        {
            get => set;
            protected set => set = value;
        }

        Dictionary<int, int> moreThan = new Dictionary<int, int>();
        Dictionary<int, int> lessThan = new Dictionary<int, int>();
        RationalFraction maxFraction;
        RationalFraction minFraction;

        protected bool changed;

        public SetOfFractions()
        {
            maxFraction = null;
            minFraction = null;
            changed = false;
            Set = new HashSet<RationalFraction>();
        }

        public SetOfFractions(StreamReader sr)
        {
            maxFraction = null;
            minFraction = null;
            changed = false;
            Set = new HashSet<RationalFraction>();

            string input = sr.ReadToEnd();
            char[] delimiterChars = { ' ', ':', '\r', '\n', '/', '\\' };
            string[] splitedFractions = input.Split(delimiterChars);
            int lastElementNumber = splitedFractions.Length - splitedFractions.Length % 2;
            for (var i = 0; i < lastElementNumber - 1; i += 2)
            {
                int numerator = 0;
                int denominator = 0;
                if (!Int32.TryParse(splitedFractions[i], out numerator))
                {
                    System.Console.WriteLine("Bad symbol in file!");
                    continue;
                }
                else
                {
                    if (!Int32.TryParse(splitedFractions[i + 1], out denominator))
                    {
                        System.Console.WriteLine("Bad symbol in file!");
                        continue;
                    }

                    set.Add(new RationalFraction(numerator, denominator));
                }

            }
        }

        public int countMoreThan(RationalFraction fraction)
        {
            int count = 0;
            if (!changed)
            {
                if (moreThan.TryGetValue(fraction.GetHashCode(), out count))
                    return count;
            }
            else
            {
                moreThan.Clear();
                lessThan.Clear();
                changed = false;
            }

            foreach (var fract in this.set)
            {
                if (fract.DoubleValue > fraction.DoubleValue)
                    count++;
            }

            moreThan.Add(fraction.GetHashCode(), count);
            return count;
        }

        public int countLessThan(RationalFraction fraction)
        {
            int count = 0;
            if (!changed)
            {
                if (lessThan.TryGetValue(fraction.GetHashCode(), out count))
                    return count;
            }
            else
            {
                moreThan.Clear();
                lessThan.Clear();
                changed = false;
            }

            foreach (var fract in this.set)
            {
                if (fract.DoubleValue < fraction.DoubleValue)
                    count++;
            }

            lessThan.Add(fraction.GetHashCode(), count);
            return count;
        }

        public void add(RationalFraction fraction)
        {
            if (maxFraction != null && maxFraction != null)
            {
                set.Add(fraction);
                changed = true;
                if (fraction.DoubleValue < minFraction.DoubleValue)
                    minFraction = fraction;
                if (fraction.DoubleValue > maxFraction.DoubleValue)
                    maxFraction = fraction;
            }
            else
            {
                set.Add(fraction);
                changed = true;
                maxFraction = fraction;
                minFraction = fraction;
            }

        }

        public override string ToString()
        {
            string str = "";
            foreach (var fract in this.set)
            {
                str += fract.ToString() + ' ';
            }
            return str;
        }


    }

    public class Polinom
    {
        public int countOfElements = 0;
        int constant = 0;

        RationalFraction[] polinom;

        public Polinom(SetOfFractions set, int constant = 0)
        {
            this.constant = constant;
            this.countOfElements = set.Set.Count;
            polinom = new RationalFraction[countOfElements];
            int i = 0;
            foreach (var fract in set.Set)
            {
                polinom[i++] = fract;
            }
        }

        public Polinom(RationalFraction[] polinom, int constant = 0)
        {
            this.polinom = polinom;
        }

        public static Polinom operator +(Polinom firstPolinom, Polinom secondPolinom)
        {
            int minLength,maxLength;
            Polinom largerPolinom;
            if (firstPolinom.countOfElements > secondPolinom.countOfElements)
            {
                maxLength = firstPolinom.countOfElements;
                minLength = secondPolinom.countOfElements;
                largerPolinom = firstPolinom;
            }
            else
            {
                maxLength = secondPolinom.countOfElements;
                minLength = firstPolinom.countOfElements;
                largerPolinom = secondPolinom;
            }

            RationalFraction[] resPolinom = new RationalFraction[maxLength];
            for (var i = 0; i < minLength; i++)
            {
                resPolinom[i] = firstPolinom.polinom[i] + secondPolinom.polinom[i];
            }


            for (var i = minLength; i < maxLength; i++)
            {
                resPolinom[i] = largerPolinom.polinom[i];
            }
            return new Polinom(resPolinom);
        }

    }

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
         }
    }
}
