
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Model
{
    class CTruyCapDuLieu
    {
        private static CTruyCapDuLieu m_tc = null;
        private QLPKDataContext dc;
        private CTruyCapDuLieu()
        {
            dc = new QLPKDataContext();
        }
        public static CTruyCapDuLieu khoitao()
        {
            if (m_tc == null) m_tc = new CTruyCapDuLieu();
            return m_tc;
        }
        public Table<BenhNhan> getDSBenhNhan()
        {
            return dc.BenhNhan;
        }       
        public Table<VaiTro> getDSVaiTro()
        {
            return dc.VaiTro;
        }
        public Table<NhanVien> getDSNhanVien()
        {
            return dc.NhanVien;
        }
        public Table<PhongKham> getDSPhongKham()
        {
            return dc.PhongKham;
        }
        public Table<ChuyenKhoa> getDSChuyenKhoa()
        {
            return dc.ChuyenKhoa;
        }
        public Table<Thuoc> getDSThuoc()
        {
            return dc.Thuoc;
        }
        public Table<PhieuThu> getDSPhieuThu()
        {
            return dc.PhieuThu;
        }
        public Table<DichVu> getDSDichVu()
        {
            return dc.DichVu;
        }
        public Table<LoaiDichVu> getDSLoaiDichVu()
        {
            return dc.LoaiDichVu;
        }
        public Table<CTCNBenhNhan> getDSCTCNBenhNhan()
        {
            return dc.CTCNBenhNhan;
        }
        public Table<PhieuDKKham> getDSPhieuDKKham()
        {
            return dc.PhieuDKKham;
        }
        public Table<CTDKDichVu> getDSCTDKDichVu()
        {
            return dc.CTDKDichVu;
        }
        public Table<CTDKPhongKham> getDSCTDKPhongKham()
        {
            return dc.CTDKPhongKham;
        }

        public Table<LichKham> getDSLichKham()
        {
            return dc.LichKham;
        }
        public Table<CaTruc> getDSCaTruc()
        {
            return dc.CaTruc;
        }
        public Table<CTDonThuoc> getDSCTDonThuoc()
        {
            return dc.CTDonThuoc;
        }

        public Table<DonThuoc> getDSDonThuoc()
        {
            return dc.DonThuoc;
        }
        public Table<PhieuKhamBenh> getDSPhieuKhamBenh()
        {
            return dc.PhieuKhamBenh;
        }
        public Table<PhieuSDDV> getDSPhieuSDDV()
        {
            return dc.PhieuSDDV;
        }
        public void capnhat()
        {
            dc.SubmitChanges();
        }
    }
}
