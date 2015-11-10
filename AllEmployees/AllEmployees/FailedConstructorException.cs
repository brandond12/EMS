using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class FailedConstructorException : Exception
    {
        /**
        * \breif default constructor. Create a FailedConstructorException with base Exception class
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public FailedConstructorException()
        {

        }

        /**
        * \breif overloaded constructor. Create a FailedConstructorException with base Exception class and message
        *
        * \details <b>Details</b>
        *
        * \param message <b>string</b> - the message to be attached to the exception
        *
        * \return  n/a
        */
        public FailedConstructorException(string message)
            : base(message)
        {

        }
    }
}
