using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;

namespace WebApp.Controllers
{
    public class ExamineeController : Controller
    {
        private DAL_DSThiSinhTheoPhong dalDSTheoPHG = new DAL_DSThiSinhTheoPhong();
        private DAL_KhoaThi dalKhoa = new DAL_KhoaThi();
        private DAL_PhongThi dalPhong = new DAL_PhongThi();
        // GET: Examinee
        [HttpGet]
        public ActionResult Examinee()
        {
            ViewData["KHOATHI"] = new SelectList(dalKhoa.GetAll(), "MAKHOA", "TENKHOA");
            var list = dalDSTheoPHG.GetAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult Examinee(string PHONGTHI)
        {
            ViewData["KHOATHI"] = new SelectList(dalKhoa.GetAll(), "MAKHOA", "TENKHOA");
            var list = dalDSTheoPHG.GetThiSinhTheoPhong(PHONGTHI);
            return View(list);
        }
        public JsonResult GetPhong(string maKhoa)
        {
            List<PHONGTHI> listPhong = dalPhong.GetPhongByMaKhoa(maKhoa);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(PHONGTHI item in listPhong)
            {
                list.Add(new SelectListItem { Text = item.TENPHONG, Value = item.MAPHONG });
            }
            return Json(new SelectList(list, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
    }
}