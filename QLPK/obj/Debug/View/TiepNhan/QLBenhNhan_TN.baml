   M S B A M L   `   `   `  ����?  ;QLPK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLPK.Model
QLPK.Model  5   	       QLPK.View.QLBenhNhan_TN   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:QLPK.Model     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��12(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5	   	      TextRenderingMode$
 Auto=�5
   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$( "Quản lý thông tin bệnh nhân��5   
    � WindowState$ 	Maximized=�6/    � WindowStartupLocation$ CenterScreen=�6^    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$$ local:CMyCommands.ThemBenhNhan��5      6�     5   
   -   5        $# local:CMyCommands.SuaBenhNhan��5      6�     5   
   -   5        $# local:CMyCommands.XoaBenhNhan��5      6�     5   
   -   5        $# local:CMyCommands.TimBenhNhan��5      6�   .��5      �� .��5   
   �� -   5        $��sp��5      .+�5      9� -   5        $��epdTTBN��5      $��Thêm bệnh nhân mới��6_   $��
0,0,-0.4,0q�6{   .��5      �� -   5        $��gbThongTinBenhNhan��5        MaterialDesignGroupBox#���  65   $��10q�5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�5      .��5      �  � ColumnDefinitions 5      �� 5      �� 5      $��3* �6/   	 � RowDefinitions	 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      .+�5(      �� $��0��6    $��0��60   $��Mã bệnh nhân: ��6=   6X   �� 5)      -	   5        $��txtMaBenhNhan��5)   ?   $��1��6"   $��0��62   
 �� 
IsReadOnly
 . 6h   �� 5+      $��0��6    $��1��60   $��Họ tên: ��6=   6R   �� 5,      -
   5        $��txtHoTen��5,   ?   $��1��6"   $��1��62   6R   �� 5.      $��0��6    $��2��60   $��Ngày sinh: ��6=   6U   (  "System.Windows.Controls.DatePicker  5/      -   5        $��
dpNgaySinh��5/   B   $��1��6%   $��2��65   6W   �� 51      $��0��6    $��3��60   $��Giới tính: ��6=   6U   �� 52      -   5        $��
gbGioiTinh��52   C   $��1��6%   $��3��65    �� Orientation$ 
Horizontal=�6U   .+�53      	� -   5        $��rdoNam��53   *   $	��Nam��68   	� 54      -   5        $��rdoNu��54   *   $
��Nữ��67    d� 	IsChecked$
 TrueY�6D   55      �� 56      $��0��6    $��4��60   $��CMND: ��6=   6P   �� 57      -   5        $��txtCMND��57   ?   $��1��6"   $��4��62   6Q   �� 59      $��0��6    $��5��60   $��Địa chỉ: ��6=   6S   �� 5:      -   5        $��	txtDiaChi��5:   ?   $��1��6"   $��5��62   6S   �� 5<      $��0��6    $��6��60   $��Điện thoại: ��6=   6V   �� 5=      -   5        $��txtDienThoai��5=   ?   $��1��6"   $��6��62   6V   5?      5@      5A      �� 5B      -   5        $��gbNut��5B      $y�Hidden=�6$   .��5C      �  5D      �� 5E      �� 5F      �� 5G      	 5I      �� 5J      .+�5L      �� -   5        $��btnThemBenhNhan��5L   I   $��0��6   $��0��6-   $��Thêm��6:   $$��local:CMyCommands.ThemBenhNhan��6`   $	��150��6�   
��� � �6�   �� 5M      -   5        $��btnSuaBenhNhan��5M   H   $��1��6   $��0��6-   $��Sửa��6:   $#��local:CMyCommands.SuaBenhNhan��6^   $	��150��6�   
��� ���6�   �� 5N      -   5        $��btnXoaBenhNhan��5N   H   $��2��6   $��0��6-   $
��Xóa��6:   $#��local:CMyCommands.XoaBenhNhan��6^   $	��150��6�   
���  ��6�   5O      5P      �� 5Q      -   5        $��gbTim��5Q      #���  6$   $��10q�5R      $ PrimaryLight=�5S      .��5T      �  5U      �� 5V      �� 5W      $��2* �6+   �� 5X      	 5Z      �� 5[      �� 5\      .+�5^      �� $��0��6   $��0��6,   $��Tìm tên bệnh nhân: ��69   6Z   �� 5_      -   5        $��txtTim��5_   ;   $��1��6   $��0��6.   6K   �� 5`      -   5        $��btnTimBenhNhan��5`   H   $��2��6   $��0��6-   $
��Tìm��6:   $#��local:CMyCommands.TimBenhNhan��6^   $	��150��6�   
���**��6�   �� 5a      -   5        $��
btnLayTTBN��5a   \   $��1��6   $��1��6-   $#��Lấy thông tin bệnh nhân��6:   $	��200��6�   
����  �$��0 10 0 0q�6�   6�   �� 5b      -   5        $��
btnXemTTBN��5b   \   $��1��6   $��1��6-   $!��Xem thông tin bệnh nhân��6:   $	��200��6�   
����  �$��316,10,13,0q�6�   $��2��6�   6�   5c      5d      �� 5e      -   5        $
��gbDG��5e      #���  6#   $��10q�5f      $ PrimaryLight=�5g      .��5h      &   System.Windows.Controls.DataGrid  -   5        $��dg��5h         AutoGenerateColumns .     CanUserAddRows .     Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã bệnh nhân��6o      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *
MaBenhNhan+   ClipboardContentBinding 6L   Z� 6�     5k      $ 	Họ tên��6j    .  6-   �� *HoTen+ 6G   Z� 6z     5l      $ 
Ngày sinh��6�    .  6-   �� *
NgaySinh+ �� StringFormat$ {0: dd/ MM/ yyyy}�� 6l   Z� 6�     5m      $ Tuổi��6i    6-   �� *Tuoi+ 6F   Z� 6i     5n      $ Giới tính��6�    .  6-   �� *
GioiTinh+$ {0: Nam; Nữ}�� 6g   Z� 6�     5o      $
 CMND��6i    .  6-   �� *CMND+ 6F   Z� 6w     5p      $ Địa chỉ��6k    .  6-   �� *DiaChi+ 6H   Z� 6|     5q      $ Điện thoại��6n    .  6-   �� *	DienThoai+ 6K   Z� 6�   5t      5v      � 5w       5x      �� 5y      $��2* �6'   �� 5z      �� 5{      �� 5|      �� 5}      $��2* �6'   	 5      �� 5�      .+�5�      �� -   5        $��btnPrevious��5�   E   $��1��6   $��0��6)   $��<��66   $��50��6Y   
�������6�   �� 5�      -   5        $��lblPageNumber��5�   5   $��2��6   $��0��6(   $	��100��6J   6X   �� 5�      -   5        $��btnNext��5�   B   $��3��6   $��0��6)   $��>��66   $��50��6Q   
�������6�   5�      5�      5�      5�      