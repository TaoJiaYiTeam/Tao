using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string Name { get; set; }
        //public DateTime CreateTime { get; set; }
        //public string Creator { get; set; }
        //public DateTime UpdateTime { get; set; }
        //public string Modifier { get; set; }
    }
}
