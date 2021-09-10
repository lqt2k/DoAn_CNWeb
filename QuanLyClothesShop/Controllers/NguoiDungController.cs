using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/

        dbQLQADataContext db = new dbQLQADataContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThongTin()
        {
            KHACHHANG khach = (KHACHHANG)Session["TaiKhoan"];           
            //KHACHHANG kh = db.KHACHHANGs.Single(k => k.MAKH == makh);
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            return View(khach);
        }

        public ActionResult ThongTinPartial()
        {         
            return PartialView();
        }

    }
}
