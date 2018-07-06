using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPK.Model;

namespace QLPK.Control
{
    class CXLPhongKham
    {
        private CTruyCapDuLieu tc;
        public CXLPhongKham()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<PhongKham> getDSPhongKham()
        {
            return tc.getDSPhongKham().ToList();
        }
        public List<PhongKham> getDSChuyenKhoaFirstNull()
        {
            List<PhongKham> ds = new List<PhongKham>();
            PhongKham a = new PhongKham();
            a.IDPhongKham = -1;
            a.MaPhongKham = "null";
            a.TenPhongKham = "Chọn phòng khám";
            a.ChuyenKhoaID = -1;
            ds.Add(a);
            ds.AddRange(getDSPhongKham());

            return ds;
        }
        public IEnumerable<CPhongKhamModel> getDSPhongKhamEnum(List<PhongKham> ds)
        {
            var query = (from pka in ds.AsEnumerable()
                         join pko in tc.getDSChuyenKhoa() on pka.ChuyenKhoaID equals pko.IDChuyenKhoa into val
                         from pko in val.DefaultIfEmpty()
                         select new CPhongKhamModel
                         {
                             MaPhongKham = pka.MaPhongKham,
                             ChuyenKhoaID = pka.ChuyenKhoaID,
                             ChuyenKhoa = pko == null ? "" : pko.TenChuyenKhoa,
                             TenPhongKham = pka.TenPhongKham
                         });
            return query;
        }


        public void them(PhongKham a)
        {
            tc.getDSPhongKham().InsertOnSubmit(a);
            tc.capnhat();
        }
        public PhongKham tim(string MaBN)
        {
            foreach (PhongKham a in tc.getDSPhongKham().Where(x => x.MaPhongKham == MaBN))
            {
                return a;
            }
            return null;
        }
        public List<CPhongKhamModel> tim2(string tenPKA)
        {
            var query = (from pka in tc.getDSPhongKham()
                         join pko in tc.getDSChuyenKhoa() on pka.ChuyenKhoaID equals pko.IDChuyenKhoa into val
                         from pko in val.DefaultIfEmpty()
                         where pka.MaPhongKham.Contains(tenPKA) || pka.TenPhongKham.Contains(tenPKA)
                         select new CPhongKhamModel
                         {
                             MaPhongKham = pka.MaPhongKham,
                             ChuyenKhoaID = pka.ChuyenKhoaID,
                             ChuyenKhoa = pko.TenChuyenKhoa,
                             TenPhongKham = pka.TenPhongKham
                         }).ToList();
            return query;
        }

        public void Sua(PhongKham a)
        {
            PhongKham b = tim(a.MaPhongKham);
            if (b != null)
            {
                b.MaPhongKham = a.MaPhongKham;
                b.TenPhongKham = a.TenPhongKham;
                b.ChuyenKhoaID = a.ChuyenKhoaID;
                tc.capnhat();
            }
        }
        public void xoa(PhongKham a)
        {
            tc.getDSPhongKham().DeleteOnSubmit(a);
            tc.capnhat();
        }

        public void xoa(string MaBN)
        {
            PhongKham a = tim(MaBN);
            if (a != null) xoa(a);
        }

        public List<PhongKham> TimMaPKO(int id)
        {
            List<PhongKham> ds = new List<PhongKham>();

            foreach (PhongKham a in tc.getDSPhongKham().Where(x => x.ChuyenKhoaID == id))
            {
                ds.Add(a);
            }

            if (ds.Count > 0)
                return ds;
            else
                return null;
        }        
    }
}
