using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Result
{
    public interface IResult
    {
        public int Status { get; }
        public List<string> Message { get; }
        public string Exception { get; }
    }
}
