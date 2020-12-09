using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLĐT.Entities
{
    public class HoaDon
    {
        #region Các thành phần dữ liệu
        private string mahoadon;
        private string tendienthoai;
        private DateTime ngayban;
        private int soluong;
        private int tongtien;
        #endregion

        #region Các thuộc tính
        public string MaHoaDon
        {
            get { return mahoadon; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    mahoadon = value;
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
        public DateTime NgayBan
        {
            get { return ngayban; }
            set
            {
                 ngayban = value;
            }
        }
        public int TongTien
        {
            get { return tongtien; }
            set
            {
                if (value>0)
                    tongtien = value;
            }
        }
        public int SoLuong
        {
            get { return soluong; }
            set
            {
                if (value > 0)
                    soluong = value;
            }
        }
        #endregion

        #region Các thương thức             
        public HoaDon() { }
        //Phương thức thiết lập sao chép
        public HoaDon(HoaDon hd)
        {
            this.mahoadon = hd.mahoadon;
            this.tendienthoai = hd.tendienthoai;
            this.ngayban = hd.ngayban;
            this.tongtien = hd.tongtien;
            this.soluong = hd.soluong;
        }
        public HoaDon(string mahoadonnhap,string tendienthoai, DateTime ngayban, int tongtiennhap, int soluong)
        {
            this.mahoadon = mahoadonnhap;
            this.tendienthoai = tendienthoai;
            this.ngayban = ngayban;
            this.tongtien = tongtiennhap;
            this.soluong = soluong;
        }
        #endregion
    }
}
