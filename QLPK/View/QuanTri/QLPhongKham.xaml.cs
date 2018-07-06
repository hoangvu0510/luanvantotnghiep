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
using QLPK.Control;
using QLPK.Model;

namespace QLPK.View
{
    /// <summary>
    /// Interaction logic for QLPhongKham.xaml
    /// </summary>
    public partial class QLPhongKham : Window
    {
        private CXLPhongKham xl;
        private CXLChuyenKhoa xl_kk;
        public QLPhongKham()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLPhongKham();
            xl_kk = new CXLChuyenKhoa();

            getDS();
        }

        private void getDS()
        {
            clearControl();
            dg.ItemsSource = xl.getDSPhongKhamEnum(xl.getDSPhongKham()).ToList();

            cmbChuyenKhoa.ItemsSource = xl_kk.getDSChuyenKhoa();
            cmbChuyenKhoa.SelectedValuePath = "IDChuyenKhoa";
            cmbChuyenKhoa.DisplayMemberPath = "TenChuyenKhoa";

        }
        private void clearControl()
        {
            txtMaPhongKham.Text = "";
            txtTenPhongKham.Text = "";
            cmbChuyenKhoa.SelectedValue = 0;
            txtTim.Focus();
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMaPhongKham.Text != "" && txtTenPhongKham.Text != ""
                && xl.tim(txtMaPhongKham.Text) == null)
                e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            PhongKham t = xl.tim(txtMaPhongKham.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có phòng khám này trong CSDL!");
                return;
            }

            PhongKham a = new PhongKham();
            a.MaPhongKham = txtMaPhongKham.Text;
            a.TenPhongKham = txtTenPhongKham.Text;
            a.ChuyenKhoaID = cmbChuyenKhoa.SelectedValue == null ? 0 : int.Parse(cmbChuyenKhoa.SelectedValue.ToString());
            var message = validate(a);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xl.them(a);

            getDS();
        }
        private void CommandBinding_CanExecute_Sua(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dg == null) return;
            CPhongKhamModel a = (CPhongKhamModel)dg.SelectedItem;
            if (a != null
                && a.MaPhongKham == txtMaPhongKham.Text)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            PhongKham a = new PhongKham();
            a.MaPhongKham = txtMaPhongKham.Text;
            a.TenPhongKham = txtTenPhongKham.Text;
            a.ChuyenKhoaID = cmbChuyenKhoa.SelectedValue == null ? 0 : int.Parse(cmbChuyenKhoa.SelectedValue.ToString());
            var message = validate(a);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xl.Sua(a);

            getDS();
        }
        private void CommandBinding_CanExecute_Xoa(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Xoa(object sender, ExecutedRoutedEventArgs e)
        {
            xl.xoa(txtMaPhongKham.Text);
            getDS();
        }
        private void CommandBinding_CanExecute_Tim(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Tim(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtTim.Text != "")
            {
                List<CPhongKhamModel> a = xl.tim2(txtTim.Text);
                if (a != null)
                {
                    dg.ItemsSource = a;
                }
                else
                    MessageBox.Show("Không tìm thấy phòng khám trên!");
            }
            else
                getDS();
        }

        private void epdTTBN_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void epdTTBN_Expanded(object sender, RoutedEventArgs e)
        {
            if (epdTTBN.IsExpanded)
                gbNut.Visibility = System.Windows.Visibility.Visible;
            else
                gbNut.Visibility = System.Windows.Visibility.Hidden;

        }
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (CPhongKhamModel a in dg.SelectedItems)
            {
                epdTTBN.IsExpanded = true;
                txtMaPhongKham.Text = a.MaPhongKham;
                txtTenPhongKham.Text = a.TenPhongKham;
                cmbChuyenKhoa.SelectedValue = a.ChuyenKhoaID;

                break;
            }
        }

        private void cmbChuyenKhoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(cmbChuyenKhoa.SelectedValue.ToString());
        }
        private string validate(PhongKham pk)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(pk.MaPhongKham))
            {
                return message = "Vui lòng nhập Mã phòng khám.";
            }
            if (string.IsNullOrEmpty(pk.TenPhongKham))
            {
                return message = "Vui lòng nhập Tên phòng khám.";
            }
            if (pk.ChuyenKhoaID == 0)
            {
                return message = "Vui lòng chọn Chuyên khoa.";
            }
            return message;
        }
    }
}
