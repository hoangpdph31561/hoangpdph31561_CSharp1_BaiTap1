using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp1_BaiTap1
{
    internal class SERVICE
    {
        List<SinhVien> _lstSinhViens;
        string _input;
        public SERVICE()
        {
            _lstSinhViens = new List<SinhVien>()
            {
                new SinhVien("PH1","Hoang",1998,8.9),
                new SinhVien("PH2","Quang",1999,10),
                new SinhVien("PH3","Huan",2000,8.6),
                new SinhVien("PH4","Minh",2004,8.2),
                new SinhVien("PH5","Linh",2003,7.1),
                new SinhVien("PH6","Giang",1997,9.8),
                new SinhVien("PH7","Son",1995,3.9),
            };
        }
        /// <summary>
        /// Nhập từ bàn phím
        /// </summary>
        /// <param name="msg">thông tin yêu cầu nhập</param>
        /// <returns>Trả về string mà người dùng nhập từ bàn phím</returns>
        private string GetInput(string msg)
        {
            Console.WriteLine($"Xin mời nhập {msg}");
            return Console.ReadLine();
        }
        /// <summary>
        /// Kiểm tra regex của người dùng nhập
        /// </summary>
        /// <param name="msg">Thông tin muốn nhập</param>
        /// <param name="regex">Regex kiểm tra</param>
        /// <returns>Nếu nhập thỏa mãn regex, sẽ trả về kết quả</returns>
        private string GetInputWithRegex(string msg, string regex)
        {
            string nhap;
            do
            {
                nhap = GetInput(msg);
                if (!Regex.IsMatch(nhap, regex))
                {
                    Console.WriteLine($"Phần nhập không thỏa mãn regex {msg}");
                    Console.WriteLine("Mời nhập lại");
                }
            } while (!Regex.IsMatch(nhap, regex));
            return nhap;
        }
        public void Nhap()
        {
            do
            {
                SinhVien student = new SinhVien();
            checkMaSinhVien: //kiểm tra mã sv đã nhập đã tồn tại hay chưa
                string checkMaSV = GetInput("mã sinh viên");
                //đếm xem mã sv vừa nhập có tồn tại hay không
                int count = _lstSinhViens.Count(x => x.MaSV.Trim().ToLower()  == checkMaSV.Trim().ToLower());
                if(count != 0)
                {
                    Console.WriteLine("Mã sinh viên bạn nhập đã tồn tại");
                    Console.WriteLine("Mời nhập mã sinh viên khác");
                    goto checkMaSinhVien;
                }
                student.MaSV = checkMaSV;
                student.Ten = GetInputWithRegex("tên sinh viên", @"^[a-zA-Z\s]+$");
            checkNamSinh: 
                //kiểm tra năm sinh nhập vào có lớn hơn năm hiện tại
                int kiemTraNamSinh = Convert.ToInt32(GetInputWithRegex("năm sinh của sinh viên", @"^[1-9]{1}[\d]{3}$"));
                if(kiemTraNamSinh > DateTime.Now.Year)
                {
                    Console.WriteLine($"Năm sinh bạn nhập quá năm hiện tại là: {DateTime.Now.Year}");
                    Console.WriteLine("Mời nhập lại");
                    goto checkNamSinh;
                }
                student.NamSinh = kiemTraNamSinh;
            checkDiem: //kiểm tra điểm sinh viên xem có nằm trong khoảng 0-10 hay không
                double kiemTraDiem = Convert.ToDouble(GetInputWithRegex("điểm sinh viên", @"^[\d]+\,?[\d]*$"));
                if(kiemTraDiem < 0 || kiemTraDiem > 10)
                {
                    Console.WriteLine("Điểm bạn nhập không nằm trong khoảng từ 0 - 10");
                    Console.WriteLine("Mời bạn nhập lại");
                    goto checkDiem;
                }
                student.Diem = kiemTraDiem;
                _lstSinhViens.Add(student);
                //Hỏi người dùng có nhập tiếp hay không
                do
                {
                    _input = GetInput("tiếp tục không");
                    //Chỉ được nhập có hoặc không, nếu sai nhập lại
                    if(String.Compare(_input,"có",true) !=0 && String.Compare(_input,"không",true) !=0)
                    {
                        Console.WriteLine("Chỉ được nhập có hoặc không, mời nhập lại");
                    }
                } while (String.Compare(_input, "có", true) != 0 && String.Compare(_input, "không", true) != 0);
            } while (String.Compare(_input, "có", true) == 0);
        }
        /// <summary>
        /// Kiểm tra xem có bản ghi nào trong List của sinh viên hay không
        /// </summary>
        /// <returns>Nếu có => true, nếu không => false</returns>
        private bool CheckCount()
        {
            if(_lstSinhViens.Count == 0)
            {
                Console.WriteLine("Danh sách không có bản ghi nào");
                return false;
            }
            return true;
        }
        public void Xuat()
        {
            if (CheckCount())
            {
                foreach (var item in _lstSinhViens)
                {
                    item.InThongTin();
                }
            }
        }
        /// <summary>
        /// Danh sách sinh viên được vé VIP (Điểm >=8)
        /// </summary>
        /// <returns>Trả về list sinh viên được tặng vé</returns>
        private List<SinhVien> DanhSachSVTangVeVip()
        {
            List<SinhVien> lstSinhVienVeVip = new List<SinhVien> ();
            if(CheckCount())
            {
                lstSinhVienVeVip = _lstSinhViens.Where(x => x.Diem >=8).ToList();
            }
            return lstSinhVienVeVip;
        }
        /// <summary>
        /// Xuất danh sách sinh viên được tặng vé vip
        /// </summary>
        public void XuatDanhSachSVVeVip()
        {
            List<SinhVien> lstSinhVienVeVip = DanhSachSVTangVeVip();
            if(lstSinhVienVeVip.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào đc tặng vé VIP");
            }
            else
            {
                foreach (var item in lstSinhVienVeVip)
                {
                    item.InThongTin();
                }
            }
        }
        /// <summary>
        /// Tính tuổi
        /// </summary>
        /// <param name="namSinh">Năm sinh của người cần tính tuổi</param>
        /// <returns>Trả về tuổi</returns>
        private int TinhTuoi(int namSinh)
        {
            return DateTime.Now.Year - namSinh;
        }
        public void XoaSVKhongDiHappyBee()
        {
            List<SinhVien> lstSinhVienKhongDiHappyBee = _lstSinhViens.Where(x => TinhTuoi(x.NamSinh) > 25 && x.Diem < 8).ToList();
            if (lstSinhVienKhongDiHappyBee.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào không được đi HappyBee");
            }
            else
            {
                Console.WriteLine("Danh sách sinh viên bị xóa là");
                foreach (var item in lstSinhVienKhongDiHappyBee)
                {
                    item.InThongTin();
                    _lstSinhViens.Remove(item);
                }
                Console.WriteLine();
                Console.WriteLine("Xóa thành công");
            }
        }
        public void KeThua()
        {
            SinhVienUD studentUD = new SinhVienUD("PH123","Meo",1990,9.8,4);
            studentUD.InThongTin();
        }
    }
}
