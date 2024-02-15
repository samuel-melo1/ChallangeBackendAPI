using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendChallengeApi.Exceptions
{
    public class ClienteExistsException : Exception
    {
        public ClienteExistsException(string message)
        : base(message) { }
    }
}
