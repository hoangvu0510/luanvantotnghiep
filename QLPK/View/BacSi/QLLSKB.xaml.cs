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
    public partial class QLLSKB : Window
    {
        private CXLPhieuKhamBenh xlPKB;
        private CXLDonThuoc xlDT;
        public QLLSKB()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xlPKB = new CXLPhieuKhamBenh();
            xlDT = new CXLDonThuoc();
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            if(txtMaBN.Text != "")
            {
                dgPKB.ItemsSource = xlPKB.getDSPhieuKhamBenhByDS(xlPKB.getDSPhieuKhamBenhByBenhNhan(txtMaBN.Text.ToString())).ToList();
                dgPKB.SelectedValuePath = "MaPhieuKB";
            }
        }

        private void dgPKB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgPKB.SelectedValue.ToString() != "")
            {
                PhieuKhamBenh a = xlPKB.Tim(dgPKB.SelectedValue.ToString());
                if(a!=null)
                {
                    List<CTDonThuoc> ctdt = new List<CTDonThuoc>();
                    foreach(DonThuoc b in a.DonThuoc)
                    {
                        ctdt.AddRange(b.CTDonThuoc);
                    }
                    dgDT.ItemsSource = ctdt.ToList();
                }
                
            }
        }

    }
}
