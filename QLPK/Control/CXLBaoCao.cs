using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLBaoCao
    {
        private CTruyCapDuLieu tc;
        public CXLBaoCao()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<PhieuThu> getDSPhieuThu()
        {
            return tc.getDSPhieuThu().ToList();
        }
        public List<PhieuThu> TimPT(string maPT)
        {
            List<PhieuThu> ds = new List<PhieuThu>();

            foreach (PhieuThu a in tc.getDSPhieuThu().Where(x => x.MaPhieuThu == maPT))
            {
                ds.Add(a);
            }

            if (ds.Count > 0)
                return ds;
            else
                return null;
        }

        public List<PhieuThu> TimNgay(DateTime ngay, int caTruc)
        {
            List<PhieuThu> ds = new List<PhieuThu>();
            foreach (PhieuThu a in tc.getDSPhieuThu().Where(x => x.NgayLap >= ngay && x.NhanVienLapID == Common.nhanVienID))
            {
                ds.Add(a);
            }

            if (ds.Count > 0)
                return ds;
            else
                return null;
        }
        public List<CBCPhieuThuModel> getDSPhieuThuReport(string maPT)
        {
            var query = TimPT(maPT);
            var i = 1;
            var all = (from a in query.AsEnumerable()
                       join b in tc.getDSCTDKDichVu() on a.PhieuSDDVID equals b.PhieuSDDVID into val
                       from b in val.DefaultIfEmpty()
                       select new CBCPhieuThuModel
                       {
                           STT = i++,
                           NgayLap = a.NgayLap,
                           MaPhieuThu = a.MaPhieuThu,
                           TenBenhNhan = a.PhieuSDDV.PhieuDKKham.BenhNhan.HoTen,
                           TenNhanVien = a.NhanVien.HoTen,
                           DiaChi = a.PhieuSDDV.PhieuDKKham.BenhNhan.DiaChi,
                           GioiTinh = a.PhieuSDDV.PhieuDKKham.BenhNhan.GioiTinh,
                           NamSinh = a.PhieuSDDV.PhieuDKKham.BenhNhan.NgaySinh,
                           TenDV = b.DichVu.TenDichVu,
                           GiaDV = b.DichVu.DonGiaDichVu,
                           TongTien = a.TongTien,
                           MaPhieuDDK = a.PhieuSDDV.PhieuDKKham.MaPhieuDKK,
                           NhanVienLapPhieuSDDV = a.PhieuSDDV.NhanVien.HoTen
                       }).ToList();
            return all;
        }

        public List<CBCPhieuThuModel> getTKNhanVienThuNganReport(DateTime ngay, int caTrucID)
        {
            var i = 1;

            var caTruc = (from ct in tc.getDSCaTruc()
                          where ct.IDCaTruc == caTrucID
                          select new
                          {
                              ThoiGianBD = ct.ThoiGianBD,
                              ThoiGianKT = ct.ThoiGianKT,
                              TenCaTruc = ct.TenCaTruc
                          }).FirstOrDefault();
            if (caTruc != null)
            {
                var tuNgay = ngay + caTruc.ThoiGianBD;
                var denNgay = ngay + caTruc.ThoiGianKT;
                var lstBCPhieuThu = (from a in tc.getDSPhieuThu().AsEnumerable()
                                     where a.NgayLap >= tuNgay && a.NgayLap <= denNgay && a.NhanVienLapID == Common.nhanVienID
                                     select new CBCPhieuThuModel
                                     {
                                         STT = i++,
                                         MaPhieuThu = a.MaPhieuThu,
                                         TenBenhNhan = a.PhieuSDDV.PhieuDKKham.BenhNhan.HoTen,
                                         TenNhanVien = a.NhanVien.HoTen,
                                         TongTien = a.TongTien,
                                         NgayLap = ngay,
                                         CaTruc = caTruc.TenCaTruc
                                     }).ToList();

                return lstBCPhieuThu;
            }
            return new List<CBCPhieuThuModel>();
        }

        public List<CBCPhieuKhamBenhModel> getTKNhanVienBacSiReport(DateTime ngay, int caTrucID)
        {
            var i = 1;

            var caTruc = (from ct in tc.getDSCaTruc()
                          where ct.IDCaTruc == caTrucID
                          select new
                          {
                              ThoiGianBD = ct.ThoiGianBD,
                              ThoiGianKT = ct.ThoiGianKT,
                              TenCaTruc = ct.TenCaTruc
                          }).FirstOrDefault();
            if (caTruc != null)
            {
                var tuNgay = ngay + caTruc.ThoiGianBD;
                var denNgay = ngay + caTruc.ThoiGianKT;
                var lstBCPhieuKB = (from a in tc.getDSPhieuKhamBenh().AsEnumerable()
                                    where a.NgayLap >= tuNgay && a.NgayLap <= denNgay && a.NhanVienLapID == Common.nhanVienID
                                    select new CBCPhieuKhamBenhModel
                                    {
                                        STT = i++,
                                        MaPhieuKB = a.MaPhieuKB,
                                        TenBenhNhan = a.PhieuDKKham.BenhNhan.HoTen,
                                        TenNhanVien = a.NhanVien.HoTen,
                                        ChanDoan = a.ChanDoan,
                                        NgayLap = ngay,
                                        CaTruc = caTruc.TenCaTruc
                                    }).ToList();
                return lstBCPhieuKB;
            }
            return new List<CBCPhieuKhamBenhModel>();
        }

        public List<CBCPhieuDKKhamModel> getTKNhanVienTiepNhanReport(DateTime ngay, int caTrucID)
        {
            var i = 1;

            var caTruc = (from ct in tc.getDSCaTruc()
                          where ct.IDCaTruc == caTrucID
                          select new
                          {
                              ThoiGianBD = ct.ThoiGianBD,
                              ThoiGianKT = ct.ThoiGianKT,
                              TenCaTruc = ct.TenCaTruc
                          }).FirstOrDefault();
            if (caTruc != null)
            {
                var tuNgay = ngay + caTruc.ThoiGianBD;
                var denNgay = ngay + caTruc.ThoiGianKT;
                var lstBCPhieuDKK = (from a in tc.getDSPhieuDKKham().AsEnumerable()
                                     where a.NgayLap >= tuNgay && a.NgayLap <= denNgay && a.NhanVienLapID == Common.nhanVienID
                                     select new CBCPhieuDKKhamModel
                                     {
                                         STT = i++,
                                         MaPhieuDKK = a.MaPhieuDKK,
                                         TenBenhNhan = a.BenhNhan.HoTen,
                                         TenNhanVien = a.NhanVien.HoTen,
                                         TrieuChung = a.TrieuChung,
                                         NgayLap = ngay,
                                         CaTruc = caTruc.TenCaTruc
                                     }).ToList();
                return lstBCPhieuDKK;
            }
            return new List<CBCPhieuDKKhamModel>();
        }

        public List<CBCPhieuDKKhamModel> getTKPhieuDKKReport(DateTime tuNgay, DateTime denNgay, int idNhanVien)
        {
            var i = 1;
            var lstAll = new List<CBCPhieuDKKhamModel>();
            var lstBCPhieuDKK = (from a in tc.getDSPhieuDKKham().AsEnumerable()
                                 where a.NgayLap.Value.Date >= tuNgay.Date && a.NgayLap.Value.Date <= denNgay.Date
                                 select new CBCPhieuDKKhamModel
                                 {
                                     STT = i++,
                                     MaPhieuDKK = a.MaPhieuDKK,
                                     TenBenhNhan = a.BenhNhan.HoTen,
                                     TenNhanVien = a.NhanVien.HoTen,
                                     TrieuChung = a.TrieuChung,
                                     TuNgay = tuNgay,
                                     DenNgay = denNgay,
                                     IDNhanVien = a.NhanVienLapID
                                 });
            lstAll = lstBCPhieuDKK.ToList();
            if (idNhanVien != 0)
            {
                lstAll = lstBCPhieuDKK.Where(x => x.IDNhanVien == idNhanVien).ToList();
            }
            return lstAll;
        }
        public List<CBCPhieuKhamBenhModel> getTKPhieuKhamBenhReport(DateTime tuNgay, DateTime denNgay, int idNhanVien)
        {
            var i = 1;
            var lstAll = new List<CBCPhieuKhamBenhModel>();
            var lstBCPhieuKB = (from a in tc.getDSPhieuKhamBenh().AsEnumerable()
                                where a.NgayLap.Value.Date >= tuNgay.Date && a.NgayLap.Value.Date <= denNgay.Date
                                select new CBCPhieuKhamBenhModel
                                {
                                    STT = i++,
                                    MaPhieuKB = a.MaPhieuKB,
                                    TenBenhNhan = a.PhieuDKKham.BenhNhan.HoTen,
                                    TenNhanVien = a.NhanVien.HoTen,
                                    IDNhanVien = a.NhanVienLapID,
                                    ChanDoan = a.ChanDoan,
                                    NgayLap = a.NgayLap,
                                    TuNgay = tuNgay,
                                    DenNgay = denNgay
                                });
            lstAll = lstBCPhieuKB.ToList();
            if (idNhanVien != 0)
            {
                lstAll = lstBCPhieuKB.Where(x => x.IDNhanVien == idNhanVien).ToList();
            }
            return lstAll;
        }

        public List<CBCPhieuThuModel> getTKPhieuThuReport(DateTime tuNgay, DateTime denNgay, int idNhanVien)
        {
            var i = 1;
            var lstAll = new List<CBCPhieuThuModel>();
            var lstBCPhieuThu = (from a in tc.getDSPhieuThu().AsEnumerable()
                                 where a.NgayLap.Value.Date >= tuNgay.Date && a.NgayLap.Value.Date <= denNgay.Date
                                 select new CBCPhieuThuModel
                                 {
                                     STT = i++,
                                     MaPhieuThu = a.MaPhieuThu,
                                     TenBenhNhan = a.PhieuSDDV.PhieuDKKham.BenhNhan.HoTen,
                                     TenNhanVien = a.NhanVien.HoTen,
                                     TongTien = a.TongTien,
                                     IDNhanVien = a.NhanVienLapID
                                 });
            lstAll = lstBCPhieuThu.ToList();
            if (idNhanVien != 0)
            {
                lstAll = lstBCPhieuThu.Where(x => x.IDNhanVien == idNhanVien).ToList();
            }
            return lstAll;

        }
    }
}

