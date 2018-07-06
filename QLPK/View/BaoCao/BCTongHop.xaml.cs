using Microsoft.Reporting.WinForms;
using QLPK.Control;
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

namespace QLPK.View.BaoCao
{
    /// <summary>
    /// Interaction logic for BCNhanVienBacSi.xaml
    /// </summary>
    public partial class BCTongHop : Window
    {
        private CXLBaoCao xlBC;
        private CXLLichKham xlLK;
        public BCTongHop()
        {
            InitializeComponent();
            xlBC = new CXLBaoCao();
            xlLK = new CXLLichKham();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dpTuNgay.Text = DateTime.Now.ToShortDateString();
            dpDenNgay.Text = DateTime.Now.ToShortDateString();

            cboCaTruc.ItemsSource = xlLK.getDSCaTrucFirstNull();
            cboCaTruc.DisplayMemberPath = "TenCaTruc";
            cboCaTruc.SelectedValuePath = "IDCaTruc";
            cboCaTruc.SelectedIndex = 0;

            cboNhanVien.ItemsSource = xlLK.getDSNhanVienFirstNull();
            cboNhanVien.SelectedValuePath = "IDNhanVien";
            cboNhanVien.DisplayMemberPath = "HoTen";
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            if (rdbPhieuDKK.IsChecked == true)
            {
                var data = xlBC.getTKPhieuDKKReport(DateTime.Parse(dpTuNgay.Text.ToString()), DateTime.Parse(dpDenNgay.Text.ToString()),cboNhanVien.SelectedValue == null ? 0 : int.Parse(cboNhanVien.SelectedValue.ToString()));
                if (data.Count != 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Value = data;
                    rpBCTongHop.LocalReport.DataSources.Add(rds);
                    rds.Name = "CBCTongHopPhieuDKK";
                    rpBCTongHop.LocalReport.ReportEmbeddedResource = "QLPK.View.BaoCao.RPTongHopPhieuDDK.rdlc";

                    rpBCTongHop.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (rdbPhieuPKB.IsChecked == true)
            {
                var data = xlBC.getTKPhieuKhamBenhReport(DateTime.Parse(dpTuNgay.Text.ToString()), DateTime.Parse(dpDenNgay.Text.ToString()), cboNhanVien.SelectedValue == null ? 0 : int.Parse(cboNhanVien.SelectedValue.ToString()));
                if (data.Count != 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Value = data;
                    rpBCTongHop.LocalReport.DataSources.Add(rds);
                    rds.Name = "CBCTongHopPhieuKham";
                    rpBCTongHop.LocalReport.ReportEmbeddedResource = "QLPK.View.BaoCao.RPTongHopPhieuKham.rdlc";

                    rpBCTongHop.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            if (rdbPhieuThu.IsChecked == true)
            {
                var data = xlBC.getTKPhieuThuReport(DateTime.Parse(dpTuNgay.Text.ToString()), DateTime.Parse(dpDenNgay.Text.ToString()), cboNhanVien.SelectedValue == null ? 0 : int.Parse(cboNhanVien.SelectedValue.ToString()));
                if (data.Count != 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Value = data;
                    rpBCTongHop.LocalReport.DataSources.Add(rds);
                    rds.Name = "CBCTongHopPhieuThu";
                    rpBCTongHop.LocalReport.ReportEmbeddedResource = "QLPK.View.BaoCao.RPTongHopPhieuThu.rdlc";

                    rpBCTongHop.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
           
        }
    }
}
