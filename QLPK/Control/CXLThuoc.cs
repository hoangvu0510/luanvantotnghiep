using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Control
{
    class CXLThuoc
    {
        private CTruyCapDuLieu tc;
        public CXLThuoc()
        {
            tc = CTruyCapDuLieu.khoitao();
        }
        public List<Thuoc> getDSThuoc()
        {
            return tc.getDSThuoc().ToList();
        }
        public List<Thuoc> getDSThuocFirstNull()
        {
            List<Thuoc> ds = new List<Thuoc>();
            Thuoc a = new Thuoc();
            a.IDThuoc = -1;
            a.MaThuoc = "null";
            a.TenThuoc = "Chọn thuốc";
            ds.Add(a);
            ds.AddRange(getDSThuoc());

            return ds;
        }
        public IEnumerable<CCTDonThuocModel> getDSCTDonThuocByDS(List<CTDonThuoc> ds)
        {
            return ds.Select(x => new CCTDonThuocModel
            {
                ID = x.DonThuocID,
                MaThuoc = x.Thuoc.MaThuoc,
                TenThuoc = x.Thuoc.TenThuoc,
                DonGia = x.DonGiaCTDT,
                SoLuong = x.SoLuong,
                ThanhTien = x.ThanhTien,
                DonViTinh = x.Thuoc.DonViTinh,
                DuongDung = x.Thuoc.DuongDung,
                ThuocID = x.ThuocID,
            });
        }
        public void them(Thuoc a)
        {
            tc.getDSThuoc().InsertOnSubmit(a);
            tc.capnhat();
        }
        public Thuoc tim(string MaBN)
        {
            foreach (Thuoc a in tc.getDSThuoc().Where(x => x.MaThuoc == MaBN))
            {
                return a;
            }
            return null;
        }

        public List<Thuoc> tim2(string TenBN)
        {
            List<Thuoc> ds = new List<Thuoc>();
            foreach (Thuoc a in tc.getDSThuoc().Where(x => x.TenThuoc.Contains(TenBN)))
            {
                ds.Add(a);
            }
            if (ds.Count > 0)
                return ds;
            else
                return null;
        }
        public void Sua(Thuoc a)
        {
            Thuoc b = tim(a.MaThuoc);
            if (b != null)
            {
                b.MaThuoc = a.MaThuoc;
                b.TenThuoc = a.TenThuoc;
                b.DonViTinh = a.DonViTinh;
                b.DuongDung = a.DuongDung;
                b.DonGiaThuoc = a.DonGiaThuoc;
                //b.KhoaKhamID = a.KhoaKham.ID;
                //b.KhoaKhamID = int.Parse(b.KhoaKhamID.Value.ToString());
                tc.capnhat();
            }
        }
        public void xoa(Thuoc a)
        {
            tc.getDSThuoc().DeleteOnSubmit(a);
            tc.capnhat();
        }

        public void xoa(string MaBN)
        {
            Thuoc a = tim(MaBN);
            if (a != null) xoa(a);
        }

        //public List<Thuoc> tim2(string TenBN)
        //{
        //    List<Thuoc> ds = new List<Thuoc>();
        //    decimal n = 0;
        //    if (decimal.TryParse(TenBN, out n))
        //    {
        //        foreach (Thuoc a in tc.getDSThuoc().Where(x => x.MaThuoc.Contains(TenBN)))
        //        {
        //            ds.Add(a);
        //        }
        //    }
        //    else
        //    {
        //        foreach (Thuoc a in tc.getDSThuoc().Where(x => x.HoTen.Contains(TenBN)))
        //        {
        //            ds.Add(a);
        //        }
        //    }

        //    if (ds.Count > 0)
        //        return ds;
        //    else
        //        return null;
        //}


        //public IEnumerable<object> getDSThuoc2(List<Thuoc> ds)
        //{
        //    return ds.Select(x => new
        //    {
        //        MaThuoc = x.MaThuoc,
        //        HoTen = x.HoTen,
        //        NgaySinh = x.NgaySinh.Value.ToShortDateString(),
        //        GioiTinh = x.GioiTinh.Value ? "Nam" : "Nữ",
        //        DiaChi = x.DiaChi,
        //        DienThoai = x.DienThoai
        //    });
        //}
        //public IEnumerable<CThuocModel> getDSThuoc3(List<Thuoc> ds)
        //{
        //    return ds.Select(x => new CThuocModel
        //    {
        //        ID = x.ID,
        //        MaThuoc = x.MaThuoc,
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
         public void them(Thuoc a)
        {
            tc.getDSThuoc().InsertOnSubmit(a);
            tc.capnhat();
        }
        public void xoa(Thuoc a)
        {
            tc.getDSThuoc().DeleteOnSubmit(a);
            tc.capnhat();
        }
        public Thuoc tim(string mahang)
        {
            foreach(Thuoc a in tc.getDSThuoc().Where(x=>x.mahang==mahang))
            {
                return a;
            }
            return null;
        }
        public void xoa(string mahang)
        {
            Thuoc a = tim(mahang);
            if (a != null) xoa(a);
        }
        public void Sua(Thuoc a)
        {
            Thuoc b = tim(a.mahang);
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
                tenhang=x.Thuoc.tenhang,
                donvitinh=x.Thuoc.donvitinh,
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
                tenhang = x.Thuoc.tenhang,
                donvitinh = x.Thuoc.donvitinh,
                dongia = x.dongia,
                soluong = x.soluong,
                thanhtien = x.soluong.Value * x.dongia.Value
            });
        }
         * */
    }
}
