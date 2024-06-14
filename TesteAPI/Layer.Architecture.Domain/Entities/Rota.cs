using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.Entities
{
    public class Rota : BaseEntity
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Cost { get; set; }
        
        
    }
}
