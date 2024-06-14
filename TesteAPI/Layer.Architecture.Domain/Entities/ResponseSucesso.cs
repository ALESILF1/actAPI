using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.Entities
{
    public class ResponseSucesso<T>
    {
        public bool Sucesso { get; set; }
        public T Data { get; set; }
    }
}
