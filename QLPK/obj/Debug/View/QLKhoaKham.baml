   M S B A M L   `   `   `  ����?  ;QLPK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLPK.Model
QLPK.Model  5   	       QLPK.View.QLKhoaKham   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:QLPK.Model     5   	   -   5          � Title$&   Quản lý thông tin khoa khám��5   	   $	��600��6-   $	��800��6:    � WindowStartupLocation$ CenterScreen=�6]    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$$ local:CMyCommands.ThemKhoaKham��5      6�     5   
   -   5        $# local:CMyCommands.SuaKhoaKham��5      6�     5	   
   -   5        $# local:CMyCommands.XoaKhoaKham��5	      6�     5
   
   -   5        $# local:CMyCommands.TimKhoaKham��5
      6�   .��5      �� -   5        $��sp��5      .+�5   
   9� -   5        $��epdTTBN��5      $��Thêm khoa khám mới��6[   $��
0,0,-0.4,0q�6w   .��5      �� -   5        $��gbThongTinKhoaKham��5      .��5      �  � ColumnDefinitions 5      �� 5      �� 5      $��3* �6+    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6   $��0��6,   $��Mã khoa khám: ��69   6T   �� 5      -	   5        $��txtMaKhoaKham��5   ;   $��1��6   $��0��6.   6S   �� 5       $��0��6   $��1��6,   $��Tên khoa khám: ��69   6U   �� 5!      -
   5        $��txtTenKhoaKham��5!   ;   $��1��6   $��1��6.   6T   �� 5#      $��0��6   $��2��6+   $��
Mô tả: ��68   6L   �� 5$      -   5        $��txtMoTa��5$   ;   $��1��6   $��2��6.   6M   52      53      54      �� 55   
   -   5        $��gbNut��55      $y�Hidden=�6    .��56      �  57      �� 58      $��3* �6'   �� 59      $
��257* �6'   �� 5:      $
��261* �6'   �� 5;      $
��260* �6'    5=      �� 5>      .+�5@      �� -   5        $��btnThemKhoaKham��5@   E   $��0��6   $��0��6)   $��Thêm��66   $$��local:CMyCommands.ThemKhoaKham��6\   $��2��6�   $��	0,0,0,0.2q�6�   6�   �� 5A      -   5        $��btnSuaKhoaKham��5A   D   $��2��6   $��0��6)   $��Sửa��66   $#��local:CMyCommands.SuaKhoaKham��6Z   $��2��6�   $��0,0,259.8,0.2q�6�   6�   �� 5B      -   5        $��btnXoaKhoaKham��5B   D   $��3��6   $��0��6)   $
��Xóa��66   $#��local:CMyCommands.XoaKhoaKham��6Z   $��0.2,0,-0.2,0.2q�6�   6�   5C      5D      �� 5E   
   -   5        $��gbTim��5E      .��5F      �  5G      �� 5H      �� 5I      $��2* �6'   �� 5J       5L      �� 5M      .+�5O      �� $��0��6   $��0��6(   $��Tìm tên bệnh nhân: ��65   6V   �� 5P      -   5        $��txtTim��5P   7   $��1��6   $��0��6*   6G   �� 5Q      -   5        $��btnTimKhoaKham��5Q   D   $��2��6   $��0��6)   $
��Tìm��66   $#��local:CMyCommands.TimKhoaKham��6Z   6�   5R      5S      �� 5T   
   -   5        $
��gbDG��5T      .��5U      &   System.Windows.Controls.DataGrid  -   5        $��dg��5U         AutoGenerateColumns .     CanUserAddRows .     Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Mã khoa khám��6k   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6)   �� *
MaKhoaKham+   ClipboardContentBinding 6H   Z� 6k     5X      $	 Tên khoa khám��6l   
 6)   �� *TenKhoaKham+ 6I   Z� 6l     5Y      $	 Mô tả��6e   
 6)   �� *MoTa+ 6B   Z� 6e   5a      5c      5d      5f      