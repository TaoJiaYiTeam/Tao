﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;

namespace Tao.IRepository
{
    public interface IProductRepo: IBaseRepository<Product>
    {
        IEnumerable<Product> GetList(UserSearch search,string SupplierName ,out int total);
    }
}
