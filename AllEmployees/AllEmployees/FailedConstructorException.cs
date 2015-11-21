/*
* FILE   : ContractEmployee.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the FailedConstructorException class. This is used for exceptions
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// \class FailedConstructorException
    ///
    /// \brief <b>Brief Description</b>
    /// The FailedConstructorException is a exception that will be thrown if the object the constructor creates is not a valid employee.
    /// FailedConstructorException is a child of the Exception class.
    ///
    /// \author <i>Brandon</i>
    public class FailedConstructorException : Exception
    {
        /**
        * \brief default constructor. Create a FailedConstructorException with base Exception class
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
        * \brief overloaded constructor. Create a FailedConstructorException with base Exception class and message
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
