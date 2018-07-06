using QLPK.Control;
using QLPK.Model;
using QLPK.View.TiepNhan;
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

namespace QLPK.View.BacSi
{
    /// <summary>
    /// Interaction logic for QLPhieuKhamBenh.xaml
    /// </summary>
    public partial class QLPhieuKhamBenh : Window
    {
        private CXLPhieuKhamBenh xlPKB;
        private CXLPhieuDKKham xlPDKK;
        private CXLBenhNhan xlBN;
        private CXLNhanVien xlNV;
        private CXLLichKham xlLL;
        private CXLPhieuSDDV xlPSDDV;
        private CXLLoaiDichVu xlLDV;
        private CXLDichVu xlDV;
        private CXLDonThuoc xlDT;
        private CXLThuoc xlT;

        private List<CTDKDichVu> dsCTDKDV = null;
        private List<CTDonThuoc> dsCTDT = null;
        private DonThuoc dt = null;
        public QLPhieuKhamBenh()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlPKB = new CXLPhieuKhamBenh();
            xlPDKK = new CXLPhieuDKKham();
            xlBN = new CXLBenhNhan();
            xlNV = new CXLNhanVien();
            xlLL = new CXLLichKham();
            xlLDV = new CXLLoaiDichVu();
            xlDV = new CXLDichVu();
            xlPSDDV = new CXLPhieuSDDV();
            xlDT = new CXLDonThuoc();
            xlT = new CXLThuoc();

            dsCTDKDV = new List<CTDKDichVu>();
            dsCTDT = new List<CTDonThuoc>();
            dt = new DonThuoc();
            dt.TongTien = 0;

            getDS();
            loadCMB();


        }
        private void loadCMB()
        {
            //List<string> data = new List<string>();
            //data.Add("Mã PDDK");
            //data.Add("Mã BN");
            //data.Add("Tên BN");
            //cmbTim.ItemsSource = data;
            //cmbTim.SelectedIndex = 0;
        }
        private void getDS()
        {
            ////clearControl();

            ////dg.ItemsSource = xlPDKK.getDSPhieuKhamBenh();
            //dg.ItemsSource = xlPKB.getDSPhieuKhamBenhByDS(xlPKB.getDSPhieuKhamBenh()).ToList();
            //dg.SelectedValuePath = "MaPhieuKB";

            cmbLoaiDichVu.ItemsSource = xlLDV.getDSLoaiDichVu();
            cmbLoaiDichVu.DisplayMemberPath = "TenLoaiDV";
            cmbLoaiDichVu.SelectedValuePath = "IDLoaiDV";
            cmbLoaiDichVu.SelectedIndex = 1;

            //cmbDichVu.ItemsSource = xlDV.TimMaDV(Common.ConvertToInt(cmbLoaiDichVu.SelectedValue));
            if (cmbLoaiDichVu.SelectedItem != null)
            {
                cmbDichVu.ItemsSource = xlDV.getDSDichVuByLoaiDV(int.Parse(cmbLoaiDichVu.SelectedValue.ToString()));
                cmbDichVu.DisplayMemberPath = "TenDichVu";
                cmbDichVu.SelectedValuePath = "IDDichVu";
                cmbDichVu.SelectedIndex = 0;
            }
            cmbThuoc.ItemsSource = xlT.getDSThuoc();
            cmbThuoc.DisplayMemberPath = "TenThuoc";
            cmbThuoc.SelectedValuePath = "IDThuoc";
            cmbThuoc.SelectedIndex = 0;

            dgCTT.SelectedValuePath = "ThuocID";
            dgCTDKDV.SelectedValuePath = "DichVuID";

            txtMaPKB.Text = xlPKB.taoMaPK();
            dpNgayLap.Text = DateTime.Now.ToShortDateString();

            if (Common.maBenhNhan != null)
            {
                txtMaBenhNhan.Text = Common.maBenhNhan.ToString();
                epdLPDKK.IsExpanded = true;
                txtTenBenhNhan.Text = Common.objBenhNhanM.HoTen.ToString();
            }
            if (Common.maNhanVien != null)
            {
                txtNhanVienLP.Text = Common.maNhanVien.ToString();
                epdLPDKK.IsExpanded = true;
            }
            txtSoLuong.Text = "1";

            ////test
            ////if (Common.maNhanVien != null)
            ////    txtNhanVienLP.Text = Common.maNhanVien.ToString();
            //txtNhanVienLP.Text = "bacsi1";
            //Common.vaiTroNhanVien = Common.BacSi;
            //Common.maNhanVien = "bacsi1";
            ////txtMaBenhNhan.Text = "BN002";

            LayTTPDKK();
        }
        private void LayTTPDKK()
        {
            if (Common.maPhieuDDK != null)
            {
                PhieuDKKham pdkk = xlPDKK.Tim(Common.maPhieuDDK.ToString());
                if (pdkk != null)
                {

                    txtMaPDKK.Text = Common.maPhieuDDK.ToString();
                    txtMaBenhNhan.Text = pdkk.BenhNhan.MaBenhNhan.ToString();
                    txtTenBenhNhan.Text = pdkk.BenhNhan.HoTen.ToString();
                    txtTrieuChung.Text = pdkk.TrieuChung.ToString();
                    dgLSCTDV.ItemsSource = xlPDKK.getDSLichSuDVByDS(xlPDKK.getDSLichSuDV(Common.maPhieuDDK.ToString()));
                    dgLSCTDV.SelectedValuePath = "ID";
                }
            }
        }
        private void clearControl()
        {
            dsCTDKDV.Clear();
            dsCTDT.Clear();
            dgCTDKDV.ItemsSource = null;
            dgCTT.ItemsSource = null;
            txtMaBenhNhan.Text = null;
            txtMaPDKK.Text = null;
            Common.maBenhNhan = null;
            txtTrieuChung.Text = null;
            txtTenBenhNhan.Text = null;
            txtTongTien.Text = null;
            dt.TongTien = 0;
            //getDS();
        }
        private void CommandBinding_CanExecute_LapPhieuKhamBenh(object sender, CanExecuteRoutedEventArgs e)
        {
            bool b= false;
            if (dgLSCTDV == null || dgLSCTDV.Items.Count < 1)
            {
                return;
            }
            if (dgLSCTDV != null)
            {
                foreach (CTDKDichVu a in xlPDKK.getDSLichSuDV(txtMaPDKK.Text.ToString()))
                {
                    if (a.TrangThai == false || a.TrangThai == null)
                    {
                        b = false;
                        break;
                    }
                    else
                        b = true;

                }
            }

            if(b==true)
            {
                 decimal tt = 0;
            if (dgCTT != null)
            {
                if (String.IsNullOrEmpty(txtTongTien.Text.ToString()) && decimal.TryParse(txtTongTien.Text, out tt) && tt > 0)
                    return;
            }
            if (txtMaPDKK.Text != "" && txtNhanVienLP.Text != "" && txtMaPKB.Text != "" && String.IsNullOrEmpty(txtChanDoan.Text) == false)
                //&& dgCTDKDV != null && dgCTDKDV.Items.Count > 0)
                e.CanExecute = true;
            }

           
        }
        private void CommandBinding_Executed_LapPhieuKhamBenh(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Xác nhận?", "Cảnh báo!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                PhieuKhamBenh pkb = new PhieuKhamBenh();

                pkb.MaPhieuKB = txtMaPKB.Text;
                pkb.ChanDoan = txtChanDoan.Text.ToString();
                pkb.NgayLap = DateTime.Now;
                PhieuDKKham pdkk = (PhieuDKKham)xlPDKK.Tim(txtMaPDKK.Text.ToString());
                if (pdkk != null)
                {
                    //MessageBox.Show(pdkk.IDPhieuDKK.ToString());
                    //psddv.PhieuDKKID = pdkk.IDPhieuDKK;
                    pkb.PhieuDKKham = pdkk;
                }
                NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
                if (nv != null)
                {
                    pkb.NhanVien = nv;
                }
                decimal tt = 0;
                if (dsCTDT != null && dsCTDT.Count > 0)
                {
                    DonThuoc dt = new DonThuoc();
                    List<DonThuoc> dsDT = new List<DonThuoc>();
                    foreach (CTDonThuoc b in dsCTDT)
                    {
                        dt.CTDonThuoc.Add(b);
                        tt += b.Thuoc.DonGiaThuoc.Value;
                    }
                    dt.TongTien = tt;
                    dt.MaDonThuoc = xlDT.taoMa().ToString();
                    dt.NgayLap = pkb.NgayLap;
                    //dt.PhieuKhamBenh.NhanVien = pkb.NhanVien;
                    dsDT.Add(dt);
                    pkb.DonThuoc.AddRange(dsDT);
                }

                xlPKB.Them(pkb);
                clearControl(); getDS();
                MessageBox.Show("Lập PKB thành công!");
                this.Close();
            }
        }


        private void btntim_Click(object sender, RoutedEventArgs e)
        {
            //if (txtTim != null)
            //{
            //    dg.ItemsSource = xlPDKK.getDSPhieuKhamBenhByDS((xlPDKK.Tim(txtTim.Text.ToString(), cmbTim.SelectedIndex))).ToList();
            //    dg.SelectedValuePath = "MaPhieuKhamBenh";
            //}
        }

        private void btnTraCuuLK_Click(object sender, RoutedEventArgs e)
        {
            // dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham(DateTime.Parse(dpNgayLap.Text.ToString())));
            //dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham());
        }

        private void btnThemCTDV_Click(object sender, RoutedEventArgs e)
        {
            // kiểm tra combobox phải có chọn dữ liệu
            DichVu dv = (DichVu)cmbDichVu.SelectedItem;
            if (cmbDichVu.SelectedValue.ToString() == "-1" || dv == null)
            {
                MessageBox.Show("Phải chọn dịch vụ!");
                return;
            }
            // kiểm tra dịch vụ vẫn chưa có trong dsCT
            foreach (CTDKDichVu b in dsCTDKDV)
            {
                if (b.DichVuID == dv.IDDichVu)
                {
                    MessageBox.Show("Đã tồn tại dịch vụ này trong chi tiết!");
                    return;
                }
            }
            CTDKDichVu ct = new CTDKDichVu();
            ct.DichVu = dv;
            dsCTDKDV.Add(ct);
            dgCTDKDV.ItemsSource = xlPDKK.getDSPhieuDKKhamByDS(dsCTDKDV).ToList();
        }

        private void btnXoaCTDV_Click(object sender, RoutedEventArgs e)
        {
            if (dgCTDKDV.SelectedValue == null) return;
            int ma = int.Parse(dgCTDKDV.SelectedValue.ToString());
            foreach (CTDKDichVu a in dsCTDKDV.Where(x => x.DichVuID == ma))
            {
                dsCTDKDV.Remove(a);
                a.DichVu = null;
                break;
            }
            dgCTDKDV.ItemsSource = xlPDKK.getDSPhieuDKKhamByDS(dsCTDKDV).ToList();
        }

        private void cmbLoaiDichVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLoaiDichVu.SelectedValue != null)
            {
                cmbDichVu.ItemsSource = xlDV.TimMaDV(Common.ConvertToInt(cmbLoaiDichVu.SelectedValue));
                cmbDichVu.SelectedValuePath = "IDDichVu";
                cmbDichVu.DisplayMemberPath = "TenDichVu";
                cmbDichVu.SelectedIndex = 0;
            }
        }

        private void btnLapPSDDV_Click(object sender, RoutedEventArgs e)
        {
            if (dgCTDKDV != null && dgCTDKDV.Items.Count > 0 && txtNhanVienLP.Text != null)
                LapPhieuSDDV(txtMaPDKK.Text.ToString());
        }
        private void LapPhieuSDDV(string maPDDK)
        {
            List<PhieuSDDV> dsPSDDV = new List<PhieuSDDV>();
            PhieuSDDV psddv = new PhieuSDDV();
            PhieuDKKham pdkk = (PhieuDKKham)xlPDKK.Tim(txtMaPDKK.Text.ToString());
            if (pdkk != null)
            {
                //MessageBox.Show(pdkk.IDPhieuDKK.ToString());
                //psddv.PhieuDKKID = pdkk.IDPhieuDKK;
                psddv.PhieuDKKham = pdkk;
            }
            NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
            if (nv != null)
            {
                //MessageBox.Show(nv.IDNhanVien.ToString());
                //psddv.NhanVienLapID = nv.IDNhanVien;
                psddv.NhanVien = nv;
            }
            decimal tt = 0;
            if (dsCTDKDV != null)
            {
                MessageBox.Show("list");
                foreach (CTDKDichVu b in dsCTDKDV)
                {
                    psddv.CTDKDichVu.Add(b);
                    //b.PhieuSDDV = a;
                    //b.PhieuSDDVID = a.IDPhieuSDDV;
                    tt += b.DichVu.DonGiaDichVu.Value;
                }
            }
            psddv.MaPhieuSDDV = xlPSDDV.taoMaPK().ToString();
            psddv.NgayLap = DateTime.Now;
            psddv.TongTien = tt;
            dsPSDDV.Add(psddv);
            //xlPSDDV.Them(psddv);

            dsPSDDV.Add(psddv);
            pdkk.PhieuSDDV.AddRange(dsPSDDV);

            xlPDKK.ThemPSDDV(pdkk);

            MessageBox.Show("Lập PSDDV thành công !");

            clearControl(); getDS();
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
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("asd");
            //if (dg.SelectedItem != null)
            //{
            //    PhieuKhamBenh pk = (PhieuKhamBenh)xlPDKK.Tim(dg.SelectedValue.ToString());
            //    if (pk != null)
            //    {
            //        txtMaPDDK.Text = pk.MaPhieuDKK;
            //        txtTenBenhNhan.Text = pk.BenhNhan.HoTen.ToString();
            //        txtMaBenhNhan.Text = pk.BenhNhan.MaBenhNhan.ToString();
            //        txtNhanVienLP.Text = pk.NhanVien.MaNhanVien.ToString();
            //        dpNgayLap.Text = pk.NgayLap.Value.ToShortDateString();

            //        List<CTDKPhongKham> ctpk = pk.CTDKPhongKham.ToList();
            //        if (ctpk != null)
            //        {
            //            dgCTDKPK.ItemsSource = xlPDKK.getDSPhieuKhamBenhByDS(ctpk).ToList();
            //        }
            //        //List<CTDKDichVu> ctdv = pk.PhieuSDDV.ToList();

            //        //if (ctdv != null)
            //        //{
            //        //    //MessageBox.Show("co ct");
            //        //    //foreach (ChiTietPhieuKhamBenh ct in a.lstCTPK)
            //        //    //{
            //        //    //    dsCT.Add(ct);
            //        //    //}
            //        //    //dgCT.ItemsSource = dsCT.ToList();
            //        //    dgCTDKDV.ItemsSource = xlPDKK.getDSPhieuKhamBenhByDS(ctdv).ToList();
            //        //}

            //    }
            //}

        }

        private void btnCho_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnTraLS_Click(object sender, RoutedEventArgs e)
        {
            QLLSKB f = new QLLSKB();
            f.ShowDialog();
        }

        //private void btnXemLSDV_Click(object sender, RoutedEventArgs e)
        //{
        //    dgLSCTDV.ItemsSource = xlPDKK.getDSLichSuDVByDS(xlPDKK.getDSLichSuDV(Common.maPhieuDDK.ToString()));
        //    dgLSCTDV.SelectedValuePath = "ID";
        //}

        //private void btnXemLSKB_Click(object sender, RoutedEventArgs e)
        //{

        //}

    }
}
