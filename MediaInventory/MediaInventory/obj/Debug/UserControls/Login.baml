   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MediaInventory.CustomControlsMediaInventory.CustomControls  5      I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls  5      '    !MediaInventory.UserControls.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8cc+clr-namespace:MediaInventory.CustomControls    5      6uc)clr-namespace:MediaInventory.UserControls    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5        $��Center=�5      $��Center=�5      .��5
      ]� ��.  .+�5   
   �� $	��Top=�6   $	��128��6%   $=��7/MediaInventory;component/Resources/Images/allMedia.png��62   �� 5   
   $	��Top=�6   $
��Bold"�6)   $��16(�6;   
�������$��Center=�6\   $��ThreeMPtree Inventory��6y   �� 5   
   $��Bottom=�6     �� Orientation$  
Horizontal=�6-   $��Center=�6F   .+�5      �� $��Login��6      NormalExpandingButtonStyle#���   6%    �� 	IsDefault . $��uc:Login.InventoryLogin��6k    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5      -   5           Command$ uc:Login.InventoryLogin��5   %   6f   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      5      �� 5      $��Cancel��6     CancelExpandingButtonStyle#���  6&    �� IsCancel . $��uc:Login.CancelLogin��6k    5        5      -   5        $ uc:Login.CancelLogin��5   %   6`   z�5      V� 5       .~�5!      �� �� 5"      �� 5#      T� 5$      5%      5'      5(      :   4MediaInventory.UserControls.AnimatedWatermarkTextBox  5)   
   -   5          Name$ txtLogin��5)   &   $	��Top=�68      
HeaderText$ Login...��6M   $��Stretch=�6c   $��5q�6�   >   8MediaInventory.UserControls.AnimatedWatermarkPasswordBox  5*   
   -   5          Name$ pwbPassword��5*   *   $	��Top=�6?      
HeaderText$ Password...��6T   $��Stretch=�6m   $��5q�6�   ]� 5+   
   $	��Top=�6   $��Stretch=�6)   .+�5,      �� $
��Left=�6   $��Forgot Login��6+   $��10, 0q�6B   $
��Left=�6Q     
LinkButton#���  6l   $��uc:Login.ForgotLogin��6�    5-        5.      -   5        $ uc:Login.ForgotLogin��5.   %   6`   z�50      V� 51      .~�52      �� �� 53      �� 54      T� 55      56      58      �� 59      $��Right=�6   $��Forgot Password��6,   $��10, 0q�6F   $��Right=�6U   #���  6q   $��uc:Login.ForgotPassword��6�    5:        5;      -   5        $ uc:Login.ForgotPassword��5;   %   6f   z�5=      V� 5>      .~�5?      �� �� 5@      �� 5A      T� 5B      5C      5E      5F      8   2MediaInventory.CustomControls.HeaderContentControl  5G   
   -   5        	  Name$	 hccInvalidLogin��5G   "    $  InvalidLoginHeaderContentControl#���  6;   $	��Top=�6v   
   Header$
 Invalid Login��6�   $��Stretch=�6�   $��5q�6�   $y�Hidden=�6�   5H      5I      