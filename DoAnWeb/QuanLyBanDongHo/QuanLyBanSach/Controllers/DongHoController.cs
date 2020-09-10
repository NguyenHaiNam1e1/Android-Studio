using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach.Models;
namespace QuanLyBanSach.Controllers
{
    public class DongHoController : Controller
    {
        //
        // GET: /Sach/
        QuanLyBanDongHoModelDataContext s = new QuanLyBanDongHoModelDataContext();
        private List<DONGHO> Laysachmoi(int count)
        {
            return s.DONGHOs.OrderByDescending(a => a.Moi).Take(count).ToList();
        }
        public ActionResult Index()
        {
            //lay 5 quyen sach moi
            var dhmoi = Laysachmoi(6);
            return View(dhmoi);
            //return View();

        }
        public ActionResult Hang()
        {
            var hang = from h in s.HANGs select h;
            return PartialView(hang);
        }
        public ActionResult Details(int id)
        {
            var Details_DH = s.DONGHOs.Where(m => m.MaDH == id).First();
            return View(Details_DH);
        }
        public ActionResult SPTheoHang(int id)
        {
            List<DONGHO> lst = s.DONGHOs.Where(t => t.MaHA == id).ToList();
            return View(lst);
        }

    }
}
