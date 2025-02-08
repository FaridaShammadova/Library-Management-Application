using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library__Management_Application.PB503Exceptions
{
    public class InvalidException : Exception
    {
        public InvalidException()
        {
        }

        public InvalidException(string message) : base(message)
        {
        }
    }
}