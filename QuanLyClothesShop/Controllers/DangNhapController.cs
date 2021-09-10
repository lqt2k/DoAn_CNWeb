using QuanLyClothesShop.Models;
using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class DangNhapController : Controller
    {
        //
        // GET: /DangNhap/

        dbQLQADataContext db = new dbQLQADataContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection form)
        {
            Session["tk"] = null;
            var tk = form["tk"];
            var mk = form["mk"];
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TENDN == tk && n.MATKHAU == mk && n.MALOAITK == 2);
            KHACHHANG kh2 = db.KHACHHANGs.SingleOrDefault(n => n.TENDN == tk && n.MATKHAU == mk && n.MALOAITK == 1);
            if (kh != null)
            {

                Session["tk"] = kh.TENKH;
                Session["TaiKhoan"] = kh;
                return RedirectToAction("SanPhamPartial", "SanPham");
            }
            if (kh2 != null)
            {
                Session["tk"] = kh2.TENKH;
                Session["TaiKhoan"] = kh2;
                return RedirectToAction("DanhSachSanPham", "Admin");
            }
            ViewBag.Thongbao = "Tài khoản mật khẩu không chính xác ";
            return View("DangNhap");
 
        }

        

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DangNhap", "DangNhap");
        }

        public ActionResult DangNhapPartial()
        {
            return PartialView();
        }

    }
}
