namespace lab1
{
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
            this.countOfElements = polinom.Length;
        }

        public static Polinom operator +(Polinom firstPolinom, Polinom secondPolinom)
        {
            int minLength, maxLength;
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


        public override string ToString()
        {
            string str = "";
            for (var i = 0; i < countOfElements; i++)
            {
                str += polinom[i].Numerator.ToString() + '/' + '*' + polinom[i].Denominator.ToString() + "x^" + (i + 1).ToString() + (i != countOfElements - 1 ? " + " : " ");
            }
            return str;
        }
    }
}