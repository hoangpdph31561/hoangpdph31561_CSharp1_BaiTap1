using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoangpdph31561_CSharp1_BaiTap1
{
    internal class SinhVien
    {
        private string maSV;
        private string ten;
        private int namSinh;
        private double diem;
        public SinhVien()
        {
            
        }

        public SinhVien(string maSV, string ten, int namSinh, double diem)
        {
            this.maSV = maSV;
            this.ten = ten;
            this.namSinh = namSinh;
            this.diem = diem;
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string Ten {  get => ten; set => ten = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public double Diem { get => diem; set => diem = value; }
        public virtual void InThongTin()
        {
            Console.WriteLine($"Mã sinh viên: {maSV}| " +
                $"Tên sinh viên: {ten}| " +
                $"Năm sinh: {namSinh}| " +
                $"Điểm: {diem}|");
        }
    }
}
