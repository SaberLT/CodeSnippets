using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {

        }

        public UserNotFoundException()
        {

        }
    }
}
