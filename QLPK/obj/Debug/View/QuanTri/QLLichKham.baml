   M S B A M L   `   `   `  ����?  ;QLPK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLPK.Model
QLPK.Model  5   	   "    QLPK.View.QuanTri.QLLichKham   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:QLPK.Model     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��12(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5	   	      TextRenderingMode$
 Auto=�5
   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Lập lịch��5   	    � WindowState$ 	Maximized=�6    � WindowStartupLocation$ CenterScreen=�6I    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:CMyCommands.LapLich��5      6�     5   
   -   5        $ local:CMyCommands.SuaLich��5      6�     5   
   -   5        $ local:CMyCommands.XoaLich��5      6�     5   
   -   5        $ local:CMyCommands.TimLich��5      6�   .��5      �� .��5   
   �� -   5        $
��spLL��5      .+�5      9� -   5        $��epdLL��5       9� 
IsExpanded . $��Lập lịch��66   .��5      �� -   5        $
��gbLL��5        MaterialDesignGroupBox#���  6'   $��10q�5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�5      .��5      � 	 � ColumnDefinitions	 5      �� 5      �� 5      $��3* �6/   
 � RowDefinitions
 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      .+�5(      �� $��0��6    $��0��60   $��Mã lịch khám: ��6=   6X   �� 5)      -	   5        $��txtMaLK��5)   ?   $��1��6"   $��0��62    �� 
IsReadOnly . 6b   �� 5+      $��0��6    $��1��60   $��Nhân viên: ��6=   6U   �� 5,      -
   5        $��cboNhanVien��5,   @   $��1��6#   $��1��63    �� IsTextSearchEnabled .  �� 
IsEditable . 6�   �� 5.      $��0��6    $��2��60   $��Phòng khám: ��6=   6V   �� 5/      -   5        $��cboPhongKham��5/   @   $��1��6#   $��2��63   6W   �� 51      $��0��6    $��3��60   $��Ca Trực: ��6=   6S   �� 52      -   5        $��	cboCaTruc��52   @   $��1��6#   $��3��63   6T   �� 54      $��0��6    $��4��60   $��Ngày: ��6=   6P   (  "System.Windows.Controls.DatePicker  55      -   5        $��dpNgay��55   B   $��1��6%   $��4��65   6S   57      58      59      �� 5:      -   5        $��gbNut��5:      #���  6$   $��10q�5;      $ PrimaryLight=�5<      .��5=      � 	 5>      �� 5?      �� 5@      �� 5A      
 5C      �� 5D      .+�5F      �� -   5        $��
btnLapLich��5F   H   $��0��6   $��0��6-   $��Lập��6:   $��local:CMyCommands.LapLich��6Z   $	��150��6   
��� � �6�   �� 5G      -   5        $��
btnSuaLich��5G   H   $��1��6   $��0��6-   $��Sửa��6:   $��local:CMyCommands.SuaLich��6Z   $	��150��6   
��� ���6�   5I      5J      �� 5K      -   5        $��gbTim��5K      #���  6$   $��10q�5L      $ PrimaryLight=�5M      .��5N      � 	 5O      �� 5P      �� 5Q      $��2* �6+   �� 5R      
 5T      �� 5U      .+�5W      �� $��0��6   $��0��6,   $��Tìm lịch: ��69   6Q   �� 5X      -   5        $��txtTim��5X   ;   $��1��6   $��0��6.   6K   �� 5Y      -   5        $��
btnTimLich��5Y   H   $��2��6   $��0��6-   $
��Tìm��6:   $��local:CMyCommands.TimLich��6Z   $	��150��6~   
���**��6�   5Z      5[      �� 5\      -   5        $
��gbDG��5\      #���  6#   $��10q�5]      $ PrimaryLight=�5^      .��5_      &   System.Windows.Controls.DataGrid  -   5        $��dg��5_         AutoGenerateColumns .     CanUserAddRows .     Columns 5`      0  *System.Windows.Controls.DataGridTextColumn  5a      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã lịch khám��6o      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *
MaLichKham+   ClipboardContentBinding 6L   Z� 6�     5b      $ Nhân viên��6p    .  6-   �� *TenNhanVien+ 6M   Z� 6�     5c      $ Phòng khám��6q    .  6-   �� *TenPhongKham+ 6N   Z� 6�     5d      $ 	Ca trực��6n    .  6-   �� *	TenCaTruc+ 6K   Z� 6     5e      $ Ngày��6�    .  6-   �� *Ngay+ �� StringFormat$ {0: dd/ MM/ yyyy}�� 6h   Z� 6�   5g      5i      5j      5k      5l      