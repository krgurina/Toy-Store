   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  6.   /clr-namespace:shop.Resourcesshop.Resources  6_       shop.Views.RegView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:shop.Views  5      .
viewmodelsclr-namespace:shop.ViewModels  6.   -
componentsclr-namespace:shop.Resources  6_     N� Title$  RegView��5
      .��5      � 
�������.+�5   
   �� .+�5      ��    RoundedButtonStyle#���   6     Back#���  6B   $	��100��6�   $��30 15q�6�   ��6c   �� *OpenAuthCommand+6�   5      �� 5   
    �� Orientation$ Vertical=�6   $��Center=�6,   $	��320��6I   .+�5      � $��
30 60 30 0q�6    � RowDefinitions 5      �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   .+�5!      �� -   5         ��Name$ login��5!   )   $��0��6     	UserLogin)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O      
IsFloating$
 True��5"   
   $��14(�66   $��Comic Sans MS)�6D   ��5!   8   �� *Login+5"   D   �� 5$      -   5        $ userName��5$   (   $��1��6     UserName# �  6Q   $
 True��5%   
   $��14(�66   $��Comic Sans MS)�6D   ��5$   :   �� *Name+5%   D   �� 5'      -   5        $ userSurname��5'   (   $��2��6     UserSurname# �  6V   $
 True��5(   
   $��14(�66   $��Comic Sans MS)�6D   ��5'   =   �� *	Surname+5(   D   �� 5*      -   5        $ 	userEmail��5*   '   $��3��6     	UserEmail# �  6Q   $
 True��5+   
   $��14(�66   $��Comic Sans MS)�6D   ��5*   :   �� *Email+5+   D   �� 5-      -   5        $ 	userPhone��5-   (   $��4��6     UserPhoneFormat# �  6R   $
 True��5.   
   $��14(�66   $��Comic Sans MS)�6D   ��5-   ;   �� *Phone+5.   D   (   "shop.Resources.BindablePasswordBox  50      $��5��61     UserPassword# �  51   3   $
 True��52   
   $��14(�66   $��Comic Sans MS)�6D      Password 51      �� *
Password+52   D     54      $��6��62     UserPassword2# �  55   4   $
 True��56   
   $��14(�66   $��Comic Sans MS)�6D    55      �� *	Password2+56   D   �� 58      $��8��6   $
��Wrap=�6G    	 TextBlockStyle#��� 	 6[   $��14(�6�   
���  ����6)   �� *ErrorMessage+6�   �� 59      -   5        #���   59       
 GetRegistration2#��� 
 6F   $��0 10 0 0q�6�   $��9��6�   $��2��6�   ��6s   �� *RegUserCommand+6�   5;      5>      5?      5@      