   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:shop.Views.Adminshop.Views.Admin  5      =#clr-namespace:shop.ViewModels.Adminshop.ViewModels.Admin  5      %    shop.Views.Admin.CategoriesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:shop.Views.Admin     5      9	viewModel#clr-namespace:shop.ViewModels.Admin     5        N� Title$  CategoriesView��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��70 �6   .+�5   
   � $��0��6   .+�5      �� $��15q�6    �� Orientation$ Vertical=�6%   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��15(�6    $��Название��6.   �� 5      -   5         ��Name$ CategoryNameTxB��5   4   $	��217��6M   ��6   �� *Name+6M   5      �� 5       	  Photo#���   6   $
��0 15q�6_   
���������6;   �� *AddPhotoCommand+6m   �� 5        Add#���  6   
���������69   �� *AddCategoryCommand+6`   �� 5       
 Delete#���  6   $
��0 15q�6g   
���������6<   �� *DeleteCategoryCommand+6u   �� 5      
���  ����6   �� *ErrorMessage+6:   �� 5      ��6   �� *	OKMessage+�� 5       $ 
Horizontal=�6   .+�5!      �� -   5        $ SearchRequest��5!      $	��180��6T   $��0 0 15 0q�6`   $��Center=�6r   ��65   �� *TextForSearch+6r   �� 5"       
 Search#���  6   
���������6A   �� *SearchCommand+6c   5#      5$      5&      � 5)   
   $��1��6   $��2��6   .+�5*      &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsGrid��5*         AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�    �� SelectedItem 6-   �� *SelectedItemForDataGrid+	 �� UpdateSourceTrigger$	 PropertyChanged=���6�   �� *
Categories+$	 PropertyChanged=�
   Columns
 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *
CategoryId+  5-        Category# �  6)   $ 2* 6M    6X   �� *Name+  5.      # �   6)   $ 2* 6J    6U   �� *	ImageLink+50      51      53      54      