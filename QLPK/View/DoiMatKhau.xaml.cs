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
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class DoiMatKhau : Window
    {
        private CXLNhanVien xl;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLNhanVien();
            txtMaNhanVien.Text = Common.maNhanVien;
        }

        private void CommandBinding_CanExecute_ChapNhan(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_ChapNhan(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (txtMaNhanVien.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng đăng nhập trước khi đổi mật khẩu.",
                         "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txtMatKhauCu.Password == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ.",
                         "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txtMatKhauMoi.Password == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới.",
                         "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txtNhapLai.Password == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu mới.",
                         "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txtMatKhauCu.Password.Equals(txtMatKhauMoi.Password) == true)
                {
                    MessageBox.Show("Mật khẩu mới giống mật khẩu cũ.",
                         "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txtMatKhauMoi.Password.Equals(txtNhapLai.Password) == false)
                {
                    MessageBox.Show("Mật khẩu mới không giống nhau",
                         "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                NhanVien nv = xl.TimMa(txtMaNhanVien.Text);
                if (nv == null)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!",
                            "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    Byte[] passwordDB = new Byte[16];
                    passwordDB = nv.MatKhau.ToArray();
                    Byte[] passwordInput = (Byte[])Common.HashPassword(this.txtMatKhauCu.Password);
                    if (passwordDB.SequenceEqual(passwordInput) == false)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        xl.DoiMatKhau(txtMatKhauMoi.Password, nv.MaNhanVien);
                        MessageBox.Show("Đổi mật khẩu thành công!",
                               "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CommandBinding_CanExecute_Thoat(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Thoat(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
