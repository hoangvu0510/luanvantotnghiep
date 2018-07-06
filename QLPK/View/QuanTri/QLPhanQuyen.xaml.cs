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

namespace QLPK.View.QuanTri
{
    /// <summary>
    /// Interaction logic for QLPhanQuyen.xaml
    /// </summary>
    public partial class QLPhanQuyen : Window
    {
        private CXLNhanVien xlNV;
        private CXLVaiTro xlVT;
        IPagedList<NhanVien> lstNV;
        int pageNumber = 1;
        public QLPhanQuyen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlNV = new CXLNhanVien();
            xlVT = new CXLVaiTro();
            clearControl();
            loadCombo();
            getDS();

        }

        //private void epdPQ_Expanded(object sender, RoutedEventArgs e)
        //{
        //    if (epdPQ.IsExpanded)
        //        gbNut.Visibility = System.Windows.Visibility.Visible;
        //    else
        //        gbNut.Visibility = System.Windows.Visibility.Hidden;
        //}
        private async void getDS()
        {
            clearControl();
            dgcmbVaiTro.ItemsSource = xlVT.getDSVaiTro();
            dgcmbVaiTro.DisplayMemberPath = "TenVaiTro";
            dgcmbVaiTro.SelectedValuePath = "IDVaiTro";

            lstNV = await GetPagedListAsync();
            btnPrevious.IsEnabled = lstNV.HasPreviousPage;
            btnNext.IsEnabled = lstNV.HasNextPage;
            lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

            dg2.ItemsSource = xlNV.getDSPCCV(lstNV).ToList();
            dg2.SelectedValuePath = "MaNhanVien";
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
            //txtMaNhanVien.Text = "";
            //txtHoTen.Text = "";
            //cboVaiTro.SelectedValue = 0;
            txtTim.Focus();
        }
        private void loadCombo()
        {
            //cboVaiTro.ItemsSource = xlVT.getDSVaiTro();
            //cboVaiTro.SelectedValuePath = "ID";
            //cboVaiTro.DisplayMemberPath = "TenVaiTro";
        }

        private void CommandBinding_CanExecute_PhanQuyen(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_PhanQuyen(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                //MaNhanVien = txtMaNhanVien.Text,
                //VaiTroID = Common.ConvertToInt(cboVaiTro.SelectedValue),
            };
            var message = validate(nv);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xlNV.PhanQuyen(nv);
            getDS();

        }

        private void CommandBinding_CanExecute_Sua(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_CanExecute_Tim(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
                    dg2.ItemsSource = nv;
                }
                else
                    MessageBox.Show("Không tìm thấy nhân viên trên!");
            }
            else
                getDS();
        }

        private void CommandBinding_Executed_Sua(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                //MaNhanVien = txtMaNhanVien.Text,
                //VaiTroID = Common.ConvertToInt(cboVaiTro.SelectedValue)
            };
            var message = validate(nv);
            if (message != string.Empty)
            {
                MessageBox.Show(message,
                              "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            xlNV.PhanQuyen(nv);
            getDS();
        }
        //private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    foreach (CNhanVienModel a in dg.SelectedItems)
        //    {
        //        epdPQ.IsExpanded = true;
        //        txtMaNhanVien.Text = a.MaNhanVien;
        //        txtHoTen.Text = a.HoTen;
        //        cboVaiTro.SelectedValue = a.VaiTroID;
        //        break;
        //    }
        //}
        private void dg2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cboVaiTro.SelectedItem = dgcmbVaiTro.SelectedItemBinding;
            //foreach (CNhanVienModel a in dg2.SelectedItems)
            //{
            //    //epdPQ.IsExpanded = true;
            //    NhanVien n = xlNV.TimMa(a.MaNhanVien);
            //    //MessageBox.Show(a.MaNhanVien.ToString());
            //    if (n != null)
            //    {
            //        //MessageBox.Show("sdasd");
            //        n.VaiTroID = a.VaiTroID;
            //    }
            //    //txtMaNhanVien.Text = a.MaNhanVien;
            //    //txtHoTen.Text = a.HoTen;
            //    //cboVaiTro.SelectedValue = a.VaiTroID;
            //    xlNV.PhanQuyen(n);
            //    getDS();
            //    break;
            //}
        }
        private void CommandBinding_CanExecute_DLMK(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_DLMK(object sender, ExecutedRoutedEventArgs e)
        {
            //if (Common.maNhanVien != null)
            //{
            //    if (Common.vaiTroNhanVien == Common.QuanTri)
            //    {
            //        NhanVien nv = xlNV.TimMa(txtMaNhanVien.Text);
            //        if (nv == null)
            //        {
            //            MessageBox.Show("Mã nhân viên không tồn tại!",
            //                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            //            return;
            //        }
            //        else
            //        {
            //            xlNV.DatLaiMatKhau("PK@" + nv.CMND, nv.MaNhanVien);
            //            MessageBox.Show("Đặt lại mật khẩu thành công!",
            //                   "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        }
            //    }

            //    else
            //    {
            //        MessageBox.Show("Bạn không có quyền");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Bạn phải đăng nhập để sử dụng chức năng này");
            //    DangNhap f = new DangNhap();
            //    f.ShowDialog();
            //}
        }
        private string validate(NhanVien nv)
        {
            var message = string.Empty;
            if (string.IsNullOrEmpty(nv.MaNhanVien))
            {
                return message = "Vui lòng nhập Nhân viên.";
            }
            if (nv.VaiTroID == 0)
            {
                return message = "Vui lòng nhập Vai trò.";
            }
            return message;
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {

            //Linq.Table<Visitor>.Context.SubmitChanges() method. 

            //    To refresh my view, I use Linq.Table<Visitor>.Context.Refresh() 
            //and then I do a ResetBindings(false)
        }

        private void dg2_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            switch (e.Column.DisplayIndex)
            {
                case 3:
                    ComboBox c = (ComboBox)e.EditingElement; //ánh xạ đến vị trí combox
                    //CNhanVienModel cnv = (CNhanVienModel)e.Row.Item; // lấy object dòng đã tác động, để lấy mã convert sang NhanVien
                    NhanVien nvold = (NhanVien)xlNV.TimMa(((CNhanVienModel)e.Row.Item).MaNhanVien.ToString()); //lấy dữ liệu cũ để rollback
                    NhanVien nv = new NhanVien // tạo dữ liệu mới để lưu CSDL
                    {
                        MaNhanVien = nvold.MaNhanVien.ToString(),
                        VaiTroID = Common.ConvertToInt(c.SelectedValue.ToString())
                    };
                    if (nvold.VaiTroID != nv.VaiTroID) // chỉ chạy khi dữ liệu cũ mới khác nhau
                    {
                        if (MessageBox.Show("Xác nhận thay đổi vai trò nhân viên '" + nv.MaNhanVien.ToString() + "' ?", "Cảnh báo!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            e.Cancel = true;
                            c.SelectedValue = nvold.VaiTroID;
                            return;
                        }
                        else
                        {
                            xlNV.PhanQuyen(nv);
                            getDS();
                        }
                    }
                    break;

            }
        }
        private void dgbtnDLMK_Click(object sender, RoutedEventArgs e)
        {
            if (Common.maNhanVien != null)
            {
                if (Common.vaiTroNhanVien == Common.QuanTri)
                {
                    NhanVien nv = xlNV.TimMa(dg2.SelectedValue.ToString());
                    if (nv == null)
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Xác nhận?", "Cảnh báo!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            return;
                        }
                        else
                        {
                            xlNV.DatLaiMatKhau("PK@" + nv.CMND, nv.MaNhanVien);
                            MessageBox.Show("Đặt lại mật khẩu '" + dg2.SelectedValue.ToString() + "' thành công!",
                                   "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
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

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

            if (lstNV.HasPreviousPage)
            {
                lstNV = await GetPagedListAsync(--pageNumber);
                btnPrevious.IsEnabled = lstNV.HasPreviousPage;
                btnNext.IsEnabled = lstNV.HasNextPage;
                lblPageNumber.Content = string.Format("Trang {0}/{1}", pageNumber, lstNV.PageCount);

                dg2.ItemsSource = xlNV.getDSPCCV(lstNV).ToList();
                dg2.SelectedValuePath = "MaNhanVien";
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

                dg2.ItemsSource = xlNV.getDSPCCV(lstNV).ToList();
                dg2.SelectedValuePath = "MaNhanVien";
            }
        }
        private void dg2_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }
    }
}
