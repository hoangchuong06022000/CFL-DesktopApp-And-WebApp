using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using System.Data.Entity;

namespace Model.DAL
{
    public class DAL_ThiSinh
    {
        public List<THISINH> GetAll()
        {
            QLTTEntity db = new QLTTEntity();
            return db.THISINHs.ToList();
        }

        public bool Insert(THISINH thiSinh)
        {
            QLTTEntity db = new QLTTEntity();
            db.THISINHs.Add(thiSinh);
            db.SaveChanges();
            return true;
        }
        public bool Update(THISINH ThisinhMoi)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                THISINH ThiSinh = db.THISINHs.Find(ThisinhMoi.CMND);
                db.THISINHs.Attach(ThiSinh);
                ThiSinh.HOTEN = ThisinhMoi.HOTEN;
                ThiSinh.NGAYSINH = ThisinhMoi.NGAYSINH;
                ThiSinh.NOISINH = ThisinhMoi.NOISINH;
                ThiSinh.GIOITINH = ThisinhMoi.GIOITINH;
                ThiSinh.SDT = ThisinhMoi.SDT;
                ThiSinh.EMAIL = ThisinhMoi.EMAIL;
                ThiSinh.NGAYCAP = ThisinhMoi.NGAYCAP;
                ThiSinh.NOICAP = ThisinhMoi.NOICAP;
                db.Entry(ThiSinh).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(THISINH ThiSinh)
        {

            try
            {
                QLTTEntity db = new QLTTEntity();
                THISINH TS = db.THISINHs.Where(p => p.CMND == ThiSinh.CMND).SingleOrDefault();
                db.THISINHs.Remove(TS);
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
