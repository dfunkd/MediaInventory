   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MediaInventory.ResourcesMediaInventory.Resources  5      &     MediaInventory.UserControls.Edit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      :	resources&clr-namespace:MediaInventory.Resources    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          >�Name$
  edit��5      .��5      ]� ��. .+�5   
   �� $	��Top=�6   $��Center=�6*    �� Orientation$ 
Horizontal=�6G   .+�5	      d� $��Movies��6    d� 	IsChecked 6,   ��  �� ElementName$
 edit�� �� Path$ InventoryType� %  !InventoryTypeToIsCheckedConverter �� 	Converter# [  -   'MediaInventory.Resources.InventoryTypes   Movies �� ConverterParameter# Z z�5
      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      5      d� 5      $��Music��6    � ToolTip$ Coming soon!!��5       5   +   �� $
 edit��$ InventoryType�# [  	   Music# Z	 z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      5      d� 5      $��Books��6   $ Coming soon!!��5       5   +   �� $
 edit��$ InventoryType�# [  
   Books# Z
 z�5       V� 5!      .~�5"      �� �� 5#      �� 5$      T� 5%      5&      5(      d� 5)      $��	Customers��6    6/   �� $
 edit��$ InventoryType�# [     	Customers# Z z�5*      V� 5+      .~�5,      �� �� 5-      �� 5.      T� 5/      50      52      53      �� 54   
   -   5         ��Name$ ccEdit��54      $	��Top=�6)   55      56      