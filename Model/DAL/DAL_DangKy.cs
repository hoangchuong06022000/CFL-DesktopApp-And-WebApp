using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using System.Data.Entity;

namespace Model.DAL
{
    public class DAL_DangKy
    {
        public bool Insert(DANGKY dangKy)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                THISINH thiSinh = new THISINH
                {
                    CMND = dangKy.CMND,
                    HOTEN = dangKy.THISINH.HOTEN,
                    GIOITINH = dangKy.THISINH.GIOITINH,
                    NGAYSINH = dangKy.THISINH.NGAYSINH,
                    NOISINH = dangKy.THISINH.NOISINH,
                    SDT = dangKy.THISINH.SDT,
                    NGAYCAP = dangKy.THISINH.NGAYCAP,
                    NOICAP = dangKy.THISINH.NOICAP,
                    EMAIL = dangKy.THISINH.EMAIL,
                };
                db.THISINHs.Add(thiSinh);
                db.SaveChanges();
                DANGKY newDK = new DANGKY
                {
                    CMND = dangKy.CMND,
                    MAKHOA = dangKy.MAKHOA,
                    TRINHDO = dangKy.TRINHDO
                };
                db.DANGKies.Add(newDK);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<DANGKY> GetAll()
        {
            QLTTEntity db = new QLTTEntity();
            return db.DANGKies.ToList();
        }

        public bool InsertDK(DANGKY DangKy)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                db.DANGKies.Add(DangKy);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(DANGKY DangKyMoi)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                DANGKY DangKy = db.DANGKies.Find(DangKyMoi.CMND, DangKyMoi.MAKHOA);
                db.DANGKies.Attach(DangKy);
                DangKy.TRINHDO = DangKyMoi.TRINHDO;
                db.Entry(DangKy).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(DANGKY DangKy)
        {

            try
            {
                QLTTEntity db = new QLTTEntity();
                DANGKY DK = db.DANGKies.Where(p => p.CMND == DangKy.CMND).SingleOrDefault();
                db.DANGKies.Remove(DK);
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
