using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Services.Exceptions
{
    class GithubBadVerificationCodeException : Exception
    {
        public GithubBadVerificationCodeException(string message) : base(message)
        {

        }

        public GithubBadVerificationCodeException()
        {

        }
    }
}
