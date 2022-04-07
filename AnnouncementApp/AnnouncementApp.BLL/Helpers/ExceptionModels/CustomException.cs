using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.BLL.Helpers.ExceptionModels
{
    /// <summary>
    /// exception class, encapsulates message and status code of http error
    /// </summary>
    public class CustomException : Exception
    {
        public int StatusCode { get; }
        public CustomException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
