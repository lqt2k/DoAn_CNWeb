using QuanLyClothesShop.Views;
using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyClothesShop.Models
{
    public class GioHang
    {
        dbQLQADataContext db = new dbQLQADataContext();
        public int iMaSP { set; get; }
        public string sTenSP { set; get; }
        public string sHinhAnh { set; get; }
        public double dDonGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        //Khởi tạo giỏ hàng
        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            SANPHAM sanpham = db.SANPHAMs.Single(s => s.MASP == iMaSP);
            sTenSP = sanpham.TENSP;
            sHinhAnh = sanpham.HINHANH;
            dDonGia = double.Parse(sanpham.DONGIA.ToString());
            iSoLuong = 1;
        }
    }
}