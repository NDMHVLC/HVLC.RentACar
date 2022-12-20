using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Result
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }

        public int Status { get; }

        public List<string> Message { get; }

        public string Exception { get; }


        public DataResult(int status, T data, List<string> message)
        {
            Status = status;
            Data = data;
            Message = message;
        }

        public DataResult(int status, T data, List<string> message, Exception exception)
        {
            Status = status;
            Data = data;           
            Message = message;
            Exception = exception.Message;
        }
        
    }
}
