   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  6.       shop.Views.CartView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      4
viewmodelsclr-namespace:shop.ViewModels     6.   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6_     N� Title$  CartView��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.6* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.3* �6   .+�5   
   �� $��1��6    �� Orientation$ Vertical=�6%   .+�5      ��    TextHeaderStyle#���   6   $��Корзина��6B   $
��0 20q�6Q   �� 5      $ 
Horizontal=�6   $
��0 10q�62   .+�5      ��   TextBlockStyle#���  6   $(��"Товаров в корзине: ��6E   �� 5      -   5        $��CartCountTxt��5   E   #���  6   ��6Y   �� *SummaryCount+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� #���  6   на сумму:6P   �� 5      -   5         ��Name$ 
CartSumTxt��5   E   #���  6   ��6Y   �� *	Summary+ �� StringFormat$ {0} BYN��$ PropertyChanged=�6�   5      �� 5        RoundedButtonStyle#���  6   $��оформить��6g   $
��0 20q�6z   ��6B   �� *OpenOrderCommand+6z   5       �� 5$   
   -   5         ��Name$ productCartList��5$   m   $��2��6I   $��2��6Y   $��Disabled=�6�   $��Stretch=�6   �� SelectedItem 6   �� *SelectedProduct+ �� Mode$ TwoWay=���6�   �� *
UserCart+$ PropertyChanged=���5%      �� 5&      	 �� 
TargetType"	 ��6   .�5'      �� 
 �� Property
 � �� �� Value$ Stretch=�6C    �� Triggers 5(      P� 5)       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5*      �� 
 �@��
IsSelected$
 True��6;   5+      5-      ��5/      �� 50      .R�53      � $	��130��6   $	��670��6(   $��Stretch=�67    54      �� 55      $	��120 �6/   �� 56      $��4* �6/   �� 57      $��2* �6/   �� 58      $��35 �6/   �� 59      $��40 �6/   �� 5:      $��35 �6/   �� 5;      $	��130 �6/   �� 5<      $��60 �6/   .+�5>      �� $��0��6    $	��120��60   $	��120��6<   ��6I   ��  �� Path$ Product.ImageLink��� 5?      $��1��6%   $��2��66   $
��Wrap=�6J   #���  6^   $��
10 10 40 0q�6�   ��6�   �� *Product.Title+6�   �� 5@      $��3��6"     TextButtonStyle#���  6�   $��30��6�   $	��Top=�6�   $��	 5 10 0 0q�6�   ��62   ��  �� ElementName$ productCartList��$ DataContext.DecreaseCount�.��5A      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�66   $��25��6C   $��25��6N   5B      �� 5D      $��4��6%   #���  65   $��10q�6�   $��Center=�6�   ��6^   �� *Count+$ PropertyChanged=�6�   �� 5E      $��5��6"   #���  6�   $��30��6�   $	��Top=�6�   $��	 5 10 0 0q�6�   ��62   �� $ productCartList��$ DataContext.IncreaseCount�.��5F        $
 Plus=�66   $��25��6B   $��25��6M   5G      �� 5I      $��6��6%   #���  65   $��10q�6�   $��Center=�6�   ��6^   �� *
SumPrice+$ {0} BYN��$ PropertyChanged=�6�   �� 5K      $��7��6"   #���  62   $��35��6_   $	��Top=�6�   $��Center=�6�   $��
 20 10 0 0q�6�   ��6k   �� $ productCartList��$  DataContext.DeleteFromCart�.��5L        $ WindowClose=�66   $��25��6I   $��25��6T   5M      �� 5O      $��2��6%   $��20��65   $	��100��6C   5P      5Q      ��5T      �� 5U      .R�5V      �  � Orientation$ 
Horizontal=�6!   $��Center=�6:   $��15q�6W   $	��350��6d   $	��700��6s   $��2��6�   $��2��6�   5W      5Y      5Z      5[      