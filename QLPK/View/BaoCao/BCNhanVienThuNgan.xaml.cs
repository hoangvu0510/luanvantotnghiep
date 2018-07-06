﻿using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for BCNhanVien.xaml
    /// </summary>
    public partial class BCNhanVienThuNgan : Window
    {
        private CXLBaoCao xlBC;
        private CXLLichKham xlLK;

        public BCNhanVienThuNgan()
        {
            InitializeComponent();
            xlBC = new CXLBaoCao();
            xlLK = new CXLLichKham();
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var data = xlBC.getTKNhanVienThuNganReport(DateTime.Parse(dpNgay.Text.ToString()), cboCaTruc.SelectedValue == null ? 0 : int.Parse(cboCaTruc.SelectedValue.ToString()));
            if (data.Count != 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Value = data;
                rpBCNhanVienThuNgan.LocalReport.DataSources.Add(rds);
                rds.Name = "CBCNhanVienThuNgan";
                rpBCNhanVienThuNgan.LocalReport.ReportEmbeddedResource = "QLPK.View.BaoCao.RPNhanVienThuNgan.rdlc";

                rpBCNhanVienThuNgan.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu");
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpNgay.Text = DateTime.Now.ToShortDateString();

            cboCaTruc.ItemsSource = xlLK.getDSCaTrucFirstNull();
            cboCaTruc.DisplayMemberPath = "TenCaTruc";
            cboCaTruc.SelectedValuePath = "IDCaTruc";
            cboCaTruc.SelectedIndex = 0;
        }
    }
}
