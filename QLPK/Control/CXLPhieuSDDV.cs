using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLPhieuSDDV
    {
        private CTruyCapDuLieu tc;

        public CXLPhieuSDDV()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<PhieuSDDV> getDSPhieuSDDV()
        {
            return tc.getDSPhieuSDDV().ToList();
        }
        public IEnumerable<CPhieuSDDVModel> getDSPhieuSDDVByDS(List<PhieuSDDV> ds)
        {
            return ds.Select(x => new CPhieuSDDVModel
            {
                IDPhieuSDDV = x.IDPhieuSDDV,
                MaPhieuSDDV = x.MaPhieuSDDV,
                NgayLap = x.NgayLap.Value.ToShortDateString(),

                MaBenhNhan = x.PhieuDKKham.BenhNhan.MaBenhNhan.ToString(),
                TenBenhNhan = x.PhieuDKKham.BenhNhan.HoTen.ToString(),
                NgaySinh = x.PhieuDKKham.BenhNhan.NgaySinh.Value.ToShortDateString(),
                CMND = x.PhieuDKKham.BenhNhan.CMND == null ? string.Empty : x.PhieuDKKham.BenhNhan.CMND.ToString(),
                TongTien = x.TongTien == null ? 0 : x.TongTien.Value,

                MaNhanVien = x.NhanVien.MaNhanVien.ToString(),
            });
        }
        public List<PhieuSDDV> getDSPhieuSDDV(DateTime TuNgay, DateTime DenNgay, bool dadongtien)
        {
            if (dadongtien == false) //chưa đóng  tiền, nợ > 0
                return tc.getDSPhieuSDDV().Where(x => x.NgayLap.Value.Date >= TuNgay.Date && x.NgayLap.Value.Date <= DenNgay.Date && x.TongTien.Value > 0).ToList();
                //return tc.getDSPhieuDKKham().ToList();
            else // đã đóng tiền, nợ = 0
                return tc.getDSPhieuSDDV().Where(x => x.NgayLap.Value.Date >= TuNgay.Date && x.NgayLap.Value.Date <= DenNgay.Date && x.TongTien.Value == 0).ToList();
                //return tc.getDSPhieuDKKham().ToList();
        }
        //public IEnumerable<CPhieuSDDVModel> getDSPhieuSDDVByDS(List<PhieuSDDV> ds)
        //{
        //    return ds.Select(x => new CPhieuSDDVModel
        //    {
        //        IDPhieuSDDV = x.IDPhieuDKK,
        //        MaPhieuSDDV = x.MaPhieuDKK,
        //        NgayLap = x.NgayLap.Value.ToShortDateString(),

        //        MaBenhNhan = x.BenhNhan.MaBenhNhan.ToString(),
        //        TenBenhNhan = x.BenhNhan.HoTen.ToString(),
        //        NgaySinh = x.BenhNhan.NgaySinh.Value.ToShortDateString(),
        //        CMND = x.BenhNhan.CMND == null ? string.Empty : x.BenhNhan.CMND.ToString(),
        //        //TongTien = x.TongTien == null ? 0 : x.TongTien.Value,

        //        MaNhanVien = x.NhanVien.MaNhanVien.ToString(),
        //    });
        //}

        public IEnumerable<CCTPhieuDKPKModel> getDSPhieuSDDVByDS(List<CTDKPhongKham> ds)
        {
            return ds.Select(x => new CCTPhieuDKPKModel
            {
                PhongKhamID = x.PhongKhamID,
                TenChuyenKhoa = x.PhongKham.ChuyenKhoa.TenChuyenKhoa.ToString(),
                TenPhongKham = x.PhongKham.TenPhongKham.ToString(),
            });
        }
        public IEnumerable<CCTPhieuSDDVVModel> getDSPhieuSDDVByDS(List<CTDKDichVu> ds)
        {
            return ds.Select(x => new CCTPhieuSDDVVModel
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
            foreach (PhieuSDDV a in tc.getDSPhieuSDDV().
                OrderByDescending(x => x.MaPhieuSDDV).Take(1).ToList())
            {
                string s = a.MaPhieuSDDV.Substring(5);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "PSDDV" + sohd;
            return sohd;
        }
        //public List<PhieuSDDV> Tim(string key, int k)
        //{
        //    if (k == 0)
        //        return tc.getDSPhieuSDDV().Where(x => x.MaPhieuDKK.Contains(key)).ToList();
        //    else if (k == 1)
        //        return tc.getDSPhieuSDDV().Where(x => x.BenhNhan.MaBenhNhan.Contains(key)).ToList();
        //    else if (k == 2)
        //        return tc.getDSPhieuSDDV().Where(x => x.BenhNhan.HoTen.Contains(key)).ToList();
        //    else
        //        return null;

        //}
        //public IEnumerable<CCTDKPK_LKModel> TimCTDKPK_LK(int idPhong, DateTime t)
        // {
        //     LichKham lk = (LichKham)tc.getDSLichKham().Where(x => x.PhongKhamID == idPhong && x.Ngay.Value==t);
        //     IEnumerable<CTDKPhongKham> ct_dkpk = tc.getDSCTDKPhongKham().Where(x => x.PhongKhamID == idPhong && x.PhieuSDDV.NgayLap.Value == t);

        //     IEnumerable<CCTDKPK_LKModel> kq = 
        //    return kq;

        // }
        public PhieuSDDV Tim(string maPK)
        {
            foreach (PhieuSDDV pk in tc.getDSPhieuSDDV().Where(x => x.MaPhieuSDDV == maPK))
            {
                return pk;
            }
            return null;
        }
        public void Them(PhieuSDDV a)
        {
            tc.getDSPhieuSDDV().InsertOnSubmit(a);
            tc.capnhat();
        }

        public void Sua(PhieuSDDV a)
        {
            PhieuSDDV b = Tim(a.MaPhieuSDDV);
            if (b != null)
            {
                b.CTDKDichVu = a.CTDKDichVu;
                tc.capnhat();
            }
        }
        public void DaDongTien(string mpdkk)
        {
            PhieuSDDV b = Tim(mpdkk);
            if (b != null)
            {
                b.TongTien = 0;
                foreach(CTDKDichVu c in b.CTDKDichVu)
                {
                    c.TrangThai = true;
                }
                tc.capnhat();
            }
        }

    }
}
