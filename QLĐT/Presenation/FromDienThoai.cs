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
            Console.WriteLine("------------------------------NHẬP THÔNG TIN ĐIỆN THOẠI------------------------------");
            DienThoai dt = new DienThoai();
            Console.Write("                         Mã điện thoại:"); dt.MaDienThoai = Console.ReadLine();
            Console.Write("                         Tên điện thoại:"); dt.TenDienThoai = Console.ReadLine();
            Console.Write("                         Giá bán:"); dt.DonGia = int.Parse(Console.ReadLine());
            dtBLL.ThemDienThoai(dt);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("------------------------------HIỂN THỊ THÔNG TIN ĐIỆN THOẠI------------------------------");
            List<DienThoai> list = dtBLL.GetAllDienThoai();
            foreach (var dt in list)
                Console.WriteLine(dt.MaDienThoai + "\t" + dt.TenDienThoai + "\t" + dt.DonGia);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("------------------------------SỬA THÔNG TIN ĐIỆN THOẠI------------------------------");
            List<DienThoai> list = dtBLL.GetAllDienThoai();
            string madienthoai;
            Console.Write("                         Nhập mã điện thoại cần sửa:");
            madienthoai = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaDienThoai == madienthoai) break;

            if (i < list.Count)
            {
                DienThoai dt = new DienThoai(list[i]);
                Console.Write("                         Nhập tên mới:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) dt.TenDienThoai = ten;
                Console.Write("                         Giá mới:");
                int gia = int.Parse(Console.ReadLine());
                if (gia > 0) dt.DonGia = gia;
                dtBLL.SuaDienThoai(dt);
            }
            else
            {
                Console.WriteLine("                         Không tồn tại mã điện thoại này!!!");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("------------------------------XÓA THÔNG TIN ĐIỆN THOẠI------------------------------");
            List<DienThoai> list = dtBLL.GetAllDienThoai();
            string madienthoai;
            Console.Write("                         Nhập mã điện thoại cần xóa:");
            madienthoai = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaDienThoai == madienthoai) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                dtBLL.XoaDienThoai(madienthoai);
            }
            else
            {
                Console.WriteLine("                         Không tồn tại mã điện thoại này!!!");
            }
        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("------------------------------TÌM KIẾM ĐIỆN THOẠI------------------------------");
            List<DienThoai> list = dtBLL.GetAllDienThoai();

            Console.Write("                         Nhập thông tin điện thoại cần tìm kiếm:");
            string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].MaDienThoai == tt || list[i].TenDienThoai == tt) break;
            if (i < list.Count)
            {
                List<DienThoai> grt = dtBLL.TimDienThoai(new DienThoai(list[i]));
                foreach (var x in grt)

                    Console.WriteLine(x.MaDienThoai + "\t" + x.TenDienThoai + "\t" + x.DonGia);
            }

            else Console.WriteLine("                         Thông tin điện thoại này không tồn tại!!!");


        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------QUẢN LÝ THÔNG TIN ĐIỆN THOẠI------------------------------");
                Console.WriteLine("                      ┌─────────────────────────────────────────┐");
                Console.WriteLine("                      |            1.Nhập điện thoại            |");
                Console.WriteLine("                      ├─────────────────────────────────────────┤");
                Console.WriteLine("                      |            2.Sửa điện thoại             |");
                Console.WriteLine("                      ├─────────────────────────────────────────┤");
                Console.WriteLine("                      |            3.Xóa điện thoại             |");
                Console.WriteLine("                      ├─────────────────────────────────────────┤");
                Console.WriteLine("                      |            4.Hiển thị danh sách         |");
                Console.WriteLine("                      ├─────────────────────────────────────────┤");
                Console.WriteLine("                      |            5.Tìm kiếm                   |");
                Console.WriteLine("                      ├─────────────────────────────────────────┤");
                Console.WriteLine("                      |            6.Trờ lại                    |");
                Console.WriteLine("                      └─────────────────────────────────────────┘");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        Nhap();
                        Hien();
                        Console.WriteLine("                         Nhấn phím bất kì để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case '4':
                        Hien();
                        Console.WriteLine("                         Nhấn phím bất kì để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case '2':
                        Sua();
                        Hien();
                        Console.WriteLine("                         Nhấn phím bất kì để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case '3':
                        Xoa();
                        Hien();
                        Console.WriteLine("                         Nhấn phím bất kì để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case '5':
                        TimKiem();                      
                        Console.WriteLine("                         Nhấn phím bất kì để tiếp tục...");
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
