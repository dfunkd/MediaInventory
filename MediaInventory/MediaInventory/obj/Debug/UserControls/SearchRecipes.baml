   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      /    )MediaInventory.UserControls.SearchRecipes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      9local)clr-namespace:MediaInventory.UserControls    5      6uc)clr-namespace:MediaInventory.UserControls    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          >�Name$  searchRecipes��5	      |�. ��.  � 	Resources 5         
cvsRecipes*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%B  &	        '       �� 5   
   6   �� 5   
   "  6.   .�5      ��  � �� 6+   Z� �� 5       � �� 6,   Z� �� 5       � ��
 �����6+    5      P� 5       �@ 
IsSelected . . �5      ��  � �� 63   Z� �� 5       � �� 64   Z� 5      5      5      .��5      ]� $��
5, 0, 5, 5q�6   ��. $��Stretch=�69   .+�5   
   :   4MediaInventory.UserControls.AnimatedWatermarkTextBox  -   5          Name$ txtSearchCriteria��5   &   $	��Top=�6A   $��5q�6V   	   
HeaderText$	 Search Recipes...��6a   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 	dgRecipes��5      $	��Top=�6&   $��5q�6;   $	��500��6F      AutoGenerateColumns .  $��Center=�6r   $	��Top=�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      CanUserAddRows .     RowHeaderWidth$ 0Q�6�   $��Disabled=�5   A    � DataContext 6w   ��  �� RelativeSource �� *Self+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Recipe��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ��  �� Path$
 Name� �� Mode$ OneWay=� �� 
GroupStyle 5!      (  "System.Windows.Controls.GroupStyle  5"         ContainerStyle 5#      �� 5$      " ��6    .�5%      ��  � ��$ 0q�67   �� 5&       � �� 5'   "   �� 5(   &    �� 
TargetType" ��66   .R�5)   *   ]� ��.  ���	#FF354B6C.+�5*   .   	�  	�Name$ tbExpand��6:   -   5        $	��Top=�5*   L   .��5+   2   ]� .+�5,   6   F�  F�Name$
 path��6;   
�������"����    ��[ � � ��[ р�[     	6V   �� 5-   6   $
��Bold"�6@   $��
5, 0, 0, 0q�6�   ��6R   �� $ 	ItemCount� �� StringFormat$	 {0}��6�   �� 5.   6   $
��Bold"�6@   $��
5, 0, 0, 0q�6�   ��6R   �� $
 Name�  RecipeGroupHeaderConverter �� 	Converter# [ 6�   �� 5/   6   $
��Bold"�6@   ��6R   �� $ 	ItemCount� $  RecipeGroupHeaderPluralConverter# [ 50   3   51   /   ]� 52   .    ]�Name$ dpItemPresenter��68   $	��Top=�6Q   ��. y�6{   �� *	IsChecked+  �� ElementName$  tbExpand�� $  BooleanTrueToVisibilityConverter# [ .+�53   2   �� $	��Top=�6A   54   /   55   +   56   '   58      59      5;      !   RowDetailsTemplate! 5=      �� 5>      .R�5?      ]� ��.  .+�5@      �� $
��Left=�6!   
���   �$��1q�6K   $��5q�6_   $	��Top=�6j   y�6�   �� $ Image�  NullToVisibilityConverter# [ ._�5A      �� $	��200��6$   ��61   �� *Image+  BinaryToImageConverter# [ 5B      ]� 5C      $	��Top=�6$   ��.  $��0q�6O   .+�5D      �� $
��Left=�6)   " �� Orientation$" 
Horizontal=�6?   .+�5E   "   �� $
��5, 0q�6,   $��	Prep Time��6:   �� 5F   "   $
��5, 0q�6,   ��6:   �� *PrepTimeMinutes+  PrepCookTimeConverter# [ 5G      �� 5H      $
��Left=�6)   $" 
Horizontal=�6?   .+�5I   "   �� $
��5, 0q�6,   $��	Cook Time��6:   �� 5J   "   $
��5, 0q�6,   ��6:   �� *CookTimeMinutes+# [ 5K      �� 5L      $
��Left=�6)   $" 
Horizontal=�6?   .+�5M   "   �� $
��5, 0q�6,   $��
Total Time��6:   �� 5N   "   $
��5, 0q�6,   $
��Bold"�6:   ��5O   &   `� 5P   *     TotalPrepCookTimeConverter# `� 	Converter## [ 67   .1�5Q   .   �� $ PrepTimeMinutes�66   �� 5R   .   $ CookTimeMinutes�66   5S   +   5U   #   5V      5W      �� 5X      $	��Top=�6$   $
��Left=�69   y�6T   �� *
Homepage+# [ �� 5Y      -   5        ��5Y   (   �� *RecipeAcquiredFrom+.�6   Recipe Origin5[      5\      �� 5]      $	��Top=�6$   $��2��69   $��Stretch=�6D   
���   �6b   ]� 5^      $	��Top=�6$   ��. $��0q�6N   .+�5_      ]� $
��Left=�6(   ��. .+�5`   "   �� $	��Top=�6,   $
��Bold"�6A   $��Ingredients��6S   �� 5a   "   $ ��Name$$ lsbIngredients��6*   ��6B   �� $# Recipe2Ingredient2Measurement���5b   &   �� 5c   *   .R�5d   .   � % � ColumnDefinitions% 5e   2   �� 5f   6   $
��Auto �6G   �� 5g   6   $��* �6G   .+�5i   2   �� $��0��6<   $��Right=�6L   ��5j   6   `� 5k   :     MeasurementConverter## [ 6G   .1�5l   >   �� $ Quantity�6F   �� 5m   >   $  Measurement��6F   $
 Name�6`   5n   ;   5p   3   �� 5q   2   $��1��6<   $
��Left=�6L   ��6g   �� $  
Ingredient��$
 Name�5r   /   5s   +   5u   #   5v      ]� 5w      $
��Left=�6(   ��. .+�5x   "   �� $	��Top=�6,   $
��Bold"�6A   $��
Directions��6S   �� 5y   "   $	��Top=�6,   $
��Wrap=�6A   ��6U   �� *	Direction+5z      5{      ]� 5|      $��Bottom=�6$   $��Stretch=�6<   ��. $��5q�6o   .+�5}      ]� $��Right=�6(   $��Right=�6?   ��.  $��5q�6q   .+�5�   "   d� $	��Top=�6/   $��8q�6D   $)��#local:SearchRecipes.ChangeValuation��5�   /   ��5�   O   ��  	 ValuationTextConverter# [	 ��6�   ��  %
 !ValuationBackgroundColorConverter# [
 & J� CommandBindings& 5�   &   )	  #System.Windows.Input.CommandBinding	  5�   *   -   5        ' 	  Command$)' #local:SearchRecipes.ChangeValuation��5�   9   6�   z�5�   &   V� 5�   *   .~�5�   .   �� �� 5�   .   �� 5�   .   T� 5�   .   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      