   M S B A M L   `   `   `  ����  ЧипЧирип%    CryptoCurrency.CryptoCurrencies   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Currencies��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��2��6   $��10,10,10,10q�6#    5      �� 5      $��* �6#   �� 5      $	��100 �6#   .+�5      �� -   5         ��Name$ CryptoListView��5      $��0,0,10,0q�6/   $��0��6A    �� View 5      �� 5      .P�5      �� $
��Rank��6)    �� Width$ 50��6]    �� DisplayMemberBinding 67   �� *rank+6]   �� 5      $
��Name��6)   $	 150��6]    67   �� *name+6]   �� 5      $��Symbol��6)   $	 100��6a    69   �� *symbol+6a   �� 5      $��Price (USD)��6)   $	 100��6h    6>   �� *
priceUsd+6h   5      5      �� 5      -   5        $ MarketsListView��5      $��0,0,0,0q�60   $��1��6A    5      �� 5       .P�5!      �� $��Markets��6)   $	 100��6:    �� CellTemplate 5"      �� 5#   "   .R�5$   &   �� ��63   �� *	markets+��5%   *   �� 5&   .   .R�5'   2   �� ��6<   �� *
exchangeId+5(   /   5*   '   5+   #   5-      5.      50      51      �� 52   
    �� Orientation$ 
Horizontal=�6   $��10,10q�6.   $��0��6=   $��1��6M   .+�53      �� -   5        	 ��Name$	 SearchTextBox��53      $	��150��6-   $��5q�69   �� 54      -   5        
 ��Name$
 SearchButton��54      $��Search��6+   $��75��6<   $��5q�6G   6R   56      57      58      