   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  6.       shop.Views.AboutUsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      4
viewmodelsclr-namespace:shop.ViewModels     6.   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6_     N� Title$  AboutUsView��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.5* �6    � RowDefinitions 5   
   �� 5      $
��0.8* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.4* �6   �� 5      $
��0.4* �6   �� 5      $
��0.3* �6   �� 5      $
��0.6* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��6   $��1��6!   $$��Связаться с нами��61   $��0 20 0 0q�6I      TextHeaderStyle#���   6[   �� 5   
   $��1��6   $��1��6!   $��В соцсетях��61   #���   6C   �� 5!   
   $��2��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $	��Top=�6K   $��50��6c   .+�5"      ��   TextButtonStyle#���  6   $	��Top=�6a   ��6?   �� *OpenVKCommand+.��5#      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Facebook=�6*   ���#9370DB$��30��6O   $��28��6Z   $��10 0 0 0q�6f   5$      �� 5%      #���  6   $	��Top=�6a   ��6?   �� *OpenVKCommand+.��5&        $ 	Instagram=�6*   ���#9370DB$��30��6P   $��28��6[   $��10 0 0 0q�6g   5'      5(      �� 5+   
   $��1��6   $��2��6!   $��По телефону��61   #���   6D   �� 5,   
   $��2��6   $��2��6!   $��+375297923846��61     TextBlockStyle#���  6F   �� 5.   
   $��1��6   $��3��6!   $��
по email��61   #���   6A   �� 5/   
   $��2��6   $��3��6!   $��kristina.gurina@gmail.com��61   #���  6R   �� 51   
   $��4��6   $��5��6!   $$��Связаться с нами��65   $��Center=�6M   $��Center=�6j   #���   6�   �� 52   
   $��5��6   $��2��6   $��15(�6L   ��6/   �� *MessageText+6L   �� 53   
   $
��send��6   $��2��6    $��6��60     RoundedButtonStyle#���  6=   ��6j   �� *SendMessageCommand+�� 54   
   $��7��6   $��2��6!   #���  6L   ��61   �� *	OKMessage+6L   56      57      