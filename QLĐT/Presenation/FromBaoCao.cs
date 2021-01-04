using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLĐT.BusinessLayer.Interface;
using QLĐT.Entities;

namespace QLĐT.Presenation
{
    public class FromBaoCao
    {
        private IHoaDonBLL hdBLL = new HoaDonBLL();
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("------------------------------HIỂN THỊ BÁO CÁO------------------------------");
            string day = DateTime.Now.ToString("dd/MM/yyyy_hh:mm:ss");
            Console.WriteLine(day);
            List<HoaDon> list = hdBLL.GetAllHoaDon();
            foreach (var hd in list)
                Console.WriteLine(hd.MaHoaDon + "\t" + hd.TenDienThoai + "\t" + hd.NgayBan + "\t" + hd.SoLuong + "\t" + hd.TongTien);            
        }
        public void SoLuongDT()
        {
            Console.WriteLine("");
        }
        public void TongTienThuNhap()
        {

        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------BÁO CÁO/ THỐNG KÊ-----------------------------------");
                Console.WriteLine("                      ┌─────────────────────────────────────────┐                       ");
                Console.WriteLine("                      |            1.Hiển thị                   |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            2.Tổng số lượng bán ra       |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            3.Tổng tiền thu nhập         |                       ");
                Console.WriteLine("                      ├─────────────────────────────────────────┤                       ");
                Console.WriteLine("                      |            4.Trờ lại                    |                       ");
                Console.WriteLine("                      └─────────────────────────────────────────┘                       ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        Hien();
                        Console.WriteLine("                         Nhấn phím bất kì để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case '2':
                        SoLuongDT();
                        break;
                    case '4':
                        Program.Menu();
                        break;
                }
            } while (true);
        }

    }
}