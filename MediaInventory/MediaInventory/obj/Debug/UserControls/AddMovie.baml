   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      *    $MediaInventory.UserControls.AddMovie   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      9local)clr-namespace:MediaInventory.UserControls    5      6uc)clr-namespace:MediaInventory.UserControls    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          >�Name$  addMovie��5       � 	Resources 5         	cvsMovies��%   &	        �� 5	   
   6   5
      .��5      ]� ��. .+�5   
   :   4MediaInventory.UserControls.AnimatedWatermarkTextBox  -   5          Name$ txtSearchCriteria��5   &   $	��Top=�6A   $��5q�6V      
HeaderText$ Search Movies...��6a   ]� 5   
   -   5         ]�Name$ dpMovieInfo��5      $��Bottom=�6)   $��5q�6A   $��Stretch=�6L   $	��Top=�6j    � DataContext 6�   ��  �� ElementName$ addMovie�� �� Path$ NewMovie�.+�5      ]� $	��Top=�6   ��.  .+�5      �� -   5         ��Name$ tbTitle��5      $
��Left=�6-   $��Right=�6C   $��5q�6_   ��6j   �� *Title+�� 5      -   5        $ 	tbRuntime��5      $
��Left=�6/   $
��Left=�6E   $��5q�6`   ��6k   �� *	Runtime+	 �� StringFormat$	 ({0} Minutes)��
 �� TargetNullValue$
  ���� 5      -   5        $ tbReleaseDate��5      $��Right=�63   $��Right=�6J   $��5q�6f   ��6q   �� *ReleaseDate+$	 d���� 5      -   5        $ tbStatus��5      $��Right=�6.   $��Right=�6E   $��5q�6a   ��6l   �� *Status+d� 5      -   5         d�Name$ tbtIsOwnedWanted��5      $	��Top=�69   $��Center=�6N   $
��8, 5q�6k   $%��local:AddMovie.OwnedWantedClick��6y    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5      -	   5           Command$% local:AddMovie.OwnedWantedClick��5   )   6t   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      5       5!      ]� 5"      $	��Top=�6   ��.  .+�5#      �� -
   5        $ tbGenres��5#      $
��Left=�6.   $
��Left=�6D   $��5q�6_   $
��Wrap=�6j   ��6~   �� *Genres+�� 5$      -   5        $ tbCollections��5$      $��Right=�63   $
��Left=�6J   $��5q�6e   $
��Wrap=�6p   ��6�   �� *Collections+5%      �� 5&      -   5        $ 
tbOverview��5&      $	��Top=�6,   $
��Left=�6A   $��5q�6\   $
��Wrap=�6g   ��6{   �� *
Overview+�� 5'      $��	Add Movie��6     NormalExpandingButtonStyle#���  6)   $$��local:AddMovie.AddMovieCommand��6^   z�5(      V� 5)      .~�5*      �� �� 5+      �� 5,      T� 5-      5.       50        51      -   5        $$ local:AddMovie.AddMovieCommand��51   %   6n   53      54      ]� 55   
   -   5        $ 	dpPageNav��55      $��Bottom=�6'   $��35��6?   ��. $��
5, 0, 5, 5q�6`   $y�Hidden=�6t   .+�56      �� $��Right=�6   $��>>��6,   $��5q�69   $��Center=�6D   #���  6_   $��local:AddMovie.LastPage��6�    57        58      -   5        $ local:AddMovie.LastPage��58   %   6`   z�5:      V� 5;      .~�5<      �� �� 5=      �� 5>      T� 5?      5@      5B      �� 5C      $��Right=�6   $��>��6,   $��5q�68   $��Center=�6C   #���  6^   $��local:AddMovie.NextPage��6�    5D        5E      -   5        $ local:AddMovie.NextPage��5E   %   6`   z�5G      V� 5H      .~�5I      �� �� 5J      �� 5K      T� 5L      5M      5O      �� 5P      $
��Left=�6   $��<<��6+   $��5q�6>   $��Center=�6I   #���  6d   $��local:AddMovie.FirstPage��6�    5Q        5R      -   5        $ local:AddMovie.FirstPage��5R   %   6b   z�5T      V� 5U      .~�5V      �� �� 5W      �� 5X      T� 5Y      5Z      5\      �� 5]      $
��Left=�6   $��<��6+   $��5q�6:   $��Center=�6E   #���  6`   $!��local:AddMovie.PreviousPage��6�    5^        5_      -   5        $! local:AddMovie.PreviousPage��5_   %   6h   z�5a      V� 5b      .~�5c      �� �� 5d      �� 5e      T� 5f      5g      5i      �� 5j      $
��Left=�6   $��Center=�6.   $��5q�6K   $��Center=�6V   ��6q   �� $ addMovie��$ PageLocation�5k      �� 5l   
   -   5         ��Name$ lbMovies��5l      $	��Top=�6$   
������ $��
5, 5, 5, 0q�6R   $��Disabled=�6f   ��6�   ��  �� Source# [   6�   ��  �� RelativeSource �� *Self+��5n      �� 5o      .R�5p      �  K� IsItemsHost . 6    5q      ��5s      �� 5t      .R�5u      �� $	��200��6:   ��6   �� $ Value�6:   5v      5x      5y      5z      