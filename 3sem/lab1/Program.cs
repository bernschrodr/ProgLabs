using System;
using System.Collections.Generic;

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


    }

    public class SetOfFractions
    {
        HashSet<RationalFraction> set = new HashSet<RationalFraction>();
        Dictionary<int, int> moreThan = new Dictionary<int, int>();
        Dictionary<int, int> lessThan = new Dictionary<int, int>();
        RationalFraction maxFraction;
        RationalFraction minFraction;

        protected bool changed;

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

        public SetOfFractions()
        {
            maxFraction = null;
            minFraction = null;
            changed = false;
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
        }
    }
}
