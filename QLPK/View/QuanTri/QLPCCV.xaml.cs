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
    /// Interaction logic for PhanCongCongViec.xaml
    /// </summary>
    public partial class QLPCCV : Window
    {
        private CXLNhanVien xlNV;
        private CXLPhongKham xlPKA;
        private CXLChuyenKhoa xlPKO;
        IPagedList<NhanVien> lstNV;
        int pageNumber = 1;
        public QLPCCV()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlNV = new CXLNhanVien();
            xlPKA = new CXLPhongKham();
            xlPKO = new CXLChuyenKhoa();
            clearControl();
            loadCombo();
            getDS();
        }
        private async void getDS()
        {
            clearControl();
            lstNV = await GetPagedListAsync();
            btnPrevious.IsEnabled = lstNV.HasPreviousPage;
            btnNext.IsEnabled = lstNV.HasNextPage;
            lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

            dg.ItemsSource = xlNV.getDSPCCV(lstNV).ToList();
            dg.SelectedValuePath = "MaNhanVien";

        }
        public async Task<IPagedList<NhanVien>> GetPagedListAsync(int pagenumber = 1, int pageSize = 5)
        {
            return await Task.Factory.StartNew(() =>
            {
                return xlNV.getDSNhanVien().ToPagedList(pageNumber, pageSize);
            });
        }
        private void clearControl()
        {
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            txtTim.Focus();
        }
        private void loadCombo()
        {

            cboChuyenKhoa.ItemsSource = xlPKO.getDSChuyenKhoa();
            cboChuyenKhoa.SelectedValuePath = "ID";
            cboChuyenKhoa.DisplayMemberPath = "TenChuyenKhoa";

            cboPhongKham.ItemsSource = xlPKA.getDSPhongKham();
            cboPhongKham.SelectedValuePath = "ID";
            cboPhongKham.DisplayMemberPath = "TenPhongKham";
        }


        private void epdPCCV_Expanded(object sender, RoutedEventArgs e)
        {
            if (epdPCCV.IsExpanded)
                gbNut.Visibility = System.Windows.Visibility.Visible;
            else
                gbNut.Visibility = System.Windows.Visibility.Hidden;
        }

        private void CommandBinding_CanExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_CanExecute_Sua(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_CanExecute_Tim(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Them(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                //PhongKhamID = Common.ConvertToInt(cboPhongKham.SelectedValue),
                //ChuyenKhoaID = Common.ConvertToInt(cboChuyenKhoa.SelectedValue)
            };
            var message = validate(nv);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xlNV.PCCV(nv);
            getDS();
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                //PhongKhamID = Common.ConvertToInt(cboPhongKham.SelectedValue),
                //ChuyenKhoaID = Common.ConvertToInt(cboChuyenKhoa.SelectedValue)
            };
            var message = validate(nv);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xlNV.PCCV(nv);
            getDS();
        }

        private async void CommandBinding_Executed_Tim(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtTim.Text != "")
            {
                lstNV = await GetPagedListAsync();
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);
                List<CNhanVienModel> nv = xlNV.Tim(txtTim.Text, lstNV);
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

        private void cboChuyenKhoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboChuyenKhoa.SelectedValue != null)
            {
                cboPhongKham.ItemsSource = xlPKA.TimMaPKO(Common.ConvertToInt(cboChuyenKhoa.SelectedValue));
                cboPhongKham.SelectedValuePath = "ID";
                cboPhongKham.DisplayMemberPath = "TenPhongKham";
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (CNhanVienModel a in dg.SelectedItems)
            {
                epdPCCV.IsExpanded = true;
                txtMaNhanVien.Text = a.MaNhanVien;
                txtHoTen.Text = a.HoTen;
                cboChuyenKhoa.SelectedValue = a.ChuyenKhoaID;
                if (a.ChuyenKhoaID != null)
                {
                    var dsPKA = xlPKA.TimMaPKO(a.ChuyenKhoaID.Value);
                    cboPhongKham.ItemsSource = dsPKA;
                    cboPhongKham.SelectedValuePath = "ID";
                    cboPhongKham.DisplayMemberPath = "TenPhongKham";
                    cboPhongKham.SelectedValue = a.PhongKhamID;
                }

                break;
            }
        }
        private string validate(NhanVien nv)
        {
            var message = string.Empty;
            //if (nv.ChuyenKhoaID == 0)
            //{
            //    return message = "Vui lòng nhập Chuyên khoa.";
            //}
            //if (nv.PhongKhamID == 0)
            //{
            //    return message = "Vui lòng nhập Phòng khám.";
            //}
            return message;
        }

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (lstNV.HasPreviousPage)
            {
                lstNV = await GetPagedListAsync(--pageNumber);
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

                dg.ItemsSource = xlNV.getDSPCCV(lstNV).ToList();
                dg.SelectedValuePath = "MaNhanVien";
            }
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lstNV.HasNextPage)
            {
                lstNV = await GetPagedListAsync(++pageNumber);
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

                dg.ItemsSource = xlNV.getDSPCCV(lstNV).ToList();
                dg.SelectedValuePath = "MaNhanVien";
            }
        }
    }
}
