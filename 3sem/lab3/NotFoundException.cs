using System;
namespace lab3{
    public class NotFoundException : Exception{
        public NotFoundException(string message):base(message){}
    }
}