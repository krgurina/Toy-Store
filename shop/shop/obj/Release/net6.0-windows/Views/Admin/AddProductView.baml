   M S B A M L   `   `   `  ���� ?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:shop.Views.Adminshop.Views.Admin  =#clr-namespace:shop.ViewModels.Adminshop.ViewModels.Admin      shop.Views.AddProductView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:shop.Views.Admin     9	viewModel#clr-namespace:shop.ViewModels.Admin     -     N� Title$  CategoriesView��.��� 
������� � ColumnDefinitions �� $	��77* ��� $
��123* �.+�� $��0��.+��� $��15, 15,0 ,0q� �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $��15(�$��Название���� -    ��Name$ ProductName��$	��217�� J� RenderTransformOrigin$ 0.5,0.5&����� *Title+�� $ 
Horizontal=�.+��� $��15(�$��Категория���� -    ��Name$ ProductCategoryName��$	��100��$��1q�
�������$	��220������ *
Categories+ �� SelectedItem �� *SelectedCategory+���� .R��� $��0q�$��Bottom=�$��Center=����� *Name+�� $ 
Horizontal=�.+��� $��15(�$��цена���� -   $ Price��$	��217��$ 0.5,0.5&����� *Price+�� $ 
Horizontal=�.+��� $��15(�$��
ID categor���� $	��217��$ 0.5,0.5&����� *
CategoryId+�� $ 
Horizontal=�.+��� $��15(�$��Описание���� -   $ ProductDescription��$	��217��$ 0.5,0.5&����� *Description+�� $ 
Horizontal=�.+��� $��15(�$��
image link���� -   $ ProductImage��$	��217��$ 0.5,0.5&����� *	ImageLink+�� -   $��добавить��$
��0 10q����� *AddProductCommand+�� $��удалить��$
��0 10q����� *DeleteProducеCommand+�� $ 
Horizontal=�.+��� -   $ SearchRequest��$	��200��$��10q��� $��
поиск��� $��1��.+�&   System.Windows.Controls.DataGrid  -	     Name$ ProductsGrid��   AutoGenerateColumns$ False��	   
IsReadOnly$
	 True�� �� *SelectedItemForDataGrid+
 �� UpdateSourceTrigger$
 PropertyChanged=����� *
Products+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ID+  $ TITLE��$ *  �� *Title+  $ CATEGORY��$ *  �� *
Category+  $ PRICE��$ *  �� *Price+  $ PTING��$ *  �� *Rating+  $ DISCRIPTION��$ *  �� *Description+