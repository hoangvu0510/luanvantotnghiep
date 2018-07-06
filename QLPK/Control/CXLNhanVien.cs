
using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace QLPK.Control
{
    class CXLNhanVien
    {
        private CTruyCapDuLieu tc;

        public CXLNhanVien()
        {
            tc = CTruyCapDuLieu.khoitao();
        }

        public List<NhanVien> getDSNhanVien()
        {
            return tc.getDSNhanVien().ToList();
        }
        public IEnumerable<CNhanVienModel> getDSNhanVien(IPagedList<NhanVien> ds)
        {
            var i = ds.FirstItemOnPage;
            return ds.Select(x => new CNhanVienModel
            {
                STT = i++,
                IDNhanVien = x.IDNhanVien,
                MaNhanVien = x.MaNhanVien,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh.Value.ToShortDateString(),
                GioiTinh = x.GioiTinh.Value ? "Nam" : "Nữ",
                CMND = x.CMND,
                DiaChi = x.DiaChi,
                DienThoai = x.DienThoai,
                TrangThai = x.TrangThai.Value ? "Làm việc" : "Nghỉ việc",
                KhoaNhanVien = x.HieuLuc.Value ? "Hiệu lực" : "Hết hiệu lực",
            });
        }

        public IEnumerable<CNhanVienModel> getDSPCCV(IPagedList<NhanVien> ds)
        {
            var i = ds.FirstItemOnPage;
            var query = (from nv in ds.AsEnumerable()
                         join vt in tc.getDSVaiTro() on nv.VaiTroID equals vt.IDVaiTro into val
                         from vt in val.DefaultIfEmpty()
                         select new CNhanVienModel
                         {
                             STT = i++,
                             MaNhanVien = nv.MaNhanVien,
                             HoTen = nv.HoTen,
                             VaiTroID = nv.VaiTroID,
                             VaiTro = vt == null ? "" : vt.TenVaiTro,
                         });
            return query;
        }
        public void Them(NhanVien nv)
        {
            tc.getDSNhanVien().InsertOnSubmit(nv);
            tc.capnhat();
        }
        public List<CNhanVienModel> Tim(string txtTim, IPagedList<NhanVien> ds)
        {
            var i = ds.FirstItemOnPage;
            var query = (from nv in tc.getDSNhanVien().AsEnumerable()
                         join vt in tc.getDSVaiTro() on nv.VaiTroID equals vt.IDVaiTro into val
                         from vt in val.DefaultIfEmpty()
                         where nv.HoTen.Contains(txtTim) || nv.MaNhanVien.Contains(txtTim)
                         select new CNhanVienModel
                         {
                             STT = i++,
                             IDNhanVien = nv.IDNhanVien,
                             MaNhanVien = nv.MaNhanVien,
                             CMND = nv.CMND,
                             HoTen = nv.HoTen,
                             DiaChi = nv.DiaChi,
                             DienThoai = nv.DienThoai,
                             GioiTinh = nv.GioiTinh.Value ? "Nam" : "Nữ",
                             NgaySinh = nv.NgaySinh.Value.ToShortDateString(),
                             VaiTroID = nv.VaiTroID,
                             VaiTro = vt == null ? "" : vt.TenVaiTro,
                             TrangThai = nv.TrangThai.Value ? "Làm việc" : "Nghỉ việc",
                             KhoaNhanVien = nv.HieuLuc.Value ? "Hết hiệu lực" : "Hiệu lực"
                         }).ToList();
            return query;

        }
        public NhanVien TimMa(string maNV)
        {
            foreach (NhanVien nv in tc.getDSNhanVien().Where(x => x.MaNhanVien == maNV))
            {
                return nv;
            }
            return null;
        }
        public void Sua(NhanVien nv)
        {
            try
            {
                NhanVien nvAll = TimMa(nv.MaNhanVien);
                if (nvAll != null)
                {
                    nvAll.HoTen = nv.HoTen;
                    nvAll.NgaySinh = nv.NgaySinh;
                    nvAll.GioiTinh = nv.GioiTinh;
                    nvAll.CMND = nv.CMND;
                    nvAll.DiaChi = nv.DiaChi;
                    nvAll.DienThoai = nv.DienThoai;
                    nvAll.TrangThai = nv.TrangThai;
                    nvAll.HieuLuc = nv.HieuLuc;
                    tc.capnhat();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PCCV(NhanVien nv)
        {
            try
            {
                NhanVien nvAll = TimMa(nv.MaNhanVien);
                if (nvAll != null)
                {
                    tc.capnhat();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DoiMatKhau(string mk, string maNV)
        {
            try
            {
                Byte[] mkMoi = (Byte[])Common.HashPassword(mk);
                NhanVien nvAll = TimMa(maNV);
                if (nvAll != null)
                {
                    nvAll.MatKhau = mkMoi;
                    tc.capnhat();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DatLaiMatKhau(string mk, string maNV)
        {
            try
            {
                NhanVien nvAll = TimMa(maNV);
                Byte[] datLaiMK = (Byte[])Common.HashPassword(mk);
                if (nvAll != null)
                {
                    nvAll.MatKhau = datLaiMK;
                    tc.capnhat();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PhanQuyen(NhanVien nv)
        {
            try
            {
                NhanVien nvAll = TimMa(nv.MaNhanVien);
                if (nvAll != null)
                {
                    nvAll.VaiTroID = nv.VaiTroID;
                    tc.capnhat();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
