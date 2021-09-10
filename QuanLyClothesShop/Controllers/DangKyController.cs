using QuanLyClothesShop.Models;
using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class DangKyController : Controller
    {
        //
        // GET: /DangKy/

        dbQLQADataContext db = new dbQLQADataContext();

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection col)
        {
            var ten = col["txtTen"];
            var diachi = col["txtDiaChi"];
            var gioitinh = col["txtGioiTinh"];
            var email = col["txtEmail"];
            //var sdt = col["txtSDT"];
            var taikhoan = col["txtTaiKhoan"];
            var matkhau = col["txtMatKhau"];
            int loaiTaiKhoan = 2;
            var ktra = db.KHACHHANGs.SingleOrDefault(x => x.TENDN == taikhoan);
            if (ktra != null)
            {
                ViewBag.ktra = "Tài khoản đã tồn tại";
                return View();
            }
            //Kiểm tra ràng buộc
            //if (String.IsNullOrEmpty(ten))
            //{
            //    ViewData["ErrorName"] = "Họ tên không được bỏ trống !";
            //}
            //else if (String.IsNullOrEmpty(diachi))
            //{
            //    ViewData["ErrorAddress"] = "Địa chỉ không được bỏ trống !";
            //}
            //else if (String.IsNullOrEmpty(email))
            //{
            //    ViewData["ErrorEmail"] = "Email không được bỏ trống !";
            //}
            //else if (String.IsNullOrEmpty(gioitinh))
            //{
            //    ViewData["ErrorSex"] = "Giới tính không được bỏ trống !";
            //}
            //else if (String.IsNullOrEmpty(taikhoan))
            //{
            //    ViewData["ErrorAccount"] = "Tên tài khoản không được bỏ trống !";
            //}
            //else if (String.IsNullOrEmpty(matkhau))
            //{
            //    ViewData["ErrorPass"] = "Mật khẩu không được bỏ trống !";
            //}
            //else
            //{
            //Lưu một dòng vào bảng khách hàng
            KHACHHANG kh = new KHACHHANG();
            kh.TENKH = ten;
            kh.DIACHI = diachi;
            kh.GIOITINH = gioitinh;
            kh.EMAIL = email;
            //kh.SDT = sdt;
            kh.TENDN = taikhoan;
            kh.MATKHAU = matkhau;
            db.KHACHHANGs.InsertOnSubmit(kh);
            kh.MALOAITK = loaiTaiKhoan;
            db.SubmitChanges();
            ViewBag.Thongbao = "Đăng Ký Thành Công";
            return this.DangKy();
                //return View(kh);
            //}
            //return View();
        }
    }
}
