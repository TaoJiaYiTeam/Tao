using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tao.Application;
using Tao.Facade;
using AutoMapper;

namespace Tab.Web.Controllers
{
    public class HomeController : Controller
    {
        private ProductApp _productApp;
        public HomeController(ProductApp productApp)
        {
            _productApp = productApp;
        }
        public ActionResult Index()
        {
            return View();
        }

        #region Product
        public ActionResult Product()
        {
            return View();
        }

        private IEnumerable<ProductVm> getProducts()
        {
            var result = _productApp.GetAll();
            return result;
        }

        [HttpGet]
        public JsonResult InitInfo()
        {

            var result = new
            {
                Products = getProducts(),
                CartsNum = Session["Cart"] != null ? getCartNum(Session["Cart"] as Dictionary<string, int>) : Session["Cart"]
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int getCartNum(Dictionary<string, int> carts)
        {
            var num = 0;
            foreach (var item in carts.Values)
            {
                num += item;
            }
            return num;
        }
        [HttpPost]
        public JsonResult AddToCart(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string,int>;
            if (carts == null || !(carts is Dictionary<string, int>))
            {
                carts = new Dictionary<string, int>();
            }
            if (carts.ContainsKey(RowGuid))
            {
                var cartNum = carts[RowGuid];
                cartNum++;
                carts[RowGuid] = cartNum;
            }
            else {
                carts.Add(RowGuid, 1);
            }
            Session["Cart"] = carts;

            return Json(new { Flag = true });
        }
        #endregion

        #region Cart
        public ActionResult Cart()
        {
            return View();
        }
        public JsonResult GetCarts()
        {
            var result = getCarts();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddNum(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, int>;
            if (carts == null)
            {
                return Json(new { Flag=true});
            }
            carts[RowGuid]++;
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }
        [HttpPost]
        public JsonResult MinusNum(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, int>;
            if (carts == null)
            {
                return Json(new { Flag = true });
            }
            carts[RowGuid]--;
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }
        [HttpPost]
        public JsonResult DeleteCart(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, int>;
            if (carts == null)
            {
                return Json(new { Flag = true });
            }
            carts.Remove(RowGuid);
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }
        private IEnumerable<CartVm> getCarts() {
            var carts = Session["Cart"] as Dictionary<string,int>;
            if (carts == null)
            {
                return default(IEnumerable<CartVm>);
            }
            var keys = new List<string>();
            foreach (var item in carts.Keys)
            {
                keys.Add(item);
            }

            var cartVms =Mapper.Map<IEnumerable<CartVm>>(_productApp.GetAll(keys));
            foreach (var item in cartVms)
            {
                item.Num = carts[item.RowGuid];
                item.Total = item.Price * item.Num;
            }
            return cartVms;
        }
        #endregion

        public ActionResult Order()
        {

            return View();
        }
    }
}