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
    /// Interaction logic for QLVaiTro.xaml
    /// </summary>
    public partial class QLVaiTro : Window
    {
        private CXLVaiTro xl;
        public QLVaiTro()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLVaiTro();
            getDS();
        }
        private void getDS()
        {
            dg.ItemsSource = xl.getDSVaiTro();
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "")
                return;
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            VaiTro t = xl.tim(txtMa.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có chức vụ này trong CSDL!");
                return;
            }

            VaiTro a = new VaiTro();
            a.MaVaiTro = txtMa.Text;
            a.TenVaiTro = txtTen.Text;
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
            VaiTro a = new VaiTro();
            a.MaVaiTro = txtMa.Text;
            a.TenVaiTro = txtTen.Text;
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
            foreach (VaiTro a in dg.SelectedItems)
            {
                txtMa.Text = a.MaVaiTro;
                txtTen.Text = a.TenVaiTro;
                break;
            }
        }
        private string validate(VaiTro vt)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(vt.MaVaiTro))
            {
                return message = "Vui lòng nhập Mã vai trò.";
            }
            if (string.IsNullOrEmpty(vt.TenVaiTro))
            {
                return message = "Vui lòng nhập Tên vai trò.";
            }
            return message;
        }
    }
}
