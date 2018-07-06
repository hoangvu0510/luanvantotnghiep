using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Model
{
    class CLichSuDVModel
    {
        public int ID { get; set; }
        public string MaPhieuSDDV { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string KetQua { get; set; }
        public string TrangThaiThanhToan { get; set; }
    }
    class CPhongKhamModel
    {
        public int ID { get; set; }
        public string MaPhongKham { get; set; }
        public string TenPhongKham { get; set; }
        public string TrangThai { get; set; }
        public int? ChuyenKhoaID { get; set; }
        public string ChuyenKhoa { get; set; }

    }
    class CCTDonThuocModel
    {
        public int ID { get; set; }
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DuongDung { get; set; }
        public string DonViTinh { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? ThanhTien { get; set; }
        public int? SoLuong { get; set; }
        public int? ThuocID { get; set; }
    }
    class CNhanVienModel
    {
        public int IDNhanVien { get; set; }

        public int STT { get; set; }
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TrangThai { get; set; }
        public string KhoaNhanVien { get; set; }
        public int? VaiTroID { get; set; }
        public int? PhongKhamID { get; set; }
        public int? ChuyenKhoaID { get; set; }
        public string VaiTro { get; set; }
        public string PhongKham { get; set; }
        public string ChuyenKhoa { get; set; }
    }
    class CLichKhamModel
    {
        public int IDLichKham { get; set; }
        public string MaLichKham { get; set; }
        public int? NhanVienID { get; set; }
        public string TenNhanVien { get; set; }
        public int? PhongKhamID { get; set; }
        public string TenPhongKham { get; set; }
        public string TenCaTruc { get; set; }
        public int? CaTrucID { get; set; }
        public string Ngay { get; set; }
        public int? SoBenhNhan { get; set; }
        public int? SoBenhNhanHoanTat { get; set; }
        public int? SoBenhNhanChoKham { get; set; }
        // public List<CTDKPhongKham> ctdkpk { get; set; }
    }
    class CDonThuocModel
    {
        public int IDDonThuoc { get; set; }
        public string MaDonThuoc { get; set; }
        public string MaPhieuKhamBenh { get; set; }
        public int? PhieuKhamBenhID { get; set; }
        public string MaNhanVien { get; set; }
        public string MaBenhNhan { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime NgayLap { get; set; }
    }
    class CDichVuModel
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal? DonGiaDichVu { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public int? LoaiDichVuID { get; set; }
        public string LoaiDichVu { get; set; }
    }
    class CChuyenKhoaModel
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public string MaChuyenKhoa { get; set; }
        public string TenChuyenKhoa { get; set; }
        public string MoTa { get; set; }

    }
    class CBenhNhanModel
    {
        public int STT { get; set; }
        public decimal ID { get; set; }
        public string MaBenhNhan { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Tuoi { get; set; }
        public string CMND { get; set; }


    }
    class CPhieuThuModel
    {
        public int? IDPhieuThu { get; set; }
        public int? NhanVienLapID { get; set; }
        public int? PhieuSDDVID { get; set; }
        public string NgayLap { get; set; }
        public string MaPhieuThu { get; set; }
        public string MaNhanVien { get; set; }
        public string MaPhieuSDDV { get; set; }
        public decimal? TongTien { get; set; }

    }




    class CPhieuDKKhamModel
    {
        public int IDPhieuDKKham { get; set; }
        public string MaPhieuDKKham { get; set; }
        public string NgayLap { get; set; }
        public string TenBenhNhan { get; set; }
        public string MaBenhNhan { get; set; }
        public string TenDichVu { get; set; }
        public string TenPhongKham { get; set; }
        public string DonGiaDichVu { get; set; }
        public string MaNhanVien { get; set; }
        public string CMND { get; set; }
        public string NgaySinh { get; set; }
        public string TrangThai { get; set; }
        public decimal? TongTien { get; set; }
        public List<CTDKDichVu> lstCTDKDV { get; set; }
        public List<CTDKPhongKham> lstCTDKPK { get; set; }
    }
    class CCTPhieuDKPKModel
    {
        public int PhieuDKKhamID { get; set; }
        public int? PhieuKhamID { get; set; }
        public int? ChuyenKhoaID { get; set; }
        public int? PhongKhamID { get; set; }
        public string TenChuyenKhoa { get; set; }
        public string TenPhongKham { get; set; }

    }
    class CCTDKPK_LKModel
    {
        public int ID { get; set; }
        //public int? PhieuKhamID { get; set; }
        //public int? ChuyenKhoaID { get; set; }
        //public int? PhongKhamID { get; set; }
        //public string TenChuyenKhoa { get; set; }
        public string TenPhongKham { get; set; }
        public string TenNhanVien { get; set; }
        public int? SoBenhNhan { get; set; }

    }
    class CCTPhieuDKDVModel
    {
        public int ID { get; set; }
        public int? PhieuKhamID { get; set; }
        public int? LoaiDichVuID { get; set; }
        public int? DichVuID { get; set; }
        public string TenLoaiDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal? DonGiaDichVu { get; set; }

    }
    class CCTPhieuDKKhamModel
    {
        public int ID { get; set; }
        public string MaChiTietPhieuKham { get; set; }
        public string TenChiTietPhieuKham { get; set; }
        public int? PhieuKhamID { get; set; }
        public int? ChuyenKhoaID { get; set; }
        public int? PhongKhamID { get; set; }
        public int? LoaiDichVuID { get; set; }
        public int? DichVuID { get; set; }
        public string GhiChu { get; set; }

        public string MaDichVu { get; set; }

        public ChuyenKhoa ChuyenKhoa { get; set; }
        public PhongKham PhongKham { get; set; }
        public LoaiDichVu LoaiDichVu { get; set; }
        public DichVu DichVu { get; set; }
    }





    class CPhieuSDDVModel
    {
        public int IDPhieuSDDV { get; set; }
        public string MaPhieuSDDV { get; set; }
        public string NgayLap { get; set; }
        public string PhieuDKKID { get; set; }
        public string MaPhieuDDK { get; set; }
        public string MaNhanVien { get; set; }
        public string MaBenhNhan { get; set; }
        public string TenBenhNhan { get; set; }
        public string NgaySinh { get; set; }
        public string CMND { get; set; }
        public decimal? TongTien { get; set; }
        public List<CTDKDichVu> lstCTDKDV { get; set; }
    }
    class CCTPhieuSDDVVModel
    {
        public int I { get; set; }
        public int? PhieuSDDVID { get; set; }
        public int? LoaiDichVuID { get; set; }
        public int? DichVuID { get; set; }
        public string TenLoaiDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal? DonGiaDichVu { get; set; }

    }

    class CPhieuKBModel
    {
        public int IDPhieuKB { get; set; }
        public int? PhieuDKKID { get; set; }
        public int? BenhNhanID { get; set; }
        public int? NhanVienID { get; set; }
        public int? DonThuocID { get; set; }
        public string MaPhieuKB { get; set; }
        public string MaBenhNhan { get; set; }
        public string MaNhanVien { get; set; }
        public string MaPhieuDKK { get; set; }
        public string TenBenhNhan { get; set; }
        public string NgayLap { get; set; }
        public string Chandoan { get; set; }

    }



    class CLapPhieuKhamModel
    {
        public int ID { get; set; }
        public string MaPhieuKham { get; set; }
        public string TenPhieuKham { get; set; }
        public string NgayLap { get; set; }
        public int? BenhNhanID { get; set; }
        public string TenBenhNhan { get; set; }
        public string MaBenhNhan { get; set; }
        //public List<ChiTietPhieuKham> lstCTPK { get; set; }
    }
    class CCTLapPhieuKhamModel
    {
        public int ID { get; set; }
        public string MaChiTietPhieuKham { get; set; }
        public string TenChiTietPhieuKham { get; set; }
        public int? PhieuKhamID { get; set; }
        public int? ChuyenKhoaID { get; set; }
        public int? PhongKhamID { get; set; }
        public int? LoaiDichVuID { get; set; }
        public int? DichVuID { get; set; }
        public string GhiChu { get; set; }
        public string MaDichVu { get; set; }
        public ChuyenKhoa ChuyenKhoa { get; set; }
        public PhongKham PhongKham { get; set; }
        public LoaiDichVu LoaiDichVu { get; set; }
        public DichVu DichVu { get; set; }
    }

    class CBCPhieuThuModel
    {
        public int? PhieuSDDVID { get; set; }
        public int STT { get; set; }
        public DateTime? NgayLap { get; set; }
        public string MaPhieuThu { get; set; }
        public string TenNhanVien { get; set; }
        public int? IDNhanVien { get; set; }
        public string TenBenhNhan { get; set; }
        public DateTime? NamSinh { get; set; }
        public bool? GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public decimal? GiaDV { get; set; }
        public string TenDV { get; set; }
        public decimal? TongTien { get; set; }
        public string CaTruc { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string NhanVienLapPhieuSDDV { get; set; }
        public string MaPhieuDDK { get; set; }
    }
    class CBCPhieuKhamBenhModel
    {
        public string CaTruc { get; set; }
        public string TenBenhNhan { get; set; }
        public string TenNhanVien { get; set; }
        public int? IDNhanVien { get; set; }
        public string MaPhieuKB { get; set; }
        public DateTime? NgayLap { get; set; }
        public string ChanDoan { get; set; }
        public int STT { get; set; }
        public bool? GioiTinh { get; set; }
        public DateTime? NamSinh { get; set; }

        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }

    }

    class CBCPhieuDKKhamModel
    {
        public string CaTruc { get; set; }
        public string TenBenhNhan { get; set; }
        public string TenNhanVien { get; set; }
        public int? IDNhanVien { get; set; }
        public string MaPhieuDKK { get; set; }
        public string MaPhieuSDDV { get; set; }
        public DateTime? NgayLap { get; set; }
        public string TrieuChung { get; set; }
        public int STT { get; set; }
        public bool? GioiTinh { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }

    }
}
