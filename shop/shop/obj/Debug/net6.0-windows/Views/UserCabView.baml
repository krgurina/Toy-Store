   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  6.       shop.Views.UserCabView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      4
viewmodelsclr-namespace:shop.ViewModels     6.     N� Title$  UserCabView��5	       � 	Resources 5
       �� 
TargetType   Visible �� Triggers �� Binding �� ElementName �� Path �� Value �� Property	 �� Value��%�   &	        �� 5   
   " ��6    5      �� 5       6   �� $ DisableChBox��$ 	IsChecked� True6[   .a�5      ��  � {�$
	 True��62   5      5      5      .��5      �� $	��450��6   $	��700��6#   .��5   
   � 
�������
 � ColumnDefinitions
 5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.5* �6    � RowDefinitions 5       �� 5!      $��1* �6    �� 5"      $��1* �6    �� 5#      $��1* �6    �� 5$      $��1* �6    �� 5%      $��1* �6    .+�5(         shop.Views.EditUser  $��1��6   $��3��6-   $��0��6A   $��Stretch=�6N   $	��300��6l    � DataContext 5)      '   !shop.ViewModels.EditUserViewModel  5*      5,      � 5.      
����p��$��1��6-   $��5��6:   $
��0 15q�6N   �� 5/      $��активные ��6   $��1��6)   $��1��66     TextHeaderStyle#���  6F   
�������$
��0 20q�6�   �� 50      -   5         ��Name$ activProductList��50   �   $
��Left=�6   $��2��6�   $��1��6�   $��3��6�   $��Disabled=�6   �� SelectedItem 62   �� *SelectedProduct+ �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *ActiveUserOrder+$ PropertyChanged=���51      �� 52      " ��6    53      P� 54       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �55   "   ��  �@��
IsSelected$
	 True��6?   56      58      ��5:      �� 5;      .R�5<      ��  �� Orientation$ Vertical=�6!   $��5q�68   .+�5=      �� $	��200��6    $	��200��6,   $��Center=�6^   ��69   �� *Product.ImageLink+6^   �� 5>      $ Vertical=�6%   $
��Left=�6<   .+�5?   "   ��   TextBlockStyle#���  6K   $
��Left=�6t   ��6,   �� *Product.Title+6t   �� 5@   "   #���  6^   ��6,   �� *
SumPrice+ �� StringFormat$ {0} BYN��6^   �� 5A   "   $
��Left=�6�   $��Подробнее��6�     TextButtonStyle#��[ 6�   ��6)   �� $ activProductList��$) #DataContext.OpenDetailedInfoCommand�6�   �� 5B   "   #���  6I   ��6,   �� *
OrderState+6I   5C      5D      5E      ��5H      �� 5I      .R�5J      �  � Orientation$ 
Horizontal=�6    $��Center=�69   $��15q�6V   5K      5M      � 5O      
����p��$��3��6-   $��5��6:   $
��0 15q�6N   �� 5P      #���  6   $��
ранее��6B   
�������$��3��6b   $��1��6o   $
��0 20q�6�   �� 5Q      -   5        $ OldProductList��5Q   �   $
��Left=�6   $��4��6�   $��1��6�   $��3��6�   $��Disabled=�6   62   �� *SelectedProduct+$ PropertyChanged=���6�   �� *OldUserOrder+$ PropertyChanged=���5R      �� 5S      " ��6    5T      P� 5U       �@J�IsMouseOver$
 True��6=   . �5V   "   ��  �@��
IsSelected$
	 True��6?   5W      5Y      ��5[      �� 5\      .R�5]      �� $ Vertical=�6%   $��5q�6<   .+�5^      �� $	��200��6$   $	��200��60   $��Center=�6b   ��6=   �� *Product.ImageLink+6b   �� 5_      $ Vertical=�6)   $
��Left=�6@   .+�5`   "   �� #���  6,   $
��Left=�6t   ��6U   �� *Product.Title+6t   �� 5a   "   #���  6,   ��6U   �� *
SumPrice+$ {0} BYN���� 5b   "   #��[ 6)   $
��Left=�6�   $��Подробнее��6�   ��6R   �� $ OldProductList��$) #DataContext.OpenDetailedInfoCommand�6�   5c      �� 5d        RoundedButtonStyle#��[ 6%   $��
Отзыв��6�   ��6Q   �� $ OldProductList��$&  DataContext.OpenAddReviewCommand�6�   5e      5f      ��5i      �� 5j      .R�5k      � $ 
Horizontal=�6$   $��Center=�6=   $��15q�6Z   5l      5n      5q      5r      5t      