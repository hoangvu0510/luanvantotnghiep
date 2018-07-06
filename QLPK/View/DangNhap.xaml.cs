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

namespace QLPK.View
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        CXLNhanVien xlNV;
        CXLLichKham xlLK;
        public DangNhap()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlNV = new CXLNhanVien();
            xlLK = new CXLLichKham();
            txtTenDangNhap.Focus();
            test();
        }
        private void test()
        {
            txtTenDangNhap.Text = "bacsi1";
            txtMatKhau.Password = "123";

            //txtTenDangNhap.Text = "bacsi1";
            //txtMatKhau.Password = "123";
            txtMatKhau.Focus();
        }
        private void CommandBinding_CanExecute_DangNhap(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtTenDangNhap.Text == "" || txtMatKhau.Password == "")
            {
                return;
            }
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_DangNhap(object sender, ExecutedRoutedEventArgs e)
        {
            NhanVien nv = xlNV.TimMa(txtTenDangNhap.Text);
            if (nv == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng!",
                        "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                Byte[] passwordDB = new Byte[16];
                passwordDB = nv.MatKhau.ToArray();
                Byte[] passwordInput = (Byte[])Common.HashPassword(this.txtMatKhau.Password);
                if (passwordDB.SequenceEqual(passwordInput))
                {
                    if (nv.TrangThai == true && nv.HieuLuc == false)
                    {
                        MessageBox.Show("Tài khoản không còn hiệu lực!",
                      "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else if (nv.TrangThai == false && nv.HieuLuc == true)
                    {
                        MessageBox.Show("Nhân viên đã nghỉ việc!",
                      "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else if (nv.TrangThai == false && nv.HieuLuc == false)
                    {
                        MessageBox.Show("Nhân viên đã nghỉ việc!",
                      "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        // MessageBox.Show("Đăng nhập thành công.",
                        //"Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        Common.maNhanVien = nv.MaNhanVien;
                        Common.nhanVienID = nv.IDNhanVien;
                        Common.vaiTroNhanVien = nv.VaiTroID.Value;
                        if (nv.VaiTroID == Common.BacSi)
                        {
                            LichKham lk = xlLK.TimLichKhamCuaNV(nv, DateTime.Now);
                            if (lk != null)
                            {
                                Common.maPhongBacSi = lk.PhongKham.MaPhongKham.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Hệ thống phát hiện bạn không có lịch khám hôm nay ! Vui lòng liên hệ người quản trị để cập nhật lịch làm việc !");
                                //return;   //ko cho login luôn
                            }

                        }
                        //LichKham lk = xlLK.TimLichKhamCuaNV(nv);
                        //if (lk != null)
                        //    Common.maPhongBacSi = lk.PhongKham.MaPhongKham.ToString();
                        //else
                        //    MessageBox.Show("null");

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu.",
                     "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (Common.maNhanVien == null)
            {
                System.Windows.Application.Current.Shutdown();
            }

        }

        private void CommandBinding_CanExecute_Thoat(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Thoat(object sender, ExecutedRoutedEventArgs e)
        {
            resetSession();
            this.Close();
        }
        private void resetSession()
        {
            Common.maNhanVien = null;
            Common.nhanVienID = null;
            Common.maBenhNhan = null;
            Common.objBenhNhanM = null;
            Common.vaiTroNhanVien = null;
        }

        private void btnDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //CommandBinding_Executed_DangNhap(sender,true)
            }
        }
    }
}
