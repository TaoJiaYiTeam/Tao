using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao.Facade
{
    public class CartVm
    {
        public CartVm() {
            Selected = false;
            Total = 0;
        }
        public bool Selected { get; set; }
        public string RowGuid { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Num { get; set; }
        public int SelledNum { get; set; }
        public decimal Total { get; set; }
    }
}
