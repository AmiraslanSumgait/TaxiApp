   M S B A M L   `   `   `  ����B  >TaxiApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TaxiApp.ViewsTaxiApp.Views  5   	       TaxiApp.Views.RideHistory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TaxiApp.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  RideHistory��5	   	   $	��500��6   $	��800��5
   	    � Icon$A ;pack://application:,,,/TaxiApp;component/Images/history.ico��5   	    � 	Resources 5         _ListBoxItemStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName � Color � Offset��%?  &	        �� 5   
   " ��6*   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $��_Border��6!   $ 5q�5   !   $��3q�5   !    . $	 5��5   !   ._�5      �� 5      
 5      P� 5       �@��
IsSelected . . �5   "   �� $ _Border��6)    � �� 5   &   �� 5   *   .��5   .   � $ #3AAED8��6;   $ 0Q�6K   6X   � 5   .   $ #BBDEF0��6;   $ 1Q�6K   6X   5    +   5"   #   �� 5#   "    � ��
 �����6?   �� 5$   "    � ��$
 Bold"�6?   5%      5'      5)      5*      5+      .��5-      � .+�5/   
   �� -   5         ��Name$ listbox��51      
���   �#��[  50      ��5/      �� *RideHistories+��52      �� 53      .R�54      � .+�55      �� 
�������$	�� 50��57      $��50��58      $	 50��59      $
��Left=�5:      $	��Top=�5;      ._�5<      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Car=�5=      $��40��5>      $��40��5?      $��5,3,0,0q�5@      5A        5C      $ MapMarkerMultiple=�5D      $��18��5E      $��18��5F      $
��Left=�5G      $	��Top=�5H      $��80,0,0,0q�5I      �� 5K       ��Name$ txtB_YourLocation��5L      $��12(�5M      $	��140��5O      $��	80,25,0,0q�5P      $
��Wrap=�5Q      
���   �$��DemiBold"�5S      $
��Left=�5T      $	��Top=�5U      ��5N      �� *YourLocation+5W      �� 5X      $	��➔��5Y      $
��Left=�5Z      $	��Top=�5[      $��20(�5\      $��
210,15,0,0q�5]      5_      �� 5a      $ txtB_Destination��5b      $��12(�5c      $	��140��5e      $��
260,25,0,0q�5f      $
��Wrap=�5g      
���   �$��DemiBold"�5i      $
��Left=�5j      $	��Top=�5k      ��5d      �� *Destination+5m        5o      $ ClipboardTextClockOutline=�5p      $��18��5q      $��18��5r      $
��Left=�5s      $	��Top=�5t      $��	450,0,0,0q�5u      �� 5w      $ 	txtB_Date��5x      $��12(�5y      $	��140��5{      $��
450,25,0,0q�5|      $
��Wrap=�5}      
���   �$��DemiBold"�5      $
��Left=�5�      $	��Top=�5�      ��5z      �� *Date+5�        5�      $ CurrencyUsd=�5�      $��18��5�      $��18��5�      $
��Left=�5�      $	��Top=�5�      $��	640,0,0,0q�5�      �� 5�      $ txtB_Payment��5�      $��12(�5�      $��40��5�      $��
645,25,0,0q�5�      $
��Wrap=�5�      
���   �$��DemiBold"�5�      $
��Left=�5�      $	��Top=�5�      ��5�      �� *	Payment+5�      �� 5�      $��12(�5�      $	��Azn��5�      $��25��5�      $��
690,25,0,0q�5�      $
��Wrap=�5�      
���   �$��DemiBold"�5�      $
��Left=�5�      $	��Top=�5�      5�      5�      5�      5�      5�      5�      