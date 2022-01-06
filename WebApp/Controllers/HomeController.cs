using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private DAL_DangKy dalDK = new DAL_DangKy();
        private DAL_KhoaThi dalKhoa = new DAL_KhoaThi();
        private QLTTEntity db = new QLTTEntity();
        // GET: Home

        public ActionResult Index()
        {
            var newKhoa = dalKhoa.GetKhoaThiMoi();
            DropDownListTrinhDo();
            return View(newKhoa);
        }
        public ActionResult FillData(string maKhoa, string trinhDo)
        {
            DANGKY newDK = new DANGKY
            {
                CMND = "",
                MAKHOA = maKhoa,
                TRINHDO = trinhDo
            };
            return View(newDK);
        }
        [HttpPost]
        public ActionResult AddThiSinh(DANGKY newDK)
        {
            if (ModelState.IsValid)
            {
                if (dalDK.Insert(newDK) == true)
                {
                    return View();  
                }
                else
                {
                    return RedirectToAction("Existed");
                }
            }
            else
            {
                return RedirectToAction("FillData");
            }
        }
        public ActionResult Existed()
        {
            return View();
        }
        public void DropDownListTrinhDo()
        {
            ViewBag.TRINHDO = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "A2", Value = "A2"},
                    new SelectListItem { Text = "B1", Value = "B1"},
                }, "Value", "Text"
            );
        }
    }
}