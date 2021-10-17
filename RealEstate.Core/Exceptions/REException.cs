using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.Exceptions
{
    public abstract class REException : Exception
    {
        public abstract System.Net.HttpStatusCode HttpCode { get; }
        public abstract string ErrorMessage { get; }
        public List<string> ErrorDetails { get; private set; }
        public REException() : this(string.Empty)
        {

        }
        public REException(string errorMessage) : this(errorMessage, null)
        {

        }
        public REException(List<string> errorDetails) : this(null, errorDetails)
        {

        }
        private REException(string errorMessage, List<string> errorDetails) : base(errorMessage)
        {
            this.ErrorDetails = errorDetails;

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                this.ErrorDetails = new List<string>() { errorMessage };
            }
        }
    }
}
