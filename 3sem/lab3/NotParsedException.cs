using System;

namespace lab3{
    public class  NotParsedException : Exception{

        public NotParsedException(string message):base(message){}
    }
}