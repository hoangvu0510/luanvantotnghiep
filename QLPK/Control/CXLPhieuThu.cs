using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLPhieuThu
    {
        private CTruyCapDuLieu tc;

        public CXLPhieuThu()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<PhieuThu> getDSPhieuThu()
        {
            return tc.getDSPhieuThu().ToList();
        }
        public List<PhieuThu> getDSPhieuThuByUser(string maNV, DateTime tg)
        {
            return tc.getDSPhieuThu().Where(x => x.NhanVien.MaNhanVien == maNV && x.NgayLap.Value.Date == tg.Date).ToList();
        }
        public IEnumerable<CPhieuThuModel> getDSPhieuThuByDS(List<PhieuThu> ds)
        {
            return ds.Select(x => new CPhieuThuModel
            {
                IDPhieuThu = x.IDPhieuThu.ToString() == null ? 0 : x.IDPhieuThu,
                MaPhieuThu = x.MaPhieuThu.ToString() == null ? "null" : x.MaPhieuThu,
                NgayLap = x.NgayLap.Value.ToShortDateString() == null ? DateTime.Now.ToShortDateString() : x.NgayLap.Value.ToShortDateString(),
                MaPhieuSDDV = x.PhieuSDDV.MaPhieuSDDV.ToString() == null ? "null" : x.PhieuSDDV.MaPhieuSDDV,
                MaNhanVien = x.NhanVien.MaNhanVien.ToString() == null ? "null" : x.NhanVien.MaNhanVien,
                PhieuSDDVID = x.PhieuSDDVID.Value.ToString() == null ? 0 : x.PhieuSDDVID.Value,
                TongTien = x.TongTien == null ? 0 : x.TongTien.Value,
            });
        }
        /*public IEnumerable<CCTPhieuDKPKModel> getDSPhieuThuByDS(List<CTDKPhongKham> ds)
        {
            return ds.Select(x => new CCTPhieuDKPKModel
            {
                PhongKhamID = x.PhongKhamID.Value,
                TenChuyenKhoa = x.PhongKham.ChuyenKhoa.TenChuyenKhoa.ToString(),
                TenPhongKham = x.PhongKham.TenPhongKham.ToString(),
            });
        }
        public IEnumerable<CCTPhieuDKDVModel> getDSPhieuThuByDS(List<CTDKDichVu> ds)
        {
            return ds.Select(x => new CCTPhieuDKDVModel
            {
                DichVuID = x.DichVuID.Value,
                TenLoaiDichVu = x.DichVu.LoaiDichVu.TenLoaiDichVu.ToString(),
                TenDichVu = x.DichVu.TenDichVu.ToString(),
            });
        }     */   
        public string taoMaPT()
        {
            string sohd = "000000001";
            foreach (PhieuThu a in tc.getDSPhieuThu().
                OrderByDescending(x => x.MaPhieuThu).Take(1).ToList())
            {
                string s = a.MaPhieuThu.Substring(4);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "PT" + sohd;
            return sohd;
        }
        public PhieuThu Tim(string maPK)
        {
            foreach (PhieuThu pk in tc.getDSPhieuThu().Where(x => x.MaPhieuThu == maPK))
            {
                return pk;
            }
            return null;
        }
        public void Them(PhieuThu a)
        {
            tc.getDSPhieuThu().InsertOnSubmit(a);
            tc.capnhat();
        }

        public void Sua(PhieuThu a)
        {
            PhieuThu b = Tim(a.MaPhieuThu);
            if (b != null)
            {
               /* b.BenhNhanID = a.BenhNhanID;
                b.NgayLap = a.NgayLap;*/
            }
        }

    }
}
