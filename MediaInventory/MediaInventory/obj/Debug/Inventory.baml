   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MediaInventoryMediaInventory  5   	   I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5   	       MediaInventory.Inventory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   ,localclr-namespace:MediaInventory    5   	   6uc)clr-namespace:MediaInventory.UserControls    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  	inventory��5   	    � Icon$) #./Resources/Icons/SkullAndBones.ico��5   	    � Title$ 	Inventory��5   	    � AllowsTransparency . 
������ $	��750��5
   	    � 
ResizeMode$ NoResize=�5   	   $
��1000��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $y�	Collapsed=�5   	    � 	Resources 5         	cvsMovies  ClosingStoryboard g� Duration	 W� From
 �� 
TargetName �� TargetProperty	 W� To��%�  &	        &	      �� 5   
   6   �� 5   
   .��5      W� $ 00:00:01D�6   $		 750X�62   $
 brdMain��6=   $ Height�6]   $ 0X�6�   W� 5      $ 00:00:01D�6   $
	 1000X�62   $
 brdMain��6>   $ Width�6^   $ 0X�6�   W� 5      $ 00:00:01D�6   $	 1X�62   $

 zoom��6;   $ ScaleX�6X   $ 0X�6{   W� 5      $ 00:00:01D�6   $	 1X�62   $

 zoom��6;   $ ScaleY�6X   $ 0X�6{   5      5      z�5      �� 5   
   -   5        zoom�� �� ScaleX$ 1Q�5   '    �� ScaleY$ 1Q�62    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   [�5       �� 5!      .��5"      �� .��5#      W� $ 00:00:01D�6*   $	 0X�6>   $
 brdMain��6G   $ Height�6g   $	 750X�6�   W� 5$      $ 00:00:01D�6*   $	 0X�6>   $
 brdMain��6G   $ Width�6g   $
 1000X�6�   W� 5%      $ 00:00:01D�6*   $	 0X�6>   $

 zoom��6G   $ ScaleX�6d   $ 1X�6�   W� 5&      $ 00:00:01D�6*   $	 0X�6>   $

 zoom��6G   $ ScaleY�6d   $ 1X�6�   5'      5(      5*      .��5-      �� -   5         ��Name$ brdMain��5-      ���	#FF373737
���   �$��1q�6I    �� CornerRadius$ 5��6]   ._�5.   
   ]� ��. .+�5/      ]� -   5         ]�Name$ dpMenu��5/      $	��Top=�6(   ���	#FF373737��.  $��5q�6j   .+�50      �� -   5         ��Name$ btnLogin��50      $
��Left=�6+   $��5q�6A     NormalExpandingButtonStyle#���  6L   $��Login��6�   $��local:Inventory.Login��6�    J� CommandBindings 51      )  #System.Windows.Input.CommandBinding  52      -   5           Command$ local:Inventory.Login��52   )   6_   z�54      V� 55      .~�56      �� �� 57      �� 58      T� 59      5:      5<      �� 5=      -   5        $ 	btnSearch��5=      $
��Left=�6,   $��5q�6B   #���  6M   $��Search Inventory��6�   $%��local:Inventory.SearchInventory��6�    5>        5?      -   5        $% local:Inventory.SearchInventory��5?   )   6s   z�5A      V� 5B      .~�5C      �� �� 5D      �� 5E      T� 5F      5G      5I      �� 5J      -	   5        $ btnAdd��5J      $
��Left=�6)   $��5q�6?   #���  6J   $��Add Inventory��6   $"��local:Inventory.AddInventory��6�    5K        5L      -
   5        $" local:Inventory.AddInventory��5L   )   6m   z�5N      V� 5O      .~�5P      �� �� 5Q      �� 5R      T� 5S      5T      5V      �� 5W      -   5        $ btnEdit��5W      $
��Left=�6*   $��5q�6@   #���  6K   $��Edit Inventory��6�   $#��local:Inventory.EditInventory��6�    5X        5Y      -   5        $# local:Inventory.EditInventory��5Y   )   6o   z�5[      V� 5\      .~�5]      �� �� 5^      �� 5_      T� 5`      5a      5c      �� 5d      -   5        $ btnClose��5d      $��Right=�6+   $��5q�6B     CancelExpandingButtonStyle#���  6M   $��Close��6�   $&�� local:Inventory.CloseApplication��6�    5e        5f      -   5        $&  local:Inventory.CloseApplication��5f   )   6u   z�5h      V� 5i      .~�5j      �� �� 5k      �� 5l      T� 5m      5n      5p      �� 5q      -   5        $ 	btnLogout��5q      $��Right=�6,   $��5q�6C   #���  6N   $��Logout��6�   $��local:Inventory.Logout��6�    5r        5s      -   5        $ local:Inventory.Logout��5s   )   6a   z�5u      V� 5v      .~�5w      �� �� 5x      �� 5y      T� 5z      5{      5}      5~      ]� 5      $��Bottom=�6   $��Stretch=�60   ��.  $��5q�6d   .+�5�      �� $
��Left=�6   $��24��6/   $��24��6:    � ToolTip 6F   ��  �� ElementName$ 	inventory�� �� Path$ LoginToolTip�.+�5�      A� ��5�      �� 5�       �� 
TargetType" A�6$    �� Triggers 5�   "   �� 5�   &    �� Binding 62   �� $ 	inventory��$ 
IsLoggedIn� �� Value	 False6m   .a�5�   *   ��  �� Property � �� �� Value 5�   .   
� 5�   2     
� GradientOrigin$  .5,.8&�6F   ! 
� RadiusX$	! 0.6Q�6]   .��5�   6   � " � Color$" 	#FF6A0100��6C   # � Offset$# 1Q�6U   � 5�   6   $" 	#FFFF000C��6C   $# 0Q�6U   5�   3   5�   +   5�   '   �� 5�   &    62   �� $ 	inventory��$ 
IsLoggedIn� True6m   .a�5�   *   ��  � �� 5�   .   
� 5�   2   $  .5,.8&�6F   $	! 0.6Q�6]   .��5�   6   � $" 	#FF005502��6C   $# 1Q�6U   � 5�   6   $" 	#FF15D600��6C   $# 0Q�6U   5�   3   5�   +   5�   '   .�5�   "   ��  � ��$ 24��6;   �� 5�   "    � ��$ 24��6:   5�      5�      A� 5�      $ �� Left$$ 3��6   
% �� Top$% 1��6.   ��5�      �� 5�      " A�6$   .�5�   "   ��  � �� 5�   &   �� 5�   *   & �� 
StartPoint$	& 0,0&�6>   ' �� EndPoint$	' 0,1&�6O   .��5�   .   � $" 	#FFFFFFFF��6;   $# 0Q�6M   � 5�   .   $" 	#00000000��6;   $# 1Q�6M   5�   +   5�   #   �� 5�   "    � ��$ 15��6;   �� 5�   "    � ��$ 18��6:   5�      5�      5�      �� 5�      $
��Left=�6     TextBlockForeground#���  62   $
��5, 0q�6e   $��Center=�6s   ��5�      �� $ 	inventory��$ CurrentUserAndRole�  NullToStringConverter( �� 	Converter#( [ ) �� ConverterParameter$) 
Logged Out���� 5�      $��Right=�6   
������ 
������  # TransparentExpandingButtonStyle#���  6c   $"��local:Inventory.OpenSettings��6�    5�        5�      -   5        $" local:Inventory.OpenSettings��5�   )   6m   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .��5�      �� $$��Resources/Icons/SilverGear.ico��6   $��32��6D   $��32��6P   5�      5�      ]� 5�      $	��Top=�6   ��. .+�5�      �� -   5        * ��Name$* ccMain��5�   !   $	��Top=�61   5�      5�      5�      5�      