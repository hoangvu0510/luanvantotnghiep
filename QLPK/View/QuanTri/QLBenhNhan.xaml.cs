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
    /// Interaction logic for QLBenhNhan.xaml
    /// </summary>
    public partial class QLBenhNhan : Window
    {
        private CXLBenhNhan xl;
        IPagedList<BenhNhan> lstBN;
        int pageNumber = 1;
        public QLBenhNhan()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xl = new CXLBenhNhan();
            dpNgaySinh.Text = DateTime.Now.ToShortDateString();

            getDS();
        }

        private async void getDS()
        {
            clearControl();
            lstBN = await GetPagedListAsync();
            btnPrevious.IsEnabled = lstBN.HasPreviousPage;
            btnNext.IsEnabled = lstBN.HasNextPage;
            lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstBN.PageCount);

            dg.ItemsSource = xl.getDSBenhNhan3(lstBN).ToList();
            dg.SelectedValuePath = "MaBenhNhan";
        }
        public async Task<IPagedList<BenhNhan>> GetPagedListAsync(int pagenumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                return xl.getDSBenhNhan().ToPagedList(pageNumber, pageSize);
            });
        }
        private void clearControl()
        {
            txtMaBenhNhan.Text = "";
            txtHoTen.Text = "";
            txtCMND.Text = "";
            dpNgaySinh.SelectedDate = DateTime.Now;
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTim.Focus();
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMaBenhNhan.Text != "" && txtHoTen.Text != "" && txtDiaChi.Text != ""
                && xl.tim(txtMaBenhNhan.Text) == null)
                e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            BenhNhan t = xl.tim(txtMaBenhNhan.Text);
            if (t != null)
            {
                MessageBox.Show("Đã có bệnh nhân này trong CSDL!");
                return;
            }
            int id = 0;
            BenhNhan a = new BenhNhan();
            a.MaBenhNhan = txtMaBenhNhan.Text;
            a.HoTen = txtHoTen.Text;
            a.CMND = txtCMND.Text;
            a.NgaySinh = DateTime.Parse(dpNgaySinh.Text.ToString());
            a.GioiTinh = rdoNam.IsChecked == true ? true : false;
            a.DiaChi = txtDiaChi.Text;
            a.DienThoai = txtDienThoai.Text;
            var message = validate(a);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xl.them(a, out id);
            getDS();
        }
        private void CommandBinding_CanExecute_Sua(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dg == null) return;
            CBenhNhanModel a = (CBenhNhanModel)dg.SelectedItem;
            if (a != null
                && a.MaBenhNhan == txtMaBenhNhan.Text)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            BenhNhan a = new BenhNhan();
            a.MaBenhNhan = txtMaBenhNhan.Text;
            a.HoTen = txtHoTen.Text;
            a.CMND = txtCMND.Text;
            a.NgaySinh = DateTime.Parse(dpNgaySinh.Text.ToString());
            a.GioiTinh = rdoNam.IsChecked == true ? true : false;
            a.DiaChi = txtDiaChi.Text;
            a.DienThoai = txtDienThoai.Text;
            var message = validate(a);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            BenhNhan t = xl.tim(txtMaBenhNhan.Text);
            CTCNBenhNhan cTBenhNhan = LogCTBenhNhan(t, a);
            xl.Sua(a);
            xl.LogBenhNhan(cTBenhNhan);
            getDS();
        }

        private CTCNBenhNhan LogCTBenhNhan(BenhNhan duLieuCu, BenhNhan duLieuMoi)
        {
            CTCNBenhNhan ctBN = new CTCNBenhNhan();
            string duLieuCuXml = string.Empty;
            duLieuCuXml += "<?xml version='1.0' encoding='UTF - 8'?>";
            duLieuCuXml += "<BenhNhan>";
            if (duLieuCu.MaBenhNhan != duLieuMoi.MaBenhNhan)
            {
                duLieuCuXml += "<MaBenhNhan>" + duLieuCu.MaBenhNhan + "</MaBenhNhan>";
            }
            if (duLieuCu.CMND != duLieuMoi.CMND)
            {
                duLieuCuXml += "<CMND>" + duLieuCu.CMND + "</CMND>";
            }
            if (duLieuCu.HoTen != duLieuMoi.HoTen)
            {
                duLieuCuXml += "<HoTen>" + duLieuCu.HoTen + "</HoTen>";
            }
            if (duLieuCu.NgaySinh != duLieuMoi.NgaySinh)
            {
                duLieuCuXml += "<NgaySinh>" + duLieuCu.NgaySinh + "</NgaySinh>";
            }
            if (duLieuCu.GioiTinh != duLieuMoi.GioiTinh)
            {
                duLieuCuXml += "<GioiTinh>" + duLieuCu.GioiTinh + "</GioiTinh>";
            }
            if (duLieuCu.DiaChi != duLieuMoi.DiaChi)
            {
                duLieuCuXml += "<DiaChi>" + duLieuCu.DiaChi + "</DiaChi>";
            }
            if (duLieuCu.DienThoai != duLieuMoi.DienThoai)
            {
                duLieuCuXml += "<DienThoai>" + duLieuCu.DienThoai + "</DienThoai>";
            }
            duLieuCuXml += "</BenhNhan>";
            ctBN.BenhNhanID = duLieuCu.IDBenhNhan;
            ctBN.NhanVienID = Common.nhanVienID;
            ctBN.NgayCapNhat = DateTime.Now;
            ctBN.DuLieuCu = duLieuCuXml;
            return ctBN;

        }
        private void CommandBinding_CanExecute_Xoa(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dg == null) return;
            CBenhNhanModel a = (CBenhNhanModel)dg.SelectedItem;
            if (dg.SelectedItem != null
                )
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_Xoa(object sender, ExecutedRoutedEventArgs e)
        {
            xl.xoa(txtMaBenhNhan.Text);
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
                lstBN = await GetPagedListAsync();
                btnPrevious.IsEnabled = lstBN.HasPreviousPage;
                btnNext.IsEnabled = lstBN.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstBN.PageCount);
                List<CBenhNhanModel> a = xl.tim2(txtTim.Text, lstBN);
                if (a != null)
                {
                    dg.ItemsSource = a;
                }
                else
                    MessageBox.Show("Không tìm thấy bệnh nhân trên!");
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
            foreach (CBenhNhanModel a in dg.SelectedItems)
            {
                epdTTBN.IsExpanded = true;
                txtMaBenhNhan.Text = a.MaBenhNhan;
                txtHoTen.Text = a.HoTen;
                txtCMND.Text = a.CMND;
                dpNgaySinh.Text = a.NgaySinh;
                txtDiaChi.Text = a.DiaChi;
                txtDienThoai.Text = a.DienThoai;
                if (a.GioiTinh == "Nam")
                    rdoNam.IsChecked = true;
                else if (a.GioiTinh == "Nữ")
                    rdoNu.IsChecked = true;
                break;
            }
        }
        private string validate(BenhNhan bn)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(bn.MaBenhNhan))
            {
                return message = "Vui lòng nhập Mã bệnh nhân.";
            }
            if (string.IsNullOrEmpty(bn.HoTen))
            {
                return message = "Vui lòng nhập Họ tên.";
            }
            if (string.IsNullOrEmpty(bn.CMND))
            {
                return message = "Vui lòng nhập CMND.";
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

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

            if (lstBN.HasPreviousPage)
            {
                lstBN = await GetPagedListAsync(--pageNumber);
                btnPrevious.IsEnabled = lstBN.HasPreviousPage;
                btnNext.IsEnabled = lstBN.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstBN.PageCount);

                dg.ItemsSource = xl.getDSBenhNhan3(lstBN).ToList();
                dg.SelectedValuePath = "MaBenhNhan";
            }
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lstBN.HasPreviousPage)
            {
                lstBN = await GetPagedListAsync(++pageNumber);
                btnPrevious.IsEnabled = lstBN.HasPreviousPage;
                btnNext.IsEnabled = lstBN.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstBN.PageCount);

                dg.ItemsSource = xl.getDSBenhNhan3(lstBN).ToList();
                dg.SelectedValuePath = "MaBenhNhan";
            }
        }
    }
}
