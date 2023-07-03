using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp1_BaiTap1
{
    internal class SinhVienUD : SinhVien
    {
        private int kiHoc;
        public SinhVienUD()
        {
            
        }

        public SinhVienUD(string maSV, string ten, int namSinh, double diem, int kiHoc) : base(maSV, ten, namSinh, diem)
        {
            this.kiHoc = kiHoc;
        }

        public int KiHoc { get => kiHoc; set => kiHoc = value; }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Kỳ học: {kiHoc}");
        }
    }
}
