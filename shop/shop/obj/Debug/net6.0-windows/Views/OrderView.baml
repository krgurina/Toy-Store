   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      /clr-namespace:shop.Resourcesshop.Resources  6/   1clr-namespace:shop.ViewModelsshop.ViewModels  6_       shop.Views.OrderView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      3
componentsclr-namespace:shop.Resources     6/   4
viewmodelsclr-namespace:shop.ViewModels     6_     N� Title$  	OrderView��5	      .��5      � 
�������.+�5   
   �� .+�5      ��    RoundedButtonStyle#���   6     Back#���  6B   $	��100��6�   $��15q�6�   ��6c   �� *OpenCartCommand+6�   5      �� 5   
   -   5         ��Name$ 
stackPanel��5      $��Center=�6*   $	��Top=�6G   $
��0 15q�6_   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   TextBlockStyle#���  6   К оплате:6R   �� 5      -   5         ��Name$ 
CartSumTxt��5      #���  60   ��6Y   �� *	Summary+ �� StringFormat$ {0} BYN��5      �� 5        	ChoosePay#���  6   #���  6;   $
��0 10q�6e   	� 5      -   5         	�Name$
 pay1��5   l    	� 	GroupName$	 Pay��6   $��Comic Sans MS)�6*     
ChoosePay1#���  6E    d� 	IsChecked 6z   �� *IsRadioButton1Checked+�� 5      ��6   �� *ShowUserControl+	� 5      -   5        $
 pay2��5   l   $	 Pay��6   $��Comic Sans MS)�6*     
ChoosePay2#���  6E   6l   	� 5      -   5        $
 pay3��5   l   $	 Pay��6   $��Comic Sans MS)�6*     
ChoosePay3#���  6E   6l   �� 5        ChooseDelivery#���  6   #���  6A   $
��0 10q�6j   	� 5      -   5        $ 	delivery1��5   z   $ Technologies��6   $��Comic Sans MS)�63     ChooseDelivery1#���  6N    6�   �� *IsRadioButton2Checked+�� 5      ��6   �� *ShowUserControl2+	� 5      -   5        $ 	delivery2��5   z   $ Technologies��6   $��Comic Sans MS)�63    	 ChooseDelivery2#��� 	 6N   6z   �� 5      #���  6   
���  ��$
��0 10q�6p   $��12(�6~   ��6A   �� *ErrorMessage+6~   �� 5       #���   6   $��заказать��6B   $	��100��6r   $
��0 15q�6~   ��6U   �� *
AddOrder+6~   �� 5!      #���  6    
 	OrderInfo#��� 
 6A   $
��0 10q�6d   $��12(�6r   5#      5%      5&      