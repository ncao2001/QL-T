using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Entities;

namespace QLĐT.DataAccessLayer.Interface
{
    class DienThoaiDAL : IDienThoaiDAL
    {
        //Xác định đường dẫn của tệp dữ liệu DienThoai.txt
        private string txtfile = @"D:\ĐỒ ÁN 1\QLĐT\QLĐT\Data/DienThoai.txt";
        //Lấy toàn bộ dữ liệu có trong file DienThoai.txt đưa vào một danh sách 
        public List<DienThoai> GetAllDienThoai()
        {
            List<DienThoai> list = new List<DienThoai>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new DienThoai(a[0], a[1], int.Parse(a[2])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Chèn một bản ghi điện thoại vào tệp
        public void ThemDienThoai(DienThoai dt)
        {
            StreamWriter fwritet = File.AppendText(txtfile);
            fwritet.WriteLine();
            fwritet.Write(dt.MaDienThoai + "#" + dt.TenDienThoai + "#" + dt.DonGia);
            fwritet.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<DienThoai> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaDienThoai + "#" + list[i].TenDienThoai + "#" + list[i].DonGia);
            fwrite.Close();
        }
    }
}
