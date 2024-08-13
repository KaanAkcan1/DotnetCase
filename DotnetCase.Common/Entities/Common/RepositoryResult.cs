using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Common.Entities.Common
{
    public class RepositoryResult<T>
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;

        public List<T> Data { get; set; } = new List<T>();

        public void SetError(string message)
        {
            Success = false;
            Message = message ?? "";
        }
    }
}
