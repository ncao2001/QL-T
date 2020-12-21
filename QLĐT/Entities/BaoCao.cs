using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLĐT.Entities
{
    public class BaoCao
    {
        private DateTime today;
        private int sldtbanra;
        private double tongthunhap;
        public DateTime ToDay
        {
            get { return today; }
            set
            {
                today = value; ;
            }
        }
        public int SoLuongDTBanRa
        {
            get { return sldtbanra; }
            set
            {
                if (value > 0)
                    sldtbanra = value;
            }
        }
        public double TongThuNhap
        {
            get { return tongthunhap; }
            set
            {
                if (value > 0)
                    tongthunhap = value;
            }
        }
        public BaoCao() { }
        public BaoCao(DateTime today, int sldtbanra, double tongthunhap)
        {
            this.today = today;
            this.sldtbanra = sldtbanra;
            this.tongthunhap = tongthunhap;         
        }
    }
}
