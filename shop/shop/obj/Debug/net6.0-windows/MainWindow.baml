   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:shop.ViewModelsshop.ViewModels  5   
   clr-namespace:shopshop  5   	   /clr-namespace:shop.Resourcesshop.Resources  5	   R       shop.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3	viewModelclr-namespace:shop.ViewModels     5   
   $localclr-namespace:shop     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   ,	resourcesclr-namespace:shop.Resources  6R      WindowStyle#���   5   	     � Title$  
MainWindow��5   	   $	��640��6   $
��1030��6)    � WindowStyle$
 None=�67    � WindowStartupLocation$ CenterScreen=�6J   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��252* �6   �� 5      $
��263* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   � ���#855bd9$��2��6$   5      �� 5   
   $��ToysNow��6     TextHeaderStyle#���  6#   
�������$��20(�6`   $
��10 0q�6n   $��Center=�6|   � 5   
   $��0��6   $��1��6   $��Right=�6,   $
��10 0q�6H   $��Center=�6V   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5          TextButtonStyle#���  5      $��1��6C   $��0��6P   $��15(�6`   $��Bottom=�6n   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6.   $��20��6;   $��20��6F   
�������6R   5      �� 5      #���  6   $��1��6C   $��0��6P   $��15(�6`   $��Bottom=�6n   .��5         -   5        $ WindowMaximize=�5    .   
�������$��20��6W   $��20��6b   $��	 10 0 0 0q�6n   6�   5!      �� 5"      #���  6   $��1��6C   $��0��6P   $��15(�6`   $��Bottom=�6n   .��5#        -   5        $ WindowClose=�5#   .   
�������$��20��6T   $��20��6_   $��10 0 0 0q�6k   6}   5$      5&      5'      � 5)   
   $��2��6   $��1��6#    5*      �� 5+      $��1* �6#   �� 5,      $
��0.7* �6#   �� 5-      $��1* �6#   �� 5.      $��1* �6#   �� 5/      $��1* �6#   �� 50      $
��3.5* �6#   �� 51      $
��0.5* �6#   �� 52      $��1* �6#   .+�56      ��   Home#���  6=   #���  6^   $��18(�6�   $��0��6�   $��
 20 0 10 0q�6�   ��6   �� *OpenHomePageCommand+6�   �� 57      #���  6<   $��18(�6f   $��1��6t   $�� 10 0q�6�    	 About#���  6�   ��6   �� *OpenAboutUsCommand+6�   �� 58      #���  6<   $��18(�6f     Catalog#���  6t   $��2��6�   $�� 10 0q�6�   ��6   �� *OpenCatalogCommand+6�   �� 5;      -   5         ��Name$ 	SearchTxB��5;      $��5��6H   $	��320��6X   $	��800��6g   $��10q�6v   $��Right=�6�   $��Comic Sans MS)�6�   $��14(�6�   ��6)   �� *textForSearch+6�   �� 5<      -   5         ��Name$ 	SearchBtn��5<   ]     RoundedButtonStyle#���  6   $��6��6B   $��45��6R   $
��Left=�6�   ��6p   �� *SearchCommand+.��5=        $ Search=�6.   $��25��6<   $��25��6G   5>      �� 5@      $��10q�6:   $��3��6F   #���  6V   $��18(�6�     Usercab#���  6�   ��6   �� *OpenUserCommand+6�   �� 5A      #���  69   $��4��6c   $��18(�6s     Cart#���  6�   ��6   �� *OpenCartCommand+6�   �� 5B      $��10q�66   $��7��6B   #���  6R   $��18(�6|   ��6   �� *CloseCommand+.��5C        $ 	ExitToApp=�6*   $��25��6;   $��25��6F   5D      5G       � 5H   
   -   5        	  �Name$	 	mainFrame��5H      $��2��6   
  � NavigationUIVisibility$
 Hidden=�61   $	��540��6Q   $��2��6a   5I      5J      