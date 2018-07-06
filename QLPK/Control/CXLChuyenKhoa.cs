using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPK.Model;
using PagedList;

namespace QLPK.Control
{
    class CXLChuyenKhoa
    {
        private CTruyCapDuLieu tc;
        public CXLChuyenKhoa()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<ChuyenKhoa> getDSChuyenKhoa()
        {
            return tc.getDSChuyenKhoa().ToList();
        }

        public IEnumerable<CChuyenKhoaModel> getDSChuyenKhoa(IPagedList<ChuyenKhoa> ds)
        {
            var i = ds.FirstItemOnPage;
            return ds.Select(x => new CChuyenKhoaModel
            {
                STT = i++,
                ID = x.IDChuyenKhoa,
                MaChuyenKhoa = x.MaChuyenKhoa,
                TenChuyenKhoa = x.TenChuyenKhoa,
                //MoTa = x.MoTa
            });
        }
        public List<ChuyenKhoa> getDSChuyenKhoaFirstNull()
        {
            List<ChuyenKhoa> ds = new List<ChuyenKhoa>();
            ChuyenKhoa a = new ChuyenKhoa();
            a.IDChuyenKhoa = -1;
            a.MaChuyenKhoa = "null";
            a.TenChuyenKhoa = "Chọn chuyên khoa";
            ds.Add(a);
            ds.AddRange(getDSChuyenKhoa());

            return ds;
        }
        public void them(ChuyenKhoa a)
        {
            tc.getDSChuyenKhoa().InsertOnSubmit(a);
            tc.capnhat();
        }
        public ChuyenKhoa tim(string MaBN)
        {
            foreach (ChuyenKhoa a in tc.getDSChuyenKhoa().Where(x => x.MaChuyenKhoa == MaBN))
            {
                return a;
            }
            return null;
        }
        public List<CChuyenKhoaModel> tim2(string tenPKO, IPagedList<ChuyenKhoa> ds)
        {
            var i = ds.FirstItemOnPage;
            var query = (from x in ds
                         where x.TenChuyenKhoa.Contains(tenPKO) || x.MaChuyenKhoa.Contains(tenPKO)
                         select new CChuyenKhoaModel
                         {
                             STT = i++,
                             ID = x.IDChuyenKhoa,
                             MaChuyenKhoa = x.MaChuyenKhoa,
                             TenChuyenKhoa = x.TenChuyenKhoa,
                            // MoTa = x.MoTa
                         }).ToList();
            return query;
        }
        
        public void Sua(ChuyenKhoa a)
        {
            ChuyenKhoa b = tim(a.MaChuyenKhoa);
            if (b != null)
            {
                b.MaChuyenKhoa = a.MaChuyenKhoa;
                b.TenChuyenKhoa = a.TenChuyenKhoa;
               // b.MoTa = a.MoTa;
                tc.capnhat();
            }
        } 
        public void xoa(ChuyenKhoa a)
        {
            tc.getDSChuyenKhoa().DeleteOnSubmit(a);
            tc.capnhat();
        }
      
        public void xoa(string MaBN)
        {
            ChuyenKhoa a = tim(MaBN);
            if (a != null) xoa(a);
        }

        //public List<ChuyenKhoa> tim2(string TenBN)
        //{
        //    List<ChuyenKhoa> ds = new List<ChuyenKhoa>();
        //    decimal n = 0;
        //    if (decimal.TryParse(TenBN, out n))
        //    {
        //        foreach (ChuyenKhoa a in tc.getDSChuyenKhoa().Where(x => x.MaChuyenKhoa.Contains(TenBN)))
        //        {
        //            ds.Add(a);
        //        }
        //    }
        //    else
        //    {
        //        foreach (ChuyenKhoa a in tc.getDSChuyenKhoa().Where(x => x.HoTen.Contains(TenBN)))
        //        {
        //            ds.Add(a);
        //        }
        //    }

        //    if (ds.Count > 0)
        //        return ds;
        //    else
        //        return null;
        //}


        //public IEnumerable<object> getDSChuyenKhoa2(List<ChuyenKhoa> ds)
        //{
        //    return ds.Select(x => new
        //    {
        //        MaChuyenKhoa = x.MaChuyenKhoa,
        //        HoTen = x.HoTen,
        //        NgaySinh = x.NgaySinh.Value.ToShortDateString(),
        //        GioiTinh = x.GioiTinh.Value ? "Nam" : "Nữ",
        //        DiaChi = x.DiaChi,
        //        DienThoai = x.DienThoai
        //    });
        //}
        //public IEnumerable<CChuyenKhoaModel> getDSChuyenKhoa3(List<ChuyenKhoa> ds)
        //{
        //    return ds.Select(x => new CChuyenKhoaModel
        //    {
        //        ID = x.ID,
        //        MaChuyenKhoa = x.MaChuyenKhoa,
        //        HoTen = x.HoTen,
        //        NgaySinh = x.NgaySinh.Value.ToShortDateString(),
        //        //Tuoi = DateTime.Now.Year - x.NgaySinh.Value.Year,
        //        Tuoi = Common.calculateAge(x.NgaySinh.Value, DateTime.Now),
        //        GioiTinh = x.GioiTinh.Value ? "Nam" : "Nữ",
        //        DiaChi = x.DiaChi,
        //        DienThoai = x.DienThoai

        //    });
        //}

       
        //public string taoSo()
        //{
        //    string so = "001";
        //    foreach (phong a in tc.getDSphong().
        //        OrderByDescending(x => x.maphong).Take(1).ToList())
        //    {
        //        string s = a.maphong;
        //        int k = int.Parse(s);
        //        k++;
        //        so = k.ToString("D3");
        //    }
        //    return so;
        //}
        //public void them(string ma, int trangthai, string ghichu, string malp)
        //{
        //    phong a = new phong();
        //    a.maphong = ma;
        //    a.trangthai = trangthai;
        //    a.ghichu = ghichu;
        //    a.malp = malp;
        //    tc.getDSphong().InsertOnSubmit(a);
        //    tc.capnhat();
        //}
        //public phong tim(string ma)
        //{
        //    foreach (phong a in tc.getDSphong().Where(x => x.maphong == ma))
        //    {
        //        return a;
        //    }
        //    return null;
        //}
        //public void Sua(string ma, int trangthai, string ghichu, string malp)
        //{
        //    phong a = tim(ma);
        //    a.maphong = ma;
        //    a.trangthai = trangthai;
        //    a.ghichu = ghichu;
        //    a.malp = malp;
        //    tc.capnhat();
        //}
        //public void xoa(string ma)
        //{
        //    phong a = tim(ma);
        //    if (a == null) return;
        //    tc.getDSphong().DeleteOnSubmit(a);
        //    tc.capnhat();
        //}
        //public bool kiemtra_TrungMaphong(object a, string ma)
        //{
        //    phong p = (phong)a;
        //    if (p.maphong == ma)
        //        return true;
        //    else
        //        return false;
        //}
        //public List<nhacungcap> timtenlist(string ma)
        //{
        //    return tc.getDSNhacungcap().Where(x => x.tenncc.Contains(ma)).ToList();
        //}
        //public bool kiemtraFK_Phong_LoaiPhong(object a)
        //{
        //    loaiphong lp = (loaiphong)a;
        //    foreach (phong b in tc.getDSphong().Where(x => x.malp == lp.malp))
        //    {
        //        return false;
        //    }
        //    return true;

        /*
         public void them(ChuyenKhoa a)
        {
            tc.getDSChuyenKhoa().InsertOnSubmit(a);
            tc.capnhat();
        }
        public void xoa(ChuyenKhoa a)
        {
            tc.getDSChuyenKhoa().DeleteOnSubmit(a);
            tc.capnhat();
        }
        public ChuyenKhoa tim(string mahang)
        {
            foreach(ChuyenKhoa a in tc.getDSChuyenKhoa().Where(x=>x.mahang==mahang))
            {
                return a;
            }
            return null;
        }
        public void xoa(string mahang)
        {
            ChuyenKhoa a = tim(mahang);
            if (a != null) xoa(a);
        }
        public void Sua(ChuyenKhoa a)
        {
            ChuyenKhoa b = tim(a.mahang);
            if(b!=null)
            {
                b.tenhang = a.tenhang;
                b.donvitinh = a.donvitinh;
                b.dongia = a.dongia;
                tc.capnhat();
            }
        } 
         * 
         * 
         * 
         * 
         * 
         * public IEnumerable<object> getDSChitiethoadonView(hoadon a)
        {
            return a.chitiethoadons.Select(x => new { 
                mahang=x.mahang,
                tenhang=x.ChuyenKhoa.tenhang,
                donvitinh=x.ChuyenKhoa.donvitinh,
                dongia=x.dongia,
                soluong=x.soluong,
                thanhtien=x.soluong.Value*x.dongia.Value
            });
        }
        public IEnumerable<object> getDSChitiethoadonView(List<chitiethoadon> ds)
        {
            return ds.Select(x => new
            {
                mahang = x.mahang,
                tenhang = x.ChuyenKhoa.tenhang,
                donvitinh = x.ChuyenKhoa.donvitinh,
                dongia = x.dongia,
                soluong = x.soluong,
                thanhtien = x.soluong.Value * x.dongia.Value
            });
        }
         * */
    }
}
