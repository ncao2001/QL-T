using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;
using QLĐT.DataAccessLayer.Interface ;

namespace QLĐT.BusinessLayer.Interface
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IDienThoaiBLL
    public class DienThoaiBLL : IDienThoaiBLL
    {
        private IDienThoaiDAL dtDA = new DienThoaiDAL();
        //Thực thi các yêu cầu
        public List<DienThoai> GetAllDienThoai()
        {
            return dtDA.GetAllDienThoai();
        }
        public void ThemDienThoai(DienThoai dt)
        {
            if (!string.IsNullOrEmpty(dt.TenDienThoai))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                dtDA.ThemDienThoai(dt);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaDienThoai(string madienthoai)
        {
            int i;
            List<DienThoai> list = GetAllDienThoai();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaDienThoai == madienthoai) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                dtDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaDienThoai(DienThoai dt)
        {
            int i;
            List<DienThoai> list = GetAllDienThoai();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaDienThoai == dt.MaDienThoai) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(dt);
                dtDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai dt nay");
        }
        public List<DienThoai> TimDienThoai(DienThoai dt)
        {
            List<DienThoai> list = GetAllDienThoai();
            List<DienThoai> kq = new List<DienThoai>();
            if (string.IsNullOrEmpty(dt.MaDienThoai) && string.IsNullOrEmpty(dt.TenDienThoai) && dt.DonGia == 0)
            {
                kq = list;
            }

            //Tim theo ten dt
            if (!string.IsNullOrEmpty(dt.TenDienThoai))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].TenDienThoai.IndexOf(dt.TenDienThoai) >= 0)
                    {
                        kq.Add(new DienThoai(list[i]));
                    }
            }

            //Tim theo gia
            else if (dt.DonGia > 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].DonGia == dt.DonGia)
                    {
                        kq.Add(new DienThoai(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }

    }
}
