using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.DataAccessLayer.Interface
{
    public interface IHoaDonDAL
    {
        List<HoaDon> GetAllHoaDon();
        void ThemHoaDon(HoaDon hd);
        void Update(List<HoaDon> list);
    }
}
