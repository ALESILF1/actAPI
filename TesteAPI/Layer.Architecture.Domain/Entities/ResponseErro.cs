using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.Entities
{
    public class ResponseErro
    {
        public bool Sucesso { get; set; }
        public string[] Erros { get; set; }
    }
}
