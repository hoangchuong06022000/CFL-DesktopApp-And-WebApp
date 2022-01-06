using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using System.Data.Entity;

namespace Model.DAL
{
    public class DAL_DSThiSinhTheoPhong
    {
        public List<DSTHISINHTHEOPHONG> GetAll()
        {
            QLTTEntity db = new QLTTEntity();
            return db.DSTHISINHTHEOPHONGs.ToList();
        }
        public int SLThiSinhA2()
        {
            QLTTEntity db = new QLTTEntity();
            return db.DSTHISINHTHEOPHONGs.Where(x => x.PHONGTHI.TRINHDO == "A2").Count();
        }
        public int SLThiSinhB1()
        {
            QLTTEntity db = new QLTTEntity();
            return db.DSTHISINHTHEOPHONGs.Where(x => x.PHONGTHI.TRINHDO == "B1").Count();
        }
        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLTTEntity db = new QLTTEntity();
            foreach (DSTHISINHTHEOPHONG thiSinh in db.DSTHISINHTHEOPHONGs.ToList())
            {
                ListPkey.Add(thiSinh.UNIQUEID);
            }
            return ListPkey;
        }
        public List<DSTHISINHTHEOPHONG> GetThiSinhBySearch(string str)
        {
            QLTTEntity db = new QLTTEntity();
            List<DSTHISINHTHEOPHONG> listThiSinh = new List<DSTHISINHTHEOPHONG>();
            List<THISINH> list = db.THISINHs.Where(x => x.HOTEN.Contains(str) || x.SDT.Contains(str)).ToList();
            foreach(THISINH thiSinh in list)
            {
                List<DSTHISINHTHEOPHONG> listTmp = new List<DSTHISINHTHEOPHONG>();
                listTmp = db.DSTHISINHTHEOPHONGs.Where(x => x.CMND == thiSinh.CMND).ToList();
                foreach (DSTHISINHTHEOPHONG item in listTmp)
                {
                    listThiSinh.Add(item);
                }
            }
            return listThiSinh;
        }
        public DSTHISINHTHEOPHONG GetKetQuaBySBD(string sbd)
        {
            QLTTEntity db = new QLTTEntity();
            return db.DSTHISINHTHEOPHONGs.Where(x => x.SBD == sbd).LastOrDefault();
        }
        public List<DSTHISINHTHEOPHONG> GetThiSinhTheoPhong(string maPhong)
        {
            QLTTEntity db = new QLTTEntity();
            return db.DSTHISINHTHEOPHONGs.Where(x => x.MAPHONG == maPhong).ToList();
        }
        public bool Insert(DSTHISINHTHEOPHONG thiSinh)
        {
            QLTTEntity db = new QLTTEntity();
            db.DSTHISINHTHEOPHONGs.Add(thiSinh);
            db.SaveChanges();
            return true;
        }
        public List<DSTHISINHTHEOPHONG> GetDSThiSinhTheoPhong(string MaPhong)
        {
            QLTTEntity db = new QLTTEntity();
            var result = from c in db.DSTHISINHTHEOPHONGs where c.MAPHONG == MaPhong select c;
            return result.ToList();
        }
        public bool Update(DSTHISINHTHEOPHONG DSThiSinhTheoPhongMoi)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                DSTHISINHTHEOPHONG DSThiSinhTheoPhong = db.DSTHISINHTHEOPHONGs.Find(DSThiSinhTheoPhongMoi.UNIQUEID);
                db.DSTHISINHTHEOPHONGs.Attach(DSThiSinhTheoPhong);
                DSThiSinhTheoPhong.DIEMNGHE = DSThiSinhTheoPhongMoi.DIEMNGHE;
                DSThiSinhTheoPhong.DIEMDOC = DSThiSinhTheoPhongMoi.DIEMDOC;
                DSThiSinhTheoPhong.DIEMNOI = DSThiSinhTheoPhongMoi.DIEMNOI;
                DSThiSinhTheoPhong.DIEMVIET = DSThiSinhTheoPhongMoi.DIEMVIET;
                db.Entry(DSThiSinhTheoPhong).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(DSTHISINHTHEOPHONG DSThiSinhTheoPhong)
        {
            try
            {
                QLTTEntity db = new QLTTEntity();
                DSTHISINHTHEOPHONG DS = db.DSTHISINHTHEOPHONGs.Find(DSThiSinhTheoPhong.UNIQUEID);
                db.DSTHISINHTHEOPHONGs.Remove(DS);
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
