using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Facade;
using Tao.IRepository;
using AutoMapper;

namespace Tao.Application
{
    public class ProductApp
    {
        private IProductRepo _productRepo;
        public ProductApp(IProductRepo productReopo)
        {
            _productRepo = productReopo;
        }
        public IEnumerable<ProductVm> GetAll()
        {
            var products = _productRepo.FindAll(new { IsDel = 0 });
            var result = Mapper.Map<IEnumerable<ProductVm>>(products);
            return result;
        }
        public IEnumerable<ProductVm> GetAll(List<string> keys)
        {
            var products = _productRepo.FindAll("where RowGuid in @Keys", new { Keys = keys });
            var result = Mapper.Map<IEnumerable<ProductVm>>(products);
            return result;
        }
        public CartVm FindOne(string RowGuid)
        {
            var product=_productRepo.FindOne(new { RowGuid = RowGuid });
            var productVm = Mapper.Map<ProductVm>(product);
            return Mapper.Map<CartVm>(productVm);
        }
    }
}
