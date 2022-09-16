using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Wrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
        public ServiceResponse(T value, bool isSuccess, int statusCode, string message) : base(isSuccess, statusCode, message)
        {
            Value = value;
        }

        public ServiceResponse(T value, bool isSuccess, int statusCode) : base(isSuccess, statusCode)
        {
            Value = value;
        }
    }
}
