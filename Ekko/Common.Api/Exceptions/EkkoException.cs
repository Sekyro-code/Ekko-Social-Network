using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Common.Api.Exceptions
{
    public class EkkoException : Exception
    {
        public string? Code { get; }
        public string? Title { get; }
        public IDictionary<string, List<string>>? Errors { get; }

        public EkkoException() : base() { }

        public EkkoException(string code)
        {
            Code = code;  
        }

        public EkkoException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public EkkoException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public EkkoException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public EkkoException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

        public EkkoException(string code, string title, IDictionary<string, List<string>> errors)
        {
            Code = code;
            Title = title;
            Errors = errors;
        }

    }
}
