using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.BusinessLayer.Interface;
using QLĐT.Entities;


namespace QLĐT.Presenation
{
    public class FromKhachHang
    {
        private IKhachHangBLL khBLL = new KhachHangBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN KHACH HANG");
            KhachHang kh = new KhachHang();
            Console.Write("Nhap ma khach hang:"); kh.MaKhachHang = Console.ReadLine();
            Console.Write("Nhap ten khach hang:"); kh.HoTen = Console.ReadLine();
            Console.Write("Nhap que quan khach hang:"); kh.QueQuan = Console.ReadLine();
            Console.Write("Nhap dia chi khach hang:"); kh.DiaChi = Console.ReadLine();
            Console.Write("Nhap sdt khach hang:"); kh.SodienThoai = Console.ReadLine();
            khBLL.ThemKhachHang(kh);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN KHACH HANG");
            List<KhachHang> list = khBLL.GetAllKhachHang();
            foreach (var kh in list)
                Console.WriteLine(kh.MaKhachHang + "\t" + kh.HoTen + "\t" + kh.QueQuan + "\t" + kh.DiaChi + "\t" + kh.SodienThoai);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN KHACH HANG");
            List<KhachHang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("Nhap ma khach hang can sua:");
            makhachhang = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhachHang == makhachhang) break;

            if (i < list.Count)
            {
                KhachHang kh = new KhachHang(list[i]);
                Console.Write("Nhap ten moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) kh.HoTen = ten;
                Console.Write("Nhap que quan moi:");
                string qq = Console.ReadLine();
                if (!string.IsNullOrEmpty(qq)) kh.QueQuan = qq;
                Console.Write("Nhap dia chi moi:");
                string dc = Console.ReadLine();
                if (!string.IsNullOrEmpty(dc)) kh.DiaChi = dc;
                Console.Write("Nhap so dien thoai moi :");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) kh.SodienThoai = sdt;
                khBLL.SuaKhachHang(kh);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma khach hang nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XOA THONG TIN KHACH HANG");
            List<KhachHang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("Nhap ma khach hang can xoa:");
            makhachhang = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhachHang == makhachhang) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                khBLL.XoaKhachHang(makhachhang);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma khach hang nay");
            }
        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("Tim kiem khach hang");
            List<KhachHang> list = khBLL.GetAllKhachHang();

            Console.Write("Nhap thong tin khach hang can tim kiem:");
            string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].HoTen == tt) break;
            if (i < list.Count)
            {
                List<KhachHang> grt = khBLL.TimKhachHang(new KhachHang(list[i]));
                foreach (var x in grt)

                    Console.WriteLine(x.MaKhachHang + "\t" + x.HoTen + "\t" + x.QueQuan + "\t" + x.DiaChi + "\t" + x.SodienThoai);
            }

            else Console.WriteLine("Thong tin khach hang nay k ton tai");


        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN KHACH HANG");
                Console.WriteLine(" 1.Nhap khach hang ");
                Console.WriteLine(" 2.Sua khach hang ");
                Console.WriteLine(" 3.Xoa khach hang ");
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
