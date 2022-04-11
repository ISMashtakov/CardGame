using System;

namespace CardGame.Web.Exceptions
{
    public class MoreThanTwoClientsException : Exception { }

    public class DisconnectFromUnexistClientException : Exception { }

    public class ProblemWithServerException : Exception
    {
        public ProblemWithServerException(string message) : base(message) { }
    }
}
