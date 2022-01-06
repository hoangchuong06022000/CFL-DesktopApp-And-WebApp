using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DAL
{
    public class DAL_GiaoVien
    {
        public List<GIAOVIEN> GetAll()
        {
            QLTTEntity db = new QLTTEntity();
            return db.GIAOVIENs.ToList();
        }
    }
}
