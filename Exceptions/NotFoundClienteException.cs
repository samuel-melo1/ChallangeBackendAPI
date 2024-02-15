using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendChallengeApi.Exceptions
{
    public class NotFoundClienteException : Exception
    {
        public NotFoundClienteException(string message)
      : base(message) { }
    }
}
