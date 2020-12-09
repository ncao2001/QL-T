using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;
using QLĐT.DataAccessLayer.Interface;

namespace QLĐT.BusinessLayer.Interface
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IKhachHangBLL
    public class KhachHangBLL : IKhachHangBLL
    {
        private IKhachHangDAL khDA = new KhachHangDAL();
        //Thực thi các yêu cầu
        public List<KhachHang> GetAllKhachHang()
        {
            return khDA.GetAllKhachHang();
        }
        public void ThemKhachHang(KhachHang kh)
        {
            if (!string.IsNullOrEmpty(kh.Hoten))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                khDA.ThemKhachHang(kh);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaKhachHang(string makhachhang)
        {
            int i;
            List<KhachHang> list = GetAllKhachHang();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhachHang == makhachhang) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                khDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaKhachHang(KhachHang kh)
        {
            int i;
            List<KhachHang> list = GetAllKhachHang();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhachHang == kh.MaKhachHang) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(kh);
                khDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai kh nay");
        }
        public List<KhachHang> TimKhachHang(KhachHang kh)
        {
            List<KhachHang> list = GetAllKhachHang();
            List<KhachHang> kq = new List<KhachHang>();
            if (string.IsNullOrEmpty(kh.MaKhachHang) && string.IsNullOrEmpty(kh.Hoten) )
            {
                kq = list;
            }

            //Tim theo ten kh
            if (!string.IsNullOrEmpty(kh.Hoten))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Hoten.IndexOf(kh.Hoten) >= 0)
                    {
                        kq.Add(new KhachHang(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }

        List<KhachHang> IKhachHangBLL.TimKhachHang(KhachHang kh)
        {
            throw new NotImplementedException();
        }
    }
}
