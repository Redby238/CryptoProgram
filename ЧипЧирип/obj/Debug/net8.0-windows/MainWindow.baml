   M S B A M L   `   `   `  ����  ЧипЧирип    CryptoDesktop.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6,   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6n     � Title$  Crypto Desktop��6�   $	��500��6�   $	��900��6�    � 	Resources 5      ��%    5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $��Crypto Desktop��5      $��24(�5      $
��Bold"�6   $��Center=�5      $��0,0,0,10q�6+   �� 5   
   -   5         ��Name$ CryptoListView��5      $��1��6+   $��0��68   $��2��6H   $��0,0,10,0q�6\    �� View 5      �� 5      .P�5      �� $
��Rank��6%    �� Width$ 50��6Y    �� DisplayMemberBinding 63   �� *rank+6Y   �� 5      $
��Name��6%   $	 150��6Y    63   �� *name+6Y   �� 5      $��Symbol��6%   $	 100��6]    65   �� *symbol+6]   5      5      �� 5!   
   	 �� Orientation$	 
Horizontal=�6   $��2��6.   $��0��6;   $
��Left=�6K   $��Center=�6f   $��0,10,0,0q�6�   .+�5"      �� -   5        
 ��Name$
 SearchTextBox��5"      $	��150��6-   $��5q�69   �� 5#      -   5         ��Name$ SearchButton��5#      $��Search��6+   $��75��6<   $��5q�6G   6R   5$      �� 5&   
   $	 
Horizontal=�6   $��2��6.   $��1��6;   $��Right=�6K   $��Center=�6g   $��0,10,0,0q�6�   .+�5'      �� -   5        $ CurrencyConverterButton��5'      $��Convert Currency��6\   $	��125��6w   $��5q�6�   �� 5(      -   5        $ CurrenciesButton��5(      $��To all currencies��6N   $	��125��6j   $��5q�6v   5)      5*      5+      