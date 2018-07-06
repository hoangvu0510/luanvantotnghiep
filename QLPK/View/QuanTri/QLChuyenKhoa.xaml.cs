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
    /// Interaction logic for QLChuyenKhoa.xaml
    /// </summary>
    public partial class QLChuyenKhoa : Window
    {
        private CXLChuyenKhoa xl;
        IPagedList<ChuyenKhoa> lstCK;
        int pageNumber = 1;
        public QLChuyenKhoa()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLChuyenKhoa();

            getDS();
        }

        private async void getDS()
        {
            clearControl();
            lstCK = await GetPagedListAsync();
            btnPrevious.IsEnabled = lstCK.HasPreviousPage;
            btnNext.IsEnabled = lstCK.HasNextPage;
            lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstCK.PageCount);

            dg.ItemsSource = xl.getDSChuyenKhoa(lstCK).ToList();
            dg.SelectedValuePath = "MaChuyenKhoa";
        }
        public async Task<IPagedList<ChuyenKhoa>> GetPagedListAsync(int pagenumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                return xl.getDSChuyenKhoa().ToPagedList(pageNumber, pageSize);
            });
        }
        private void clearControl()
        {
            txtMaChuyenKhoa.Text = "";
            txtTenChuyenKhoa.Text = "";
            //dpNgaySinh.SelectedDate = DateTime.Now;
            //txtDiaChi.Text = "";
            //txtDienThoai.Text = "";
            txtTim.Focus();
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {

            if (txtMaChuyenKhoa.Text != "" && txtTenChuyenKhoa.Text != ""
                && xl.tim(txtMaChuyenKhoa.Text) == null)
                e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            ChuyenKhoa t = xl.tim(txtMaChuyenKhoa.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có phòng khoa này trong CSDL!");
                return;
            }

            ChuyenKhoa a = new ChuyenKhoa();
            a.MaChuyenKhoa = txtMaChuyenKhoa.Text;
            a.TenChuyenKhoa = txtTenChuyenKhoa.Text;
            //a.MoTa = txtMoTa.Text;
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
            CChuyenKhoaModel a = (CChuyenKhoaModel)dg.SelectedItem;
            if (a != null
                && a.MaChuyenKhoa == txtMaChuyenKhoa.Text)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            ChuyenKhoa a = new ChuyenKhoa();
            a.MaChuyenKhoa = txtMaChuyenKhoa.Text;
            a.TenChuyenKhoa = txtTenChuyenKhoa.Text;
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
            CChuyenKhoaModel a = (CChuyenKhoaModel)dg.SelectedItem;
            if (dg.SelectedItem != null
                )
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Xoa(object sender, ExecutedRoutedEventArgs e)
        {

            xl.xoa(txtMaChuyenKhoa.Text);

            getDS();
        }
        private void CommandBinding_CanExecute_Tim(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private async void CommandBinding_Executed_Tim(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtTim.Text != "")
            {
                lstCK = await GetPagedListAsync();
                btnPrevious.IsEnabled = lstCK.HasPreviousPage;
                btnNext.IsEnabled = lstCK.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstCK.PageCount);
                List<CChuyenKhoaModel> a = xl.tim2(txtTim.Text, lstCK);
                if (a != null)
                {
                    dg.ItemsSource = a;
                }
                else
                    MessageBox.Show("Không tìm thấy chuyên khoa!");
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
            foreach (CChuyenKhoaModel a in dg.SelectedItems)
            {
                epdTTBN.IsExpanded = true;
                txtMaChuyenKhoa.Text = a.MaChuyenKhoa;
                txtTenChuyenKhoa.Text = a.TenChuyenKhoa;
                break;
            }
        }
        private string validate(ChuyenKhoa ck)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(ck.MaChuyenKhoa))
            {
                return message = "Vui lòng nhập Mã chuyên khoa.";
            }
            if (string.IsNullOrEmpty(ck.TenChuyenKhoa))
            {
                return message = "Vui lòng nhập Tên chuyên khoa.";
            }
            return message;
        }

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (lstCK.HasPreviousPage)
            {
                lstCK = await GetPagedListAsync(--pageNumber);
                btnPrevious.IsEnabled = lstCK.HasPreviousPage;
                btnNext.IsEnabled = lstCK.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstCK.PageCount);

                dg.ItemsSource = xl.getDSChuyenKhoa(lstCK).ToList();
                dg.SelectedValuePath = "MaChuyenKhoa";
            }
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lstCK.HasNextPage)
            {
                lstCK = await GetPagedListAsync(++pageNumber);
                btnPrevious.IsEnabled = lstCK.HasPreviousPage;
                btnNext.IsEnabled = lstCK.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstCK.PageCount);

                dg.ItemsSource = xl.getDSChuyenKhoa(lstCK).ToList();
                dg.SelectedValuePath = "MaChuyenKhoa";
            }

        }
    }
}
