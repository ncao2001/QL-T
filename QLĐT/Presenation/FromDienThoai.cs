using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.BusinessLayer.Interface;
using QLĐT.Entities;


namespace QLĐT.Presenation
{
    public class FromDienThoai
    {
        private IDienThoaiBLL dtBLL = new DienThoaiBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN DIEN THOAI");
            DienThoai dt = new DienThoai();
            Console.Write("Nhap ten dien thoai:"); dt.TenDienThoai = Console.ReadLine();
            Console.Write("Nhap gia dien thoai:"); dt.DonGia = int.Parse(Console.ReadLine());
            dtBLL.ThemDienThoai(dt);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN DIEN THOAI");
            List<DienThoai> list = dtBLL.GetAllDienThoai();
            foreach (var sp in list)
                Console.WriteLine(sp.MaDienThoai + "\t" + sp.TenDienThoai + "\t" + sp.DonGia);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN DIEN THOAI");
            List<DienThoai> list = dtBLL.GetAllDienThoai();
            string madienthoai;
            Console.Write("Nhap ma dien thoai can sua:");
            madienthoai = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaDienThoai == madienthoai) break;

            if (i < list.Count)
            {
                DienThoai dt = new DienThoai(list[i]);
                Console.Write("Nhap ten moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) dt.TenDienThoai = ten;
                Console.Write("Gia moi:");
                int gia = int.Parse(Console.ReadLine());
                if (gia > 0) dt.DonGia = gia;
                dtBLL.SuaDienThoai(dt);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma dien thoai nay");
            }
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN DIEN THOAI");
                Console.WriteLine(" 1.Nhap dien thoai ");
                Console.WriteLine(" 2.Sua dien thoai ");
                Console.WriteLine(" 3.Xoa dien thoai ");
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
                    case '6':
                        Program.Menu();
                        break;
                }
            } while (true);
        }
    }
}
