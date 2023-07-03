using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp1_BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Menu();
        }
        static void Menu()
        {
            SERVICE sv = new SERVICE();
            int chonChuongTrinh;
            do
            {
                Console.WriteLine("----Menu----");
                Console.WriteLine("1. Nhập");
                Console.WriteLine("2. Xuất");
                Console.WriteLine("3. Danh sách sinh viên được tặng vé VIP");
                Console.WriteLine("4. Xóa những sinh viên không được tham gia HappyBee nếu không được tặng");
                Console.WriteLine("5. Kế thừa");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("------------");
                Console.WriteLine("Mời bạn chọn chương trình mong muốn");
                chonChuongTrinh = Convert.ToInt32(Console.ReadLine());
                switch (chonChuongTrinh)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        sv.Nhap();
                        break;
                    case 2:
                        sv.Xuat();
                        break;
                    case 3:
                        sv.XuatDanhSachSVVeVip();
                        break;
                    case 4:
                        sv.XoaSVKhongDiHappyBee();
                        break;
                    case 5:
                        sv.KeThua();
                        break; 
                    default:
                        Console.WriteLine("Chương trình chọn sai, mời chọn lại");
                        break;
                }
            } while (chonChuongTrinh !=0);
        }
    }
}
