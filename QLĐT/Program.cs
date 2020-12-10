using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.Presenation;

namespace QLĐT
{
    public class Program
    {
        public static void Menu()
        {
            {
                Console.Clear();
                Console.WriteLine("------------------------------ĐỒ ÁN XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ BÁN ĐIỆN THOẠI------------------------------");
                Console.WriteLine("                                 ┌─────────────────────────────────────────┐");
                Console.WriteLine("                                 |           1.Quản lý điện thoại          |");
                Console.WriteLine("                                 ├─────────────────────────────────────────┤");
                Console.WriteLine("                                 |           2.Quản lý khách hàng          |");
                Console.WriteLine("                                 ├─────────────────────────────────────────┤");
                Console.WriteLine("                                 |           3.Quản lý hóa đơn             |");
                Console.WriteLine("                                 ├─────────────────────────────────────────┤");
                Console.WriteLine("                                 |           4.Báo cáo/Thống kê            |");
                Console.WriteLine("                                 ├─────────────────────────────────────────┤");
                Console.WriteLine("                                 |           5.Kết thúc                    |");
                Console.WriteLine("                                 └─────────────────────────────────────────┘");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        FromDienThoai frmdt = new FromDienThoai();
                        frmdt.Menu();
                        break;
                    case '2':
                        FromKhachHang frmkh = new FromKhachHang();
                        frmkh.Menu();
                        break;
                    case '3':
                        FromHoaDon frmhd = new FromHoaDon();
                        frmhd.Menu();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            do
            {
                Console.WriteLine("                                 ┌─────────────────────────────────────────┐");
                Console.WriteLine("                                 |                Đăng nhập                |");
                Console.WriteLine("                                 └─────────────────────────────────────────┘");
                Console.Write("                                           Tài khoản:");
                String tk = Console.ReadLine();
                Console.Write("                                           Mật khẩu:");
                String mk = Console.ReadLine();
                if (tk == "1" && mk == "1")
                {
                    Console.Clear();
                    Menu();
                }
                else
                {

                    Console.WriteLine("                                Tài khoản hoặc mật khẩu không chính xác!!!");
                    Console.WriteLine("                                Chọn 1 để tiếp tục đăng nhập | Chọn 2 để thoát");
                    String chon = Console.ReadLine();
                    if (chon == "1")
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (chon == "2")
                    {
                        break;
                    }
                }
            } while (true); 
        }
    }
}
