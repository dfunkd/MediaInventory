   M S B A M L   `   `   `  ����  MediaInventory-    'MediaInventory.Windows.CustomMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  messageWindow��5   	    � AllowsTransparency .  � Title$ OurMessageBox��6     � ShowInTaskbar .  
������ $	��175��5   "   $	��250��62   $	��375��6A    � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�6.    � WindowStyle$
 None=�6M   .��5      �� -   5         ��Name$ 
bdrMessage��5      ���	#FF373737
���   �$��2q�6L    �� CornerRadius$ 5��6`   $��5q�6q   	 J� Effect	 5	   
   3  -System.Windows.Media.Effects.DropShadowEffect  5
      ._�5   
   � 
 � RowDefinitions
 5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� -   5        $ 	bdrHeader��5      $ 5��6(   ���	#FF373737._�5      �� -   5         ��Name$ tbHeader��5         TableViewSelectionTextBrush#���   6.   $
��Bold"�6i   $��WrapWithOverflow=�6{   $��2q�6�   ��6�   ��  �� ElementName$ messageWindow�� �� Path$ Caption�5      ]� 5      $��1��6   .+�5      �� -   5         ��Name$ messageBoxImage��5   >   $��5q�6   $��Center=�6#   $y�	Collapsed=�6W   $��60��6n   �� 5      $��Bottom=�6   
���   �$��15, 5, 5, 5q�6F    d� 	IsChecked 6[   �� $ messageWindow��$ IsConfirmed���6�   �� $ messageWindow��$ ConfirmationMessage�y�5      �� $ messageWindow��$ ConfirmationMessage� & "StringContentToVisibilityConverter �� 	Converter# [ �� 5      -   5        $ 	tbMessage��5      $��1��6/   $��10q�6?   $��WrapWithOverflow=�6K   $��Center=�6k   ��6�   �� $ messageWindow��$ MessageText�5      �� 5      $��2��6   $��2��6%   
���   �$��Stretch=�6=   $��3,10,3,0q�6[   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��2��6O   $��5,5,5,10q�6c   $��3��6u   .+�5      �� -   5         ��Name$ messageYesButton��5      $��75��63   $	��Yes��6]   $��5q�6k   $y�	Collapsed=�6v   �� 5      -   5        $ messageNoButton��5      $��75��62   $��No��6\   $��5q�6i   $y�	Collapsed=�6t   �� 5       -	   5        $ messageOKButton��5       $��75��62   $��OK��6\   $��5q�6i   �� 5!      -
   5        $ messageCancelButton��5!      $��75��66   $��Cancel��6d   $��5q�6u   $y�	Collapsed=�6�   5"      5#      5$      5%      