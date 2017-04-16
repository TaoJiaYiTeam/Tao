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
            var carts = Session["Cart"] as Dictionary<string,CartVm>;
            if (carts == null || !(carts is Dictionary<string, CartVm>))
            {
                carts = new Dictionary<string, CartVm>();
            }
            if (carts.ContainsKey(RowGuid))
            {
                var cartNum = carts[RowGuid].Num;
                cartNum++;
                carts[RowGuid].Num = cartNum;
            }
            else {
                var product = _productApp.FindOne(RowGuid);
                if (product != null)
                {
                    product.Total = product.Num * product.Price;
                    carts.Add(RowGuid, product);
                }
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
        public JsonResult ChangeSelected(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, CartVm>;
            if (carts == null)
            {
                return Json(new { Flag = true });
            }
            carts[RowGuid].Selected = !carts[RowGuid].Selected;
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }

        [HttpPost]
        public JsonResult ChangeAllSelected(bool status)
        {
            var carts = Session["Cart"] as Dictionary<string, CartVm>;
            if (carts == null)
            {
                return Json(new { Flag = true });
            }
            foreach (var item in carts.Values)
            {
                item.Selected = status;
            }
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }

        [HttpPost]
        public JsonResult AddNum(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, CartVm>;
            if (carts == null)
            {
                return Json(new { Flag=true});
            }
            carts[RowGuid].Num++;
            carts[RowGuid].Total = carts[RowGuid].Price * carts[RowGuid].Num;
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }
        [HttpPost]
        public JsonResult MinusNum(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, CartVm>;
            if (carts == null)
            {
                return Json(new { Flag = true });
            }
            carts[RowGuid].Num--;
            carts[RowGuid].Total = carts[RowGuid].Price * carts[RowGuid].Num;
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }
        [HttpPost]
        public JsonResult DeleteCart(string RowGuid)
        {
            var carts = Session["Cart"] as Dictionary<string, CartVm>;
            if (carts == null)
            {
                return Json(new { Flag = true });
            }
            carts.Remove(RowGuid);
            Session["Cart"] = carts;
            return Json(new { Flag = true });
        }
        private IEnumerable<CartVm> getCarts() {
            var carts = Session["Cart"] as Dictionary<string,CartVm>;
            if (carts == null)
            {
                return default(IEnumerable<CartVm>);
            }

            var cartVms = new List<CartVm>();
            foreach (var item in carts.Values)
            {
              
                cartVms.Add(item);
            }
            return cartVms;
        }
        #endregion


        #region Order
        public ActionResult Order()
        {

            return View();
        }
        [HttpGet]
        public JsonResult GetSelectProduct()
        {
            var carts = Session["Cart"] as Dictionary<string, CartVm>;
            if (carts == null)
            {
                return Json(default(IEnumerable<CartVm>),JsonRequestBehavior.AllowGet);
            }
            var cartVms =new List<CartVm>();
            foreach (var item in carts.Values)
            {
                if (item.Selected)
                {
                    cartVms.Add(item);
                }
            }
            return Json(new { Products = cartVms , TotalPrice =cartVms.Sum(o=>o.Total)} , JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}