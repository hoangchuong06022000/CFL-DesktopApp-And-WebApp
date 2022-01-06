using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;

namespace WebApp.Controllers
{
    public class StaticticController : Controller
    {
        private DAL_KhoaThi dalKhoa = new DAL_KhoaThi();
        private DAL_PhongThi dalPhong = new DAL_PhongThi();
        private DAL_DSThiSinhTheoPhong dalDSTheoPHG = new DAL_DSThiSinhTheoPhong();
        // GET: Statictic
        public ActionResult Statictic()
        {
            ViewBag.SLKHOATHI = dalKhoa.SLKhoaThi();
            ViewBag.SLPHONGTHI = dalPhong.SLPhongThi();
            ViewBag.SLTHISINHA2 = dalDSTheoPHG.SLThiSinhA2();
            ViewBag.SLTHISINHB1 = dalDSTheoPHG.SLThiSinhB1();
            return View();
        }
    }
}