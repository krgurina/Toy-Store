   M S B A M L   `   `   `  ���� ?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  1clr-namespace:shop.ViewModelsshop.ViewModels      shop.Views.SearchView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:shop.Views     3	viewModelclr-namespace:shop.ViewModels       N� Title$  
SearchView��.��� 
������� � RowDefinitions �� $��50 ��� $��* � � ColumnDefinitions �� $	��100���� $��3* �.+��� $��0��$��0��фильтры�� $��0��$��1�� �� Orientation$ Vertical=����#7E2898.+��� $��Категории���� $	��100��$��1q�
����������� *
Categories+ �� SelectedItem �� *SelectedCategory+���� .R��� $��0q�$��Bottom=�$��Center=����� *Name+�� $��цена���� �� $ 
Horizontal=�.+��� $ 
Horizontal=�$��0 0 20 0q�$��60��.+��� $
��от��$��0 0 10 0q��� $��Center=�$��60��
���   �$��1q����� *
MinValue+�� $ 
Horizontal=�$��60��.+��� $
��до��$��0 0 10 0q��� $��Center=�$��60��
���   �$��1q����� *
MaxValue+�� $ 
Horizontal=�$��	0 20 0 10q�.+��� $��Найдено:���� $��Center=�$��60������ *ProductsCount+ �� UpdateSourceTrigger$ PropertyChanged=��� $��Center=�$��60������ *ProductsCount+$ PropertyChanged=��� -    ��Name$ 	SortOrder��$	��100��$��1q�
�������$��0 10 0 0q� �� SelectedIndex �� *SelectedSortIndex+ �� *SelectedSort+.@��� -    ��Name$ PriceAsc��$*��$По возрастанию цены���� -   $ PriceDsc��$$��По убыванию цены���� -   $ 	RatingAsc��$��По рейтингу���� -   	 ��Name$	 UseFilterBtn��$��Применить��$��0 50 0 0q����� *FilterCommand+�� -   $	 AllProductBtn��$*��$Показать все товары��$
��0 10q����� *ShowAllCommand+�� $��0��$��1��$ 
Horizontal=�$��Center=�.+��� -   
 ��Name$
 	SearchTxB��$	��400��$��10q����� *textForSearch+�� -   $	 	SearchBtn��$��Search������ *SearchCommand+�� -	    ��Name$ productList��$��1��$��1��$	��491��$	��700��$��Disabled=� �� *SelectedProduct+���� *
Products+$ PropertyChanged=����� .R��� $ Vertical=�$��5q�.+��� $	��200��$	��200��$��Center=����� *	ImageLink+�� $ Vertical=�$
��Left=�.+��� $��12(�$��Center=����� *Title+�� ���� *Price+ �� StringFormat$ {0} BYN���� $	 InCard��$��В корзину��$	��200��$��0 20 0 0q�����  �� ElementName$ productList�� �� Path$ DataContext.AddToCart����� .R��  � Orientation$ 
Horizontal=�$��Center=�$��15q�