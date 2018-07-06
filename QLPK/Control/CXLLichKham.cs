using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLLichKham
    {
        private CTruyCapDuLieu tc;
        public CXLLichKham()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<LichKham> getDSLichKham()
        {
            return tc.getDSLichKham().ToList();
        }

        public List<LichKham> getDSLichKham(DateTime d)
        {
            //phân biệt load sáng hay chiều
            //int Ca1BD = 7;
            //int Ca2BD = 13;

            //if (int.Parse(DateTime.Now.Hour.ToString()) >= 7 && int.Parse(DateTime.Now.Hour.ToString()) <= 11)
            //    return tc.getDSLichKham().Where(x => x.Ngay.Value == d && x.CaTrucID == 1).ToList();
            //else if (DateTime.Now.Hour > Ca2BD && DateTime.Now.Hour <= Ca2BD + 4)
            //    return tc.getDSLichKham().Where(x => x.Ngay.Value == d && x.CaTrucID == 2).ToList();
            //else
            //    return null;
            return tc.getDSLichKham().Where(x => x.Ngay.Value.Date == d.Date).ToList();
        }
        public List<LichKham> getDSLichKhamChuyenKhoa(int idChuyenKhoa, DateTime d)
        {
            //phân biệt load sáng hay chiều
            //int Ca1BD = 7;
            //int Ca2BD = 13;

            //if (int.Parse(DateTime.Now.Hour.ToString()) >= 7 && int.Parse(DateTime.Now.Hour.ToString()) <= 11)
            //    return tc.getDSLichKham().Where(x => x.Ngay.Value == d && x.CaTrucID == 1).ToList();
            //else if (DateTime.Now.Hour > Ca2BD && DateTime.Now.Hour <= Ca2BD + 4)
            //    return tc.getDSLichKham().Where(x => x.Ngay.Value == d && x.CaTrucID == 2).ToList();
            //else
            //    return null;
            return tc.getDSLichKham().Where(x => x.PhongKham.ChuyenKhoa.IDChuyenKhoa == idChuyenKhoa && x.Ngay.Value.Date == d.Date).ToList();
        }
        public IEnumerable<CLichKhamModel> getDSLichKhamByDS(List<LichKham> ds)
        {
            return ds.Select(x => new CLichKhamModel
            {
                IDLichKham = x.IDLichKham,
                MaLichKham = x.MaLichKham,
                NhanVienID = x.NhanVienID,
                TenNhanVien = x.NhanVien.HoTen,
                TenPhongKham = x.PhongKham.TenPhongKham,
                PhongKhamID = x.PhongKhamID,
                TenCaTruc = x.CaTruc.TenCaTruc,
                CaTrucID = x.CaTrucID,
                Ngay = x.Ngay.Value.ToShortDateString(),
                //SoBenhNhan = tc.getDSCTDKPhongKham().Where(y => y.PhongKhamID == x.PhongKhamID && y.PhieuDKKham.NgayLap.Value.Date == x.Ngay.Value.Date).Count(),
                SoBenhNhan = FSoBenhNhan(x.PhongKhamID.Value, x.Ngay.Value.Date),
                SoBenhNhanHoanTat = FSoBenhNhanHoanTat(x.PhongKhamID.Value,x.Ngay.Value.Date),
                SoBenhNhanChoKham = FSoBenhNhan(x.PhongKhamID.Value, x.Ngay.Value.Date) - FSoBenhNhanHoanTat(x.PhongKhamID.Value, x.Ngay.Value.Date),
            });
        }
        public int FSoBenhNhan(int idPhongKham, DateTime dt)
        {
            int kq = 0;
            foreach (CTDKPhongKham b in tc.getDSCTDKPhongKham().Where(x => x.PhieuDKKham.NgayLap.Value.Date == dt.Date))
                {
                    if (b.PhongKhamID == idPhongKham)
                        kq++;
                }            
            return kq;
        }
        public int FSoBenhNhanHoanTat(int idPhongKham, DateTime dt)
        {
            int kq = 0;
            foreach( PhieuKhamBenh a in tc.getDSPhieuKhamBenh().Where(x=>x.NgayLap.Value.Date == dt.Date))
            {
                foreach(CTDKPhongKham b in a.PhieuDKKham.CTDKPhongKham)
                {
                    if (b.PhongKhamID == idPhongKham)
                        kq++;
                }
            }
            return kq;
        }
        public List<CaTruc> getDSCaTruc()
        {
            return tc.getDSCaTruc().ToList();
        }

        public List<NhanVien> getDSNhanVien()
        {
            return tc.getDSNhanVien().ToList();
        }

        public List<PhongKham> getDSPhongKham()
        {
            return tc.getDSPhongKham().ToList();
        }

        public List<CaTruc> getDSCaTrucFirstNull()
        {
            List<CaTruc> ds = new List<CaTruc>();
            ds.AddRange(getDSCaTruc());
            return ds;
        }
        public List<PhongKham> getDSPhongKhamFirstNull()
        {
            List<PhongKham> ds = new List<PhongKham>();
            PhongKham a = new PhongKham();
            a.IDPhongKham = -1;
            a.MaPhongKham = "null";
            a.TenPhongKham = "Chọn phòng khám";
            ds.Add(a);
            ds.AddRange(getDSPhongKham());

            return ds;
        }
        public List<NhanVien> getDSNhanVienFirstNull()
        {
            List<NhanVien> ds = new List<NhanVien>();
            NhanVien a = new NhanVien();
            a.IDNhanVien = -1;
            a.MaNhanVien = "null";
            a.HoTen = "Chọn nhân viên";
            ds.Add(a);
            ds.AddRange(getDSNhanVien());

            return ds;
        }
      
        public IEnumerable<CLichKhamModel> getDSLapLich(List<LichKham> ds)
        {
            var query = (from lk in tc.getDSLichKham()
                         join nv in tc.getDSNhanVien() on lk.NhanVienID equals nv.IDNhanVien into val
                         from nv in val.DefaultIfEmpty()
                         join pk in tc.getDSPhongKham() on lk.PhongKhamID equals pk.IDPhongKham into val1
                         from pk in val1.DefaultIfEmpty()
                         join ct in tc.getDSCaTruc() on lk.CaTrucID equals ct.IDCaTruc into val2
                         from ct in val2.DefaultIfEmpty()
                         select new CLichKhamModel
                         {
                             IDLichKham = lk.IDLichKham,
                             MaLichKham = lk.MaLichKham,
                             NhanVienID = nv.IDNhanVien,
                             TenNhanVien = nv.HoTen,
                             TenPhongKham = pk.TenPhongKham,
                             PhongKhamID = pk.IDPhongKham,
                             TenCaTruc = ct.TenCaTruc,
                             CaTrucID = ct.IDCaTruc,
                             Ngay = lk.Ngay.Value.ToShortDateString(),
                         }).ToList();
            return query;
        }

        public void Them(LichKham lk)
        {
            tc.getDSLichKham().InsertOnSubmit(lk);
            tc.capnhat();
        }

        public LichKham Tim(string maLK)
        {
            foreach (LichKham a in tc.getDSLichKham().Where(x => x.MaLichKham == maLK))
            {
                return a;
            }
            return null;
        }
        public LichKham TimLichKhamCuaNV(NhanVien maNV, DateTime d)
        {
            foreach (LichKham a in getDSLichKham().Where(x => x.NhanVien == maNV && x.Ngay.Value.Date == d.Date))
            {
                return a;
            }
            return null;
        }
        public List<CLichKhamModel> TimBy(string txtTim)
        {
            var query = (from lk in tc.getDSLichKham()
                         join nv in tc.getDSNhanVien() on lk.NhanVienID equals nv.IDNhanVien into val
                         from nv in val.DefaultIfEmpty()
                         //join pk in tc.getDSPhongKham() on nv.PhongKhamID equals pk.IDPhongKham into val1
                         //from pk in val1.DefaultIfEmpty()
                         join ct in tc.getDSCaTruc() on lk.CaTrucID equals ct.IDCaTruc into val2
                         from ct in val2.DefaultIfEmpty()
                         where lk.MaLichKham.Contains(txtTim)
                         select new CLichKhamModel
                         {
                            // IDLichKham = nv.ID,
                             MaLichKham = lk.MaLichKham,
                             NhanVienID = nv.IDNhanVien,
                             TenNhanVien = nv.HoTen,

                             //TenPhongKham = pk.TenPhongKham,
                             //PhongKhamID = pk.IDPhongKham,
                             TenCaTruc = ct.TenCaTruc,
                             CaTrucID = ct.IDCaTruc,
                             Ngay = lk.Ngay.Value.ToShortDateString(),
                         }).ToList();
            return query;

        }
        public void Sua(LichKham a)
        {
            LichKham b = Tim(a.MaLichKham);
            if (b != null)
            {
                b.MaLichKham = a.MaLichKham;
                b.NhanVienID = a.NhanVienID;
                //b.PhongKhamID = a.PhongKhamID;
                b.CaTrucID = a.CaTrucID;
                b.Ngay = a.Ngay;
                tc.capnhat();
            }
        }

        public void Xoa(LichKham a)
        {
            tc.getDSLichKham().DeleteOnSubmit(a);
            tc.capnhat();
        }

        public void Xoa(string maLk)
        {
            LichKham a = Tim(maLk);
            if (a != null) Xoa(a);
        }
        public string taoMaPK()
        {
            string sohd = "000000001";
            foreach (LichKham a in tc.getDSLichKham().
                OrderByDescending(x => x.MaLichKham).Take(1).ToList())
            {
                string s = a.MaLichKham.Substring(4);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "LK" + sohd;
            return sohd;
        }
    }
}
