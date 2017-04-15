using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class Product:IAggregateRoot
    {
        public string RowGuid { get; private set; }
        public string Name { get; private set; }
        public string SupplierId { get; private set; }
        public string SupplierName { get; private set; }
        public string ImgUrl { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Category { get; private set; }
        public int SelledNum { get; private set; }
        public DateTime CreateTime { get; private set; }
        public string Creator { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public string Modifier { get; private set; }
        public int IsDel { get; private set; }

        protected Product() {

        }
        public static Product CreateNew(string name,
            string supplierid,
            string suppliername,
            string imgurl,
            decimal price,
            int stock,
            string category,
            int sellednum,
            string creator)
        {
            var product = new Product() {
                Category = category,
                CreateTime = DateTime.Now,
                Creator = creator,
                ImgUrl = imgurl,
                IsDel = 0,
                Modifier = creator,
                Name = name,
                Price = price,
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                SelledNum=sellednum,
                Stock=stock,
                SupplierId=supplierid,
                SupplierName=suppliername,
                UpdateTime=DateTime.Now
            };
            return product;
        }
    }
}
