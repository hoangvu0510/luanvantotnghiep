using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLPhieuDKKham
    {
        private CTruyCapDuLieu tc;

        public CXLPhieuDKKham()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<PhieuDKKham> getDSPhieuDKKham()
        {
            return tc.getDSPhieuDKKham().ToList();
        }
        public List<PhieuDKKham> getDSPhieuDKKhamByUser(string maNV, DateTime tg)
        {
            return tc.getDSPhieuDKKham().Where(x => x.NhanVien.MaNhanVien == maNV && x.NgayLap.Value.Date == tg.Date).ToList();
        }
        public List<PhieuDKKham> getDSPDKKChuaKham()
        {
            var dsChuaKham = (from a in tc.getDSPhieuDKKham()
                              where !tc.getDSPhieuKhamBenh().Any(x => x.PhieuDKKID == a.IDPhieuDKK)
                              select a).ToList();
            return dsChuaKham;
        }
        public List<PhieuDKKham> getDSPDKKTheoPhong(string maPhong)
        {
            List<PhieuDKKham> pdkkPhong = new List<PhieuDKKham>();
            foreach(PhieuDKKham a in tc.getDSPhieuDKKham())
            {
                if(a.NgayLap.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    foreach (CTDKPhongKham b in a.CTDKPhongKham)
                    {
                        if (b.PhongKham.MaPhongKham == maPhong)
                            pdkkPhong.Add(a);
                    }
                }             
            }
            return pdkkPhong;
        }
        public List<PhieuDKKham> getDSPDKKChuaKham(string maPBS)
        {
            var dsChuaKham = (from a in getDSPDKKTheoPhong(maPBS)
                              where !tc.getDSPhieuKhamBenh().Any(x => x.PhieuDKKID == a.IDPhieuDKK)
                              select a).ToList();
            return dsChuaKham;
        }
        public List<PhieuSDDV> getDSCTPhieuSDDV(string maPDKK)
        {
            List<PhieuSDDV> lpsddv = new List<PhieuSDDV>();
            foreach (PhieuSDDV pdv in tc.getDSPhieuSDDV())
            {
                if (pdv.PhieuDKKham.MaPhieuDKK == maPDKK)
                    lpsddv.Add(pdv);
            }
            return lpsddv;
        }
        public List<CTDKDichVu> getDSLichSuDV(string maPDKK)
        {
            List<CTDKDichVu> lsdv = new List<CTDKDichVu>();
            PhieuDKKham pdkk = Tim(maPDKK);
            if (pdkk != null)
            {
                foreach (PhieuSDDV pdv in pdkk.PhieuSDDV)
                {
                    if (pdv.CTDKDichVu != null)
                    {
                        lsdv.AddRange(pdv.CTDKDichVu);
                    }
                }
            }
            return lsdv;
        }
        public IEnumerable<CLichSuDVModel> getDSLichSuDVByDS(List<CTDKDichVu> ds)
        {
            return ds.Select(x => new CLichSuDVModel
            {
                ID = x.ID,
                MaPhieuSDDV = x.PhieuSDDV.MaPhieuSDDV.ToString(),
                MaDichVu = x.DichVu.MaDichVu.ToString(),
                TenDichVu = x.DichVu.TenDichVu.ToString(),
                TrangThaiThanhToan = x.TrangThai==false || x.TrangThai ==null ? "Chưa thanh toán": "Đã nộp phí",
            });
        }
        public List<PhieuDKKham> getDSPhieuDKKham(DateTime TuNgay, DateTime DenNgay, bool dadongtien)
        {
            if (dadongtien == false) //chưa đóng  tiền, nợ > 0
                return tc.getDSPhieuDKKham().ToList();
            else // đã đóng tiền, nợ = 0
                return tc.getDSPhieuDKKham().ToList();
        }
        public IEnumerable<CPhieuDKKhamModel> getDSPhieuDKKhamByDS(List<PhieuDKKham> ds)
        {
            return ds.Select(x => new CPhieuDKKhamModel
            {
                IDPhieuDKKham = x.IDPhieuDKK,
                MaPhieuDKKham = x.MaPhieuDKK,
                NgayLap = x.NgayLap.Value.ToShortDateString(),

                MaBenhNhan = x.BenhNhan.MaBenhNhan.ToString(),
                TenBenhNhan = x.BenhNhan.HoTen.ToString(),
                NgaySinh = x.BenhNhan.NgaySinh.Value.ToShortDateString(),
                CMND = x.BenhNhan.CMND == null ? string.Empty : x.BenhNhan.CMND.ToString(),
                TrangThai = x.TrangThai == null || x.TrangThai == false ? "Chưa khám" : "Đang khám",
                MaNhanVien = x.NhanVien.MaNhanVien.ToString(),
            });
        }
        public IEnumerable<CPhieuDKKhamModel> getDSPhieuDKKhamByDS(string maNV)
        {
            NhanVien nv = (NhanVien)tc.getDSNhanVien().Where(x => x.MaNhanVien == maNV);
            LichKham lk_nv_p = (LichKham)tc.getDSLichKham().Where(x => x.NhanVienID == nv.IDNhanVien);
            List<PhieuDKKham> ds_pdkk_nv_phong = new List<PhieuDKKham>();
            foreach (PhieuDKKham a in tc.getDSPhieuDKKham())
            {
                List<CTDKPhongKham> dsDKPK = a.CTDKPhongKham.ToList();
                foreach (CTDKPhongKham b in dsDKPK)
                {
                    if (b.PhongKhamID == lk_nv_p.PhongKhamID)
                    {
                        ds_pdkk_nv_phong.Add(a);
                    }
                }
            }
            return ds_pdkk_nv_phong.Select(x => new CPhieuDKKhamModel
            {
                IDPhieuDKKham = x.IDPhieuDKK,
                MaPhieuDKKham = x.MaPhieuDKK,
                NgayLap = x.NgayLap.Value.ToShortDateString(),

                MaBenhNhan = x.BenhNhan.MaBenhNhan.ToString(),
                TenBenhNhan = x.BenhNhan.HoTen.ToString(),
                NgaySinh = x.BenhNhan.NgaySinh.Value.ToShortDateString(),
                CMND = x.BenhNhan.CMND == null ? string.Empty : x.BenhNhan.CMND.ToString(),
                MaNhanVien = x.NhanVien.MaNhanVien.ToString(),
            });
        }

        public IEnumerable<CCTPhieuDKPKModel> getDSPhieuDKKhamByDS(List<CTDKPhongKham> ds)
        {
            return ds.Select(x => new CCTPhieuDKPKModel
            {
                PhongKhamID = x.PhongKhamID,
                TenChuyenKhoa = x.PhongKham.ChuyenKhoa.TenChuyenKhoa.ToString(),
                TenPhongKham = x.PhongKham.TenPhongKham.ToString(),
            });
        }
        public IEnumerable<CCTPhieuDKDVModel> getDSPhieuDKKhamByDS(List<CTDKDichVu> ds)
        {
            return ds.Select(x => new CCTPhieuDKDVModel
            {
                DichVuID = x.DichVuID,
                TenLoaiDichVu = x.DichVu.LoaiDichVu.TenLoaiDV.ToString(),
                TenDichVu = x.DichVu.TenDichVu.ToString(),
                DonGiaDichVu = x.DichVu.DonGiaDichVu.Value,
            });
        }
        public string taoMaPK()
        {
            string sohd = "000000001";
            foreach (PhieuDKKham a in tc.getDSPhieuDKKham().
                OrderByDescending(x => x.MaPhieuDKK).Take(1).ToList())
            {
                string s = a.MaPhieuDKK.Substring(4);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "PDKK" + sohd;
            return sohd;
        }
        public List<PhieuDKKham> Tim(string key, int k)
        {
            if (k == 0)
                return tc.getDSPhieuDKKham().Where(x => x.MaPhieuDKK.Contains(key)).ToList();
            else if (k == 1)
                return tc.getDSPhieuDKKham().Where(x => x.BenhNhan.MaBenhNhan.Contains(key)).ToList();
            else if (k == 2)
                return tc.getDSPhieuDKKham().Where(x => x.BenhNhan.HoTen.Contains(key)).ToList();
            else
                return null;

        }
        public PhieuDKKham Tim(string maPK)
        {
            foreach (PhieuDKKham pk in tc.getDSPhieuDKKham().Where(x => x.MaPhieuDKK == maPK))
            {
                return pk;
            }
            return null;
        }
        public void Them(PhieuDKKham a)
        {
            tc.getDSPhieuDKKham().InsertOnSubmit(a);
            tc.capnhat();
        }
        public void ThemPSDDV(PhieuDKKham a)
        {
            PhieuDKKham b = Tim(a.MaPhieuDKK);
            if (b != null)
            {
                b.PhieuSDDV.AddRange(a.PhieuSDDV);
                tc.capnhat();
            }
        }
        public void Sua(PhieuDKKham a)
        {
            PhieuDKKham b = Tim(a.MaPhieuDKK);
            if (b != null)
            {
                b.BenhNhanID = a.BenhNhanID;
                b.NgayLap = a.NgayLap;
                tc.capnhat();
            }
        }
        public void DaDongTien(string mpdkk)
        {
            PhieuDKKham b = Tim(mpdkk);
            if (b != null)
            {
                tc.capnhat();
            }
        }
        public void DangKham(string mpdkk)
        {
            PhieuDKKham b = Tim(mpdkk);
            if (b != null)
            {
                b.TrangThai = true;
                tc.capnhat();
            }
        }

    }
}
