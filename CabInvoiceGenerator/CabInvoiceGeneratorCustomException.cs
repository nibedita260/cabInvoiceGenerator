using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoiceGeneratorCustomException:Exception
    {
        public enum ExceptionType
        {
            INVALID_COST
        }
        public readonly ExceptionType Type;
        /// <summary>
        /// creating a constructor and passing string message and exception type 
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="message"></param>
        public CabInvoiceGeneratorCustomException(ExceptionType Type, string message) : base(message)
        {
            this.Type = Type;
        }
    }
}
