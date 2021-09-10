using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
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
        public ActionResult DangNhap(FormCollection col)
        {
            string taiKhoan = col["txtTaiKhoan"];
            string matKhau = col["txtMatKhau"];
            KHACHHANG khach = db.KHACHHANGs.SingleOrDefault(k => k.TENDN == taiKhoan && k.MATKHAU == matKhau && k.MALOAITK == 1);
            if (khach == null) //không thành công
            {
                ViewBag.tb = "Thông tin đăng nhập sai";
                return View();
            }
            Session["kh"] = khach;
            return RedirectToAction("DanhSachSanPham", "Admin");
        }

        public ActionResult DangXuat()
        {
            Session["kh"] = null;
            return RedirectToAction("DangNhap","DangNhap");
        }
        public ActionResult DanhSachSanPham()
        {
            List<SANPHAM> dssp = db.SANPHAMs.ToList();
            return View(dssp);
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.MaNhaSanXuat = new SelectList(db.NHASANXUATs.ToList(), "MANSX", "TENNSX");
            ViewBag.MaLoaiSanPham = new SelectList(db.LOAIs.ToList(), "MALOAI", "TENLOAI");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham_KQ(FormCollection col, HttpPostedFileBase fup)
        {
            string ten = col["txtTen"];
            int gia = Convert.ToInt32(col["txtGia"].ToString().Trim());
            string hinhMinhHoa = col["fup"];
            int loaiSP = int.Parse(col["MaLoaiSanPham"]);
            int loaiNSX = int.Parse(col["MaNhaSanXuat"]);
            //Lưu một dòng vào bảng sản phẩm
            SANPHAM sp = new SANPHAM();
            sp.TENSP = ten;
            sp.DONGIA = gia;
            sp.HINHANH = hinhMinhHoa;
            sp.MALOAI = loaiSP;
            sp.MANSX = loaiNSX;
            db.SANPHAMs.InsertOnSubmit(sp);
            db.SubmitChanges();
            return View(sp); 
        }
        public ActionResult ChiTietSanPham(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(item => item.MASP == id);
            return View(sp);
        }

        public ActionResult SuaSanPham(int id)
        {
            var Edit_SanPham = db.SANPHAMs.First(m => m.MASP == id);
            return View(Edit_SanPham);
        }

        [HttpPost]
        public ActionResult SuaSanPham(int id, FormCollection c)
        {
            var lstSanPham = db.SANPHAMs.First(m => m.MASP == id);
            var CB_1 = c["TENSP"];
            var CB_2 = c["DONGIA"];
            var CB_3 = c["HINHANH"];
            var CB_5 = c["MALOAI"];
            var CB_6 = c["MANSX"];
            lstSanPham.MASP = id;
            UpdateModel(lstSanPham);
            db.SubmitChanges();
            return RedirectToAction("DanhSachSanPham");
        }

        public ActionResult XoaSanPham(int id)
        {
            var Delete_SanPham = db.SANPHAMs.First(m => m.MASP == id);
            return View(Delete_SanPham);
        }
        [HttpPost]
        public ActionResult XoaSanPham(int id, FormCollection collection)
        {
            var Xoa_SanPham = db.SANPHAMs.Where(m => m.MASP == id).First();
            db.SANPHAMs.DeleteOnSubmit(Xoa_SanPham);
            db.SubmitChanges();
            return RedirectToAction("DanhSachSanPham");
        }

        //Qua mục khách hàng

        public ActionResult DanhSachKhachHang()
        {
            //if (Session["kh"] == null || Session["kh"].ToString() == "")
            //{
            //    return RedirectToAction("DangNhap", "Admin");
            //}
            List<KHACHHANG> dsKH = db.KHACHHANGs.ToList();
            return View(dsKH);
        }



        //Qua mục hóa đơn

        public ActionResult DanhSachHoaDon()
        {
            //if (Session["kh"] == null || Session["kh"].ToString() == "")
            //{
            //    return RedirectToAction("DangNhap", "Admin");
            //}
            List<HOADON> dsHD = db.HOADONs.ToList();
            return View(dsHD);
        }

  
    }
}
