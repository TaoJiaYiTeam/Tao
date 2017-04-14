using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tao.IRepository;
using Tao.Repository;
using Tao.Domain;
using AutoMapper;

namespace Apptest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.Initialize(o =>
            {
                o.AddProfile<ModelProfiles>();

            });

            IProductRepo _proRepo = new ProductRepo();
            var result=_proRepo.Insert(new Product { RowGuid = Guid.NewGuid().ToString(), Name = "拉提" });
        }
        public T EnCoding<T>(T entity)
        {
            var type = typeof(T);
            foreach (var item in type.GetProperties())
            {
                //通过反射出来值，然后加密后，再重新赋值。
               item.SetValue(entity, Encoding(item.GetValue(entity).ToString()));
            }
            return entity;
        }
        public string Encoding(string str)
        {
            return null;
        }
    }
}
