   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  5          shop.Views.SearchView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      3	viewModelclr-namespace:shop.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  67     N� Title$  
SearchView��5      .��5      � 
������� � RowDefinitions 5   
    � ColumnDefinitions 5   
   �� 5      $	��240��6   $	��300��6.   �� 5      $��3* �6   .+�5   
   � .+�5      �� $��0��6    �� Orientation$ Vertical=�6*   ���#DCCBFF.+�5      �� $��Категории��6      TextBlockStyle#���   6-   $��
10 50 0 10q�6V   �� 5        ChooseCategory)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6i   $��Comic Sans MS)�6�   $	��100��6�   $��16(�6�   $��	10 0 10 0q�6�   ��6   �� *
Categories+ �� SelectedItem 6?   �� *SelectedCategory+��5      �� 5      .R�5      �� $��0q�6D   $��Bottom=�6O   $��Center=�5   (   ��5   +   �� *Name+5   (   5      5!      �� 5#      $��цена��6   #���   6)   $��
10 20 0 10q�6R   �� 5&      $ 
Horizontal=�6   .+�5(      �� $ 
Horizontal=�6!   $��	10 0 20 0q�6:   $��60��6M   .+�5)      �� $
��от��6$   $��0 0 10 0q�6.   #���   6A   $��Center=�6j   �� 5*      $��Comic Sans MS)�6"   $��Center=�6=   $��16(�6Z   $��Center=�6�   $��80��6�   $��1q�6�   ��6h   �� *
MinValue+6�   5+      �� 5-      $ 
Horizontal=�6!   $��60��6:   .+�5.      �� $
��до��6$   $��0 0 10 0q�6.   #���   6A   $��Center=�6j   �� 5/      $��Comic Sans MS)�6"   $��Center=�6W   $��80��6r   $��1q�6}   $��15(�6�   ��6=   �� *
MaxValue+6�   51      53      �� 55      $ 
Horizontal=�6   $��
10 20 0 10q�66   .+�56      �� $��Найдено:��6    #���   61   �� 57      $��Center=�6e   $��60��6�   $��16(�6�   $��10 0 0 0q�6�   ��6    �� *ProductsCount+ �� UpdateSourceTrigger$ PropertyChanged=�6�   58      �� 59      -   5         ��Name$ 	SortOrder��59   �     ChooseSorting# �  6   $��Comic Sans MS)�6\   
 � Tag$	 ssd��6w   $	��100��6�   $��0 0 0 1q�6�   $��
10 10 10 0q�6  $��16(�6%  	 �� SelectedIndex	 6�   �� *SelectedSortIndex+ 6�   �� *SelectedSort+.@�5:      �� -   5        
 ��Name$
 PriceAsc��5:   A   $*��$По возрастанию цены��6#   6A   �� 5;      -   5        $
 PriceDsc��5;   >   $$��По убыванию цены��6#   6>   �� 5<      -   5        $
 	RatingAsc��5<   9   $��По рейтингу��6#   69   5=      5A      �� 5B      -   5         ��Name$ UseFilterBtn��5B   B     RoundedButtonStyle#���  6   $��Применить��6X   $��10 10 10 40q�6�   $��Bottom=�6�   ��6l   �� *FilterCommand+6�   �� 5C      -   5        $ AllProductBtn��5C   R     TextButtonStyle#��[ 6   $��Medium"�6>   $*��$Показать все товары��6i   $
��0 10q�6�   $��Bottom=�6�   ��6�   �� *ShowAllCommand+6�   5D      �� 5G   
   -   5         ��Name$ productList��5G   q   $��1��6a   $	��491��6�   $	��700��6�   $��Disabled=�6�    6   �� *SelectedProduct+$ PropertyChanged=���6�   �� *
Products+$ PropertyChanged=���5H      �� 5I       �� 
TargetType" ��6    �� Triggers 5J      P� 5K       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5L      ��  �� Property � �� �� Value
 ��p��6;   �� 5M       �@��
IsSelected$
 True��6;   5N      5P      ��5R      �� 5S      .R�5U      �� $ Vertical=�6%   $��5q�6<   .+�5V      �� $	��200��6$   $	��200��60   $��Center=�6Z   ��6=   �� *	ImageLink+6Z   �� 5W      $ Vertical=�6)   $
��Left=�6@   .+�5X      �� #���   6@   ��6(   �� *Title+6@   �� 5Y      #���   6Y   ��6(   �� *Price+ �� StringFormat$ {0} BYN��6Y   �� 5Z      $
��Left=�6%   #��[ 6@   $��Подробнее��6�   ��6i   ��  �� ElementName$ productList�� �� Path$) #DataContext.OpenDetailedInfoCommand�6�   5[      �� 5\      $ InCard��6N   #���  6!     	AddToCart#���  6^   $	��200��6�   $��0 20 0 0q�6�   ��6�   �� $ productList��$ DataContext.AddToCart�6�   5]      5^      ��5a      �� 5b      .R�5c      �  � Orientation$ 
Horizontal=�6$   $��Center=�6=   $��15q�6Z   5d      5f      5h      5i      