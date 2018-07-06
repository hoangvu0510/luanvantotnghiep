using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLPhieuKhamBenh
    {
        private CTruyCapDuLieu tc;

        public CXLPhieuKhamBenh()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<PhieuKhamBenh> getDSPhieuKhamBenh()
        {
            return tc.getDSPhieuKhamBenh().ToList();
        }
        public List<PhieuKhamBenh> getDSPhieuKhamBenhByBenhNhan(string maBN)
        {
            return getDSPhieuKhamBenh().Where(x => x.PhieuDKKham.BenhNhan.MaBenhNhan == maBN).ToList();
        }
        public List<PhieuKhamBenh> getDSPhieuKhamBenhByUser(string maNV, DateTime tg)
        {
            return tc.getDSPhieuKhamBenh().Where(x => x.NhanVien.MaNhanVien == maNV && x.NgayLap.Value.Date == tg.Date).ToList();
        }

        public IEnumerable<CPhieuKBModel> getDSPhieuKhamBenhByDS(List<PhieuKhamBenh> ds)
        {
            return ds.Select(x => new CPhieuKBModel
            {
                IDPhieuKB = x.IDPhieuKB,
                MaPhieuKB = x.MaPhieuKB,
                NgayLap = x.NgayLap.Value.ToShortDateString(),
                MaPhieuDKK = x.PhieuDKKham.MaPhieuDKK.ToString(),
                MaBenhNhan = x.PhieuDKKham.BenhNhan.MaBenhNhan.ToString(),
                TenBenhNhan = x.PhieuDKKham.BenhNhan.HoTen.ToString(),
                MaNhanVien = x.NhanVien.MaNhanVien.ToString(),
                Chandoan = x.ChanDoan.ToString(),
            });
        }

        public IEnumerable<CCTPhieuDKPKModel> getDSPhieuKhamBenhByDS(List<CTDKPhongKham> ds)
        {
            return ds.Select(x => new CCTPhieuDKPKModel
            {
                PhongKhamID = x.PhongKhamID,
                TenChuyenKhoa = x.PhongKham.ChuyenKhoa.TenChuyenKhoa.ToString(),
                TenPhongKham = x.PhongKham.TenPhongKham.ToString(),
            });
        }
        public IEnumerable<CCTPhieuDKDVModel> getDSPhieuKhamBenhByDS(List<CTDKDichVu> ds)
        {
            return ds.Select(x => new CCTPhieuDKDVModel
            {
                DichVuID = x.DichVuID,
                TenLoaiDichVu = x.DichVu.LoaiDichVu.TenLoaiDV,
                TenDichVu = x.DichVu.TenDichVu.ToString(),
                DonGiaDichVu = x.DichVu.DonGiaDichVu.Value,
            });
        }
        public string taoMaPK()
        {
            string sohd = "000000001";
            foreach (PhieuKhamBenh a in tc.getDSPhieuKhamBenh().
                OrderByDescending(x => x.MaPhieuKB).Take(1).ToList())
            {
                string s = a.MaPhieuKB.Substring(3);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "PKB" + sohd;
            return sohd;
        }        
        public PhieuKhamBenh Tim(string maPK)
        {
            foreach (PhieuKhamBenh pk in tc.getDSPhieuKhamBenh().Where(x => x.MaPhieuKB == maPK))
            {
                return pk;
            }
            return null;
        }
        public PhieuKhamBenh PDKK_DaCo_PKB_Chua(PhieuDKKham a)
        {
            foreach (PhieuKhamBenh pk in tc.getDSPhieuKhamBenh().Where(x => x.PhieuDKKham == a))
            {
                return pk;
            }
            return null;
        }
        public void Them(PhieuKhamBenh a)
        {
            tc.getDSPhieuKhamBenh().InsertOnSubmit(a);
            tc.capnhat();
        }     

    }
}
