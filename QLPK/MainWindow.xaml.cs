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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLPK.Model;
using QLPK.View;
using QLPK.Control;
using QLPK.View.QuanTri;
using QLPK.View.TiepNhan;
using QLPK.View.ThuNgan;
using QLPK.View.BacSi;
using QLPK.View.BaoCao;

namespace QLPK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DangNhap f = new DangNhap();
            f.ShowDialog();
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            if (Common.maNhanVien != null)
            {
                if (Common.vaiTroNhanVien == Common.QuanTri)
                {
                    this.Hide();
                    MainQuanTri f = new MainQuanTri();
                    f.ShowDialog();

                }
                else if (Common.vaiTroNhanVien == Common.BacSi)
                {                   
                    this.Hide();
                    MainBacSi f = new MainBacSi();
                    f.ShowDialog();
                }
                else if (Common.vaiTroNhanVien == Common.TiepNhan)
                {
                    this.Hide();
                    MainTiepNhan f = new MainTiepNhan();
                    f.ShowDialog();

                }
                else if (Common.vaiTroNhanVien == Common.ThuNgan)
                {
                    this.Hide();
                    MainThuNgan f = new MainThuNgan();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải đăng nhập để sử dụng chức năng này");
            }
        }
    }
}
