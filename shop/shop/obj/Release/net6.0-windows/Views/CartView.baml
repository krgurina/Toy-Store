   M S B A M L   `   `   `  ���� ?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  1clr-namespace:shop.ViewModelsshop.ViewModels      shop.Views.CartView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:shop.Views     4
viewmodelsclr-namespace:shop.ViewModels       N� Title$  CartView��.��� 
������� � ColumnDefinitions �� $
��587* ��� $
��213* �.+��� $��2��$��
0,0,0,-0.4q�
CartView�� -    ��Name$ productCartList��$��0��$	��300��$��Disabled=�$��
0,0,0,-0.4q����� *
UserCart+ �� UpdateSourceTrigger$ PropertyChanged=����� .R���  �� Orientation$ Vertical=�$��5q�.+��� $ 
Horizontal=�.+��� $	��100��$	��100������  �� Path$ Product.ImageLink��� $��12(����� *Product.Title+�� $��-���� $��12(����� *Count+�� $��+���� ���� *Price+ �� StringFormat$ {0} BYN���� $��x������ .R��  � Orientation$ 
Horizontal=�$��Center=�$��15q�