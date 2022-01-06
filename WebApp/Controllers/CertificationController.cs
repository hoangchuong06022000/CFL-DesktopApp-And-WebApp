using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;

namespace WebApp.Controllers
{
    public class CertificationController : Controller
    {
        private DAL_DSThiSinhTheoPhong dalTSTheoPHG = new DAL_DSThiSinhTheoPhong();
        // GET: Certification
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Certification(string sbd)
        {
            var thiSinh = dalTSTheoPHG.GetKetQuaBySBD(sbd);
            return View(thiSinh);
        }
    }
}