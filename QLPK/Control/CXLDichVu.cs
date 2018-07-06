using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPK.Model;
using PagedList;

namespace QLPK.Control
{
    class CXLDichVu
    {
        private CTruyCapDuLieu tc;
        public CXLDichVu()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<DichVu> getDSDichVu()
        {
            return tc.getDSDichVu().ToList();
        }
        public List<DichVu> getDSDichVuByLoaiDV(int idLoai)
        {
            return tc.getDSDichVu().Where(x => x.LoaiDichVuID == idLoai).ToList();
        }
        public IEnumerable<CDichVuModel> getDSDichVu(IPagedList<DichVu> ds)
        {
            var i = ds.FirstItemOnPage;
            return ds.Select(x => new CDichVuModel
            {
                STT = i++,
                ID = x.IDDichVu,
                MaDichVu = x.MaDichVu,
                TenDichVu = x.TenDichVu,
                DonGiaDichVu = x.DonGiaDichVu,
                LoaiDichVu = x.LoaiDichVu.TenLoaiDV,
                LoaiDichVuID = x.LoaiDichVuID,
                MoTa = x.MoTa,
                TrangThai = x.TrangThai
            });
        }
        public List<DichVu> getDSDichVuFirstNull()
        {
            List<DichVu> ds = new List<DichVu>();
            DichVu a = new DichVu();
            a.IDDichVu = -1;
            a.MaDichVu = "null";
            a.TenDichVu = "Chọn dịch vụ";
            a.LoaiDichVuID = -1;
            ds.Add(a);
            ds.AddRange(getDSDichVu());

            return ds;
        }
        public void them(DichVu a)
        {
            tc.getDSDichVu().InsertOnSubmit(a);
            tc.capnhat();
        }
        public DichVu tim(string Ma)
        {
            foreach (DichVu a in tc.getDSDichVu().Where(x => x.MaDichVu == Ma))
            {
                return a;
            }
            return null;
        }
        public void Sua(DichVu a)
        {
            DichVu b = tim(a.MaDichVu);
            if (b != null)
            {
                b.MaDichVu = a.MaDichVu;
                b.TenDichVu = a.TenDichVu;
                b.LoaiDichVuID = a.LoaiDichVuID;
                b.DonGiaDichVu = a.DonGiaDichVu;
                b.MoTa = a.MoTa;                
                b.TrangThai = a.TrangThai;
                tc.capnhat();
            }
        } 
        public void xoa(DichVu a)
        {
            tc.getDSDichVu().DeleteOnSubmit(a);
            tc.capnhat();
        }
      
        public void xoa(string Ma)
        {
            DichVu a = tim(Ma);
            if (a != null) xoa(a);
        }
        public List<DichVu> TimMaDV(int id)
        {
            List<DichVu> ds = new List<DichVu>();

            foreach (DichVu a in tc.getDSDichVu().Where(x => x.LoaiDichVuID == id))
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
