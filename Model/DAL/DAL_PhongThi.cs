using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using System.Data.Entity;

namespace Model.DAL
{
    public class DAL_PhongThi
    {
        public List<PHONGTHI> GetAll()
        {
            QLTTEntity db = new QLTTEntity();
            return db.PHONGTHIs.ToList();
        }

        public int SLPhongThi()
        {
            QLTTEntity db = new QLTTEntity();
            return db.PHONGTHIs.Count();
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLTTEntity db = new QLTTEntity();
            foreach (PHONGTHI phong in db.PHONGTHIs.ToList())
            {
                ListPkey.Add(phong.MAPHONG);
            }
            return ListPkey;
        }

        public List<PHONGTHI> GetPhongByMaKhoa(string maKhoa)
        {
            QLTTEntity db = new QLTTEntity();
            return db.PHONGTHIs.Where(x => x.MAKHOA == maKhoa).ToList();
        }

        public bool Insert(PHONGTHI phongThi)
        {
            QLTTEntity db = new QLTTEntity();
            db.PHONGTHIs.Add(phongThi);
            db.SaveChanges();
            return true;
        }
        public List<PHONGTHI> GetPhongThi(string MaKhoa)
        {
            QLTTEntity db = new QLTTEntity();
            var result = from c in db.PHONGTHIs where c.MAKHOA == MaKhoa select c;
            return result.ToList();
        }
        public bool Update(PHONGTHI PHONGTHIMoi)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                PHONGTHI PhongThi = db.PHONGTHIs.Find(PHONGTHIMoi.MAPHONG);
                db.PHONGTHIs.Attach(PhongThi);
                PhongThi.CATHI = PHONGTHIMoi.CATHI;
                db.Entry(PhongThi).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(PHONGTHI PHONGTHI)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                PHONGTHI PhongThi = db.PHONGTHIs.Find(PHONGTHI.MAPHONG);
                db.PHONGTHIs.Remove(PhongThi);
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
