using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using System.Data.Entity;

namespace Model.DAL
{
    public class DAL_KhoaThi
    {
        public List<KHOATHI> GetAll()
        {
            QLTTEntity db = new QLTTEntity();
            return db.KHOATHIs.ToList();
        }

        public int SLKhoaThi()
        {
            QLTTEntity db = new QLTTEntity();
            return db.KHOATHIs.Count();
        }

        public KHOATHI GetKhoaThiMoi()
        {
            QLTTEntity db = new QLTTEntity();
            return db.KHOATHIs.ToList().LastOrDefault();
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLTTEntity db = new QLTTEntity();
            foreach (KHOATHI khoa in db.KHOATHIs.ToList())
            {
                ListPkey.Add(khoa.MAKHOA);
            }
            return ListPkey;
        }

        public bool Insert(KHOATHI khoaThi)
        {
            QLTTEntity db = new QLTTEntity();
            db.KHOATHIs.Add(khoaThi);
            db.SaveChanges();
            return true;
        }

        public bool Update(KHOATHI KhoaThiMoi)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                KHOATHI KhoaThi = db.KHOATHIs.Find(KhoaThiMoi.MAKHOA);
                db.KHOATHIs.Attach(KhoaThi);
                KhoaThi.TENKHOA = KhoaThiMoi.TENKHOA;
                KhoaThi.NGAYTHI = KhoaThiMoi.NGAYTHI;
                db.Entry(KhoaThi).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(KHOATHI KhoaThi)
        {

            try
            {
                QLTTEntity db = new QLTTEntity();
                KHOATHI KT = db.KHOATHIs.Where(p => p.MAKHOA == KhoaThi.MAKHOA).SingleOrDefault();
                db.KHOATHIs.Remove(KT);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
