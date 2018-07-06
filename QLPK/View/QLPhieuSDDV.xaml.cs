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
    /// Interaction logic for QLPhieuSDDV.xaml
    /// </summary>
    public partial class QLPhieuSDDV : Window
    {
        private CXLPhieuSDDV xlPSDDV;
        private CXLLoaiDichVu xlLDV;
        private CXLDichVu xlDV;
        private CXLPhieuDKKham xlPDDK;
        private CXLNhanVien xlNv;
        
        private List<CTDKDichVu> dsCTDKDV = null;
        public QLPhieuSDDV()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlPSDDV = new CXLPhieuSDDV();
            xlLDV = new CXLLoaiDichVu();
            xlDV = new CXLDichVu();
            xlPDDK = new CXLPhieuDKKham();
            xlNv = new CXLNhanVien();
            dsCTDKDV = new List<CTDKDichVu>();

            getDS();  
        }
        private void getDS()
        {
            //clearControl();
            //dg.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(xlPSDDV.getDSPhieuSDDV()).ToList();
            //dg.ItemsSource = xlPSDDV.getDSPhieuSDDV();
            dg.SelectedValuePath = "MaPhieuSDDV";

           

            cmbLoaiDichVu.ItemsSource = xlLDV.getDSLoaiDichVuFirstNull();
            cmbLoaiDichVu.DisplayMemberPath = "TenLoaiDV";
            cmbLoaiDichVu.SelectedValuePath = "IDLoaiDV";
            cmbLoaiDichVu.SelectedIndex = 0;

            //cmbDichVu.ItemsSource = xlDV.TimMaDV(Common.ConvertToInt(cmbLoaiDichVu.SelectedValue));
            cmbDichVu.ItemsSource = xlDV.getDSDichVuFirstNull();
            cmbDichVu.DisplayMemberPath = "TenDichVu";
            cmbDichVu.SelectedValuePath = "IDDichVu";
            cmbDichVu.SelectedIndex = 0;

            dgCTDKDV.SelectedValuePath = "DichVuID";

            txtMaPhieuSDDV.Text = xlPSDDV.taoMaPK();
            dpNgayLap.Text = DateTime.Now.ToShortDateString();

            if (Common.maPhieuDDK != null)
            {
                epdLPDKK.IsExpanded = true;
                txtMaPhieuDDK.Text = Common.maPhieuDDK.ToString();                
            }
            if (Common.objBenhNhanM != null)
            {
                epdLPDKK.IsExpanded = true;
                txtTenBenhNhan.Text = Common.objBenhNhanM.HoTen.ToString();
            }
            if (Common.maNhanVien != null)
            {
                txtNhanVienLP.Text = Common.maNhanVien.ToString();
                epdLPDKK.IsExpanded = true;
            }

            //test
            //if (Common.maNhanVien != null)
            //    txtNhanVienLP.Text = Common.maNhanVien.ToString();
            //txtNhanVienLP.Text = "bhvu";
            //txtMaPhieuDDK.Text = "PDDK1";
        }
        private void CommandBinding_CanExecute_LapPhieuSDDV(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMaPhieuDDK.Text != "" && txtNhanVienLP.Text != "" && txtMaPhieuSDDV.Text != "" && dsCTDKDV !=null && dsCTDKDV.Count() > 0)
                e.CanExecute = true;
        }
        private void CommandBinding_Executed_LapPhieuSDDV(object sender, ExecutedRoutedEventArgs e)
        {
            PhieuSDDV a = new PhieuSDDV();
            a.MaPhieuSDDV = txtMaPhieuSDDV.Text;
            //BenhNhan bn = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            PhieuDKKham pdkk = (PhieuDKKham)xlPDDK.Tim(txtMaPhieuDDK.Text.ToString());
            if (pdkk != null)
            {
                MessageBox.Show(pdkk.IDPhieuDKK.ToString());
                a.PhieuDKKID = pdkk.IDPhieuDKK;
                a.PhieuDKKham = pdkk;
            }
            NhanVien nv = (NhanVien)xlNv.TimMa(txtNhanVienLP.Text.ToString());
            if (nv != null)
            {
                MessageBox.Show(nv.IDNhanVien.ToString());
                a.NhanVienLapID = nv.IDNhanVien;
                a.NhanVien = nv;
            }
            //a.BenhNhan = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            //a.PhieuDKKham = (PhieuDKKham)xlPDDK.Tim(txtMaPhieuDDK.Text.ToString());
            a.NgayLap = DateTime.Parse(dpNgayLap.Text.ToString());
            // a.NhanVien = (NhanVien)xlNV.TimMa(Common.maNhanVien.ToString());

            decimal tt = 0;
            if (dgCTDKDV.Items != null)
            {
                MessageBox.Show("list");
                foreach (CTDKDichVu b in dsCTDKDV)
                {
                    a.CTDKDichVu.Add(b);
                    //b.PhieuSDDV = a;
                    //b.PhieuSDDVID = a.IDPhieuSDDV;
                    tt += b.DichVu.DonGiaDichVu.Value;
                }
            }
            a.TongTien = tt;
            xlPSDDV.Them(a);
            this.Close();
            btnLapPhieu.IsEnabled = false;
            //dsCTDKDV.Clear();
            //dgCTDKDV.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(dsCTDKDV).ToList();


            //clearControl();
            //getDS();
        }
        private void CommandBinding_CanExecute_SuaPhieuSDDV(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed_SuaPhieuSDDV(object sender, ExecutedRoutedEventArgs e)
        {
            //PhieuSDDV a = new PhieuSDDV();
            //a.MaPhieuSDDV = txtMaPDDK.Text;
            //a.NgayLap = DateTime.Parse(dpNgayLap.Text.ToString());
            //a.BenhNhanID = 1;
            //xlPSDDV.Sua(a);

            //getDS();
        }
        //public void CommandBinding_CanExecute_ChonBenhNhan(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}
        //public void CommandBinding_Executed_ChonBenhNhan(object sender, ExecutedRoutedEventArgs e)
        //{
        //    QLBenhNhan_TN f = new QLBenhNhan_TN();
        //    f.ShowDialog();
        //    txtMaBenhNhan.Text = Common.maBenhNhan.ToString();
        //    epdLPK.IsExpanded = true;
        //}
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dg.SelectedItem != null)
            //{
            //    PhieuSDDV pk = (PhieuSDDV)xlPSDDV.Tim(dg.SelectedValue.ToString());
            //    if (pk != null)
            //    {
            //        epdLPDKK.IsExpanded = true;
            //        txtMaPDDK.Text = pk.MaPhieuSDDV;
            //        txtTenBenhNhan.Text = pk.BenhNhan.HoTen.ToString();
            //        txtMaBenhNhan.Text = pk.BenhNhan.MaBenhNhan.ToString();
            //        txtNhanVienLP.Text = pk.NhanVien.MaNhanVien.ToString();
            //        dpNgayLap.Text = pk.NgayLap.Value.ToShortDateString();

            //        List<CTDKPhongKham> ctpk = pk.CTDKPhongKham.ToList();

            //        if (ctpk != null)
            //        {
            //            //MessageBox.Show("co ct");
            //            //foreach (ChiTietPhieuSDDV ct in a.lstCTPK)
            //            //{
            //            //    dsCT.Add(ct);
            //            //}
            //            //dgCT.ItemsSource = dsCT.ToList();
            //            dgCTDKPK.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(ctpk).ToList();
            //        }
            //        //List<CTDKDichVu> ctdv = pk.PhieuSDDV.ToList();

            //        //if (ctdv != null)
            //        //{
            //        //    //MessageBox.Show("co ct");
            //        //    //foreach (ChiTietPhieuSDDV ct in a.lstCTPK)
            //        //    //{
            //        //    //    dsCT.Add(ct);
            //        //    //}
            //        //    //dgCT.ItemsSource = dsCT.ToList();
            //        //    dgCTDKDV.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(ctdv).ToList();
            //        //}

            //    }
            //}

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
        private void dgCTDKDV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (CTDKDichVu a in dgCTDKDV.SelectedItems)
            //{
            //    //epdLPK.IsExpanded = true;
            //    //cmbChuyenKhoa.SelectedIndex = int.Parse(a.ChuyenKhoaID.Value.ToString());
            //    cmbDichVu.SelectedValue = int.Parse(a.DichVuID.Value.ToString());
            //    //cmbLoaiDichVu.SelectedIndex = int.Parse(a.LoaiDichVuID.Value.ToString());
            //    //cmbDichVu.SelectedIndex = int.Parse(a.DichVuID.Value.ToString());
            //    //txtGhiChu.Text = a.GhiChu;
            //    break;
            //}
        }
        private void btnLayTTBN_Click(object sender, RoutedEventArgs e)
        {
            //QLBenhNhan_TN f = new QLBenhNhan_TN();
            //f.ShowDialog();
            //if (Common.maBenhNhan != null)
            //{
            //    txtMaBenhNhan.Text = Common.maBenhNhan.ToString();
            //    txtTenBenhNhan.Text = Common.objBenhNhanM.HoTen.ToString();
            //    epdLPDKK.IsExpanded = true;
            //}

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
            dgCTDKDV.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(dsCTDKDV).ToList();
        }
        private void btnXoaCTDV_Click(object sender, RoutedEventArgs e)
        {
            if (dgCTDKDV.SelectedValue == null) return;
            int ma = int.Parse(dgCTDKDV.SelectedValue.ToString());
            foreach (CTDKDichVu a in dsCTDKDV.Where(x => x.DichVuID == ma))
            {
                dsCTDKDV.Remove(a);
                break;
            }
            dgCTDKDV.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(dsCTDKDV).ToList();
        }
        private void btntim_Click(object sender, RoutedEventArgs e)
        {
            if (txtTim != null)
            {
                //dg.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS((xlPSDDV.Tim(txtTim.Text.ToString(), cmbTim.SelectedIndex))).ToList();
                dg.SelectedValuePath = "MaPhieuSDDV";
            }
        }

        private void btnTraCuuLK_Click(object sender, RoutedEventArgs e)
        {
            //dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham(DateTime.Parse(dpNgayLap.Text.ToString())));
            ////dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham());
        }

        private void btnTraCuuCTPK_Click(object sender, RoutedEventArgs e)
        {
            //dgCTPK.ItemsSource = xlPSDDV.TimCTDKPK_LK(2, DateTime.Parse(dpNgayLap.Text.ToString())).ToList();
        }

    }
}
