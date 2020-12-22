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
        private string ngayban;
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
        public string NgayBan
        {
            get { return ngayban; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    ngayban = value;
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
        public int TongTien
        {
            get { return tongtien; }
            set
            {
                if (value>0)
                    tongtien = value;
            }
        }
        #endregion

        #region Các thương thức             
        public HoaDon() { }
        public HoaDon(HoaDon hd)
        {
            this.mahoadon = hd.mahoadon;
            this.tendienthoai = hd.tendienthoai;
            this.ngayban = hd.ngayban;
            this.soluong = hd.soluong;
            this.tongtien = hd.tongtien;
        }
        public HoaDon(string mahoadon,string tendienthoai, string ngayban, int soluong, int tongtien)
        {
            this.mahoadon = mahoadon;
            this.tendienthoai = tendienthoai;
            this.ngayban = ngayban;
            this.soluong = soluong;
            this.tongtien = tongtien;
        }
        #endregion
    }
}
