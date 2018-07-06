using QLPK.Control;
using QLPK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLPK.View.TiepNhan
{
    /// <summary>
    /// Interaction logic for QLDonThuoc.xaml
    /// </summary>
    public partial class QLDonThuoc : Window
    {
        private CXLDonThuoc xlDT;
        private CXLThuoc xlT;
        private CXLPhieuKhamBenh xlPKB;
        private CXLNhanVien xlNV;

        private List<CTDonThuoc> dsCTDT = null;
        private DonThuoc dt = null;
        public QLDonThuoc()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlDT = new CXLDonThuoc();
            xlT = new CXLThuoc();
            xlPKB = new CXLPhieuKhamBenh();
            dsCTDT = new List<CTDonThuoc>();
            xlNV = new CXLNhanVien();
            dt = new DonThuoc();
            dt.TongTien = 0;

            getDS();
            loadCMB();

        }
        private void loadCMB()
        {
            List<string> data = new List<string>();
            data.Add("Mã PKB");
            data.Add("Mã DT");
            //data.Add("Mã BN");
            //data.Add("Tên BN");
            cmbTim.ItemsSource = data;
            cmbTim.SelectedIndex = 0;
        }
        private void getDS()
        {
            ////clearControl();
            dg.ItemsSource = xlDT.getDSDonThuocByDS(xlDT.getDSDonThuoc()).ToList();
            //dg.ItemsSource = xlDT.getDSDonThuoc();
            dg.SelectedValuePath = "MaDonThuoc";

            //cmbThuoc.ItemsSource = xlDV.TimMaDV(Common.ConvertToInt(cmbLoaiThuoc.SelectedValue));
            cmbThuoc.ItemsSource = xlT.getDSThuocFirstNull();
            cmbThuoc.DisplayMemberPath = "TenThuoc";
            cmbThuoc.SelectedValuePath = "IDThuoc";
            cmbThuoc.SelectedIndex = 0;

            dgCTT.SelectedValuePath = "ThuocID";
            //dgCTDKPK.SelectedValuePath = "PhongKhamID";

            //txtMaPDDK.Text = xlT.taoMaPK();
            //dpNgayLap.Text = DateTime.Now.ToShortDateString();

            //if (Common.maBenhNhan != null)
            //{
            //    txtMaBenhNhan.Text = Common.maBenhNhan.ToString();
            //    epdLPDKK.IsExpanded = true;
            //    txtTenBenhNhan.Text = Common.objBenhNhanM.HoTen.ToString();
            //}
            //if (Common.maNhanVien != null)
            //{
            //    txtNhanVienLP.Text = Common.maNhanVien.ToString();
            //    epdLPDKK.IsExpanded = true;
            //}

            txtMaDT.Text = xlDT.taoMa().ToString();
            dpNgayLap.SelectedDate = DateTime.Now;
            //test
            if (Common.maNhanVien != null)
                txtNhanVienLP.Text = Common.maNhanVien.ToString();
            txtNhanVienLP.Text = "bhvu";
            txtMaPhieuKhamBenh.Text = "TRO";
        }
        private void clearControl()
        {
            txtMaDT.Text = xlDT.taoMa();

            //txtMaBenhNhan.Text = null;
            //Common.maBenhNhan = null;
            //txtNhanVienLP.Text = null;
            //Common.maNhanVien = null;
            dpNgayLap.SelectedDate = DateTime.Now;
        }
        private void CommandBinding_CanExecute_LapDonThuoc(object sender, CanExecuteRoutedEventArgs e)
        {
            decimal tt = 0;
            if (txtMaPhieuKhamBenh.Text != "" && txtNhanVienLP.Text != "" && txtMaDT.Text != "" && decimal.TryParse(txtTongTien.Text, out tt)
                && tt > 0 && dsCTDT != null && dgCTT.Items.Count > 0)
                e.CanExecute = true;
        }
        private void CommandBinding_Executed_LapDonThuoc(object sender, ExecutedRoutedEventArgs e)
        {
            //DonThuoc a = new DonThuoc();
            //a.MaDonThuoc = txtMaPDDK.Text;
            ////BenhNhan bn = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            //BenhNhan bn = (BenhNhan)xlBN.tim(txtMaBenhNhan.Text.ToString());
            //if (bn != null)
            //{
            //    a.BenhNhanID = bn.ID;
            //}
            //NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
            //if (nv != null)
            //{
            //    a.NhanVienID = nv.ID;
            //}
            ////a.BenhNhan = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            //a.TrieuChung = txtTrieuChung.Text.ToString();
            //a.NgayLap = DateTime.Parse(dpNgayLap.Text.ToString());
            //// a.NhanVien = (NhanVien)xlNV.TimMa(Common.maNhanVien.ToString());

            //if (dsCTDKPK != null)
            //{
            //    foreach (CTDKPhongKham b in dsCTDKPK)
            //    {
            //        a.CTDKPhongKham.Add(b);
            //        b.DonThuoc = a;
            //        b.DonThuocID = a.ID;

            //    }
            //}
            //decimal tt = 0;
            //if (dsCTDT != null)
            //{
            //    foreach (CTDonThuoc b in dsCTDT)
            //    {
            //        a.CTDonThuoc.Add(b);
            //        b.DonThuoc = a;
            //        b.DonThuocID = a.ID;
            //        tt += b.Thuoc.DonGiaThuoc.Value;
            //    }
            //}
            //a.TongTien = tt;
            //xlT.Them(a);

            //dsCTDKPK.Clear();
            //dsCTDT.Clear();
            //dgCTDKPK.ItemsSource = xlT.getDSDonThuocByDS(dsCTDKPK).ToList();
            //dgCTT.ItemsSource = xlT.getDSDonThuocByDS(dsCTDT).ToList();


            //clearControl();
            //getDS();


            DonThuoc a = new DonThuoc();
            a.MaDonThuoc = txtMaDT.Text;
            //BenhNhan bn = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            PhieuKhamBenh pkb = (PhieuKhamBenh)xlPKB.Tim(txtMaPhieuKhamBenh.Text.ToString());
            if (pkb != null)
            {
                MessageBox.Show(pkb.IDPhieuKB.ToString());
                a.PhieuKhamBenh = pkb;
            }
            NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
            if (nv != null)
            {
                MessageBox.Show(nv.IDNhanVien.ToString());
                a.PhieuKhamBenh.NhanVien = nv;
            }
            a.NgayLap = DateTime.Parse(dpNgayLap.Text.ToString());

            decimal tt = 0;
            if (dgCTT.Items != null)
            {
                MessageBox.Show("list");
                foreach (CTDonThuoc b in dsCTDT)
                {
                    a.CTDonThuoc.Add(b);
                    tt += b.Thuoc.DonGiaThuoc.Value;
                }
            }
            a.TongTien = tt;
            xlDT.Them(a);
            this.Close();
        }
        private void CommandBinding_CanExecute_SuaDonThuoc(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed_SuaDonThuoc(object sender, ExecutedRoutedEventArgs e)
        {
            //DonThuoc a = new DonThuoc();
            //a.MaDonThuoc = txtMaPDDK.Text;
            //a.NgayLap = DateTime.Parse(dpNgayLap.Text.ToString());
            //a.BenhNhanID = 1;
            //xlT.Sua(a);

            //getDS();
        }
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dg.SelectedItem != null)
            //{
            //    DonThuoc pk = (DonThuoc)xlT.Tim(dg.SelectedValue.ToString());
            //    if (pk != null)
            //    {
            //        epdLPDKK.IsExpanded = true;
            //        txtMaPDDK.Text = pk.MaDonThuoc;
            //        txtTenBenhNhan.Text = pk.BenhNhan.HoTen.ToString();
            //        txtMaBenhNhan.Text = pk.BenhNhan.MaBenhNhan.ToString();
            //        txtNhanVienLP.Text = pk.NhanVien.MaNhanVien.ToString();
            //        dpNgayLap.Text = pk.NgayLap.Value.ToShortDateString();

            //        List<CTDKPhongKham> ctpk = pk.CTDKPhongKham.ToList();

            //        if (ctpk != null)
            //        {
            //            //MessageBox.Show("co ct");
            //            //foreach (ChiTietDonThuoc ct in a.lstCTPK)
            //            //{
            //            //    dsCT.Add(ct);
            //            //}
            //            //dgCT.ItemsSource = dsCT.ToList();
            //            dgCTDKPK.ItemsSource = xlT.getDSDonThuocByDS(ctpk).ToList();
            //        }
            //        List<CTDonThuoc> ctdv = pk.CTDonThuoc.ToList();

            //        if (ctdv != null)
            //        {
            //            //MessageBox.Show("co ct");
            //            //foreach (ChiTietDonThuoc ct in a.lstCTPK)
            //            //{
            //            //    dsCT.Add(ct);
            //            //}
            //            //dgCT.ItemsSource = dsCT.ToList();
            //            dgCTT.ItemsSource = xlT.getDSDonThuocByDS(ctdv).ToList();
            //        }

            //    }
            //}

        }
        private void dgCTT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (CTDonThuoc a in dgCTT.SelectedItems)
            //{
            //    //epdLPK.IsExpanded = true;
            //    //cmbChuyenKhoa.SelectedIndex = int.Parse(a.ChuyenKhoaID.Value.ToString());
            //    cmbThuoc.SelectedValue = int.Parse(a.ThuocID.Value.ToString());
            //    //cmbLoaiThuoc.SelectedIndex = int.Parse(a.LoaiThuocID.Value.ToString());
            //    //cmbThuoc.SelectedIndex = int.Parse(a.ThuocID.Value.ToString());
            //    //txtGhiChu.Text = a.GhiChu;
            //    break;
            //}
        }
        private void btnThemCTT_Click(object sender, RoutedEventArgs e)
        {
            decimal tt = 0;
            Thuoc dv = (Thuoc)cmbThuoc.SelectedItem;
            if (cmbThuoc.SelectedValue.ToString() == "-1" || dv == null)
            {
                MessageBox.Show("Chọn thuốc!");
                cmbThuoc.Focus();
                return;
            }

            int sl = 0;
            if (String.IsNullOrEmpty(txtSoLuong.Text) || int.TryParse(txtSoLuong.Text, out sl) == false || sl <= 0)
            {
                MessageBox.Show("Số lượng!");
                txtSoLuong.Focus();
                return;
            }

            // kiểm tra combobox phải có chọn dữ liệu

            // kiểm tra dịch vụ vẫn chưa có trong dsCT
            foreach (CTDonThuoc b in dsCTDT)
            {
                if (b.ThuocID == dv.IDThuoc)
                {
                    MessageBox.Show("Đã tồn tại thuốc này trong chi tiết!");
                    return;
                }
            }
            CTDonThuoc ct = new CTDonThuoc();
            ct.Thuoc = dv;
            ct.ThuocID = dv.IDThuoc;
            ct.SoLuong = int.Parse(txtSoLuong.Text.ToString());
            ct.DonGiaCTDT = dv.DonGiaThuoc;
            ct.ThanhTien = int.Parse(txtSoLuong.Text.ToString()) * dv.DonGiaThuoc;
            dt.TongTien += ct.ThanhTien;
            dt.CTDonThuoc.Add(ct);
            dsCTDT.Add(ct);
            dgCTT.ItemsSource = xlT.getDSCTDonThuocByDS(dsCTDT.ToList()).ToList();
            txtTongTien.Text = dt.TongTien.Value.ToString();
            foreach (CTDonThuoc a in dsCTDT)
            {
                tt += a.ThanhTien.Value;
            }
            txtTongTien.Text = tt.ToString();
            // dgCTT.ItemsSource = xlT.getDSDonThuocByDS(dsCTDT).ToList();
        }
        private void btnXoaCTT_Click(object sender, RoutedEventArgs e)
        {
            decimal tt = 0;
            if (dgCTT.SelectedValue == null) return;
            int ma = int.Parse(dgCTT.SelectedValue.ToString());
            foreach (CTDonThuoc a in dsCTDT.Where(x => x.ThuocID == ma))
            {
                dsCTDT.Remove(a);
                dt.TongTien -= a.ThanhTien;
                dt.CTDonThuoc.Remove(a);
                break;
            }
            dgCTT.ItemsSource = xlT.getDSCTDonThuocByDS(dsCTDT.ToList()).ToList();
            foreach (CTDonThuoc a in dsCTDT)
            {
                tt += a.ThanhTien.Value;
            }
            txtTongTien.Text = tt.ToString();
            //dgCTT.ItemsSource = xlT.getDSDonThuocByDS(dsCTDT).ToList();
        }
        private void btntim_Click(object sender, RoutedEventArgs e)
        {
            if (txtTim != null)
            {
                dg.ItemsSource = xlDT.getDSDonThuocByDS((xlDT.Tim(txtTim.Text.ToString(), cmbTim.SelectedIndex))).ToList();
                dg.SelectedValuePath = "MaDonThuoc";
            }
            else
            {
                dg.ItemsSource = xlDT.getDSDonThuoc();
                dg.SelectedValuePath = "MaDonThuoc";
            }
        }

        private void btnTraCuuLK_Click(object sender, RoutedEventArgs e)
        {
            //dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham(DateTime.Parse(dpNgayLap.Text.ToString())));
            ////dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham());
        }

        private void btnTraCuuCTPK_Click(object sender, RoutedEventArgs e)
        {
            //dgCTPK.ItemsSource = xlT.TimCTDKPK_LK(2, DateTime.Parse(dpNgayLap.Text.ToString())).ToList();
        }

        private void dgCTT_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            switch (e.Column.DisplayIndex)
            {
                case 5:
                    decimal tt = 0;
                    int sl = 0;
                    TextBox c = (TextBox)e.EditingElement; //ánh xạ đến vị trí combox
                    CCTDonThuocModel cctdt = (CCTDonThuocModel)e.Row.Item; // lấy object dòng đã tác động, để lấy mã convert sang NhanVien
                    if (int.TryParse(c.Text.ToString(), out sl))
                    {
                        if (sl > 0)
                        {
                            //CTDonThuoc nvold = (CTDonThuoc)xlDT.Tim(((CNhanVienModel)e.Row.Item).MaNhanVien.ToString()); //lấy dữ liệu cũ để rollback
                            foreach (CTDonThuoc a in dsCTDT)
                            {
                                if (a.ThuocID == cctdt.ThuocID)
                                {
                                    a.SoLuong = int.Parse(c.Text);
                                    a.ThanhTien = int.Parse(c.Text) * a.DonGiaCTDT;
                                    break;
                                }
                            }
                            foreach (CTDonThuoc a in dsCTDT)
                            {
                                tt += a.ThanhTien.Value;
                            }
                            txtTongTien.Text = tt.ToString();
                            dgCTT.ItemsSource = xlT.getDSCTDonThuocByDS(dsCTDT.ToList()).ToList();
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("Số lượng phải lớn hơn 0 !");
                            c.Text = cctdt.SoLuong.Value.ToString();
                            return;
                        }

                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show("Nhập số!");
                        c.Text = cctdt.SoLuong.Value.ToString();
                        return;
                    }
                    break;
            }
        }
    }
}
