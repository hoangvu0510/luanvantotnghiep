   M S B A M L   `   `   `  ����?  ;QLPK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLPK.Model
QLPK.Model  5   	   #    QLPK.View.QuanTri.QLPhanQuyen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:QLPK.Model     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��12(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5	   	      TextRenderingMode$
 Auto=�5
   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Quản lý Phân quyền��5   	    � WindowState$ 	Maximized=�6%    � WindowStartupLocation$ CenterScreen=�6T    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$! local:CMyCommands.PhanQuyen��5      6�     5   
   -   5        $ local:CMyCommands.SuaPQ��5      6�     5   
   -   5        $% local:CMyCommands.DatLaiMatKhau��5      6�     5   
   -   5        $ local:CMyCommands.TimPQ��5      6�   .��5      �� .��5   
   �� -   5        $
��spPQ��5      .+�5@      �� -   5        $��gbTim��5@        MaterialDesignGroupBox#���  6$   $��10q�5A      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�5B      .��5C      �  � ColumnDefinitions 5D      �� 5E      �� 5F      $��2* �6+   �� 5G      	 � RowDefinitions	 5I      �� 5J      .+�5L      �� $��0��6   $��0��6,   $��Tìm nhân viên: ��69   6V   �� 5M      -   5        $��txtTim��5M   ;   $��1��6   $��0��6.   6K   �� 5N      -	   5        $��btnTim��5N   H   $��2��6   $��0��6-   $
��Tìm��6:   $��local:CMyCommands.TimPQ��6V   $	��150��6x   
���**��6�   5O      5P      �� 5Q      -
   5        $
��gbDG��5Q      #���  6#   $��10q�5R      $/��)Cập nhật trực tiếp trên DataGrid��6   $ PrimaryLight=�5S      .��5T      &   System.Windows.Controls.DataGrid  -   5        $	��dg2��5T      
   AutoGenerateColumns
 .     CanUserAddRows .     Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6h      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *STT+   ClipboardContentBinding 6E   Z� 6�     5X      $ Mã nhân viên��6o    .  6-   �� *
MaNhanVien+ 6L   Z� 6�     5Y      $ 	Họ tên��6j    .  6-   �� *HoTen+ 6G   Z� 6z   4	  .System.Windows.Controls.DataGridComboBoxColumn	  5Z      -   5        dgcmbVaiTro��$ Vai trò��5Z   �    	  SelectedValueBinding 6F   �� *
VaiTroID+ 	  ClipboardContentBinding 6p   Z� 6�   4
  .System.Windows.Controls.DataGridTemplateColumn
  5[       
  CellTemplate 5\      �� 5]   "   .R�5^   &   �� $��	dgbtnDLMK��6-   -   5        .��5^   V   Đặt lại mật khẩu6h   5_   #   5a      5c      5d      � 5e       5f      �� 5g      $��3* �6'   �� 5h      �� 5i      �� 5j      �� 5k      $��3* �6'   	 5m      �� 5n      .+�5p      �� -   5        $��btnPrevious��5p   E   $��1��6   $��0��6)   $��<��66   $��40��6Y   
�������6�   �� 5q      -   5        $��lblPageNumber��5q   5   $��2��6   $��0��6(   $	��100��6J   6X   �� 5r      -   5        $��btnNext��5r   B   $��3��6   $��0��6)   $��>��66   $��40��6Q   
�������6�   5s      5t      5u      5v      