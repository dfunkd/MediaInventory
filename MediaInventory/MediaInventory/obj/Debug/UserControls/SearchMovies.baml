   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      .    (MediaInventory.UserControls.SearchMovies   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      9local)clr-namespace:MediaInventory.UserControls    5      6uc)clr-namespace:MediaInventory.UserControls    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          >�Name$  searchMovies��5	      |�. ��.  � 	Resources 5         cvsInventory*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%F  &	        '       �� 5   
   5      �� 5   
   "  6.   .�5      ��  � �� 6+   Z� �� 5       � �� 6,   Z� �� 5       � ��
 �����6+    5      P� 5       �@ 
IsSelected . . �5      ��  � �� 63   Z� �� 5       � �� 64   Z� 5      5      5      .��5      ]� $��
5, 0, 5, 5q�6   ��. $��Stretch=�69   .+�5   
   :   4MediaInventory.UserControls.AnimatedWatermarkTextBox  -   5          Name$ txtSearchCriteria��5   &   $	��Top=�6A   $��5q�6V   	   
HeaderText$	 Search Movies...��6a   �� 5   
   $	��Top=�6   $��Group By��6(   $��5q�6:   $
��Left=�6E   $��
5, 5, 7, 2q�6`   .��5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5       	� -   5         	�Name$ 	rdoFormat��5       $��Format��61    	� 	GroupName$ GroupFilter��6B   6Z   	� 5!      -   5        $ 	rdoStatus��5!      $��Check Status��61   $ GroupFilter��6H   6`   	� 5"      -   5        $ rdoOwned��5"      $��Owned��60   $ GroupFilter��6@   6X   	� 5#      -   5        $ 	rdoWanted��5#      $��Wanted��61   $ GroupFilter��6B   6Z   5$      5%      &   System.Windows.Controls.DataGrid  5&   
   -   5          Name$ dgMovies��5&      $	��Top=�6%   $��5q�6:   $	��500��6E      AutoGenerateColumns .  $��Center=�6q   $	��Top=�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      CanUserAddRows .     RowHeaderWidth$ 0Q�6�   $��Disabled=�5'   @    � DataContext 6v   ��  �� RelativeSource �� *Self+   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ��  �� Path$
 Name� �� Mode$ OneWay=� �� 
GroupStyle 5+      (  "System.Windows.Controls.GroupStyle  5,         ContainerStyle 5-      �� 5.      " ��6    .�5/      ��  � ��$ 0q�67   �� 50       � �� 51   "   �� 52   &    �� 
TargetType" ��66   .R�53   *   ]� ��.  ���	#FF354B6C.+�54   .   	� $ tbExpand��6:   -   5        $	��Top=�54   L   .��55   2   ]� .+�56   6   F�  F�Name$
 path��6;   
�������"����    ��[ � � ��[ р�[     	6V   �� 57   6   $
��Bold"�6@   $��
5, 0, 0, 0q�6�   ��6R   �� $ 	ItemCount� �� StringFormat$	 {0}��6�   �� 58   6   $
��Bold"�6@   $��
5, 0, 0, 0q�6�   ��6R   �� $
 Name�  MovieGroupHeaderConverter  �� 	Converter#  [ 6�   �� 59   6   $
��Bold"�6@   ��6R   �� $ 	ItemCount� # MovieGroupHeaderPluralConverter#  [ 5:   3   5;   /   ]� 5<   .   ! ]�Name$! dpItemPresenter��68   $	��Top=�6Q   ��. y�6{   �� *	IsChecked+" �� ElementName$" tbExpand�� $  BooleanTrueToVisibilityConverter#  [ .+�5=   2   �� $	��Top=�6A   5>   /   5?   +   5@   '   5B      5C      5E      #   RowDetailsTemplate# 5G      �� 5H      .R�5I      ]� ��.  .+�5J      �� $
��Left=�6!   
���   �$��1q�6K   $��5q�6_   $	��Top=�6j   y�6�   �� $ 
PosterPath�  NullToVisibilityConverter#  [ ._�5K      �� $	��200��6$   ��61   �� *
PosterPath+5L      ]� 5M      $	��Top=�6$   ��.  $��0q�6O   .+�5N      �� $
��Left=�6(   
�������$
��Bold"�6u   ��6Q   �� *Title+$ OneWay=�6u   �� 5O      $
��Left=�6(   
�������$
��5, 0q�6Q   ��6_   �� *ReleaseDate+$ 
({0:yyyy})��$ �� ConverterCulture$$ en-GB���� 5P      $
��Left=�6(   
�������$
��5, 0q�6Q   ��6_   �� *Budget+$ {0:C0}���� 5Q      $��Right=�6(   $��Right=�6?   
���������6n   �� $ Genres�  GenreListToStringConverter#  [ 5R      �� 5S      $	��Top=�6$   $��2��69   $��Stretch=�6D   
���   �6b   ]� 5T      $	��Top=�6$   ��.  $��0q�6O   .+�5U      �� $
��Left=�6(   
�������$��Overview��6Q   $
��Bold"�6a   �� 5V      $
��Left=�6'   $
��5, 0q�6=   $��Is Adult��6K   {�.  % d� 	IsChecked% 6p   �� *	IsAdult+$ OneWay=��� 5W      $��Right=�6(   $
��5, 0q�6?   
���������6`   �� *Format.Name+$ OneWay=�5X      �� 5Y      $	��Top=�6$   $
��Left=�69   y�6T   �� *
Homepage+#  [ �� 5Z      -	   5        ��5Z   (   �� *
Homepage+.�6u   
Homepage5\      5]      ]� 5^      $��Bottom=�6$   $��Stretch=�6<   ��. $��5q�6o   .+�5_      ]� $��Right=�6(   $��Right=�6?   ��.  $��5q�6q   .+�5`   "   	� $ rdoIsCheckedOut��6.   -
   5        $	��Top=�5`   G   $��8q�6\   $
��Left=�6g   ��5a   *   �� $ OneWay=�& �� UpdateSourceTrigger$& PropertyChanged=�  IsCheckedOutToTextConverter#  [ ��5b   *   �� $ OneWay=�$& PropertyChanged=� * &IsCheckedOutToBackgroundColorConverter#  [ % 5c   *   �� $ OneWay=�$& PropertyChanged=�{�6q   ��   CheckOutEnabledConverter#  [ d� 5z   "   $	��Top=�6/   $��8q�6D   $)��#local:SearchMovies.OwnedWantedClick��5{   /   ��5z   O   ��  	 IsWantedOwnedTextConverter#  [	 ��6�   ��  %
 !IsWantedOwnedBackgroumdConnverter#  [
 ' J� CommandBindings' 5|   &   )	  #System.Windows.Input.CommandBinding	  5}   *   -   5        ( 	  Command$)( #local:SearchMovies.OwnedWantedClick��5}   9   6�   z�5   &   V� 5�   *   .~�5�   .   �� �� 5�   .   �� 5�   .   T� 5�   .   5�   +   5�   #   5�        5�      $��Right=�6'   )   AlternatingRowBackground) �	#FF5A7BAD .   .  *   CanUserDeleteRows* .  +   CanUserSortColumns+ .  $
��Left=�6�   $��5q�6�   $	��125��6�   ,   RowBackground, �	#FF354B6C$ 0Q�5�   '   $��Disabled=�6:   $ Single=�6p   $ FullRow=�6�   $	��Top=�6�   ��6�   �� $ CheckOutHistories� 5�   "     5�   &   $ Customer Name��69   $ * 6P   -   
IsReadOnly- .  6l   �� $ Customer.FullName�  5�   &   $ Check Out Date��69   - .  6c   �� $ CheckOutDate� ( $DateTimeToDateAndTimeOrNullConverter#  [   5�   &   $ Check In Date��69   - .  6b   �� $ CheckInDate�#  [ .   RowStyle. 5�   "   �� 5�   &   )
  #System.Windows.Controls.DataGridRow" 
 6,   .�5�   *   ��  � �� 6G   Z� �� 5�   *    � �� 6H   Z� �� 5�   *    � ��
 �����6G    5�   *   P� 5�   .    �@
 
IsSelected . . �5�   2   ��  � �� 6O   Z� �� 5�   2    � �� 6P   Z� 5�   /   5�   '   ��5�   "   �� 5�   &   "  6,    5�   *   �� 5�   .   / �� Binding/ 6:   �� *Items.Count+ �� *Self+0 �� Value0 06�   .a�5�   2   ��  � y�$ 	Collapsed=�6O   5�   /   5�   '   5�      5�      �� 5�      $	��Top=�6$   $
��Wrap=�69   
���������6`   �� *
Overview+5�      5�      . 5�      �� 5�      " 
 6   .�5�      ��  � ��
 �����63   -   5         5�      P� 5�       �@
 AlternationIndex$ 0��6>   . �5�      ��  � �� 6;   ��  # IsCheckedOutToRowColorConverter#  [ 5�      P� 5�       �@
 AlternationIndex$ 1��6>   . �5�      ��  � �� 6;   ��  , (IsCheckedOutToAlternateRowColorConverter#  [ 5�      5�      5�      5�      5�      