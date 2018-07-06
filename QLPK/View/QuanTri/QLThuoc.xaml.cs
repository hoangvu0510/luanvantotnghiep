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

namespace QLPK.View
{
    /// <summary>
    /// Interaction logic for QLThuoc.xaml
    /// </summary>
    public partial class QLThuoc : Window
    {
        private CXLThuoc xl;
        public QLThuoc()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLThuoc();

            getDS();
        }

        private void getDS()
        {
            clearControl();
            dg.ItemsSource = xl.getDSThuoc();
            //dg.SelectedValuePath = "MaThuoc";

        }
        private void clearControl()
        {
            txtMaThuoc.Text = "";
            txtTenThuoc.Text = "";
            txtDonViTinh.Text = "";
            txtDuongDung.Text = "";
            txtDonGia.Text = "";
            txtTim.Focus();
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            decimal x;
            if (txtMaThuoc.Text != "" && txtTenThuoc.Text != ""
                && decimal.TryParse(txtDonGia.Text, out x)
                && xl.tim(txtMaThuoc.Text) == null)
                e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            Thuoc t = xl.tim(txtMaThuoc.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có thuốc này trong CSDL!");
                return;
            }

            Thuoc a = new Thuoc();
            a.MaThuoc = txtMaThuoc.Text;
            a.TenThuoc = txtTenThuoc.Text;
            a.DonViTinh = txtDonViTinh.Text;
            a.DuongDung = txtDuongDung.Text;
            a.DonGiaThuoc = decimal.Parse(txtDonGia.Text);
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
            Thuoc a = (Thuoc)dg.SelectedItem;
            decimal x;
            if (a != null
                && decimal.TryParse(txtDonGia.Text, out x)
                && a.MaThuoc == txtMaThuoc.Text)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            Thuoc a = new Thuoc();
            a.MaThuoc = txtMaThuoc.Text;
            a.TenThuoc = txtTenThuoc.Text;
            a.DonViTinh = txtDonViTinh.Text;
            a.DuongDung = txtDuongDung.Text;
            a.DonGiaThuoc = decimal.Parse(txtDonGia.Text);
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
            if (dg == null) return;
            Thuoc a = (Thuoc)dg.SelectedItem;
            if (dg.SelectedItem != null
                )
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Xoa(object sender, ExecutedRoutedEventArgs e)
        {

            xl.xoa(txtMaThuoc.Text);

            getDS();
        }
        private void CommandBinding_CanExecute_Tim(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (txtTim.Text == "")
            //    return;
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Tim(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtTim.Text != "")
            {
                List<Thuoc> a = xl.tim2(txtTim.Text);
                if (a != null)
                {
                    dg.ItemsSource = a;
                }
                else
                    MessageBox.Show("Không tìm thấy thuốc trên!");
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

        //private void txtTim_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        if (txtTim.Text != "")
        //        {
        //            List<Thuoc> a = xl.tim2(txtTim.Text);
        //            if (a != null)
        //            {
        //                dg.ItemsSource = a;
        //            }
        //            else
        //                MessageBox.Show("Không tìm thấy bệnh nhân trên!");
        //        }
        //        else
        //            getDS();
        //    }
        //}



        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Thuoc a = xl.tim(dg.SelectedValue.ToString());
            //// MessageBox.Show(dg.SelectedValue.ToString());
            //txtMaThuoc.Text = a.MaThuoc;
            //txtHoTen.Text = a.HoTen;
            //dpNgaySinh.SelectedDate = a.NgaySinh.Value;
            //txtDiaChi.Text = a.DiaChi;
            //txtDienThoai.Text = a.DienThoai;
            //if (a.GioiTinh == true)
            //    rdoNam.IsChecked = true;
            //else if (a.GioiTinh == false)
            //    rdoNu.IsChecked = true;

            foreach (Thuoc a in dg.SelectedItems)
            {
                epdTTBN.IsExpanded = true;
                txtMaThuoc.Text = a.MaThuoc;
                txtTenThuoc.Text = a.TenThuoc;
                txtDuongDung.Text = a.DuongDung;
                txtDonViTinh.Text = a.DonViTinh;
                txtDonGia.Text = a.DonGiaThuoc.Value.ToString();
                //dpNgaySinh.Text = a.NgaySinh;
                //txtDiaChi.Text = a.DiaChi;
                //txtDienThoai.Text = a.DienThoai;
                //if (a.GioiTinh == "Nam")
                //    rdoNam.IsChecked = true;
                //else if (a.GioiTinh == "Nữ")
                //    rdoNu.IsChecked = true;
                break;
            }
        }

        private void cmbKhoaKham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(int.Parse(cmbKhoaKham.SelectedValue.ToString()).ToString());
        }

        private string validate(Thuoc t)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(t.MaThuoc))
            {
                return message = "Vui lòng nhập Mã thuốc.";
            }
            if (string.IsNullOrEmpty(t.TenThuoc))
            {
                return message = "Vui lòng nhập Tên thuốc.";
            }
            if (t.DonGiaThuoc == null || t.DonGiaThuoc == 0)
            {
                return message = "Vui lòng nhập Đơn giá thuốc.";
            }
            if (string.IsNullOrEmpty(t.DonViTinh))
            {
                return message = "Vui lòng nhập Đơn vị tính.";
            }
            if (string.IsNullOrEmpty(t.DuongDung))
            {
                return message = "Vui lòng nhập Đương dùng.";
            }
            return message;
        }


    }
}
