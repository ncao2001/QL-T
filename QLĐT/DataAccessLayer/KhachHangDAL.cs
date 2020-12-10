using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.DataAccessLayer.Interface
{
    class KhachHangDAL : IKhachHangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu KhachHang.txt
        private string txtfile = @"D:\ĐỒ ÁN 1\QLĐT\QLĐT\Data/KhachHang.txt";
        //Lấy toàn bộ dữ liệu có trong file KhachHang.txt đưa vào một danh sách 
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new KhachHang(a[0], a[1], a[2], a[3], a[4]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Chèn một bản ghi khách hàng vào tệp
        public void ThemKhachHang(KhachHang kh)
        {
            //string makhachhanng = "DT" + DateTime.Now.ToString("yyMMddhhmmss");
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(kh.MaKhachHang + "#" + kh.HoTen + "#" + kh.QueQuan + "#" + kh.DiaChi + "#" + kh.SodienThoai);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<KhachHang> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaKhachHang + "#" + list[i].HoTen + "#" + list[i].QueQuan + "#" + list[i].DiaChi + "#" + list[i].SodienThoai);
            fwrite.Close();
        }
    }
}
