using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLPK.Model
{
    class CMyCommands
    {
        // Event benh nhan
        public static RoutedUICommand ThemBenhNhan = new RoutedUICommand("them", "ThemBenhNhan", typeof(CMyCommands));
        public static RoutedUICommand SuaBenhNhan = new RoutedUICommand("sua", "SuaBenhNhan", typeof(CMyCommands));
        public static RoutedUICommand XoaBenhNhan = new RoutedUICommand("xoa", "XoaBenhNhan", typeof(CMyCommands));
        public static RoutedUICommand TimBenhNhan = new RoutedUICommand("tim", "TimBenhNhan", typeof(CMyCommands));
        // Event he thong
        public static RoutedUICommand DangNhap = new RoutedUICommand("dangnhap", "DangNhap", typeof(CMyCommands));
        public static RoutedUICommand ChapNhan = new RoutedUICommand("chapnhan", "ChapNhan", typeof(CMyCommands));
        public static RoutedUICommand Thoat = new RoutedUICommand("thoat", "Thoat", typeof(CMyCommands));

        // Event vai tro
        public static RoutedUICommand ThemVaiTro = new RoutedUICommand("them", "ThemVaiTro", typeof(CMyCommands));
        public static RoutedUICommand SuaVaiTro = new RoutedUICommand("sua", "SuaVaiTro", typeof(CMyCommands));
        public static RoutedUICommand XoaVaiTro = new RoutedUICommand("tim", "XoaVaiTro", typeof(CMyCommands));

        // event nhan vien
        public static RoutedUICommand ThemNhanVien = new RoutedUICommand("them", "ThemNhanVien", typeof(CMyCommands));
        public static RoutedUICommand SuaNhanVien = new RoutedUICommand("sua", "SuaNhanVien", typeof(CMyCommands));
        public static RoutedUICommand DatLaiMatKhau = new RoutedUICommand("datlaimatkhau", "DatLaiMatKhau", typeof(CMyCommands));
        public static RoutedUICommand TimNhanVien = new RoutedUICommand("tim", "TimNhanVien", typeof(CMyCommands));

        // event phong kham
        public static RoutedUICommand ThemPhongKham = new RoutedUICommand("them", "ThemPhongKham", typeof(CMyCommands));
        public static RoutedUICommand SuaPhongKham = new RoutedUICommand("sua", "SuaPhongKham", typeof(CMyCommands));
        public static RoutedUICommand XoaPhongKham = new RoutedUICommand("xoa", "XoaPhongKham", typeof(CMyCommands));
        public static RoutedUICommand TimPhongKham = new RoutedUICommand("tim", "TimPhongKham", typeof(CMyCommands));

        // event chuyen khoa
        public static RoutedUICommand ThemChuyenKhoa = new RoutedUICommand("them", "ThemChuyenKhoa", typeof(CMyCommands));
        public static RoutedUICommand SuaChuyenKhoa = new RoutedUICommand("sua", "SuaChuyenKhoa", typeof(CMyCommands));
        public static RoutedUICommand XoaChuyenKhoa = new RoutedUICommand("xoa", "XoaChuyenKhoa", typeof(CMyCommands));
        public static RoutedUICommand TimChuyenKhoa = new RoutedUICommand("tim", "TimChuyenKhoa", typeof(CMyCommands));

        // event phan cong cong viec
        public static RoutedUICommand ThemPCCV = new RoutedUICommand("them", "ThemPCCV", typeof(CMyCommands));
        public static RoutedUICommand SuaPCCV = new RoutedUICommand("sua", "SuaPCCV", typeof(CMyCommands));
        public static RoutedUICommand TimPCCV = new RoutedUICommand("tim", "TimPCCV", typeof(CMyCommands));

        // event thuoc

        public static RoutedUICommand ThemThuoc = new RoutedUICommand("them", "ThemThuoc", typeof(CMyCommands));
        public static RoutedUICommand SuaThuoc = new RoutedUICommand("sua", "SuaThuoc", typeof(CMyCommands));
        public static RoutedUICommand XoaThuoc = new RoutedUICommand("xoa", "XoaThuoc", typeof(CMyCommands));
        public static RoutedUICommand TimThuoc = new RoutedUICommand("tim", "TimThuoc", typeof(CMyCommands));

        // event phan quyen

        public static RoutedUICommand PhanQuyen = new RoutedUICommand("them", "PhanQuyen", typeof(CMyCommands));
        public static RoutedUICommand SuaPQ = new RoutedUICommand("sua", "SuaPQ", typeof(CMyCommands));
        public static RoutedUICommand TimPQ = new RoutedUICommand("tim", "TimPQ", typeof(CMyCommands));
        // Event dich vu
        public static RoutedUICommand ThemDichVu = new RoutedUICommand("them", "ThemDichVu", typeof(CMyCommands));
        public static RoutedUICommand SuaDichVu = new RoutedUICommand("sua", "SuaDichVu", typeof(CMyCommands));
        public static RoutedUICommand XoaDichVu = new RoutedUICommand("xoa", "XoaDichVu", typeof(CMyCommands));
        public static RoutedUICommand TimDichVu = new RoutedUICommand("tim", "TimDichVu", typeof(CMyCommands));


        // Event loai dich vu
        public static RoutedUICommand ThemLoaiDichVu = new RoutedUICommand("them", "ThemLoaiDichVu", typeof(CMyCommands));
        public static RoutedUICommand SuaLoaiDichVu = new RoutedUICommand("sua", "SuaLoaiDichVu", typeof(CMyCommands));
        public static RoutedUICommand XoaLoaiDichVu = new RoutedUICommand("xoa", "XoaLoaiDichVu", typeof(CMyCommands));
        public static RoutedUICommand TimLoaiDichVu = new RoutedUICommand("tim", "TimLoaiDichVu", typeof(CMyCommands));


        // event lap pheiu kham
        public static RoutedUICommand ChonBenhNhan = new RoutedUICommand("chonbenhnhan", "ChonBenhNhan", typeof(CMyCommands));
        public static RoutedUICommand LapPhieuKham = new RoutedUICommand("lapphieukham", "LapPhieuKham", typeof(CMyCommands));
        public static RoutedUICommand SuaPhieuKham = new RoutedUICommand("suaphieukham", "SuaPhieuKham", typeof(CMyCommands));
        public static RoutedUICommand LuuCTPhieuKham = new RoutedUICommand("luuctphieukham", "LuuCTPhieuKham", typeof(CMyCommands));
        public static RoutedUICommand XoaCTPhieuKham = new RoutedUICommand("xoactphieukham", "XoaCTPhieuKham", typeof(CMyCommands));


        // event lap phieu dang ky kham
        public static RoutedUICommand LayTTBenhNhan = new RoutedUICommand("LayTTBenhNhan", "LayTTBenhNhan", typeof(CMyCommands));
        public static RoutedUICommand LapPhieuDKKham = new RoutedUICommand("lapphieukham", "LapPhieuKham", typeof(CMyCommands));
        public static RoutedUICommand SuaPhieuDKKham = new RoutedUICommand("suaphieukham", "SuaPhieuKham", typeof(CMyCommands));
        public static RoutedUICommand ThemCTPhongPhieuDKKham = new RoutedUICommand("ThemCTPhongPhieuDKKham", "ThemCTPhongPhieuDKKham", typeof(CMyCommands));
        public static RoutedUICommand XoaCTPhongPhieuDKKham = new RoutedUICommand("XoaCTPhongPhieuDKKham", "XoaCTPhongPhieuDKKham", typeof(CMyCommands));
        public static RoutedUICommand ThemPSDDV = new RoutedUICommand("ThemPSDDV", "ThemPSDDV", typeof(CMyCommands));
        public static RoutedUICommand SuaPSDDV = new RoutedUICommand("SuaPSDDV", "SuaPSDDV", typeof(CMyCommands));
        public static RoutedUICommand ThemCTDichVuPhieuDKKham = new RoutedUICommand("ThemCTDichVuPhieuDKKham", "ThemCTDichVuPhieuDKKham", typeof(CMyCommands));
        public static RoutedUICommand XoaCTDichVuPhieuDKKham = new RoutedUICommand("XoaCTDichVuPhieuDKKham", "XoaCTDichVuPhieuDKKham", typeof(CMyCommands));

        // event lap phieu dang ky kham
        public static RoutedUICommand LapPhieuSDDV = new RoutedUICommand("LapPhieuSDDV", "LapPhieuSDDV", typeof(CMyCommands));
        public static RoutedUICommand SuaPhieuSDDV = new RoutedUICommand("SuaPhieuSDDV", "SuaPhieuSDDV", typeof(CMyCommands));

        // event lap phieu thu
        public static RoutedUICommand XemTT = new RoutedUICommand("xemtt", "XemTT", typeof(CMyCommands));
        public static RoutedUICommand LapPhieuThu = new RoutedUICommand("lapphieuthu", "LapPhieuThu", typeof(CMyCommands));


        //event lap lich kham
        public static RoutedUICommand LapLich = new RoutedUICommand("laplich", "LapLich", typeof(CMyCommands));
        public static RoutedUICommand SuaLich = new RoutedUICommand("sualich", "SuaLich", typeof(CMyCommands));
        public static RoutedUICommand XoaLich = new RoutedUICommand("xoalich", "XoaLich", typeof(CMyCommands));
        public static RoutedUICommand TimLich = new RoutedUICommand("timlich", "TimLich", typeof(CMyCommands));

        //don thuoc
        public static RoutedUICommand LapDonThuoc = new RoutedUICommand("LapDonThuoc", "LapDonThuoc", typeof(CMyCommands));
        public static RoutedUICommand SuaDonThuoc = new RoutedUICommand("SuaDonThuoc", "SuaDonThuoc", typeof(CMyCommands));

        public static RoutedUICommand LapPhieuKhamBenh = new RoutedUICommand("LapPhieuKhamBenh", "LapPhieuKhamBenh", typeof(CMyCommands));
        //public static RoutedUICommand SuaDonThuoc = new RoutedUICommand("SuaDonThuoc", "SuaDonThuoc", typeof(CMyCommands));
    }
}
