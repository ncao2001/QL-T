using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;
using QLĐT.DataAccessLayer.Interface;

namespace QLĐT.BusinessLayer.Interface
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IHoaDonBLL
    public class HoaDonBLL : IHoaDonBLL
    {
        private IHoaDonDAL hdDA = new HoaDonDAL();
        //Thực thi các yêu cầu
        public List<HoaDon> GetAllHoaDon()
        {
            return hdDA.GetAllHoaDon();
        }
        public void ThemHoaDon(HoaDon hd)
        {
            if (!string.IsNullOrEmpty(hd.MaHoaDon))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                hdDA.ThemHoaDon(hd);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaHoaDon(string mahoadon)
        {
            int i;
            List<HoaDon> list = GetAllHoaDon();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaHoaDon(HoaDon hd)
        {
            int i;
            List<HoaDon> list = GetAllHoaDon();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == hd.MaHoaDon) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(hd);
                hdDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai hdn nay");
        }
        public List<HoaDon> TimHoaDon(HoaDon hdn)
        {
            List<HoaDon> list = GetAllHoaDon();
            List<HoaDon> kq = new List<HoaDon>();
            if (string.IsNullOrEmpty(hdn.MaHoaDon))
            {
                kq = list;
            }

            //Tim theo ten hdn
            if (!string.IsNullOrEmpty(hdn.MaHoaDon))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].MaHoaDon.IndexOf(hdn.MaHoaDon) >= 0)
                    {
                        kq.Add(new HoaDon(list[i]));
                    }
            }
            return kq;
        }
    }
}
