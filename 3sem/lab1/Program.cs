using System;
using System.Collections.Generic;

namespace lab1
{
    class RationalFraction{
        int m,n;
        RationalFraction(int m, int n){
            this.m = m;
            this.n = n; 
        }
    }

    class SetOfFractions{
        HashSet<RationalFraction> set = new HashSet<RationalFraction>();
        RationalFraction maxFraction = null;
        RationalFraction minFraction = null; 

        SetOfFractions(){
        }

        void add(RationalFraction fraction){
            if(maxFraction != 0 )
            set.Add(fraction);

        }


    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
