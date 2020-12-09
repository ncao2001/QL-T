using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.BusinessLayer.Interface
{
    public interface IHoaDonBLL
    {
        List<HoaDon> GetAllHoaDon();
        void ThemHoaDon(HoaDon hd);
        void XoaHoaDon(string mahoadon);
        void SuaHoaDon(HoaDon hd);
        List<HoaDon> TimHoaDon(HoaDon hd);
    }
}
