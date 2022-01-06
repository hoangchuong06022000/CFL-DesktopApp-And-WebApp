using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;

namespace WebApp.Controllers
{
    public class InfoThiSinhController : Controller
    {
        private DAL_DSThiSinhTheoPhong dalDSTheoPHG = new DAL_DSThiSinhTheoPhong();
        // GET: InfoThiSinh
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult ViewInfo(string strSearch)
        {
            var thiSinh = dalDSTheoPHG.GetThiSinhBySearch(strSearch).ToList();
            return View(thiSinh);
        }
    }
}