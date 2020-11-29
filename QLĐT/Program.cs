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
            do
            {
                Console.Clear();
                Console.WriteLine(" 1.Quan ly khach hang ");
                Console.WriteLine(" 2.Quan ly dien thoai ");
                Console.WriteLine(" 3.Quan ly hoa don ");
                Console.WriteLine(" 4.Bao cao/Thong ke ");
                Console.WriteLine(" 5.Ket thuc ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        FromDienThoai frm = new FromDienThoai();
                        frm.Menu();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
