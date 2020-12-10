using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.DataAccessLayer.Interface
{
    class HoaDonDAL : IHoaDonDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HoaDon.txt
        private string txtfile = @"D:\ĐỒ ÁN 1\QLĐT\QLĐT\Data/HoaDon.txt";
        //Lấy toàn bộ dữ liệu có trong file HoaDon.txt đưa vào một danh sách 
        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new HoaDon(a[0], a[1], a[2], int.Parse(a[3]), int.Parse(a[4])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }


        //Chèn một bản ghi hóa đơn vào tệp
        public void ThemHoaDon(HoaDon hd)
        {
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(hd.MaHoaDon + "#" + hd.TenDienThoai + "#" + hd.NgayBan + "#" + hd.SoLuong + "#" + hd.TongTien );
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<HoaDon> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaHoaDon + "#" + list[i].TenDienThoai + "#" + list[i].NgayBan + "#" + list[i].SoLuong + "#" + list[i].TongTien);
            fwrite.Close();
        }
    }
}
