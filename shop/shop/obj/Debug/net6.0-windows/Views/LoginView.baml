   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5   	       shop.Views.LoginView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:shop.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  60     � Title$  	LoginView��5   	   $	��500��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    � WindowStyle$
 None=�6J    � WindowStartupLocation$ CenterScreen=�6^   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��320 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5       � -   5          �Name$ 
loginFrame��5        � NavigationUIVisibility$ Hidden=�6)   5      � 5   
   $��1��6   .+�5      � ��5      �� 5       �� ImageSource$( "F:\Курсач\image\Group108.png��6!    j� Stretch$ UniformToFill=�6L   	 � RowDefinitions	 5      �� 5      $��30 �6$   �� 5      $��* �6$   .+�5      �� 
 �� Orientation$
 
Horizontal=�6   $��0��66   $��Right=�6C   $��Center=�6_   $�� 0 0 8 0q�6z   .+�5      �� -   5           TextButtonStyle#���   5      $��1��6G   $��0��6T   $��15(�6d   $��Bottom=�6r   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�62   $��20��6?   $��20��6J   
�������6V   5      �� 5      #���   6   $��1��6G   $��0��6T   $��15(�6d   $��Bottom=�6r   .��5        -   5        $ WindowClose=�5   2   
�������$��20��6X   $��20��6c   $��6 0 0 0q�6o   6�   5       5"      5#      5$      5%      5&      