using QLPK.Model;
using QLPK.View;
using QLPK.View.BacSi;
using QLPK.View.BaoCao;
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
    /// Interaction logic for MainBacSi.xaml
    /// </summary>
    public partial class MainBacSi : Window
    {
        public MainBacSi()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void resetSession()
        {
            Common.maNhanVien = null;
            Common.nhanVienID = null;
            Common.maBenhNhan = null;
            Common.objBenhNhanM = null;
            Common.vaiTroNhanVien = null;
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


        private void mnuDanhMucNhanVien_Click(object sender, RoutedEventArgs e)
        {
            QLNhanVien_BS f = new QLNhanVien_BS();
            f.ShowDialog();
        }

        private void mnuLapPhieuKham_Click(object sender, RoutedEventArgs e)
        {
            QLDSDKK f = new QLDSDKK();
            f.ShowDialog();
        }

        private void mnuLSBN_Click(object sender, RoutedEventArgs e)
        {
            QLLSKB f = new QLLSKB();
            f.ShowDialog();
        }

        private void mnuThongKeNhanVienBacSi_Click(object sender, RoutedEventArgs e)
        {
            BCNhanVienBacSi f = new BCNhanVienBacSi();
            f.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            resetSession();
            MainWindow main = new MainWindow();
            main.Show();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }
    }
}
