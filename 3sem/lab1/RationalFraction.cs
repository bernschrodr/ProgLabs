using System;

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
            int resNumerator, resDenominator;
            resDenominator = firstFraction.Denominator * secondFraction.Denominator;
            resNumerator = firstFraction.Numerator * secondFraction.Denominator
            + secondFraction.Numerator * firstFraction.Denominator;

            return new RationalFraction(resNumerator, resDenominator);
        }




    }
}