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
    /// Interaction logic for QLLoaiDichVu.xaml
    /// </summary>
    public partial class QLLoaiDichVu : Window
    {
        private CXLLoaiDichVu xl;
        public QLLoaiDichVu()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLLoaiDichVu();
            getDS();
        }
        private void getDS()
        {
            dg.ItemsSource = xl.getDSLoaiDichVu();
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "")
                return;
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            LoaiDichVu t = xl.tim(txtMa.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có loại dịch vụ này trong CSDL!");
                return;
            }

            LoaiDichVu a = new LoaiDichVu();
            a.MaLoaiDV = txtMa.Text;
            a.TenLoaiDV = txtTen.Text;
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
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            LoaiDichVu a = new LoaiDichVu();
            a.MaLoaiDV = txtMa.Text;
            a.TenLoaiDV = txtTen.Text;
            //a.MoTa = txtMoTa.Text;
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
            xl.xoa(txtMa.Text);

            getDS();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (LoaiDichVu a in dg.SelectedItems)
            {
                txtMa.Text = a.MaLoaiDV;
                txtTen.Text = a.TenLoaiDV;
                // txtMoTa.Text = a.MoTa;
                break;
            }
        }
        private string validate(LoaiDichVu ldv)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(ldv.MaLoaiDV))
            {
                return message = "Vui lòng nhập Mã loại dịch vụ.";
            }
            if (string.IsNullOrEmpty(ldv.TenLoaiDV))
            {
                return message = "Vui lòng nhập Tên loại dịch vụ.";
            }
            return message;
        }
    }
}
