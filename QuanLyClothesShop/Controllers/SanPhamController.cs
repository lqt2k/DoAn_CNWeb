using QuanLyClothesShop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace QuanLyClothesShop.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/

        dbQLQADataContext db = new dbQLQADataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPhamPartial(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var listSanPham = db.SANPHAMs.OrderBy(sp => sp.TENSP).ToPagedList(pageNumber, pageSize);
            return View(listSanPham);
        }

        public ActionResult SPPartialView()
        {
            return PartialView();
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

        public ActionResult TimKiemSanPham(string searchSP)
        {
            var s = from TENSP in db.SANPHAMs select TENSP;
            if (!String.IsNullOrEmpty(searchSP))
            {
                s = s.Where(x => x.TENSP.Contains(searchSP));
                var sl = s.Count();
                ViewBag.sl = sl;
            }
            return View(s);
        }
        public ActionResult Searchtheogia()
        {
            ViewBag.MANSX = new SelectList(db.NHASANXUATs.ToList(), "MANSX", "TENNSX");
            return View();
        }
        [HttpPost]
        public ActionResult Searchtheogia(FormCollection c)
        {
            string ten = c["txtTen"];
            int maNSX = int.Parse(c["MANSX"]);

            List<SANPHAM> dstk = db.SANPHAMs.Where(t => t.TENSP.Contains(ten)).ToList();
            List<SANPHAM> ds2 = dstk.Where(t => t.MANSX == maNSX).ToList();
            List<SANPHAM> dsSP = new List<SANPHAM>();

            if (c["g1"] == "1")
            {
                List<SANPHAM> d1 = ds2.Where(s => s.DONGIA > 0 && s.DONGIA <= 100000).ToList();
                dsSP.AddRange(d1);
            }
            if (c["g2"] == "2")
            {
                List<SANPHAM> d2 = ds2.Where(s => s.DONGIA > 100000 && s.DONGIA <= 200000).ToList();
                dsSP.AddRange(d2);
            }
            if (c["g3"] == "3")
            {
                List<SANPHAM> d3 = ds2.Where(s => s.DONGIA > 200000 && s.DONGIA <= 400000).ToList();
                dsSP.AddRange(d3);
            }
            if (c["g4"] == "4")
            {
                List<SANPHAM> d4 = ds2.Where(s => s.DONGIA > 400000).ToList();
                dsSP.AddRange(d4);
            }
            return View("Index", dsSP);
        }
    }
}
