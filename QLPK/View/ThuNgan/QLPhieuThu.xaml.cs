using QLPK.Control;
using QLPK.Model;
using QLPK.View.BaoCao;
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

namespace QLPK.View.ThuNgan
{
    /// <summary>
    /// Interaction logic for QLPhieuThu.xaml
    /// </summary>
    public partial class QLPhieuThu : Window
    {
        private CXLPhieuDKKham xlPDDK;
        private CXLPhieuThu xlPT;
        private CXLNhanVien xlNV;
        private CXLPhieuSDDV xlPSDDV;
        private CXLBaoCao xlBC;

        private List<CTDKDichVu> dsCTDKDV = null;
        public QLPhieuThu()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlPDDK = new CXLPhieuDKKham();
            xlPT = new CXLPhieuThu();
            xlNV = new CXLNhanVien();
            xlPSDDV = new CXLPhieuSDDV();
            dsCTDKDV = new List<CTDKDichVu>();
            xlBC = new CXLBaoCao();

            //getDS();
            //if (Common.maNhanVien != null)
            //    txtNhanVienLP.Text = Common.maNhanVien.ToString();
            //txtNhanVienLP.Text = "bhvu";


            dpTuNgay.Text = DateTime.Now.ToShortDateString();
            dpDenNgay.Text = DateTime.Now.ToShortDateString();

            dpNgayLap.Text = DateTime.Now.ToShortDateString();

            refresh();

        }
        private void getDSPT()
        {
            //dgPT.ItemsSource = xlPT.getDSPhieuThu();
            dgPT.ItemsSource = xlPT.getDSPhieuThuByDS(xlPT.getDSPhieuThuByUser(Common.maNhanVien.ToString(), DateTime.Now)).ToList();
            dgPT.SelectedValuePath = "MaPhieuThu";
        }

        private void XemCTDKDV_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                PhieuSDDV a = (PhieuSDDV)xlPSDDV.Tim(dg.SelectedValue.ToString());
                if (a != null)
                {
                    if (a.CTDKDichVu.Count > 0)
                    {
                        dgCTDV.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(a.CTDKDichVu.ToList());
                        MessageBox.Show("Tìm được " + a.CTDKDichVu.Count.ToString() + " records");

                        decimal tt = 0;
                        foreach (CTDKDichVu x in a.CTDKDichVu)
                        {
                            tt += x.DichVu.DonGiaDichVu.Value;
                        }
                        if (tt != a.TongTien.Value)
                        {
                            txtTongTien.Text = null;
                            MessageBox.Show("Có lỗi kết toán tổng tiền ko trùng khớp!");
                            return;
                        }
                        txtTongTien.Text = a.TongTien.Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu chi tiết!");
                        return;
                    }
                }
            }
        }
        private void getDSPSDDV()
        {
            List<PhieuSDDV> Lpddk = xlPSDDV.getDSPhieuSDDV(DateTime.Parse(dpTuNgay.Text.ToString()), DateTime.Parse(dpDenNgay.Text.ToString()), chbDaDongTien.IsChecked == true ? true : false).ToList();
            if (Lpddk.Count > 0)
            {
                dg.ItemsSource = null;
                dgCTDV.ItemsSource = null;
                dg.ItemsSource = xlPSDDV.getDSPhieuSDDVByDS(Lpddk).ToList();
                dg.SelectedValuePath = "MaPhieuSDDV";
                MessageBox.Show("Tìm được " + Lpddk.Count.ToString() + " records");
            }
            else
            {
                dg.ItemsSource = null;
                dgCTDV.ItemsSource = null;
                refresh();
                MessageBox.Show("Không có dữ liệu!");
                return;
            }
        }
        private void btnTimKiemPSDDV_Click(object sender, RoutedEventArgs e)
        {
            getDSPSDDV();

        }
        private void CommandBinding_CanExecute_LapPhieuThu(object sender, CanExecuteRoutedEventArgs e)
        {
            decimal tt = 0;

            if (txtMaPT.Text != "" && txtNhanVienLP.Text != "" && txtTongTien.Text != "" && decimal.TryParse(txtTongTien.Text.ToString(), out tt) && tt > 0
                && dg.Items.Count > 0 && dgCTDV.Items.Count > 0)
                if (decimal.Parse(txtTongTien.Text) > 0)
                    e.CanExecute = true;
        }
        private void CommandBinding_Executed_LapPhieuThu(object sender, ExecutedRoutedEventArgs e)
        {
            PhieuThu a = new PhieuThu();
            a.MaPhieuThu = txtMaPT.Text.ToString();
            a.TongTien = decimal.Parse(txtTongTien.Text.ToString());


            NhanVien nv = (NhanVien)xlNV.TimMa(txtNhanVienLP.Text.ToString());
            if (nv != null)
            {
                a.NhanVien = nv;
            }
            PhieuSDDV pk = (PhieuSDDV)xlPSDDV.Tim(dg.SelectedValue.ToString());
            if (pk != null)
            {
                a.PhieuSDDV = pk;
            }
            a.NgayLap = DateTime.Now;
            xlPT.Them(a);
            xlPSDDV.DaDongTien(dg.SelectedValue.ToString());

            //getDSPT();
            //getDSPSDDV();

            refresh();
            getDSPSDDV();
        }
        private void refresh()
        {
            //dgCTDV.ItemsSource = null;
            //dg.ItemsSource = null;
            //getDS2();
            txtMaPT.Text = xlPT.taoMaPT().ToString();
            txtTongTien.Text = null;
            if (Common.maNhanVien != null)
                txtNhanVienLP.Text = Common.maNhanVien.ToString();
            //txtNhanVienLP.Text = "bhvu";
            getDSPT();

        }

        private void btnInPT_Click(object sender, RoutedEventArgs e)
        {
            if (dgPT.SelectedItem != null)
            {
                var maPT = dgPT.SelectedValue.ToString();
                InPhieuThu f = new InPhieuThu();
                f.data = xlBC.getDSPhieuThuReport(maPT);
                f.Show();
            }
        }
    }
}
