using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLDonThuoc
    {
        private CTruyCapDuLieu tc;

        public CXLDonThuoc()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<DonThuoc> getDSDonThuoc()
        {
            return tc.getDSDonThuoc().ToList();
        }
        //public List<DonThuoc> getDSDonThuoc(DateTime TuNgay, DateTime DenNgay, bool dadongtien)
        //{
        //    if (dadongtien == false) //chưa đóng  tiền, nợ > 0
        //        return tc.getDSDonThuoc().Where(x => x.NgayLap.Value.Date >= TuNgay.Date && x.NgayLap.Value.Date <= DenNgay.Date && x.TongTien.Value > 0).ToList();
        //    else // đã đóng tiền, nợ = 0
        //        return tc.getDSDonThuoc().Where(x => x.NgayLap.Value.Date >= TuNgay.Date && x.NgayLap.Value.Date <= DenNgay.Date && x.TongTien.Value == 0).ToList();
        //}
        public IEnumerable<CDonThuocModel> getDSDonThuocByDS(List<DonThuoc> ds)
        {
            return ds.Select(x => new CDonThuocModel
            {
                IDDonThuoc = x.IDDonThuoc,
                MaDonThuoc = x.MaDonThuoc,
                NgayLap = x.NgayLap.Value,

                MaPhieuKhamBenh = x.PhieuKhamBenh.MaPhieuKB.ToString(),
                TongTien = x.TongTien == null ? 0 : x.TongTien.Value,
                MaBenhNhan = x.PhieuKhamBenh.PhieuDKKham.BenhNhan.MaBenhNhan,
                MaNhanVien = x.PhieuKhamBenh.NhanVien.MaNhanVien
                

                //MaNhanVien = x.NhanVienLapID.
            });
        }

        public IEnumerable<CCTPhieuDKPKModel> getDSDonThuocByDS(List<CTDKPhongKham> ds)
        {
            return ds.Select(x => new CCTPhieuDKPKModel
            {
                PhongKhamID = x.PhongKhamID,
                TenChuyenKhoa = x.PhongKham.ChuyenKhoa.TenChuyenKhoa.ToString(),
                TenPhongKham = x.PhongKham.TenPhongKham.ToString(),
            });
        }
        public IEnumerable<CCTPhieuDKDVModel> getDSDonThuocByDS(List<CTDKDichVu> ds)
        {
            return ds.Select(x => new CCTPhieuDKDVModel
            {
                DichVuID = x.DichVuID,
                TenLoaiDichVu = x.DichVu.LoaiDichVu.TenLoaiDV.ToString(),
                TenDichVu = x.DichVu.TenDichVu.ToString(),
                DonGiaDichVu = x.DichVu.DonGiaDichVu.Value,
            });
        }
        public string taoMa()
        {
            string sohd = "000000001";
            foreach (DonThuoc a in tc.getDSDonThuoc().
                OrderByDescending(x => x.MaDonThuoc).Take(1).ToList())
            {
                string s = a.MaDonThuoc.Substring(4);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "DT" + sohd;
            return sohd;
        }
        public List<DonThuoc> Tim(string key, int k)
        {
            if (k == 0)
                return tc.getDSDonThuoc().Where(x => x.PhieuKhamBenh.MaPhieuKB.Contains(key)).ToList();
            else if (k == 1)
                return tc.getDSDonThuoc().Where(x => x.MaDonThuoc.Contains(key)).ToList();
            //else if (k == 1)
            //    return tc.getDSDonThuoc().Where(x => x.PhieuKhamBenh.PhieuDKKham.MaBenhNhan.Contains(key)).ToList();
            //else if (k == 2)
            //    return tc.getDSDonThuoc().Where(x => x.BenhNhan.HoTen.Contains(key)).ToList();
            //else
            return null;

        }
        //public IEnumerable<CCTDKPK_LKModel> TimCTDKPK_LK(int idPhong, DateTime t)
        // {
        //     LichKham lk = (LichKham)tc.getDSLichKham().Where(x => x.PhongKhamID == idPhong && x.Ngay.Value==t);
        //     IEnumerable<CTDKPhongKham> ct_dkpk = tc.getDSCTDKPhongKham().Where(x => x.PhongKhamID == idPhong && x.DonThuoc.NgayLap.Value == t);

        //     IEnumerable<CCTDKPK_LKModel> kq = 
        //    return kq;

        // }
        public DonThuoc Tim(string maPK)
        {
            foreach (DonThuoc pk in tc.getDSDonThuoc().Where(x => x.MaDonThuoc == maPK))
            {
                return pk;
            }
            return null;
        }
        public void Them(DonThuoc a)
        {
            tc.getDSDonThuoc().InsertOnSubmit(a);
            tc.capnhat();
        }

        //public void Sua(DonThuoc a)
        //{
        //    DonThuoc b = Tim(a.MaDonThuoc);
        //    if (b != null)
        //    {
        //        b.BenhNhanID = a.BenhNhanID;
        //        b.NgayLap = a.NgayLap;
        //        tc.capnhat();
        //    }
        //}
        //public void DaDongTien(string mpdkk)
        //{
        //    DonThuoc b = Tim(mpdkk);
        //    if (b != null)
        //    {
        //        b.TongTien = 0;
        //        tc.capnhat();
        //    }
        //}

    }
}
