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
    /// Interaction logic for BCNhanVienTiepNhan.xaml
    /// </summary>
    public partial class BCNhanVienTiepNhan : Window
    {
        private CXLBaoCao xlBC;
        private CXLLichKham xlLK;
        public BCNhanVienTiepNhan()
        {
            InitializeComponent();
            xlBC = new CXLBaoCao();
            xlLK = new CXLLichKham();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpNgay.Text = DateTime.Now.ToShortDateString();

            cboCaTruc.ItemsSource = xlLK.getDSCaTrucFirstNull();
            cboCaTruc.DisplayMemberPath = "TenCaTruc";
            cboCaTruc.SelectedValuePath = "IDCaTruc";
            cboCaTruc.SelectedIndex = 0;
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {

            var data = xlBC.getTKNhanVienTiepNhanReport(DateTime.Parse(dpNgay.Text.ToString()), cboCaTruc.SelectedValue == null ? 0 : int.Parse(cboCaTruc.SelectedValue.ToString()));
            if (data.Count != 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Value = data;
                rpBCNhanVienTiepNhan.LocalReport.DataSources.Add(rds);
                rds.Name = "CBCPhieuDKK";
                rpBCNhanVienTiepNhan.LocalReport.ReportEmbeddedResource = "QLPK.View.BaoCao.RPNhanVienTiepNhan.rdlc";

                rpBCNhanVienTiepNhan.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu");
            }
        }
    }
}
