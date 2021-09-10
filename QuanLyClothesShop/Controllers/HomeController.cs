using QuanLyClothesShop.Models;
using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        dbQLQADataContext db = new dbQLQADataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeLayout()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult TaiKhoanNULL()
        {
            return View();
        }

    }
}
