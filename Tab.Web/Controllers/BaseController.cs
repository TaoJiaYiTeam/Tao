using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tab.Web.Filters;
using Tao.Facade;

namespace Tab.Web.Controllers
{
    [CustomAction(Order = 1)]
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {

        }

        private string username = string.Empty;

        public UserVm UserInfo
        {
            get { return Session["User"] as UserVm; }
        }
        public RoleVm Role
        {
            get
            {

                return Session["Role"] as RoleVm;
            }
        }
        public IEnumerable<MenuVm> Menus
        {
            get
            {
                var result = Session["Menu"] as IEnumerable<MenuVm>;
                return result ?? new List<MenuVm>();
            }
        }
    }
}