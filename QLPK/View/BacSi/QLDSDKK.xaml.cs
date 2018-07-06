using QLPK.Control;
using QLPK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace QLPK.View.BacSi
{
    /// <summary>
    /// Interaction logic for QLDSDKK.xaml
    /// </summary>
    public partial class QLDSDKK : Window
    {
        private CXLPhieuKhamBenh xlPKB;
        private CXLPhieuDKKham xlPDDK;
        private CXLLichKham xlLK;
        public QLDSDKK()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlPKB = new CXLPhieuKhamBenh();
            xlPDDK = new CXLPhieuDKKham();
            xlLK = new CXLLichKham();
            getDS();
            //if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 11)
            //    MessageBox.Show("Hệ thống phát hiện phiên làm việc: 'Ca sáng !'");
            //else if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour <= 17)
            //    MessageBox.Show("Hệ thống phát hiện phiên làm việc: 'Ca chiều !'");
            //else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 22)
            //    MessageBox.Show("Hệ thống phát hiện phiên làm việc: 'Ca tối !'");

            if (Common.maPhongBacSi != null)
            {
                MessageBox.Show("Hôm nay bạn trực phòng: " + Common.maPhongBacSi.ToString() + " nhé!");
            }
        }
        private void getDS()
        {
            if (Common.maPhongBacSi != null)
            {
                dgPDKK.ItemsSource = xlPDDK.getDSPhieuDKKhamByDS(xlPDDK.getDSPDKKChuaKham(Common.maPhongBacSi)).ToList();
                dgPDKK.SelectedValuePath = "MaPhieuDKKham";

                dgPKB.ItemsSource = xlPKB.getDSPhieuKhamBenhByDS(xlPKB.getDSPhieuKhamBenhByUser(Common.maNhanVien, DateTime.Now)).ToList();
                dgPKB.SelectedValuePath = "MaPhieuKB";
            }

           

          
        }
        private void clearControl()
        {
            Common.maBenhNhan = null;
            getDS();
        }
        private void dgbtnKB_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(dgPDKK.SelectedValue.ToString());
            if(dgPDKK.SelectedItem !=null)
            {
                bool b = false;
                foreach (CTDKDichVu a in xlPDDK.getDSLichSuDV(dgPDKK.SelectedValue.ToString()))
                {
                    if (a.TrangThai == false || a.TrangThai == null)
                    {
                        b = false;
                        break;
                    }
                    else
                        b = true;

                }
                if (b == true)
                {
                    Common.maPhieuDDK = dgPDKK.SelectedValue.ToString();
                    xlPDDK.DangKham(dgPDKK.SelectedValue.ToString());
                    QLPhieuKhamBenh f = new QLPhieuKhamBenh();
                    f.ShowDialog();
                    Common.maPhieuDDK = null;
                    getDS();
                }
                else
                    MessageBox.Show("Phiếu DKK có dịch vụ chưa nộp phí !");
            }
        }

    }
}
