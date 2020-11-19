using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLĐT.Entities
{
    public class DienThoai
    {
        #region Các thành phần dữ liệu
        private string madienthoai;
        private string tendienthoai;
        private int dongia;
        #endregion

        #region Các thuộc tính
        public string MaDienThoai
        {
            get { return madienthoai; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    madienthoai = value;
            }
        }
        public string TenDienThoai
        {
            get { return tendienthoai; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tendienthoai = value;
            }
        }
        public int DonGia
        {
            get { return dongia; }
            set
            {
                if (value > 0)
                    dongia = value;
            }
        }
        #endregion

        #region Các thương thức             
        public DienThoai() { }
        //Phương thức thiết lập sao chép
        public DienThoai(DienThoai dt)
        {
            this.madienthoai = dt.madienthoai;
            this.tendienthoai = dt.tendienthoai;
            this.dongia = dt.dongia;
        }
        public DienThoai(string masanpham, string tensanpham, int dongia)
        {
            this.madienthoai = masanpham;
            this.tendienthoai = tensanpham;
            this.dongia = dongia;
        }
        #endregion
    }
}
