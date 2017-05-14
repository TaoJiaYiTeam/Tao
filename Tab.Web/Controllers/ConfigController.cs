using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tao.Application;
using Tao.Facade;

namespace Tab.Web.Controllers
{
    public class ConfigController : BaseController
    {
        private AdminApp _adminApp;
        private ProductApp _productApp;
        public ConfigController(AdminApp adminApp, ProductApp productApp) {

            _adminApp = adminApp;
            _productApp = productApp;
        }
        // GET: Config
        public ActionResult Index()
        {
            ViewBag.UserName = UserInfo.UserName;
            return View();
        }
      
        public PartialViewResult Menu()
        {

            return PartialView(Menus);
        }




        #region 用户添加

        public ActionResult UserManager()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserList(UserSearchVm search)
        {
            int total;
            var result = _adminApp.GetUserList(search, out total);
            return Json(new { total = total, rows = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertUser(UserVm vm)
        {
            if (string.IsNullOrEmpty(vm.LogonNo))
            {
                return Json(false);
            }
            if (string.IsNullOrEmpty(vm.UserName))
            {
                return Json(false);
            }
            if (string.IsNullOrEmpty(vm.PassWord))
            {
                return Json(false);
            }
            if (string.IsNullOrEmpty(vm.RoleGuid))
            {
                return Json(false);
            }
            return Json(_adminApp.InsertUser(vm));

        }

        [HttpPost]
        public JsonResult DeleteUser(UserVm vm)
        {
            return Json(_adminApp.DeleteUser(vm));
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            return Json(_adminApp.GetRoles(), JsonRequestBehavior.AllowGet);
        }
        #endregion



        public ActionResult Product()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetProductList(UserSearchVm search)
        {
            int total;
            var result = _productApp.GetLists(search,UserInfo, out total);
            return Json(new { total = total, rows = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertProduct(ProductVm vm)
        {
            return Json(_productApp.Insert(vm, UserInfo));

        }

        [HttpPost]
        public JsonResult DeleteProduct(ProductVm vm)
        {
            return Json(_productApp.Detele(vm));
        }

    }
}