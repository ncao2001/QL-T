using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.BusinessLayer.Interface
{
    public interface IKhachHangBLL
    {
        List<KhachHang> GetAllKhachHang();
        void ThemKhachHang(KhachHang kh);
        void XoaKhachHang(string makhachhang);
        void SuaKhachHang(KhachHang kh);
        List<KhachHang> TimKhachHang(KhachHang kh);
    }
}
