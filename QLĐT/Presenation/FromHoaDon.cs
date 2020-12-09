using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.BusinessLayer.Interface;
using QLĐT.Entities;


namespace QLĐT.Presenation
{
    public class FromHoaDon
    {
        private IHoaDonBLL hdBLL = new HoaDonBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN HOA DON ");
            HoaDon hd = new HoaDon();
            Console.Write("Nhap ma hoa don:"); hd.MaHoaDon = Console.ReadLine();
            Console.Write("Nhap ten dien thoai:");hd.TenDienThoai = Console.ReadLine();
            Console.Write("Ngay ban:"); hd.NgayBan = DateTime.Parse(Console.ReadLine());
            Console.Write("So luong:"); hd.SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Tong tien:"); hd.TongTien = int.Parse(Console.ReadLine());
            hdBLL.ThemHoaDon(hd);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN HOA DON");
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            foreach (var hd in list)
                Console.WriteLine(hd.MaHoaDon +"\t" + hd.TenDienThoai + "\t" + hd.NgayBan + "\t" + hd.SoLuong + "\t" + hd.TongTien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN DIEN THOAI");
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            string mahoadon;
            Console.Write("Nhap ma hoa don can sua:");
            mahoadon = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;

            if (i < list.Count)
            {
                HoaDon hd = new HoaDon(list[i]);
                Console.Write("Ten dien thoai:");
                string tendienthoai = Console.ReadLine();
                if (tendienthoai != "")
                hd.TenDienThoai = tendienthoai;
                Console.Write("Ngay ban:");
                DateTime ngayban = DateTime.Parse(Console.ReadLine());
                hd.NgayBan = ngayban;
                Console.Write("So luong:");
                int soluong = int.Parse(Console.ReadLine());
                if (soluong > 0) hd.SoLuong = soluong;
                Console.Write("So luong:");
                int tongtien = int.Parse(Console.ReadLine());
                if (tongtien > 0) hd.TongTien = tongtien;
                hdBLL.SuaHoaDon(hd);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma hoa don nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XOA THONG TIN HOA DON");
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            string mahoadon;
            Console.Write("Nhap ma hoa don can xoa:");
            mahoadon = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdBLL.XoaHoaDon(mahoadon);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma hoa don nay");
            }
        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("Tim tiem hoa don");
            List<HoaDon> list = hdBLL.GetAllHoaDon();

            Console.Write("Nhap thong tin hoa don can tim kiem:");
            string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].MaHoaDon == tt) break;
            if (i < list.Count)
            {
                List<HoaDon> grt = hdBLL.TimHoaDon(new HoaDon(list[i]));
                foreach (var x in grt)

                    Console.WriteLine(x.MaHoaDon + "\t" + x.TenDienThoai + "\t" + x.NgayBan + "\t" + x.SoLuong + "\t" +x.TongTien);
            }

            else Console.WriteLine("Thong tin hoa don nay k ton tai");


        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN HOA DON");
                Console.WriteLine(" 1.Nhap hoa don ");
                Console.WriteLine(" 2.Sua hoa don ");
                Console.WriteLine(" 3.Xoa hoa don ");
                Console.WriteLine(" 4.Hien danh sach ");
                Console.WriteLine(" 5.Kim kiem ");
                Console.WriteLine(" 6.Back ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case '4':
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case '2':
                        Sua();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case '3':
                        Xoa();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case '5':
                        TimKiem();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case '6':
                        Program.Menu();
                        break;
                }
            } while (true);
        }

    }
}
