using Microsoft.Reporting.WinForms;
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

namespace QLPK.View.BaoCao
{
    /// <summary>
    /// Interaction logic for PhieuThu.xaml
    /// </summary>
    public partial class InPhieuThu : Window
    {
        public object data;
        public InPhieuThu()
        {            
            InitializeComponent();       
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Value = data;
            rpInPhieuThu.LocalReport.DataSources.Add(rds);
            rds.Name = "CBCPhieuThuModel";
            rpInPhieuThu.LocalReport.ReportEmbeddedResource = "QLPK.View.BaoCao.RPPhieuThu.rdlc";
            rpInPhieuThu.RefreshReport();
        }
    }
}
