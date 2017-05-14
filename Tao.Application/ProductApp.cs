using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Facade;
using Tao.IRepository;
using AutoMapper;
using Tao.Domain;

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

        public IEnumerable<ProductVm> GetLists(UserSearchVm search,UserVm user , out int total)
        {
            var users = _productRepo.GetList(Mapper.Map<UserSearch>(search), user.RowGuid, out total);
            var userVms = Mapper.Map<IEnumerable<ProductVm>>(users);
            return userVms;
        }
        public bool Insert(ProductVm vm, UserVm user)
        {
            var model = Product.CreateNew(vm.Name,
                user.RowGuid,
                user.UserName,
                vm.ImgUrl,
                vm.Price,
                vm.Stock,
                vm.Category,
                vm.SelledNum,
                user.UserName);
            var flag = _productRepo.Insert(model);
            return flag;
        }
        public bool Detele(ProductVm vm)
        {
            var product = _productRepo.FindOne(new { RowGuid = vm.RowGuid });
            product.Delete();
            var flag = _productRepo.Update(product);
            return flag;
        }
    }
}
