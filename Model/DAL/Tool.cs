using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class Tool
    {
        public string next_ma(List<int> ma)
        {
            int[] hashmap = new int[ma.Count + 107];
            foreach (int a in ma)
            {
                if (a <= ma.Count)
                {
                    hashmap[a] = 1;
                }
            }
            int res = 1;
            while (hashmap[res] == 1)
            {
                res++;
            }
            string nextma = res.ToString();
            while (nextma.Length < 3)
            {
                nextma = "0" + nextma;
            }
            return nextma;
        }
        public string next_maTSTheoPhong(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(1)));
            }
            return "U" + next_ma(int_ma);
        }
        public string next_maPhong(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(1)));
            }
            return "P" + next_ma(int_ma);
        }
        public string next_maKhoa(List<string> ma)
        {
            List<int> int_ma = new List<int>();
            foreach (string i in ma)
            {
                int_ma.Add(int.Parse(i.Substring(1)));
            }
            return "K" + next_ma(int_ma);
        }
    }
}
