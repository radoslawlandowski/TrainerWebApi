using System;

namespace TrainerWebApi.Exceptions
{
    public class NoSuchUserException : Exception
    {
        public NoSuchUserException(string message) : base(message)
        {
        }
    }
}