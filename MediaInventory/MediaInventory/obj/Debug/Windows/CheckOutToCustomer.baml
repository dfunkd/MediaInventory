   M S B A M L   `   `   `  ����)  %System.Windows.Controls.Input.ToolkitpTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5   	   I EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MediaInventory.WindowsMediaInventory.Windows 5   	   I)clr-namespace:MediaInventory.UserControlsMediaInventory.UserControls 5   	   /   )MediaInventory.Windows.CheckOutToCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   ftoolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit    5   	   4local$clr-namespace:MediaInventory.Windows    5   	   6uc)clr-namespace:MediaInventory.UserControls    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  customerCheckOut��5   	    � Title$ CheckOutToCustomer��5   	    � AllowsTransparency . 
������ $	��200��5
   	    � 
ResizeMode$ NoResize=�5   	   $	��300��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5         cvsCustomers*  $System.Windows.Controls.DataGridCell �� 
TargetType �� BasedOn��%k   &	        '       7 �� 5   
   6   �� 5   
   "  6   8   .�5      -   5        5      5      .��5      �� -   5        ���	#FF373737
���   �$��1q�5   8   	 �� CornerRadius$	 5��6L   ._�5   
   ]� ��.  .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dgCustomers��5      $
��Left=�6,   $��5q�6B   $	��500��6M      AutoGenerateColumns .  $��Center=�6y   $	��Top=�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      CanUserAddRows .     RowHeaderWidth$ 0Q�6�   $��Disabled=�5   C   ��6y   ��  �� Source# [   � DataContext 6�   ��  �� RelativeSource �� *Self+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   ��  �� Path$ FullName� �� Mode$ OneWay=�5      �� 5       $	��Top=�6   
�������$
��5, 0q�6@   ��6N   ��  �� ElementName$ customerCheckOut��$ SelectedCustomer.FullName��� 5!      $	��Top=�6   
�������$
��5, 0q�6@   ��6N   �� $ customerCheckOut��$# SelectedCustomer.AddressLine1�y�6�   �� *AddressLine1+ # EmptyStringToCollapsedConverter �� 	Converter# [ �� 5"      $	��Top=�6   
�������$
��5, 0q�6@   ��6N   �� $ customerCheckOut��$# SelectedCustomer.AddressLine2�y�6�   �� *AddressLine1+# [ �� 5#      $	��Top=�6   
�������$
��5, 0q�6@   ��6N   �� $ customerCheckOut��$  SelectedCustomer.CellPhone� �� StringFormat$ (C) {0}��y�6�   �� *AddressLine1+# [ �� 5$      $	��Top=�6   
�������$
��5, 0q�6@   ��6N   �� $ customerCheckOut��$  SelectedCustomer.HomePhone�$ (H) {0}��y�6�   �� *AddressLine1+# [ �� 5%      $	��Top=�6   
�������$
��5, 0q�6@   ��5&      `� 5'      $ {0}, {1} {2}��6#   .1�5(      �� $ SelectedCustomer.City�6"   �� 5)      $) #SelectedCustomer.State.Abbreviation�6"   �� 5*      $ SelectedCustomer.ZipCode�6"   5+      5-      �� 5.      $��Bottom=�6    �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�5/      �� $��Ok��6   $��5q�6&    �� 	IsDefault .   NormalExpandingButtonStyle#���  6B   $)��#local:CheckOutToCustomer.OkCheckout��6w    J� CommandBindings 50      )  #System.Windows.Input.CommandBinding  51      -   5           Command$) #local:CheckOutToCustomer.OkCheckout��51   )   6r   z�53      V� 54      .~�55      �� �� 56      �� 57      T� 58      59      5;      �� 5<      $��Cancel��6   $��5q�6*    �� IsCancel .   CancelExpandingButtonStyle#���  6E   $-��'local:CheckOutToCustomer.CancelCheckout��6z    5=        5>      -   5        $- 'local:CheckOutToCustomer.CancelCheckout��5>   )   6z   z�5@      V� 5A      .~�5B      �� �� 5C      �� 5D      T� 5E      5F      5H      5I      5J      5K      5L      