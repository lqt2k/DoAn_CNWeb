using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class LienHeController : Controller
    {
        //
        // GET: /LienHe/
        dbQLQADataContext db = new dbQLQADataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LienHePatial()
        {
            return View();
        }

    }
}
