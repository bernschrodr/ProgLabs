
using System.Collections.Generic;
using System;
using System.IO;

namespace lab1
{
    public class SetOfFractions
    {
        List<RationalFraction> set;
        public List<RationalFraction> Set
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
            Set = new List<RationalFraction>();
        }

        public SetOfFractions(StreamReader sr)
        {
            maxFraction = null;
            minFraction = null;
            changed = false;
            Set = new List<RationalFraction>();

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
}