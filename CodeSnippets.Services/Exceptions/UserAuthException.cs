using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Services.Exceptions
{
    public class UserAuthException : Exception
    {
        public UserAuthException(string message) : base(message)
        {

        }

        public UserAuthException()
        {

        }
    }
}
