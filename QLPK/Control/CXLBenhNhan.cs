using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPK.Model;
using PagedList;

namespace QLPK.Control
{
    class CXLBenhNhan
    {
        private CTruyCapDuLieu tc;
        public CXLBenhNhan()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<BenhNhan> getDSBenhNhan()
        {
            return tc.getDSBenhNhan().ToList();
        }
        public IEnumerable<object> getDSBenhNhan2(List<BenhNhan> ds)
        {
            return ds.Select(x => new
            {
                MaBenhNhan = x.MaBenhNhan,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh.Value.ToShortDateString(),
                GioiTinh = x.GioiTinh.Value ? "Nam" : "Nữ",
                DiaChi = x.DiaChi,
                DienThoai = x.DienThoai,
                CMND = x.CMND
            });
        }
        public IEnumerable<CBenhNhanModel> getDSBenhNhan3(IPagedList<BenhNhan> ds)
        {
            var i = ds.FirstItemOnPage;
            return ds.Select(x => new CBenhNhanModel
            {
                STT = i++,
                ID = x.IDBenhNhan,
                MaBenhNhan = x.MaBenhNhan,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh.Value.ToShortDateString(),
                Tuoi = Common.calculateAge(x.NgaySinh.Value, DateTime.Now),
                GioiTinh = x.GioiTinh.Value ? "Nam" : "Nữ",
                DiaChi = x.DiaChi,
                DienThoai = x.DienThoai,
                CMND = x.CMND

            });
        }
        public void them(BenhNhan a, out int ID)
        {
            tc.getDSBenhNhan().InsertOnSubmit(a);
            tc.capnhat();
            ID = a.IDBenhNhan;
        }
        public BenhNhan tim(string MaBN)
        {
            foreach (BenhNhan a in tc.getDSBenhNhan().Where(x => x.MaBenhNhan == MaBN))
            {
                return a;
            }
            return null;
        }
        public List<CBenhNhanModel> tim2(string TenBN, IPagedList<BenhNhan> ds)
        {
            var i = ds.FirstItemOnPage;
            var query = (from bn in ds
                         where bn.HoTen.Contains(TenBN)
                         select new CBenhNhanModel
                         {
                             STT = i++,
                             ID = bn.IDBenhNhan,
                             MaBenhNhan = bn.MaBenhNhan,
                             HoTen = bn.HoTen,
                             DiaChi = bn.DiaChi,
                             DienThoai = bn.DienThoai,
                             GioiTinh = bn.GioiTinh.Value ? "Nam" : "Nữ",
                             NgaySinh = bn.NgaySinh.Value.ToShortDateString(),
                             Tuoi = Common.calculateAge(bn.NgaySinh.Value, DateTime.Now),
                             CMND = bn.CMND
                         }).ToList();
            return query;
        }
        public void Sua(BenhNhan a)
        {
            BenhNhan b = tim(a.MaBenhNhan);
            if (b != null)
            {
                b.MaBenhNhan = a.MaBenhNhan;
                b.HoTen = a.HoTen;
                b.NgaySinh = a.NgaySinh;
                b.GioiTinh = a.GioiTinh;
                b.DiaChi = a.DiaChi;
                b.DienThoai = a.DienThoai;
                b.CMND = a.CMND;
                tc.capnhat();
            }
        }
        public void xoa(BenhNhan a)
        {
            tc.getDSBenhNhan().DeleteOnSubmit(a);
            tc.capnhat();
        }

        public void xoa(string MaBN)
        {
            BenhNhan a = tim(MaBN);
            if (a != null) xoa(a);
        }

        public void LogBenhNhan(CTCNBenhNhan cTBN)
        {
            tc.getDSCTCNBenhNhan().InsertOnSubmit(cTBN);
            tc.capnhat();
        }
        public string taoMaPK()
        {
            string sohd = "000000001";
            foreach (BenhNhan a in tc.getDSBenhNhan().
                OrderByDescending(x => x.MaBenhNhan).Take(1).ToList())
            {
                string s = a.MaBenhNhan.Substring(4);
                int k = int.Parse(s);
                k++;
                sohd = k.ToString("D9");
            }
            sohd = "BN" + sohd;
            return sohd;
        }

    }
}
