using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.DataAccessLayer.Interface
{
    public interface IDienThoaiDAL
    {
        List<DienThoai> GetAllDienThoai();
        void ThemDienThoai(DienThoai dt);
        void Update(List<DienThoai> list);
    }
}
