using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach.Models;

namespace QuanLyBanSach.Controllers
{
    
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        QuanLyBanDongHoModelDataContext s = new QuanLyBanDongHoModelDataContext();
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
        public ActionResult DangNhap(FormCollection cl)
        {
            Session["tk"] = null;
            var tk=cl["tk"];
            var mk = cl["mk"];
            KHACHHANG kh = s.KHACHHANGs.SingleOrDefault(n => n.TAIKHOAN == tk && n.MATKHAU == mk);
            if (kh != null)
            {
               
                Session["tk"] = kh.HOTEN;
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "DongHo");
            }
                ViewBag.Thongbao = "Tài khoản mật khẩu ko chính xác ";
                return View("DangNhap");
        }

        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
         [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var matkhaunhaplai = collection["MatKhauNhapLai"];
            var diachi = collection["Diachi"];
            var gioitinh = collection["Gioitinh"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);

             kh.HOTEN = hoten;
             kh.TAIKHOAN = tendn;
             kh.MATKHAU = matkhau;
             kh.EMAIL = email;
             kh.DIACHI = diachi;
             kh.GIOITINH = gioitinh;
             kh.SDT = dienthoai;
             kh.NGAYSINH = DateTime.Parse(ngaysinh);
             s.KHACHHANGs.InsertOnSubmit(kh);
             s.SubmitChanges();
            
             ViewBag.Thongbao = "Đăng Ký Thành Công ";

             return this.DangKy();
        }
         public ActionResult DangXuat()
         {
             Session["tk"] = null;
             return RedirectToAction("DangNhap");
         }
    }
}
