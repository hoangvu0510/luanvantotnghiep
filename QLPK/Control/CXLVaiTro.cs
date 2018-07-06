using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPK.Model;

namespace QLPK.Control
{
    class CXLVaiTro
    {
        private CTruyCapDuLieu tc;
        public CXLVaiTro()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<VaiTro> getDSVaiTro()
        {
            return tc.getDSVaiTro().ToList();
        }
        public void them(VaiTro a)
        {
            tc.getDSVaiTro().InsertOnSubmit(a);
            tc.capnhat();
        }
        public VaiTro tim(string Ma)
        {
            foreach (VaiTro a in tc.getDSVaiTro().Where(x => x.MaVaiTro == Ma))
            {
                return a;
            }
            return null;
        }
        public void Sua(VaiTro a)
        {
            VaiTro b = tim(a.MaVaiTro);
            if (b != null)
            {
                b.MaVaiTro = a.MaVaiTro;
                b.TenVaiTro = a.TenVaiTro;
                tc.capnhat();
            }
        } 
        public void xoa(VaiTro a)
        {
            tc.getDSVaiTro().DeleteOnSubmit(a);
            tc.capnhat();
        }
      
        public void xoa(string Ma)
        {
            VaiTro a = tim(Ma);
            if (a != null) xoa(a);
        }
       
        
    }
}
