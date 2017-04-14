using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao.Domain
{
    public class Product:IAggregateRoot
    {
        public string RowGuid { get; set; }
        public string Name { get; set; }
        //public DateTime CreateTime { get; set; }
        //public string Creator { get; set; }
        //public DateTime UpdateTime { get; set; }
        //public string Modifier { get; set; }
    }
}
