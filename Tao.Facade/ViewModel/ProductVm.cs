using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao.Facade
{
    public class ProductVm
    {
        public string RowGuid { get; set; }
        public string Name { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public int SelledNum { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Modifier { get; set; }
    }
}
