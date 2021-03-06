using System;

namespace lab1
{
    public class RationalFraction
    {

        private int numerator, denominator;
        public bool isValid;
        public bool IsValid{
            private set => isValid = value;
            get => isValid;
        }
        private double doubleValue;
        public RationalFraction(int numerator, int denominator)
        {
            if(denominator == 0){
                isValid = false;
                return;            
            }
            else
            {
                isValid = true;
            }
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

        private double DoubleValue
        {
            get => doubleValue;
            set => doubleValue = value;

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
            return $"{numerator}/{denominator}"; //numerator.ToString() + '/' + denominator.ToString() + ' ';
        }

        public static RationalFraction operator +(RationalFraction firstFraction, RationalFraction secondFraction)
        {
            int resNumerator, resDenominator;
            resDenominator = firstFraction.Denominator * secondFraction.Denominator;
            resNumerator = firstFraction.Numerator * secondFraction.Denominator
            + secondFraction.Numerator * firstFraction.Denominator;

            return new RationalFraction(resNumerator, resDenominator);
        }

        public static bool operator <(RationalFraction firstFraction, RationalFraction secondFraction)
        {
            bool result = false;
            if(firstFraction.Numerator * secondFraction.Denominator < secondFraction.Numerator * firstFraction.Denominator){
                result = true;
            }
            return result;
        }

        public static bool operator >(RationalFraction firstFraction, RationalFraction secondFraction)
        {
            bool result;
            if(firstFraction.Numerator * secondFraction.Denominator > secondFraction.Numerator * firstFraction.Denominator){
                result = true;
            }
            else{
                result = false;
            }
            return result;
        }



    }
}