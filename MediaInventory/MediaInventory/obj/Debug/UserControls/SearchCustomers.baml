   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      1    +MediaInventory.UserControls.SearchCustomers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      9local)clr-namespace:MediaInventory.UserControls    5      6uc)clr-namespace:MediaInventory.UserControls    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          >�Name$  searchCustomers��5	      |�. ��.  � 	Resources 5         cvsCheckOutHistory  CheckOutHistoryContextMenu � DataContext �� RelativeSource   NormalExpandingMenuItemStyle��%(  &	        &	      �� 5   
   6   �� 5   
   ���	#FF373737 6P   �� *PlacementTarget.DataContext+ �� *Self+.@�5      m� $��Check In��6   #���  6)   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      5      5      5      .��5      ]� $��
5, 0, 5, 5q�6   ��. $��Stretch=�69   .+�5   
   :   4MediaInventory.UserControls.AnimatedWatermarkTextBox  -   5          Name$ txtSearchCriteria��5   &   $	��Top=�6A   $��5q�6V      
HeaderText$ Search Customers...��6a   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCustomers��5      $	��Top=�6(   $��5q�6=   $	��500��6H      AutoGenerateColumns .  $��Center=�6t   $	��Top=�6�      SelectionMode$ Single=�6�   	   SelectionUnit$	 FullRow=�6�   
   CanUserAddRows
 .     RowHeaderWidth$ 0Q�5      $��Disabled=�6V      AlternatingRowBackground �	#FF5A7BAD��6�   ��  �� ElementName$ searchCustomers�� �� Path$ 	Customers� 5      ��  �� *Self+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� $ FullName� �� Mode$ OneWay=�   RowDetailsTemplate 5#      �� 5$      .R�5%      ]� ��. .+�5&      ]� $
��Left=�6$   $��Center=�6:   ��.  .+�5'      ]� $	��Top=�6(   ��.  .+�5(   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   $
��Bold"�6c   ��5)   &   `� 5*   *    �� StringFormat$ {0}, {1}��67   .1�5+   .   �� $ LastName�66   $ OneWay=�6F   �� 5,   .   $ 	FirstName�66   $ OneWay=�6G   5-   +   5/   #   50      ]� 51      $	��Top=�6(   ��.  .+�52   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   ��6c   �� *AddressLine1+$ OneWay=�y�6�   �� *AddressLine1+ # EmptyStringToCollapsedConverter �� 	Converter# [ 53      ]� 54      $	��Top=�6(   ��.  .+�55   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   ��6c   �� *AddressLine2+$ OneWay=�y�6�   �� *AddressLine2+# [ 56      ]� 57      $	��Top=�6(   ��.  .+�58   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   ��59   &   `� 5:   *   $ {0}, {1} {2}��67   .1�5;   .   �� $
 City�66   $ OneWay=�6B   �� 5<   .   $ State.Abbreviation�66   $ OneWay=�6P   �� 5=   .   $ ZipCode�66   $ OneWay=�6E   5>   +   5@   #   5A      ]� 5B      $	��Top=�6(   ��.  .+�5C   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   ��6c   �� *EmailAddress+$ OneWay=�5D      ]� 5E      $	��Top=�6(   ��.  .+�5F   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   ��6c   �� *	CellPhone+$ OneWay=�$ (C) {0}��5G      ]� 5H      $	��Top=�6(   ��.  .+�5I   "   �� $
��Left=�6,   
�������$
��5, 0q�6U   ��6c   �� *	HomePhone+$ OneWay=�$ (H) {0}��5J      5K        5L      -   5        $	��Top=�5L   #   $��5q�68   $	��500��6C    .  $��Center=�6o   $	��Top=�6�   $ Single=�6�   $	 FullRow=�6�   
 .  $ 0Q�5M   #   $��Disabled=�66    �	#FF5A7BAD   RowBackground �	#FF7C96BE��6l   �� $ CheckOutHistories� 5O        5P   "   $ Title��65   $ * 6D    6N   �� $ 
Movie.Name�  5Q   "   $ Check Out Date��65    6M   �� $ CheckOutDate� ( $DateTimeToDateAndTimeOrNullConverter# [   5R   "   $ Check In Date��65    6L   �� $ CheckInDate�# [ 4  .System.Windows.Controls.DataGridTemplateColumn  5S   "   $ Check In Date��69      CellTemplate 5T   &   �� 5U   *   .R�5V   .   � $��Stretch=�63   $��0q�6Q   .+�5W   2   �� ��6<   �� $ CheckInDate�# [ y�6�   �� $ CheckInDate� & "StringContentToVisibilityConverter# [ �� 5X   2   -   5        $��Check In��5X   9   $��Stretch=�6L     CancelExpandingButtonStyle#���  6j   y�6�   �� $ CheckInDate�  NullToCollapsedConverter# [ z�5\   6   V� 5]   :   .~�5^   >   �� �� 5_   >   �� 5`   >   T� 5a   >   5b   ;   5d   3   5e   /   5f   +   5h   #   5q      5r      5s         RowStyle 5u      �� 5v       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5w      ��  �� Property � �� �� Value �	#FF46638E63   �� 5x       � ��
 �����63   5y      5{      5|      5}      