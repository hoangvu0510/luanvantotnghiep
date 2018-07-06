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
using PagedList;

namespace QLPK.View
{
    /// <summary>
    /// Interaction logic for QLDichVu.xaml
    /// </summary>
    public partial class QLDichVu : Window
    {
        private CXLDichVu xl;
        private CXLLoaiDichVu xlLDV;
        IPagedList<DichVu> lstDV;
        int pageNumber = 1;
        public QLDichVu()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLDichVu();
            xlLDV = new CXLLoaiDichVu();
            getDS();
        }
        private async void getDS()
        {
            clearControl();
            lstDV = await GetPagedListAsync();
            btnPrevious.IsEnabled = lstDV.HasPreviousPage;
            btnNext.IsEnabled = lstDV.HasNextPage;
            lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstDV.PageCount);

            dg.ItemsSource = xl.getDSDichVu(lstDV).ToList();

            cmbLoaiDV.ItemsSource = xlLDV.getDSLoaiDichVu();
            cmbLoaiDV.SelectedValuePath = "IDLoaiDV";
            cmbLoaiDV.DisplayMemberPath = "TenLoaiDV";
        }
        public async Task<IPagedList<DichVu>> GetPagedListAsync(int pagenumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                return xl.getDSDichVu().ToPagedList(pageNumber, pageSize);
            });
        }
        private void clearControl()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDonGia.Text = "";
            txtMoTa.Text = "";
            chbTrangThai.IsChecked = false;
            cmbLoaiDV.SelectedValue = 0;

        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "")
                return;
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            DichVu t = xl.tim(txtMa.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có dịch vụ này trong CSDL!");
                return;
            }

            DichVu a = new DichVu();
            a.MaDichVu = txtMa.Text;
            a.TenDichVu = txtTen.Text;
            a.LoaiDichVuID = cmbLoaiDV.SelectedValue == null ? 0 : int.Parse(cmbLoaiDV.SelectedValue.ToString());
            a.DonGiaDichVu = decimal.Parse(txtDonGia.Text);
            a.MoTa = txtMoTa.Text;
            a.TrangThai = chbTrangThai.IsChecked == true ? true : false;
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
            DichVu a = new DichVu();
            a.MaDichVu = txtMa.Text;
            a.TenDichVu = txtTen.Text;
            a.DonGiaDichVu = decimal.Parse(txtDonGia.Text);
            a.MoTa = txtMoTa.Text;
            a.TrangThai = chbTrangThai.IsChecked == true ? true : false;
            a.LoaiDichVuID = cmbLoaiDV.SelectedValue == null ? 0 : int.Parse(cmbLoaiDV.SelectedValue.ToString());
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
            cmbLoaiDV.ItemsSource = xlLDV.getDSLoaiDichVu();
            cmbLoaiDV.SelectedValuePath = "IDLoaiDV";
            cmbLoaiDV.DisplayMemberPath = "TenLoaiDV";
            foreach (CDichVuModel a in dg.SelectedItems)
            {
                txtMa.Text = a.MaDichVu;
                txtTen.Text = a.TenDichVu;
                cmbLoaiDV.SelectedValue = a.LoaiDichVuID;
                txtDonGia.Text = a.DonGiaDichVu.Value.ToString();
                txtMoTa.Text = a.MoTa;
                chbTrangThai.IsChecked = a.TrangThai.Value == true ? true : false;
                break;
            }
        }

        private string validate(DichVu dv)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(dv.MaDichVu))
            {
                return message = "Vui lòng nhập Mã dịch vụ.";
            }
            if (string.IsNullOrEmpty(dv.TenDichVu))
            {
                return message = "Vui lòng nhập Tên dịch vụ.";
            }
            if (dv.DonGiaDichVu == null || dv.DonGiaDichVu == 0)
            {
                return message = "Vui lòng nhập Đơn giá dịch vụ.";
            }
            if (dv.LoaiDichVuID == 0)
            {
                return message = "Vui lòng chọn Loại dịch vụ.";
            }
            return message;
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lstDV.HasNextPage)
            {
                lstDV = await GetPagedListAsync(++pageNumber);
                btnPrevious.IsEnabled = lstDV.HasPreviousPage;
                btnNext.IsEnabled = lstDV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstDV.PageCount);

                dg.ItemsSource = xl.getDSDichVu(lstDV).ToList();
            }
        }

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (lstDV.HasPreviousPage)
            {
                lstDV = await GetPagedListAsync(--pageNumber);
                btnPrevious.IsEnabled = lstDV.HasPreviousPage;
                btnNext.IsEnabled = lstDV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstDV.PageCount);

                dg.ItemsSource = xl.getDSDichVu(lstDV).ToList();
            }
        }
    }
}
