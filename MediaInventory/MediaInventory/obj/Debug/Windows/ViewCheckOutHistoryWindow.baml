   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MediaInventory.WindowsMediaInventory.Windows  5   	   6    0MediaInventory.Windows.ViewCheckOutHistoryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   4local$clr-namespace:MediaInventory.Windows    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  checkoutHistory��5   	    � Title$ Check Out History��5   	    � AllowsTransparency . 
������ $	��325��5   	    � 
ResizeMode$ NoResize=�5	   	    � SizeToContent$ WidthAndHeight=�5
   	   $	��500��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   .��5      �� -   5        ���	#FF373737
���   �$��1q�5   8    �� CornerRadius$ 5��6L   ._�5   
   ]� ��. .+�5      �� $	��Top=�6   $
��Bold"�6-   $��16(�6?   
�������$��Center=�6`   ��6}   ��  �� ElementName$ checkoutHistory��	 �� Path$	 Header��� 5      $	��Top=�6   $
��Bold"�6-   $��16(�6?   
�������$��Center=�6`   $��Check Out History��6}   �� 5      $��Bottom=�6   $��Ok��6-   $��5q�6:      NormalButtonStyle#���   6E   $��Center=�6q   $1��+local:ViewCheckOutHistoryWindow.CloseWindow��6�   
 J� CommandBindings
 5      )  #System.Windows.Input.CommandBinding  5      -   5           Command$1 +local:ViewCheckOutHistoryWindow.CloseWindow��5   %   6w   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgCheckOutHistory��5      $	��Top=�62   $��5q�6G      AutoGenerateColumns .     SelectionMode$ Single=�6n      SelectionUnit$ FullRow=�6�      CanUserAddRows .     RowHeaderWidth$ 0Q�6�   ��5      �� $ checkoutHistory��$	 CheckOutHistory�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Customer.FullName+  5      $ Check Out Date��6)    6A   �� $	 CheckOutDate� ( $DateTimeToDateAndTimeOrNullConverter �� 	Converter# [   5      $ Check In Date��6)    6@   �� $	 CheckInDate�# [    RowDetailsTemplate 5!      �� 5"      .R�5#      ]� ��.  $��5q�6:    � DataContext 6E   �� *
Customer+.+�5$      �� $	��Top=�6)   $
��Left=�6>    �� Orientation$ 
Horizontal=�6Y   .+�5%   "   �� 
���   ���6?   �� *
FullName+5&      �� 5'      $	��Top=�6)   $
��Left=�6>   $ 
Horizontal=�6Y   .+�5(   "   �� 
���   ���6?   �� *AddressLine1+5)      �� 5*      $	��Top=�6)   $
��Left=�6>   $ 
Horizontal=�6Y   y�6r   �� *AddressLine2+  NullToVisibilityConverter# [ .+�5+   "   �� 
���   ���6?   �� *AddressLine2+5,      �� 5-      $	��Top=�6)   $
��Left=�6>   $ 
Horizontal=�6Y   .+�5.   "   �� 
���   ���5/   &   `� 50   *    �� StringFormat$ {0} {1}, {2}��67   .1�51   .   �� $
	 City�66   �� 52   .   $	 State.Abbreviation�66   �� 53   .   $	 ZipCode�66   54   +   56   #   57      �� 58      $	��Top=�6)   $
��Left=�6>   $ 
Horizontal=�6Y   .+�59   "   �� 
���   ���5:   &   `� 5;   *   $ (H) {0} (C) {1}��67   .1�5<   .   �� $	 	HomePhone�66   �� 5=   .   $	 	CellPhone�66   5>   +   5@   #   5A      �� 5B      $	��Top=�6)   $
��Left=�6>   $ 
Horizontal=�6Y   .+�5C   "   �� 
���   ���6?   �� *EmailAddress+5D      5E      5F         RowStyle 5H      �� 5I       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5J      ��  �� Property � �� �� Value 67   �� *IsCheckedOut+ # IsCheckedOutToRowColorConverter# [ 5K      5M      5N      5O      5P      