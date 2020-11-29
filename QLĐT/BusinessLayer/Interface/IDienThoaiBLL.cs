using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.BusinessLayer.Interface
{
    public interface IDienThoaiBLL
    {
        List<DienThoai> GetAllDienThoai();
        void ThemDienThoai(DienThoai dt);
        void XoaDienThoai(string madienthoai);
        void SuaDienThoai(DienThoai sp);
        List<DienThoai> TimDienThoai(DienThoai dt);
    }
}
