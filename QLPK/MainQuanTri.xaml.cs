using QLPK.Model;
using QLPK.View;
using QLPK.View.BaoCao;
using QLPK.View.QuanTri;
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
    /// Interaction logic for MainQuanTri.xaml
    /// </summary>
    public partial class MainQuanTri : Window
    {
        public MainQuanTri()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            resetSession();
            MainWindow main = new MainWindow();
            main.Show();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
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

        private void mnuThongKeTongHop_Click(object sender, RoutedEventArgs e)
        {
            BCTongHop f = new BCTongHop();
            f.ShowDialog();
        }

        private void mnuDMQLLapLich_Click(object sender, RoutedEventArgs e)
        {
            QLLichKham f = new QLLichKham();
            f.ShowDialog();
        }

        private void mnuDanhMucDichVu_Click(object sender, RoutedEventArgs e)
        {
            QLDichVu f = new QLDichVu();
            f.ShowDialog();
        }

        private void mnuDanhMucLoaiDichVu_Click(object sender, RoutedEventArgs e)
        {
            QLLoaiDichVu f = new QLLoaiDichVu();
            f.ShowDialog();
        }

        private void mnuPhongKham_Click(object sender, RoutedEventArgs e)
        {
            QLPhongKham f = new QLPhongKham();
            f.ShowDialog();
        }

        private void mnuChuyenKhoa_Click(object sender, RoutedEventArgs e)
        {
            QLChuyenKhoa f = new QLChuyenKhoa();
            f.ShowDialog();
        }

        private void mnuDanhMucBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            QLBenhNhan f = new QLBenhNhan();
            f.ShowDialog();
        }

        private void mnuPQ_Click(object sender, RoutedEventArgs e)
        {
            QLPhanQuyen f = new QLPhanQuyen();
            f.ShowDialog();
        }

        private void mnuVaiTro_Click(object sender, RoutedEventArgs e)
        {
            QLVaiTro f = new QLVaiTro();
            f.ShowDialog();
        }

        private void mnuThuoc_Click(object sender, RoutedEventArgs e)
        {
            QLThuoc f = new QLThuoc();
            f.ShowDialog();
        }

        private void mnuDanhMucNhanVien_Click(object sender, RoutedEventArgs e)
        {
            QLNhanVien f = new QLNhanVien();
            f.ShowDialog();
        }
    }
}
