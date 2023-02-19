using System;

namespace Zoo
{
    public class AnimalException : Exception
    {
        public AnimalException(string message) : base(message)
        { }
    }
}