using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    class EndOfProgramException : Exception
    {
        /**
        * \brief The EndOfProgramException method is the default constructor for the exception.
        * 
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return n/a
        */
        public EndOfProgramException()
        {

        }

        /**
        * \brief The EndOfProgramException method is an overloaded constructor for the exception. 
        * This method takes a message that will be displayed when an exception is thrown.
        * 
        * \details <b>Details</b>
        * 
        * \param message <b>string</b> - The message to display when the exception is thrown
        * 
        * \return n/a
        */
        public EndOfProgramException(String message) : base(message)
        {

        }
    }
}
