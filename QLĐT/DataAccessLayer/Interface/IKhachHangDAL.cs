using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.DataAccessLayer.Interface
{
    public interface IKhachHangDAL
    {
        List<KhachHang> GetAllKhachHang();
        void ThemKhachHang(KhachHang kh);
        void Update(List<KhachHang> list);
    }
}
