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
            Console.WriteLine("------------------------------NHẬP THÔNG TIN HÓA ĐƠN------------------------------");
            HoaDon hd = new HoaDon();
            Console.Write("Mã hóa đơn:"); hd.MaHoaDon = Console.ReadLine();
            Console.Write("Tên điện thoại:"); hd.TenDienThoai = Console.ReadLine();
            Console.Write("Ngày bán:"); hd.NgayBan = Console.ReadLine();
            Console.Write("Số lượng:"); hd.SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Tổng tiền:"); hd.TongTien = int.Parse(Console.ReadLine());
            hdBLL.ThemHoaDon(hd);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("------------------------------HIỂN THỊ THÔNG TIN HÓA ĐƠN------------------------------");
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            foreach (var hd in list)
                Console.WriteLine(hd.MaHoaDon +"\t" + hd.TenDienThoai + "\t" + hd.NgayBan + "\t" + hd.SoLuong + "\t" + hd.TongTien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("------------------------------SỬA THÔNG TIN HÓA ĐƠN------------------------------");
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            string mahoadon;
            Console.Write("Nhập mã hóa đơn cần sửa:");
            mahoadon = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;
            if (i < list.Count)
            {
                HoaDon hd = new HoaDon(list[i]);
                Console.Write("Tên điện thoại:");
                string tendienthoai = Console.ReadLine();
                if (tendienthoai != "")
                hd.TenDienThoai = tendienthoai;
                Console.Write("Ngày bán:");
                string ngayban = Console.ReadLine();
                hd.NgayBan = ngayban;
                Console.Write("Số lượng:");
                int soluong = int.Parse(Console.ReadLine());
                if (soluong > 0) hd.SoLuong = soluong;
                Console.Write("Tổng tiền:");
                int tongtien = int.Parse(Console.ReadLine());
                if (tongtien > 0) hd.TongTien = tongtien;
                hdBLL.SuaHoaDon(hd);
            }
            else
            {
                Console.WriteLine("                         Không tồn tại mã hóa đơn này!!!");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("------------------------------XÓA HÓA ĐƠN------------------------------");
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            string mahoadon;
            Console.Write("Nhập mã hóa đơn cần xóa:");
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
                Console.WriteLine("                         Không tồn tại mã hóa đơn này!!!");
            }
        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("------------------------------TÌM KIẾM HÓA ĐƠN------------------------------");
            List<HoaDon> list = hdBLL.GetAllHoaDon();

            Console.Write("Nhập mã hóa đơn cần tìm kiếm:");
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

            else Console.WriteLine("                         Không tồn tại mã hóa đơn này!!!");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------QUẢN LÝ THÔNG TIN HÓA ĐƠN------------------------------");
                Console.WriteLine("                      ┌─────────────────────────────────────────┐                       ");
                Console.WriteLine("                      |            1.Nhập hóa đơn               |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            2.Sửa hóa đơn                |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            3.Xóa hóa đơn                |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            4.Hiển thị danh sách         |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            5.Tìm kiếm                   |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            6.Trờ lại                    |                       ");
                Console.WriteLine("                      └─────────────────────────────────────────┘                       ");
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
