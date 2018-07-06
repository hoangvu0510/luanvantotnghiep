using QLPK.Control;
using QLPK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace QLPK.View.QuanTri
{
    /// <summary>
    /// Interaction logic for QLLichKham.xaml
    /// </summary>
    public partial class QLLichKham : Window
    {
        private CXLLichKham xl;

        public QLLichKham()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLLichKham();
            getDS();
        }
        private void getDS()
        {
            clearControl();
            dg.ItemsSource = xl.getDSLapLich(xl.getDSLichKham()).ToList();

            cboNhanVien.ItemsSource = xl.getDSNhanVienFirstNull();
            cboNhanVien.SelectedValuePath = "IDNhanVien";
            cboNhanVien.DisplayMemberPath = "HoTen";

            cboPhongKham.ItemsSource = xl.getDSPhongKhamFirstNull();
            cboPhongKham.DisplayMemberPath = "TenPhongKham";
            cboPhongKham.SelectedValuePath = "IDPhongKham";
            cboPhongKham.SelectedIndex = 0;

            cboCaTruc.ItemsSource = xl.getDSCaTrucFirstNull();
            cboCaTruc.DisplayMemberPath = "TenCaTruc";
            cboCaTruc.SelectedValuePath = "IDCaTruc";
            cboCaTruc.SelectedIndex = 0;

            txtMaLK.Text = xl.taoMaPK().ToString();
        }
        private void clearControl()
        {
            txtMaLK.Text = "";
            txtTim.Text = "";
            cboCaTruc.SelectedValue = 0;
            cboPhongKham.SelectedValue = 0;
            cboNhanVien.SelectedValue = 0;

        }
        private void epdLL_Expanded(object sender, RoutedEventArgs e)
        {
            if (epdLL.IsExpanded)
                gbNut.Visibility = System.Windows.Visibility.Visible;
            else
                gbNut.Visibility = System.Windows.Visibility.Hidden;
        }

        private void CommandBinding_CanExecute_LapLich(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_LapLich(object sender, ExecutedRoutedEventArgs e)
        {
            LichKham t = xl.Tim(txtMaLK.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có lịch này trong CSDL!");
                return;
            }

            LichKham a = new LichKham();
            a.MaLichKham = txtMaLK.Text;
            a.NhanVienID = cboNhanVien.SelectedValue == null ? 0 : int.Parse(cboNhanVien.SelectedValue.ToString());
            a.PhongKhamID = cboPhongKham.SelectedValue == null ? 0 : int.Parse(cboPhongKham.SelectedValue.ToString());
            a.CaTrucID = cboCaTruc.SelectedValue == null ? 0 : int.Parse(cboCaTruc.SelectedValue.ToString());
            a.Ngay = DateTime.Parse(dpNgay.Text.ToString());
            xl.Them(a);

            getDS();
        }

        private void CommandBinding_CanExecute_SuaLich(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_SuaLich(object sender, ExecutedRoutedEventArgs e)
        {
            LichKham a = new LichKham();
            a.MaLichKham = txtMaLK.Text;
            a.NhanVienID = cboNhanVien.SelectedValue == null ? 0 : int.Parse(cboNhanVien.SelectedValue.ToString());
            a.PhongKhamID = cboPhongKham.SelectedValue == null ? 0 : int.Parse(cboPhongKham.SelectedValue.ToString());
            a.CaTrucID = cboCaTruc.SelectedValue == null ? 0 : int.Parse(cboCaTruc.SelectedValue.ToString());
            a.Ngay = DateTime.Parse(dpNgay.Text.ToString());
            xl.Sua(a);

            getDS();
        }

        private void CommandBinding_CanExecute_XoaLich(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_XoaLich(object sender, ExecutedRoutedEventArgs e)
        {
            xl.Xoa(txtMaLK.Text);

            getDS();
        }

        private void CommandBinding_CanExecute_TimLich(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_TimLich(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtTim.Text != "")
            {
                List<CLichKhamModel> lk = xl.TimBy(txtTim.Text);
                if (lk != null)
                {
                    dg.ItemsSource = lk;
                }
                else
                    MessageBox.Show("Không tìm thấy lịch trên!");
            }
            else
                getDS();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            cboNhanVien.ItemsSource = xl.getDSNhanVienFirstNull();
            cboNhanVien.SelectedValuePath = "IDNhanVien";
            cboNhanVien.DisplayMemberPath = "HoTen";

            cboPhongKham.ItemsSource = xl.getDSPhongKhamFirstNull();
            cboPhongKham.DisplayMemberPath = "TenPhongKham";
            cboPhongKham.SelectedValuePath = "IDPhongKham";
            cboPhongKham.SelectedIndex = 0;

            cboCaTruc.ItemsSource = xl.getDSCaTrucFirstNull();
            cboCaTruc.DisplayMemberPath = "TenCaTruc";
            cboCaTruc.SelectedValuePath = "IDCaTruc";
            cboCaTruc.SelectedIndex = 0;
            foreach (CLichKhamModel a in dg.SelectedItems)
            {
                txtMaLK.Text = a.MaLichKham;
                cboNhanVien.SelectedValue = a.NhanVienID;
                cboPhongKham.SelectedValue = a.PhongKhamID;
                cboCaTruc.SelectedValue = a.CaTrucID;
                dpNgay.Text = a.Ngay;
                break;
            }
        }

    }
}
