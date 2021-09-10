using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyClothesShop.Controllers
{
    public class LoaiSPController : Controller
    {
        //
        // GET: /LoaiSP/

        dbQLQADataContext db = new dbQLQADataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoaiSPPartial()
        {
            var listLoaiSP = db.LOAIs.OrderBy(l => l.TENLOAI).ToList();
            return View(listLoaiSP);
        }

        public ActionResult SanPhamTheoLoai(int maloai)
        {
            var listSP = db.SANPHAMs.Where(lsp => lsp.MALOAI == maloai).OrderBy(sp => sp.TENSP).ToList();
            if (listSP.Count == 0)
            {
                ViewBag.LoaiSP = "Không có sản phẩm trong loại này !";
            }
            return View(listSP);
        }

        public ActionResult XemChiTiet(int masp)
        {
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == masp);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

    }
}
