using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPK.Model;

namespace QLPK.Control
{
    class CXLLoaiDichVu
    {
        private CTruyCapDuLieu tc;
        public CXLLoaiDichVu()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<LoaiDichVu> getDSLoaiDichVu()
        {
            return tc.getDSLoaiDichVu().ToList();
        }
        public List<LoaiDichVu> getDSLoaiDichVuFirstNull()
        {
            List<LoaiDichVu> ds = new List<LoaiDichVu>();
            LoaiDichVu a = new LoaiDichVu();
            a.IDLoaiDV = -1;
            a.MaLoaiDV = "null";
            a.TenLoaiDV = "Chọn loại dịch vụ";
            ds.Add(a);
            ds.AddRange(getDSLoaiDichVu());

            return ds;
        }
        public void them(LoaiDichVu a)
        {
            tc.getDSLoaiDichVu().InsertOnSubmit(a);
            tc.capnhat();
        }
        public LoaiDichVu tim(string Ma)
        {
            foreach (LoaiDichVu a in tc.getDSLoaiDichVu().Where(x => x.MaLoaiDV == Ma))
            {
                return a;
            }
            return null;
        }
        public void Sua(LoaiDichVu a)
        {
            LoaiDichVu b = tim(a.MaLoaiDV);
            if (b != null)
            {
                b.MaLoaiDV = a.MaLoaiDV;
                b.TenLoaiDV = a.TenLoaiDV;
                //b.MoTa = a.MoTa;
                tc.capnhat();
            }
        } 
        public void xoa(LoaiDichVu a)
        {
            tc.getDSLoaiDichVu().DeleteOnSubmit(a);
            tc.capnhat();
        }
      
        public void xoa(string Ma)
        {
            LoaiDichVu a = tim(Ma);
            if (a != null) xoa(a);
        }
       
        
    }
}
