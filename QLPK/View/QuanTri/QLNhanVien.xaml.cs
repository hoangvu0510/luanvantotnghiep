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
using PagedList;

namespace QLPK.View
{
    /// <summary>
    /// Interaction logic for QLNhanVien.xaml
    /// </summary>
    public partial class QLNhanVien : Window
    {
        private CXLNhanVien xl;
        IPagedList<NhanVien> lstNV;
        int pageNumber = 1;
        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void epdTTNV_Expanded(object sender, RoutedEventArgs e)
        {
            if (epdTTNV.IsExpanded)
                gbNut.Visibility = System.Windows.Visibility.Visible;
            else
                gbNut.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLNhanVien();
            dpNgaySinh.Text = DateTime.Now.ToShortDateString();

            getDS();
        }
        private async void getDS()
        {
            clearControl();

            lstNV = await GetPagedListAsync();
            btnPrevious.IsEnabled = lstNV.HasPreviousPage;
            btnNext.IsEnabled = lstNV.HasNextPage;
            lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

            dg.ItemsSource = xl.getDSNhanVien(lstNV).ToList();
            dg.SelectedValuePath = "MaNhanVien";

        }
        public async Task<IPagedList<NhanVien>> GetPagedListAsync(int pagenumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                return xl.getDSNhanVien().ToPagedList(pageNumber, pageSize);
            });
        }
        private void clearControl()
        {
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            dpNgaySinh.SelectedDate = DateTime.Now;
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTim.Focus();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (CNhanVienModel a in dg.SelectedItems)
            {
                epdTTNV.IsExpanded = true;
                txtMaNhanVien.Text = a.MaNhanVien;
                txtHoTen.Text = a.HoTen;
                txtCMND.Text = a.CMND;
                dpNgaySinh.Text = a.NgaySinh.ToString();
                txtDiaChi.Text = a.DiaChi;
                txtDienThoai.Text = a.DienThoai;
                if (a.GioiTinh == "Nam")
                    rdoNam.IsChecked = true;
                else
                    rdoNu.IsChecked = true;
                if (a.TrangThai == "Làm việc")
                    rdoLamViec.IsChecked = true;
                else
                    rdoNghiViec.IsChecked = true;
                if (a.KhoaNhanVien == "Hiệu lực")
                    rdoHieuluc.IsChecked = true;
                else
                    rdoHethieuluc.IsChecked = true;
                break;
            }
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMaNhanVien.Text != "" && txtHoTen.Text != "" && txtCMND.Text != "" && txtDienThoai.Text != ""
                 && xl.TimMa(txtMaNhanVien.Text) == null)
                e.CanExecute = true;
        }

        private void CommandBinding_CanExecute_Sua(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dg == null) return;
            CNhanVienModel a = (CNhanVienModel)dg.SelectedItem;
            if (a != null
                && a.MaNhanVien == txtMaNhanVien.Text)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_CanExecute_Tim(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien t = xl.TimMa(txtMaNhanVien.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có nhân viên này trong CSDL!");
                return;
            }
            Byte[] matKhau = (Byte[])Common.HashPassword("PK@" + txtCMND.Text);
            NhanVien nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                HoTen = txtHoTen.Text,
                NgaySinh = DateTime.Parse(dpNgaySinh.Text.ToString()),
                GioiTinh = rdoNam.IsChecked == true ? true : false,
                CMND = txtCMND.Text,
                DiaChi = txtDiaChi.Text,
                DienThoai = txtDienThoai.Text,
                TrangThai = rdoLamViec.IsChecked == true ? true : false,
                HieuLuc = rdoHieuluc.IsChecked == true ? true : false,
                MatKhau = matKhau,
                VaiTroID = 1, // 1 = Trong
            };
            var message = validate(nv);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xl.Them(nv);
            getDS();
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                HoTen = txtHoTen.Text,
                NgaySinh = DateTime.Parse(dpNgaySinh.Text.ToString()),
                GioiTinh = rdoNam.IsChecked == true ? true : false,
                CMND = txtCMND.Text,
                DiaChi = txtDiaChi.Text,
                DienThoai = txtDienThoai.Text,
                TrangThai = rdoLamViec.IsChecked == true ? true : false,
                HieuLuc = rdoHieuluc.IsChecked == true ? true : false
            };
            var message = validate(nv);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xl.Sua(nv);
            getDS();
        }

        private async void CommandBinding_Executed_Tim(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtTim.Text != "")
            {
                lstNV = await GetPagedListAsync(++pageNumber);
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

                List<CNhanVienModel> nv = xl.Tim(txtTim.Text, lstNV);
                if (nv != null)
                {
                    dg.ItemsSource = nv;
                }
                else
                    MessageBox.Show("Không tìm thấy nhân viên trên!");
            }
            else
                getDS();
        }

        private void CommandBinding_CanExecute_DatLaiMatKhau(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_DatLaiMatKhau(object sender, ExecutedRoutedEventArgs e)
        {
            if (Common.maNhanVien != null)
            {
                if (Common.vaiTroNhanVien == Common.QuanTri)
                {
                    NhanVien nv = xl.TimMa(txtMaNhanVien.Text);
                    if (nv == null)
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        xl.DatLaiMatKhau("PK@" + nv.CMND, nv.MaNhanVien);
                        MessageBox.Show("Đặt lại mật khẩu thành công!",
                               "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Bạn không có quyền");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải đăng nhập để sử dụng chức năng này");
                DangNhap f = new DangNhap();
                f.ShowDialog();
            }
        }
        private string validate(NhanVien bn)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(bn.MaNhanVien))
            {
                return message = "Vui lòng nhập Mã nhân viên.";
            }
            if (string.IsNullOrEmpty(bn.HoTen))
            {
                return message = "Vui lòng nhập Họ tên.";
            }
            if (string.IsNullOrEmpty(bn.CMND))
            {
                return message = "Vui lòng nhập Số CMND.";
            }
            if (string.IsNullOrEmpty(bn.DienThoai))
            {
                return message = "Vui lòng nhập Số điện thoại.";
            }
            else
            {
                if (bn.DienThoai.Length < 10)
                    return message = "Nhập không đúng số điện thoại.";
            }
            return message;
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lstNV.HasNextPage)
            {
                lstNV = await GetPagedListAsync(++pageNumber);
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

                dg.ItemsSource = xl.getDSNhanVien(lstNV).ToList();
                dg.SelectedValuePath = "MaNhanVien";
            }
        }

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (lstNV.HasPreviousPage)
            {
                lstNV = await GetPagedListAsync(--pageNumber);
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

                dg.ItemsSource = xl.getDSNhanVien(lstNV).ToList();
                dg.SelectedValuePath = "MaNhanVien";
            }
        }
    }
}
