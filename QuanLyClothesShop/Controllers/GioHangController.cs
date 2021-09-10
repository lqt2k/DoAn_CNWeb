
using QuanLyClothesShop.Models;
using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/

        dbQLQADataContext db = new dbQLQADataContext();

        public ActionResult Index()
        {
            return View();
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng null thì khởi tạo
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int msp, string strURL)
        {
            //Lấy ra giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sách này có tồn tại trong Session["GioHang"] chưa.
            GioHang sanpham = lstGioHang.Find(sp => sp.iMaSP == msp);
            if (sanpham == null)
            {
                sanpham = new GioHang(msp);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }

        private double TongTien()
        {
            double tt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tt += lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Cart", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongTien();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien=TongTien();
            return PartialView();
        }
        //xoa 1 san pham rong gio hang
        public ActionResult XoaGioHang(int MaSP)
        {
            //Lấy giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra giỏ hàng rỗng??
            GioHang sp = lstGioHang.Single(s => s.iMaSP == MaSP);
            //Kiểm tra tồn tại thì sẽ xóa
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.iMaSP == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Cart", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        //Xóa tất cả sản phẩm trong giỏ
        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra giỏ hàng rỗng
            lstGioHang.Clear();
            return RedirectToAction("Cart", "Home");
        }

        //Update giỏ hàng
        public ActionResult CapNhatGioHang(int msp, FormCollection col)
        {
            //Lấy giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSP == msp);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(col["txtSL"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        //Xác nhận hóa đơn
        [HttpGet]
        public ActionResult XacNhanDonHang()
        {
            //Kiểm tra khách hàng đã đăng nhập chưa
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Cart", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            //ViewBag.k = khach;
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }

        //Add data vào hoadon và chitiethoadon
        [HttpPost]
        public ActionResult XacNhanDonHang(FormCollection x)
        {                       
            //Lưu một dòng vào bảng hóa đơn           
            HOADON hd = new HOADON();
            KHACHHANG khach = (KHACHHANG)Session["TaiKhoan"];
            List<GioHang> lstGioHang = LayGioHang();
            hd.MAKH = khach.MAKH;
            hd.NGAYLAP = DateTime.Now;
            hd.THANHTIEN = Convert.ToInt32(TongTien());
            db.HOADONs.InsertOnSubmit(hd);
            db.SubmitChanges();

            //Lưu nhiều dòng vào bảng chi tiết hóa đơn của dòng hóa đơn đó

            foreach (var item in lstGioHang)
            {
                CHITIETHD cthd = new CHITIETHD();
                cthd.MAHD = hd.MAHD;
                cthd.MASP = item.iMaSP;
                cthd.SOLUONG = item.iSoLuong;
                cthd.TONGTIEN = Convert.ToInt32(item.dDonGia);
                db.CHITIETHDs.InsertOnSubmit(cthd);
                db.SubmitChanges();
            }
            ViewBag.name = khach.TENKH;
            db.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("TaoDonDatHang", "GioHang");
            //return this.XacNhanDonHang();
        }

        public ActionResult TaoDonDatHang()
        {
            return View();
        }

        public ActionResult ThongTinDonHang(int makh)
        {
            ////Kiểm tra khách hàng đã đăng nhập chưa
            //if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            //{
            //    return RedirectToAction("DangNhap", "DangNhap");
            //}
            //List<GioHang> lstGioHang = LayGioHang();
            //ViewBag.TongSoLuong = TongSoLuong();
            //ViewBag.TongTien = TongTien();
            //return View(lstGioHang);
            //HOADON hd = (HOADON)Session["HoaDon"];
            ////KHACHHANG kh = db.KHACHHANGs.Single(k => k.MAKH == makh);
            //if (Session["HoaDon"] == null || Session["HoaDon"].ToString() == "")
            //{
            //    return RedirectToAction("Cart", "Home");
            //}
            //return View(hd);
            HOADON dsHD = db.HOADONs.Single(ds => ds.MAKH == makh);
            return View(dsHD);
        }
    }
}
