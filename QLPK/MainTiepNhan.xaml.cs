using QLPK.Model;
using QLPK.View;
using QLPK.View.BaoCao;
using QLPK.View.TiepNhan;
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

namespace QLPK
{
    /// <summary>
    /// Interaction logic for MainTiepNhan.xaml
    /// </summary>
    public partial class MainTiepNhan : Window
    {
        public MainTiepNhan()
        {
            InitializeComponent();
        }
        private void resetSession()
        {
            Common.maNhanVien = null;
            Common.nhanVienID = null;
            Common.maBenhNhan = null;
            Common.objBenhNhanM = null;
            Common.vaiTroNhanVien = null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            resetSession();
            MainWindow main = new MainWindow();
            main.Show();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void mnuHeThongDangXuat_Click(object sender, RoutedEventArgs e)
        {
            Common.maNhanVien = null;
            if (Common.maNhanVien == null)
            {
                resetSession();
                MessageBox.Show("Đăng xuất thành công!");
                this.Close();
                MainWindow main = new MainWindow();
                main.Show();
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
            }
            else
                MessageBox.Show("Lỗi đăng xuất!");
        }

        private void mnuHeThongDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            if (Common.maNhanVien != null)
            {
                DoiMatKhau f = new DoiMatKhau();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn phải đăng nhập để sử dụng chức năng này");
                this.Close();
                MainWindow main = new MainWindow();
                main.Show();
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
            }
        }

        private void mnuDanhMucPhieuDKKham_Click(object sender, RoutedEventArgs e)
        {
            QLPhieuDKKham f = new QLPhieuDKKham();
            f.ShowDialog();
        }

        private void mnuThongKeNhanVienTiepNhan_Click(object sender, RoutedEventArgs e)
        {
            BCNhanVienTiepNhan f = new BCNhanVienTiepNhan();
            f.ShowDialog();
        }

        private void mnuDMQLTTBenhNhanTN_Click(object sender, RoutedEventArgs e)
        {
            QLBenhNhan_TN f = new QLBenhNhan_TN();
            f.ShowDialog();
        }

        private void mnuDanhMucNhanVienTN_Click(object sender, RoutedEventArgs e)
        {
            QLNhanVien_TN f = new QLNhanVien_TN();
            f.ShowDialog();
        }
    }
}
