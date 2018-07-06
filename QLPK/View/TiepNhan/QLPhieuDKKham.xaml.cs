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
    /// Interaction logic for QLPhieuDKKham.xaml
    /// </summary>
    public partial class QLPhieuDKKham : Window
    {
        private CXLPhieuDKKham xlPDDK;
        private CXLChuyenKhoa xlCK;
        private CXLPhongKham xlPK;
        private CXLBenhNhan xlBN;
        private CXLNhanVien xlNV;
        private CXLLichKham xlLL;
        private CXLPhieuSDDV xlPSDDV;
        private CXLLoaiDichVu xlLDV;
        private CXLDichVu xlDV;

        private List<CTDKPhongKham> dsCTDKPK = null;
        private List<CTDKDichVu> dsCTDKDV = null;
        public QLPhieuDKKham()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlPDDK = new CXLPhieuDKKham();
            xlCK = new CXLChuyenKhoa();
            xlPK = new CXLPhongKham();
            xlBN = new CXLBenhNhan();
            xlNV = new CXLNhanVien();
            xlLL = new CXLLichKham();
            xlLDV = new CXLLoaiDichVu();
            xlDV = new CXLDichVu();
            xlPSDDV = new CXLPhieuSDDV();
            dsCTDKPK = new List<CTDKPhongKham>();
            dsCTDKDV = new List<CTDKDichVu>();

            //if (Common.vaiTroNhanVien != null)
            //{
            //    if (Common.vaiTroNhanVien == Common.BacSi)
            //    {
            //        loadGiaoDienBS();
            //    }             

            //}
            //else
            //{
            getDS();
            loadCMB();

            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 11)
                MessageBox.Show("Hệ thống phát hiện phiên làm việc: 'Ca sáng !'");
            else if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour <= 15)
                MessageBox.Show("Hệ thống phát hiện phiên làm việc: 'Ca chiều !'");
            //}
        }
        //private void loadGiaoDienBS()
        //{
        //    if(Common.vaiTroNhanVien != null && Common.maNhanVien != null)
        //    {
        //        if (Common.vaiTroNhanVien == Common.BacSi)
        //        {
        //            epdCTDV.IsEnabled = false;
        //            epdCTPK.IsEnabled = false;
        //            epdTTBN.IsEnabled = false;
        //            epdLPDKK.IsEnabled = false;
        //            epdCTDV.IsExpanded = false;
        //            epdCTPK.IsExpanded = false;
        //            epdTTBN.IsExpanded = false;
        //            epdLPDKK.IsExpanded = false;
        //            loadCMB();
        //            NhanVien a = xlNV.TimMa(Common.maNhanVien);
        //            dg.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(Common.maNhanVien.ToString()).ToList();
        //            //dg.ItemsSource = xlPDDK.getDSPhieuDKKham();
        //            dg.SelectedValuePath = "MaPhieuDKKham";
        //        }
        //    }

        //}
        private void loadCMB()
        {
            List<string> data = new List<string>();
            data.Add("Mã PDDK");
            data.Add("Mã BN");
            data.Add("Tên BN");
            cmbTim.ItemsSource = data;
            cmbTim.SelectedIndex = 0;
        }
        private void getDS()
        {
            //if (Common.vaiTroNhanVien != null)
            //{
            //    if (Common.vaiTroNhanVien == Common.BacSi)
            //    {

            //    }
            //}
            //clearControl();
            dg.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(xlPDDK.getDSPhieuDKKhamByUser(Common.maNhanVien.ToString(),DateTime.Now)).ToList();
            //dg.ItemsSource = xlPDDK.getDSPhieuDKKham();
            dg.SelectedValuePath = "MaPhieuDKKham";

            cmbChuyenKhoa.ItemsSource = xlCK.getDSChuyenKhoa();
            cmbChuyenKhoa.DisplayMemberPath = "TenChuyenKhoa";
            cmbChuyenKhoa.SelectedValuePath = "IDChuyenKhoa";
            cmbChuyenKhoa.SelectedIndex = 0;

            //cmbPhongKham.ItemsSource = xlPK.TimMaPKO(Common.ConvertToInt(cmbChuyenKhoa.SelectedValue));
            cmbPhongKham.ItemsSource = xlPK.getDSPhongKham();
            cmbPhongKham.DisplayMemberPath = "TenPhongKham";
            cmbPhongKham.SelectedValuePath = "IDPhongKham";
            cmbPhongKham.SelectedIndex = 0;

            cmbLoaiDichVu.ItemsSource = xlLDV.getDSLoaiDichVu();
            cmbLoaiDichVu.DisplayMemberPath = "TenLoaiDV";
            cmbLoaiDichVu.SelectedValuePath = "IDLoaiDV";
            cmbLoaiDichVu.SelectedIndex = 0;

            //cmbDichVu.ItemsSource = xlDV.TimMaDV(Common.ConvertToInt(cmbLoaiDichVu.SelectedValue));
            if (cmbLoaiDichVu.SelectedItem != null)
            {
                cmbDichVu.ItemsSource = xlDV.getDSDichVuByLoaiDV(int.Parse(cmbLoaiDichVu.SelectedValue.ToString()));
                cmbDichVu.DisplayMemberPath = "TenDichVu";
                cmbDichVu.SelectedValuePath = "IDDichVu";
                cmbDichVu.SelectedIndex = 0;
            }

            dgCTDKDV.SelectedValuePath = "DichVuID";
            dgCTDKPK.SelectedValuePath = "PhongKhamID";

            txtMaPDDK.Text = xlPDDK.taoMaPK();
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

            //test
            //if (Common.maNhanVien != null)
            //    txtNhanVienLP.Text = Common.maNhanVien.ToString();
            //txtNhanVienLP.Text = "bhvu";
            //txtMaBenhNhan.Text = "BN002";
        }
        private void clearControl()
        {
            dsCTDKPK.Clear();
            dsCTDKDV.Clear();
            dgCTDKPK.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(dsCTDKPK).ToList();
            dgCTDKDV.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(dsCTDKDV).ToList();
            txtMaBenhNhan.Text = null;
            Common.maBenhNhan = null;
            txtTrieuChung.Text = null;
            txtTenBenhNhan.Text = null;
            getDS();
        }
        private void CommandBinding_CanExecute_LapPhieuDKKham(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMaBenhNhan.Text != "" && txtNhanVienLP.Text != "" && txtMaPDDK.Text != "" && dgCTDKPK != null && dgCTDKPK.Items.Count > 0
               && dgCTDKDV != null && dgCTDKDV.Items.Count > 0)
                e.CanExecute = true;
        }
        private void CommandBinding_Executed_LapPhieuDKKham(object sender, ExecutedRoutedEventArgs e)
        {
            PhieuDKKham pdkk = new PhieuDKKham();
            PhieuSDDV psddv = new PhieuSDDV();
            List<PhieuSDDV> dsPSDDV = new List<PhieuSDDV>();

            pdkk.MaPhieuDKK = txtMaPDDK.Text;
            pdkk.TrieuChung = txtTrieuChung.Text.ToString();
            pdkk.NgayLap = DateTime.Now;
            BenhNhan bn = (BenhNhan)xlBN.tim(txtMaBenhNhan.Text.ToString());
            if (bn != null)
            {
                pdkk.BenhNhan = bn;
            }
            NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
            if (nv != null)
            {
                pdkk.NhanVien = nv;
            }
            if (dsCTDKPK != null)
            {
                foreach (CTDKPhongKham b in dsCTDKPK)
                {
                    //b.PhieuDKKham = a;
                    //b.PhieuDKKID = pdkk.IDPhieuDKK;
                    pdkk.CTDKPhongKham.Add(b);
                }
            }
            decimal tt = 0;
            if (dsCTDKDV != null)
            {
                foreach (CTDKDichVu b in dsCTDKDV)
                {
                    psddv.CTDKDichVu.Add(b);
                    //b.PhieuSDDV = a;
                    //b.PhieuSDDVID = a.IDPhieuSDDV;
                    tt += b.DichVu.DonGiaDichVu.Value;
                }
            }
            psddv.TongTien = tt;
            psddv.MaPhieuSDDV = xlPSDDV.taoMaPK().ToString();
            psddv.NgayLap = pdkk.NgayLap;
            psddv.NhanVien = pdkk.NhanVien;
            dsPSDDV.Add(psddv);

            pdkk.PhieuSDDV.AddRange(dsPSDDV);

            xlPDDK.Them(pdkk);


            //Common.maPhieuDDK = txtMaPDDK.Text.ToString();
            //QLPhieuSDDV f = new QLPhieuSDDV();
            //f.ShowDialog();
            //dgSDDV.ItemsSource = xlPDDK.getDSCTPhieuSDDV(txtMaPDDK.Text.ToString()).ToList();                  

            clearControl();
            MessageBox.Show("Lập PDKK thành công!");
        }
        private void LapPhieuSDDV(string maPDDK)
        {
            PhieuSDDV psddv = new PhieuSDDV();
            psddv.MaPhieuSDDV = xlPSDDV.taoMaPK().ToString();
            //BenhNhan bn = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            PhieuDKKham pdkk = (PhieuDKKham)xlPDDK.Tim(maPDDK);
            if (pdkk != null)
            {
                psddv.PhieuDKKID = pdkk.IDPhieuDKK;
                psddv.PhieuDKKham = pdkk;
            }
            NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
            if (nv != null)
            {
                psddv.NhanVienLapID = nv.IDNhanVien;
                psddv.NhanVien = nv;
            }
            //a.BenhNhan = (BenhNhan)xlBN.tim(Common.maBenhNhan.ToString());
            //a.PhieuDKKham = (PhieuDKKham)xlPDDK.Tim(txtMaPhieuDDK.Text.ToString());
            psddv.NgayLap = DateTime.Now;
            // a.NhanVien = (NhanVien)xlNV.TimMa(Common.maNhanVien.ToString());

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
                MessageBox.Show("1");
            }
            psddv.TongTien = tt;
            MessageBox.Show("2");
            xlPSDDV.Them(psddv);
            MessageBox.Show("Lập PSDDV thành công !");

        }
        private void CommandBinding_CanExecute_SuaPhieuDKKham(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed_SuaPhieuDKKham(object sender, ExecutedRoutedEventArgs e)
        {
            PhieuDKKham a = new PhieuDKKham();
            a.MaPhieuDKK = txtMaPDDK.Text;
            //a.NgayLap = DateTime.Parse(dpNgayLap.Text.ToString());
            a.BenhNhanID = 1;
            xlPDDK.Sua(a);

            getDS();
        }
        private void CommandBinding_CanExecute_ThemPSDDV(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMaPDDK.Text != null && Common.objBenhNhanM != null && dsCTDKPK != null && dsCTDKPK.Count > 0)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_SuaPSDDV(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
        private void epdLPK_Expanded(object sender, RoutedEventArgs e)
        {
            //if (epdLPK.IsExpanded)
            //    gbNut.Visibility = System.Windows.Visibility.Visible;
            //else
            //    gbNut.Visibility = System.Windows.Visibility.Hidden;
        }
       

        private void dgCTDKPK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (CTDKPhongKham a in dgCTDKPK.SelectedItems)
            //{
            //    //epdLPK.IsExpanded = true;
            //    //cmbChuyenKhoa.SelectedIndex = int.Parse(a.ChuyenKhoaID.Value.ToString());
            //    cmbPhongKham.SelectedIndex = int.Parse(a.PhongKhamID.Value.ToString());
            //    //cmbLoaiDichVu.SelectedIndex = int.Parse(a.LoaiDichVuID.Value.ToString());
            //    //cmbDichVu.SelectedIndex = int.Parse(a.DichVuID.Value.ToString());
            //    //txtGhiChu.Text = a.GhiChu;
            //    break;
            //}


        }

        private void btnLayTTBN_Click(object sender, RoutedEventArgs e)
        {
            QLBenhNhan_TN f = new QLBenhNhan_TN();
            f.ShowDialog();
            if (Common.maBenhNhan != null)
            {
                txtMaBenhNhan.Text = Common.maBenhNhan.ToString();
                txtTenBenhNhan.Text = Common.objBenhNhanM.HoTen.ToString();
                epdLPDKK.IsExpanded = true;
            }

        }
        private void btnThemCTPK_Click(object sender, RoutedEventArgs e)
        {
            // kiểm tra combobox phải có chọn dữ liệu
            PhongKham dv = (PhongKham)cmbPhongKham.SelectedItem;
            if (cmbPhongKham.SelectedValue.ToString() == "-1" || dv == null)
            {
                MessageBox.Show("Phải chọn phòng khám!");
                return;
            }
            // kiểm tra phòng khám vẫn chưa có trong dsCT
            foreach (CTDKPhongKham b in dsCTDKPK)
            {
                if (b.PhongKhamID == dv.IDPhongKham)
                {
                    MessageBox.Show("Đã tồn tại phòng khám này trong chi tiết!");
                    return;
                }
            }
            CTDKPhongKham ct = new CTDKPhongKham();
            ct.PhongKham = dv;
            dsCTDKPK.Add(ct);
            dgCTDKPK.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(dsCTDKPK).ToList();

        }
        private void btnXoaCTPK_Click(object sender, RoutedEventArgs e)
        {
            if (dgCTDKPK.SelectedValue == null) return;
            int ma = int.Parse(dgCTDKPK.SelectedValue.ToString());
            foreach (CTDKPhongKham a in dsCTDKPK.Where(x => x.PhongKhamID == ma))
            {
                dsCTDKPK.Remove(a);
                a.PhongKham = null;
                break;
            }
            dgCTDKPK.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(dsCTDKPK).ToList();
        }

        private void btntim_Click(object sender, RoutedEventArgs e)
        {
            if (txtTim != null)
            {
                dg.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS((xlPDDK.Tim(txtTim.Text.ToString(), cmbTim.SelectedIndex))).ToList();
                dg.SelectedValuePath = "MaPhieuDKKham";
            }
        }

     
        private void btnTraCuuCTPK_Click(object sender, RoutedEventArgs e)
        {
            //dgCTPK.ItemsSource = xlPDDK.TimCTDKPK_LK(2, DateTime.Parse(dpNgayLap.Text.ToString())).ToList();
        }

        private void btnThemPSDDV_Click(object sender, RoutedEventArgs e)
        {


        }
        private void btnSuaPSDDV_Click(object sender, RoutedEventArgs e)
        {

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
            dgCTDKDV.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(dsCTDKDV).ToList();
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
            dgCTDKDV.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(dsCTDKDV).ToList();
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

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg.ItemsSource != null)
            {
                Common.maPhieuDDK = dg.SelectedValue.ToString();
                this.Close();
            }

        }

        private void btnXemPDKK_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                PhieuDKKham pk = (PhieuDKKham)xlPDDK.Tim(dg.SelectedValue.ToString());
                if (pk != null)
                {
                    txtMaPDDK.Text = pk.MaPhieuDKK;
                    txtTenBenhNhan.Text = pk.BenhNhan.HoTen.ToString();
                    txtMaBenhNhan.Text = pk.BenhNhan.MaBenhNhan.ToString();
                    txtNhanVienLP.Text = pk.NhanVien.MaNhanVien.ToString();
                    dpNgayLap.Text = pk.NgayLap.Value.ToShortDateString();

                    List<CTDKPhongKham> ctpk = pk.CTDKPhongKham.ToList();
                    if (ctpk != null)
                    {
                        dgCTDKPK.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(ctpk).ToList();
                    }
                    //List<CTDKDichVu> ctdv = pk.PhieuSDDV.ToList();

                    //if (ctdv != null)
                    //{
                    //    //MessageBox.Show("co ct");
                    //    //foreach (ChiTietPhieuDKKham ct in a.lstCTPK)
                    //    //{
                    //    //    dsCT.Add(ct);
                    //    //}
                    //    //dgCT.ItemsSource = dsCT.ToList();
                    //    dgCTDKDV.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(ctdv).ToList();
                    //}

                }
            }
        }
        //private void CommandBinding_Executed_ThemPSDDV(object sender, ExecutedRoutedEventArgs e)
        //{
        //    Common.maPhieuDDK = txtMaPDDK.Text.ToString();
        //    QLPhieuSDDV f = new QLPhieuSDDV();
        //    f.ShowDialog();
        //    dgSDDV.ItemsSource = xlPDDK.getDSCTPhieuSDDV(txtMaPDDK.Text.ToString()).ToList();
        //}
        //private void CommandBinding_CanExecute_SuaPSDDV(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}
        private void btnTraCuuLK_Click(object sender, RoutedEventArgs e)
        {
            dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham(dpNgayLap.SelectedDate.Value));
            //dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKham());
        }
        private void cmbChuyenKhoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbChuyenKhoa.SelectedValue != null)
            {
                cmbPhongKham.ItemsSource = xlPK.TimMaPKO(Common.ConvertToInt(cmbChuyenKhoa.SelectedValue));
                cmbPhongKham.SelectedValuePath = "IDPhongKham";
                cmbPhongKham.DisplayMemberPath = "TenPhongKham";
                cmbPhongKham.SelectedIndex = 0;

                if (cmbChuyenKhoa.SelectedValue != null && dpNgayLap.SelectedDate != null)
                {
                    dgLK.ItemsSource = xlLL.getDSLichKhamByDS(xlLL.getDSLichKhamChuyenKhoa(int.Parse(cmbChuyenKhoa.SelectedValue.ToString()), dpNgayLap.SelectedDate.Value));
                }
            }
        }

    }
}
