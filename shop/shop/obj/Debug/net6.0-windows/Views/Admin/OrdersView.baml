   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:shop.Views.Adminshop.Views.Admin  5      =#clr-namespace:shop.ViewModels.Adminshop.ViewModels.Admin  64   !    shop.Views.Admin.OrdersView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:shop.Views.Admin     5      5admin#clr-namespace:shop.ViewModels.Admin     64   -   5          N� Title$  
OrdersView��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsGrid��5       $��0��6      AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�    �� SelectedItem 66   �� *SelectedItemForDataGrid+ �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *Orders+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 0.5* 61   
   
IsReadOnly$

 True��6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	OrderId+6Z     5      $ ORDER_STATE��6%   $	 * 6:    6D   �� *
OrderState+$ PropertyChanged=�  5      $
 USER��6%   $	 * 63   $

 True��6Y    6=   �� *	User.ID+6Y     5      $ PRODUCT��6%   $	 * 66   $

 True��6b    6@   �� *Product.Title+6b     5      $ COUNT��6%   $
	 0.5* 64   $

 True��6\    6B   �� *Count+6\     5      $ Sum(BYN)��6%   $
	 0.5* 67    6E   �� *
SumPrice+  5      $
 DATE��6%   $	 * 63    6=   �� *	OrderDate+  5      $ ADDRESS��6%   $	 * 66    6@   �� *	Address+  5      $	 PAY��6%   $	 * 62    6<   �� *Cart+5      � 5   
   $��1��6   $��Center=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5       ��    OrderState1#���   6   $�� 10 0q�6g   
���������6A   �� *SetStatus1Command+6v   �� 5!        OrderState2#���  6   $�� 10 0q�6g   
���������6A   �� *SetStatus2Command+6v   �� 5"        OrderState3#���  6   $�� 10 0q�6g   
���������6A   �� *SetStatus3Command+6v   5#      5$      5&      5'      