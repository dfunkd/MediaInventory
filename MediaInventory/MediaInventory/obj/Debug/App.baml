   M S B A M L   `   `   `  ����I  EMediaInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MediaInventory.CustomControlsMediaInventory.CustomControls  5      C&clr-namespace:MediaInventory.ResourcesMediaInventory.Resources  5      /clr-namespace:MediaInventoryMediaInventory  5          MediaInventory.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8cc+clr-namespace:MediaInventory.CustomControls    5      5conv&clr-namespace:MediaInventory.Resources    5      ,localclr-namespace:MediaInventory    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        �� 	Resources  5
      5   /MediaInventory.Resources.BinaryToImageConverter   BinaryToImageConverter?   9MediaInventory.Resources.BooleanTrueToVisibilityConverter $  BooleanTrueToVisibilityConverter7   1MediaInventory.Resources.CheckOutEnabledConverter  CheckOutEnabledConverterC   =MediaInventory.Resources.DateTimeToDateAndTimeOrNullConverter ( $DateTimeToDateAndTimeOrNullConverter>   8MediaInventory.Resources.EmptyStringToCollapsedConverter # EmptyStringToCollapsedConverter>   8MediaInventory.Resources.ForgotTypeToVisibilityConverter # ForgotTypeToVisibilityConverter9   3MediaInventory.Resources.GenreListToStringConverter  GenreListToStringConverter@   :MediaInventory.Resources.InventoryTypeToIsCheckedConverter % !InventoryTypeToIsCheckedConverterG	   AMediaInventory.Resources.IsCheckedOutToAlternateRowColorConverter , (IsCheckedOutToAlternateRowColorConverterE
   ?MediaInventory.Resources.IsCheckedOutToBackgroundColorConverter *	 &IsCheckedOutToBackgroundColorConverter>   8MediaInventory.Resources.IsCheckedOutToRowColorConverter #
 IsCheckedOutToRowColorConverter:   4MediaInventory.Resources.IsCheckedOutToTextConverter  IsCheckedOutToTextConverter@   :MediaInventory.Resources.IsWantedOwnedBackgroumdConnverter % !IsWantedOwnedBackgroumdConnverter9   3MediaInventory.Resources.IsWantedOwnedTextConverter  IsWantedOwnedTextConverter3   -MediaInventory.Resources.MeasurementConverter  MeasurementConverter8   2MediaInventory.Resources.MovieGroupHeaderConverter  MovieGroupHeaderConverter>   8MediaInventory.Resources.MovieGroupHeaderPluralConverter # MovieGroupHeaderPluralConverter7   1MediaInventory.Resources.NullToCollapsedConverter  NullToCollapsedConverter4   .MediaInventory.Resources.NullToStringConverter  NullToStringConverter8   2MediaInventory.Resources.NullToVisibilityConverter  NullToVisibilityConverter4   .MediaInventory.Resources.PrepCookTimeConverter  PrepCookTimeConverterA   ;MediaInventory.Resources.StringContentToVisibilityConverter & "StringContentToVisibilityConverter9   3MediaInventory.Resources.TotalPrepCookTimeConverter  TotalPrepCookTimeConverter@   :MediaInventory.Resources.ValuationBackgroundColorConverter % !ValuationBackgroundColorConverter5   /MediaInventory.Resources.ValuationTextConverter  ValuationTextConverter " HeaderContentControlBackground �� EndPoint �� 
StartPoint � Color � Offset . *InvalidLoginHeaderContentControlBackground  CancelButtonBorderBrush �� Color  CancelButtonBackground  CancelButtonForeground  CancelButtonMouseOver  CancelButtonPressed   CancelButtonFocused "! DataGridColumnHeaderBackground #" DataGridColumnHeaderBorderBrush "# DataGridColumnHeaderForeground $ DisabledBackground % DisabledForeground $&  HeaderContentControlLineSepColor "' HeaderContentControlForeground ( InvalidBackground ) InvalidForeground 0* ,InvalidLoginHeaderContentControlLineSepColor '+ #InvalidLoginHeaderControlForeground , NormalButtonBorderBrush - NormalButtonBackground . NormalButtonForeground / NormalButtonMouseOver 0 NormalButtonPressed 1 NormalButtonFocused 2 NormalMenuItemBackground 3 NormalMenuItemBorderBrush 4 NormalMenuItemForeground 5 TextBlockForeground 6 BorderThickness u� Bottom u� Left u� Right
	 u� Top 7 ButtonPadding 8 CancelExpandingButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Triggers �� Binding �� Path �� Value :� RoutedEvent g� 	BeginTime �� TargetProperty O� KeyTime O� Value 9 
LinkButton : NormalExpandingButtonStyle #; TransparentExpandingButtonStyle < glyphDefaultBordeBrush /= +checkBoxOutsideBorderDefaultBackgroundBrush +> 'checkBoxOutsideBorderDefaultBorderBrush .? *checkBoxInsideBorderDefaultBackgroundBrush *@ &checkBoxInsideBorderDefaultBorderBrush 3A /checkBoxOutsideBorderIsMouseOverBackgroundBrush /B +checkBoxOutsideBorderIsMouseOverBorderBrush 2C .checkBoxInsideBorderIsMouseOverBackgroundBrush .D *checkBoxInsideBorderIsMouseOverBorderBrush 1E -checkBoxOutsideBorderIsPressedBackgroundBrush -F )checkBoxOutsideBorderIsPressedBorderBrush 0G ,checkBoxInsideBorderIsPressedBackgroundBrush ,H (checkBoxInsideBorderIsPressedBorderBrush 1I -checkBoxOutsideBorderIsEnabledBackgroundBrush -J )checkBoxOutsideBorderIsEnabledBorderBrush 0K ,checkBoxInsideBorderIsEnabledBackgroundBrush ,L (checkBoxInsideBorderIsEnabledBorderBrush �� 
Background �� Bullet ��Name �� CornerRadius  F�Name! �� Stretch" �� StrokeDashCap# �� StrokeEndLineCap$ �� StrokeLineJoin% �� StrokeStartLineCap&   System.Windows.Controls.DataGrid& �� RelativeSource=  7System.Windows.Controls.Primitives.DataGridColumnHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader M BorderGapMaskConverter' � ColumnDefinitions( � RowDefinitions) �� Padding* J� OpacityMask+ `� 	Converter, `� ConverterParameter- �� ElementName8   2MediaInventory.CustomControls.HeaderContentControl.   Header/ J� Opacity0 ��Name $N  InvalidLoginHeaderContentControl  O NormalExpandingMenuItemStyle1 ��Name2 z� SharedSizeGroup3 �Name4 �Name5 �� AncestorType6 � IsSharedSizeScope7 K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation8   DirectionalNavigation9 d� 	IsChecked: �� Mode��%o  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 
    &	     &	 0    &	 C    &	 V    &	 i    &	 |    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 E    &	 h    &	 �    &	 �    &	 �    &	  �    &	!     &	" :    &	# ]    &	$ �    &	% �    &	& �    &	' �    &	(     &	) /    &	* R    &	+ u    &	, �    &	- �    &	. �    &	/     &	0 $    &	1 G    &	2 j    &	3 �    &	4 �    &	5 �    &	6 �    &	7 8    &	8 |    &	9 _    &	:     &	;     &	< %    &	= %%    &	> H%    &	? k%    &	@ &    &	A �&    &	B �&    &	C '    &	D �'    &	E W(    &	F z(    &	G �(    &	H E)    &	I �)    &	J *    &	K 3*    &	L �*    '�� �+    7 = 7 > 7 ? 7 @ 7 < 7 < 7 < 7 B 7 A 7 C 7 D 7 E 7 G 7 H 7 F 7 I 7 J 7 K 7 L '  28    '  �8    '  �9    &	M �9    '�� :    7 M '  �>    &	N A    &	O TC    '	� �V    '�� �Z    'd� Lb      5   
   6&     5   
   60     5   
   6(     5   
   64     5   
   6/     5   
   6/     5   
   6*     5   
   61   	  5   
   68   
  5   
   66     5   
   6/     5   
   6+     5   
   61     5   
   6*     5   
   6$     5   
   6)     5   
   6/     5   
   6(     5   
   6%     5   
   6)     5   
   6%     5    
   62     5!   
   6*     5"   
   61     5#   
   6&   �� 5%   
   $ 0.5,0&�6E   $ 0.5,1&�6V   .��5&      � $ 	#FF058686��6   $ 0Q�6-   � 5'      $ 	#FF0F5DA3��6   $
 0.17Q�6-   � 5(      $ 	#FF13477B��6   $
 0.28Q�6-   � 5)      $ 	#FF19263F��6   $
 0.66Q�6-   � 5*      $ 	#FF12283F��6   $ 1Q�6-   5+      �� 5,   
   $ 0.5,0&�6Q   $ 0.5,1&�6b   .��5-      � $ 	#FFA00610��6   $ 0Q�6-   � 5.      $ 	#FFBB1123��6   $
 0.17Q�6-   � 5/      $ 	#FF8D1620��6   $
 0.28Q�6-   � 50      $ 	#FF8D1620��6   $
 0.66Q�6-   � 51      $ 	#FF471418��6   $ 1Q�6-   52      �� 54   
   $ 	#FF783C3B��6:   �� 55   
   $ 	#FF783C3B��69   �� 56   
   $ 	#FFFFFFFF��69   �� 57   
   $ 	#FFB46765��68   �� 58   
   $ 	#FFD5ABAA��66   �� 59   
   $ 	#FF6A6A6A��66   �� 5:   
   $ 	#FF354B6C��6A   �� 5;   
   $ 	#FF373737��6B   �� 5<   
   $ 	#FFFFFFFF��6A   �� 5=   
   $ 	#FF6A6A6A��65   �� 5>   
   $ 	#FF783C3B��65   �� 5?   
   $ 	#A6FFFFFF��6C   �� 5@   
   $ 	#FFFFFFFF��6A   �� 5A   
   $ 	#FF6A6A6A��64   �� 5B   
   $ 	#FF783C3B��64   �� 5C   
   $ 	#A6A00610��6O   �� 5D   
   $ 	#FFFFFFFF��6F   �� 5E   
   $ 	#FF354A6C��6:   �� 5F   
   $ 	#FF354A6C��69   �� 5G   
   $ 	#FFFFFFFF��69   �� 5H   
   $ 	#FF597BAE��68   �� 5I   
   $ 	#FF9EB2CF��66   �� 5J   
   $ 	#FF6A6A6A��66   �� 5K   
   $ 	#FF354A6C��6;   �� 5L   
   $ 	#FF373737��6<   �� 5M   
   $ 	#FFFFFFFF��6;   �� 5N   
   $ 	#FFFFFFFF��66   u� 5P   
   $ 1Q�6,   $ 1Q�67   $ 1Q�6@   $	 1Q�6J   u� 5Q   
   $ 3Q�6*   $ 16Q�65   $ 16Q�6?   $	 3Q�6J   �� 5S   
   "
 ��63   .�5T      ��  �@�FocusVisualStyle 61   Z� �� 5U       � ��# �  6+   �� 5V       � ��# �  6,   �� 5W       � ��# � 6 60   �� 5X       � ��# �  6+   �� 5Y       � ��$ Center=�6;   �� 5Z       � ��$ Center=�69   �� 5[       � ��# � 7 6(   �� 5\       �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5]       � �� 5^      �� 5_      " ��6&   .R�5`      �� $��Chrome��6!   #��z��6/   #��z��6Y   #��z��6�    . ._�5a      �� $��	Presenter��6/   #��z��6@   #��z��6c   #��z��6�   ��. # z 5b   /   5c       5d      P� 5e       � {� .  . �5f   "   �� # � $ 6?    � ���� 5g   "   # � % 6?    � ��5h      P� 5i       �@J�IsMouseOver . . �5j   "   �� # �  6?    � ��5k      P� 5l       � �� . . �5m   "   �� # �  6?    � ��5n      P� 5o       �@J�	IsFocused . . �5p   "   �� $ Chrome��6)   # �   6T    � ��5q      5s      5u       5v      �� 5w       6   �� $ IsValid�	 False6?   .a�5x      ��  � ��# � ( 63   �� 5y       � ��# � ) 63   5z      :� 5{      $ Mouse.MouseEnter��6   .[�5|      �� .��5}      �� .��5~      U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5   "   �� $ 00:00:00.2000000��67    1.26R   5�      U� 5�      $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�   "   �� $ 00:00:00.2000000��67    1.26R   5�      5�      5�      5�      :� 5�      $ Mouse.MouseLeave��6   .[�5�      �� .��5�      �� .��5�      U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5�   "   �� $ 00:00:00��67    1.26J   �� 5�   "   $ 00:00:00.2000000��67    16R   5�      U� 5�      $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�   "   �� $ 00:00:00��67    1.26J   �� 5�   "   $ 00:00:00.2000000��67    16R   5�      5�      5�      5�      5�      �� 5�   
   "
 ��6#   .�5�      ��  � ��
 �����6+   �� 5�       � ��$ Center=�64   �� 5�       � ��$ 0q�6'   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��10(�6$   �� 5�   "   5�      5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 �  ��63   �� 5�       �@�Cursor$
 Hand��6/   5�      5�      �� 5�   
   "
 ��63   .�5�      ��  �@�FocusVisualStyle 61   Z� �� 5�       � �� �	#FF354B6C6+   �� 5�       � ��# � , 6,   �� 5�       � ��# � 6 60   �� 5�       � �� �	#FFFFFFFF6+   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��# � 7 6(   �� 5�       �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��Chrome��6!   #��z��6/   #��z��6Y   #��z��6�    . ._�5�      �� $��	Presenter��6/   #��z��6@   #��z��6c   #��z��6�   ��. # z 5�   /   5�       5�      P� 5�       � {� .  . �5�   "   �� # � $ 6?    � ���� 5�   "   # � % 6?    � ��5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� # � / 6?    � ��5�      P� 5�       � �� . . �5�   "   �� # � 0 6?    � ��5�      P� 5�       �@J�	IsFocused . . �5�   "   �� $ Chrome��6)   # � 1 6T    � ��5�      5�      5�       5�      �� 5�       6   �� $ IsValid�	 False6?   .a�5�      ��  � ��# � ( 63   �� 5�       � ��# � ) 63   5�      :� 5�      $ Mouse.MouseEnter��6   .[�5�      �� .��5�      �� .��5�      U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5�   "   �� $ 00:00:00.2000000��67    1.26R   5�      U� 5�      $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�   "   �� $ 00:00:00.2000000��67    1.26R   5�      5�      5�      5�      :� 5�      $ Mouse.MouseLeave��6   .[�5�      �� .��5�      �� .��5�      U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5�   "   �� $ 00:00:00��67    1.26J   �� 5�   "   $ 00:00:00.2000000��67    16R   5�      U� 5�      $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�   "   �� $ 00:00:00��67    1.26J   �� 5�   "   $ 00:00:00.2000000��67    16R   5�      5�      5�      5�      5�      �� 5�   
   "
 ��68   .�5�      ��  �@�FocusVisualStyle 61   Z� �� 5�       � ��
 ���� 6+   �� 5�       � ��
 ���� 6,   �� 5�       � ��# � 6 60   �� 5�       � ��# �  6+   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��# � 7 6(   �� 5�       �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��Chrome��6!   #��z��6/   #��z��6Y   #��z��6�    . ._�5�      �� $��	Presenter��6/   #��z��6@   #��z��6c   #��z��6�   ��. # z 5�   /   5�       5      P� 5      � {� .  . �5  "   �� # � $ 6?    � ���� 5  "   # � % 6?    � ��5     P� 5      �@J�IsMouseOver . . �5  "   ��  � ��
 ���� 6?   5     P� 5      � �� . . �5	  "   ��  � ��
 ���� 6?   5
     P� 5      �@J�	IsFocused . . �5  "   �� $ Chrome��6)    � ��
 ���� 6T   5     5     5      5     �� 5      6   �� $ IsValid�	 False6?   .a�5     ��  � ��
 ���� 63   �� 5      � ��
 ���� 63   5     :� 5     $ Mouse.MouseEnter��6   .[�5     �� .��5     �� .��5     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5  "   �� $ 00:00:00.2000000��67    1.26R   5     U� 5     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5  "   �� $ 00:00:00.2000000��67    1.26R   5     5      5!     5"     :� 5#     $ Mouse.MouseLeave��6   .[�5$     �� .��5%     �� .��5&     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5'  "   �� $ 00:00:00��67    1.26J   �� 5(  "   $ 00:00:00.2000000��67    16R   5)     U� 5*     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5+  "   �� $ 00:00:00��67    1.26J   �� 5,  "   $ 00:00:00.2000000��67    16R   5-     5.     5/     50     52     �� 54  
   $ 	#FF4F6982��69   �� 55  
   $ 	#FFF4F4FF��6N   �� 56  
   $ 	#FF8484FF��6J   �� 57  
   $ 0.854,0.854&�6Q   $ 0.146,0.146&�6h   .��58     � $ 	#FFCACFFF��6   $ 0Q�6-   � 59     $ 	#FFF6F6FF��6   $ 1Q�6-   5:     �� 5;  
   $ 0.854, 0.854&�6M   $ 0.146, 0.146&�6e   .��5<     � $ 	#FFA2ACFF��6   $ 0Q�6-   � 5=     $ 	#FFE4E6FF��6   $ 1Q�6-   5>     �� 5?  
   $ 	#FFF4F4F4��6R   �� 5@  
   $ 	#FF848484��6N   �� 5A  
   $ 0.854, 0.854&�6U   $ 0.146, 0.146&�6m   .��5B     � $ 	#FFA4A7ED��6   $ 0Q�6-   � 5C     $ 	#FFE3E3F9��6   $ 1Q�6-   5D     �� 5E  
   $ 0.854, 0.854&�6Q   $ 0.146, 0.146&�6i   .��5F     � $ 	#FF6E77E0��6   $ 0Q�6-   � 5G     $ 	#FFC7C8F4��6   $ 1Q�6-   5H     �� 5I  
   $ 	#FFE5ECF7��6P   �� 5J  
   $ 	#FF8484FF��6L   �� 5K  
   $ 0.854,0.854&�6S   $ 0.146,0.146&�6j   .��5L     � $ 	#FF5B6EE1��6   $ 0Q�6-   � 5M     $ 	#FFCECEF7��6   $ 1Q�6-   5N     �� 5O  
   $ 0.854,0.854&�6O   $ 0.146,0.146&�6f   .��5P     � $ 	#FF2087C9��6   $ 0Q�6-   � 5Q     $ 	#FFA4CDEB��6   $ 1Q�6-   5R     �� 5S  
   $ 	#FFFFFFFF��6P   �� 5T  
   $ 	#FFAEB1B5��6L   �� 5U  
   $ 0.854,0.854&�6S   $ 0.146,0.146&�6j   .��5V     � $ 	#FFEEF0F2��6   $ 0Q�6-   � 5W     $ 	#FFFFFFFF��6   $ 0.976Q�6-   5X     �� 5Y  
   $ 0.854,0.854&�6O   $ 0.146,0.146&�6f   .��5Z     � $ 	#FFE0E2E5��6   $ 0Q�6-   � 5[     $ 	#FFF2F3F3��6   $ 1Q�6-   5\     �� 5]  
   "
 ��6   .�5^     ��  � �� �	#FF8700006+   �� 5_      �@J�SnapsToDevicePixels . 64   �� 5`      �@�OverridesDefaultStyle . 66   �� 5a      � �� 5b     �� 5c     " ��6&   .R�5d     �� 
 ����  5e     � 5f  "   $��13��6'   $��13��62   ���	#FFF4F4F4.+�5g  &   �� $ OutsideBorder��6-   8��  8�� #��� 6 6�   ._�5h  *   �� $ InsideBorder��61   $��1q�6G   $
��Auto��6R   $
��Auto��6_   $��1q�6m   8�� 8�� 5i  1   5j  '   �� 5k  &   $ 	nullCheck��6-   8�� $��3q�6u   $ 1��6�   $y�	Collapsed=�6�   F� 5l  &   $  	CheckMark��6+   8�� $
! Fill=�6m   8�� $" Round=�6�   $# Round=�6�   $$ Round=�5m  +   $% Round=�6B   $��1��6]   $��Stretch=�6q   $��3, 2, 2.125, 2.375q�6�   $
��Auto��6�   :����A� ��- Q8�Y �"Yvw7#@Q� ; ȫSUU@Q�W �x�"�@	5n  +   5o  #   ._�5q     �� #��z��6/   #��z��6r   #��z��6�   ��. 5r  /   5s      5t     P� 5u      6;   Z�  �@d�	IsChecked. �5v  "   �� $ 	nullCheck��6)    � y�$ Visible=�6V   �� 5w  "   $ 	CheckMark��6Q    � y�$ 	Collapsed=�6?   6Q   5x     P� 5y      �@d�	IsChecked$ falseY�6;   . �5z  "   �� $ 	CheckMark��6Q    � y�$ 	Collapsed=�6?   6Q   5{     P� 5|      �@J�IsMouseOver . . �5}  "   �� $ OutsideBorder��6@   8   � ��6[   �� 5~  "   $ OutsideBorder��6?   8   � ��6Z   �� 5  "   $ InsideBorder��6?   8 	  � ��6Y   �� 5�  "   $ InsideBorder��6@   8 
  � ��6Z   5�     P� 5�      � �� . . �5�  "   �� $ OutsideBorder��6?   8   � ��6Z   �� 5�  "   $ InsideBorder��6?   8   � ��6Y   �� 5�  "   $ InsideBorder��6@   8   � ��6Z   �� 5�  "   $ OutsideBorder��6@   8   � ��6[   5�     P� 5�      � {� .  . �5�  "   �� $ OutsideBorder��6?   8   � ��6Z   �� 5�  "   $ OutsideBorder��6@   8   � ��6[   �� 5�  "   $ InsideBorder��6?   8   � ��6Y   �� 5�  "   $ InsideBorder��6@   8   � ��6Z   5�     5�     5�      5�     :� 5�     $ Mouse.MouseEnter��6   .[�5�     �� .��5�     �� .��5�     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5�  "   �� $ 00:00:00.2000000��67    1.26R   5�     U� 5�     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�  "   �� $ 00:00:00.2000000��67    1.26R   5�     5�     5�     5�     :� 5�     $ Mouse.MouseLeave��6   .[�5�     �� .��5�     �� .��5�     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5�  "   �� $ 00:00:00��67    1.26J   �� 5�  "   $ 00:00:00.2000000��67    16R   5�     U� 5�     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�  "   �� $ 00:00:00��67    1.26J   �� 5�  "   $ 00:00:00.2000000��67    16R   5�     5�     5�     5�     5�     �� 5�  
   "
  6    5�     �� 5�      6   �� *Items.Count+& �� *Self+ 06d   .a�5�     ��  � y�$ 	Collapsed=�63   5�     5�     �� 5�  
   "
  6   .�5�     ��  � ��# � ! 6+   �� 5�      � ��# � " 6,   �� 5�      � ��# � 6 60   �� 5�      � ��$
 Bold"�6+   �� 5�      � ��# � # 6+   5�     �� 5�  
   "
  6   .�5�     ��  � ��$ 0��6&   5�     �� 5�  
   6!   �� 5�  
   "
 ��6   .�5�     ��  � �� �	#FF3737376+   �� 5�      � ��# � 0 6,   �� 5�      � ��$ 1q�60   �� 5�      � ��# � 0 6+   �� 5�      � �� 5�     �� 5�     " ��6&   .R�5�     �  . ' 5�     �� 5�  "   $��6 �63   �� 5�  "   $
��Auto �63   �� 5�  "   $��* �63   �� 5�  "   $��6 �63   ( 5�     �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $��* �60   �� 5�  "   $��6 �60   .+�5�     �� $��0��6%   $��4��65   $��1��6I   $��3��6V   #��z��6g   
������ #��z��6�   $ 4��6�   �� 5�     $ Header��6%   $��1��65   $��0��6E   $��2��6R   $
) 3, 1q�6c   ._�5�  "   �� $��Header��63   ��. # z 6e   5�     �� 5�     $��2��6/   $��1��6<   $��2��6L   #��z��6`   # z 6�   �� 5�     $��4��6%   $��1��69   $��3��6F   #��z��6W   #��z��6�   $ 3��6�   * 5�  "   `� 5�  &   8+   $, 7��6g   .1�5�  *   �� $- Header��62   $ ActualWidth�6G   �� 5�  *   $ ActualWidth�62   & 6E   �� *Self+�� 5�  *   $ ActualHeight�62   & 6F   �� *Self+5�  '   5�     5�     5�     5�     5�     �� 5�  
   "
  6   .�5�     ��  � �� 5�     �� 5�     "  6&   .R�5�     �  . $��2q�6:   ( 5�     �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $��* �60   .+�5�     �� $��0��6(   $��0q�65   #���  6@   �� 5�     $��0��6/   $
��5, 1q�6<   #��� ' 6J   $��Center=�6�   $
��Bold"�6�   #��z. 6�    . 6�   �� 5�     $��1��6(   $��0q�65   $��2��6@   #��� & 6K   $/ 1Q�6�   �� 5�     $0 PART_Content��6/   $��2��6E   $��
0, 2, 0, 0q�6R   5�     5�     5�     5      �� 5  
   "
  69   .�5     ��  � �� 5     �� 5     "  6&   .R�5     �  . $��2q�6:   ( 5     �� 5  "   $
��Auto �60   �� 5	  "   $
��Auto �60   �� 5
  "   $��* �60   .+�5     �� $��0��6(   $��0q�65   #���  6@   �� 5     $��0��6/   $
��5, 1q�6<   #��� + 6J   $��Center=�6�   $
��Bold"�6�   #��z. 6�    . 6�   �� 5     $��1��6(   $��0q�65   $��2��6@   #��� * 6K   $/ 1Q�6�   �� 5     $0 PART_Content��6/   $��2��6E   $��
0, 2, 0, 0q�6R   5     5     5     5     �� 5!  
   "
 m�65   .�5"     ��  �@�FocusVisualStyle 61   Z� �� 5#      � ��# � 2 6+   �� 5$      � ��# � 3 6,   �� 5%      � ��# � 6 60   �� 5&      � ��# � 4 6+   �� 5'      � ��$ Center=�6;   �� 5(      � ��$ Center=�69   �� 5)      � ��# � 7 6(   �� 5*      �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5+      � �� 5,     �� 5-     " m�6&   .R�5.     �� $ Border��6!   #��z��61   #��z��6[   #��z��6�   ._�5/     � ' 50  "   �� 51  &   $
1 Col0��67   $��17��6E   $
��Auto �6S   $2 MenuItemIconColumnGroup��6`   �� 52  &   $
��Auto �67   $2 MenuTextColumnGroup��6D   �� 53  &   $
��Auto �67   $2 MenuItemIGTColumnGroup��6D   �� 54  &   $
1 Col3��67   $��14 �6E   .+�56  "   �� $
0 Icon��6W   $��0��63   $��
4, 0, 6, 0q�6C   $��Center=�6e   $
��Icon��6�   � 57  "   $3 
GlyphPanel��6_   $��0��6'   $y�Hidden=�67   $��
4, 0, 6, 0q�6K   $��Center=�6s   .+�58  &   F� $  GlyphPanelpath��6+   $��Center=�6C   #��z��6^   =����    �� �     >I Ѡ%& @�p �`Vl ��* �`Vl     Ѡ%& �0F 	$��LeftToRight=�6�   59  #   �� 5:  "   $0 
HeaderHost��6f   $��1��63   #��z��6C   ��. $��Header��6�   �� 5;  "   $0 IGTHost��6Q   $��2��63   $
��8, 1q�6C   $��InputGestureText��6b   $��Center=�6�   � 5<  "   $3 
ArrowPanel��6K   $��3��6'   $��
4, 0, 6, 0q�67   $��Center=�6_   .+�5=  &   F� $  ArrowPanelPath��6+   $��Right=�6C   $��Center=�6_   #��z��6z   "����        �     z � 	=  	= 	6�   5>  #   � 5?  "   $4 SubMenuPopup��6�   $��Right=�6   |�.  #��� -�6�   ��6(   �� $ IsSubmenuOpen�& �� *TemplatedParent+.��5@  &   �� $ SubMenuBorder��6-   $��1q�6�   $) 2q�6�   ��6D   �� $ 
Foreground�& �� "5 o�._�5A  *   � $3 SubMenu��6/   6 . .+�5B  .   �� 7 . $8 Cycle=�6L   5C  +   5D  '   5E  #   5F     5G      5H     P� 5I      �@m�Role$ TopLevelHeader=�66   . �5J  "   ��  � ��$
 6, 1q�6<   �� 5K  "   $ SubMenuPopup��6M    � ��$ Bottom=�6>   6M   �� 5L  "   $
 Col0��6G    � ��$ 0��6=   6G   �� 5M  "   $
 Col3��6G    � ��$
 Auto �6:   6G   �� 5N  "   $
 Icon��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5O  "   $ 
GlyphPanel��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5P  "   $ IGTHost��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5Q  "   $ 
ArrowPanel��6Q    � y�$ 	Collapsed=�6?   6Q   5R     P� 5S      �@m�Role$ TopLevelItem=�66   . �5T  "   ��  � ��$
 6 ,1q�6<   �� 5U  "   $ 
ArrowPanel��6Q    � y�$ 	Collapsed=�6?   6Q   5V     P� 5W      �@m�Role$ SubmenuHeader=�66   . �5X  "   ��  � ��$	 Top=�6C   �� 5Y  "    � ��$
 0, 2q�6<   5Z     P� 5[      �@m�Role$ SubmenuItem=�66   . �5\  "   ��  � ��$	 Top=�6C   �� 5]  "    � ��$
 0, 2q�6<   �� 5^  "   $ 
ArrowPanel��6Q    � y�$ 	Collapsed=�6?   6Q   5_     P� 5`     " �@m�IsSuspendingPopupAnimation . . �5a  "   �� $ SubMenuPopup��6P    � ��$
 None=�6C   6P   5b     P� 5c      66   Z�  �@m�Icon. �5d  "   �� $
 Icon��6Q    � y�$ 	Collapsed=�6?   6Q   5e     P� 5f      �@m�	IsChecked . . �5g  "   �� $ 
GlyphPanel��6O    � y�$ Visible=�6?   6O   �� 5h  "   $
 Icon��6Q    � y�$ 	Collapsed=�6?   6Q   5i     P� 5j      �@m�IsHighlighted . . �5k  "   �� # � 0 6?   $ Border��6m    � ��5l     P� 5m      � {� .  . �5n  "   �� # � $ 6?    � ���� 5o  "   # � % 6?    � ��5p     5r     5t      5u     �� 5v      6   �� $ IsValid�	 False6?   .a�5w     ��  � ��# � ( 63   �� 5x      � ��# � ) 63   5y     :� 5z     $ Mouse.MouseEnter��6   .[�5{     �� .��5|     �� .��5}     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5~  "   �� $ 00:00:00.2000000��67    1.26R   5     U� 5�     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�  "   �� $ 00:00:00.2000000��67    1.26R   5�     5�     5�     5�     :� 5�     $ Mouse.MouseLeave��6   .[�5�     �� .��5�     �� .��5�     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5�  "   �� $ 00:00:00��67    1.26J   �� 5�  "   $ 00:00:00.2000000��67    16R   5�     U� 5�     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5�  "   �� $ 00:00:00��67    1.26J   �� 5�  "   $ 00:00:00.2000000��67    16R   5�     5�     5�     5�     5�     �� 5�  
   "
 	�6   .�5�     ��  �@�FocusVisualStyle 61   Z� �� 5�      � ��# � - 6+   �� 5�      � ��# � , 6,   �� 5�      � ��# � 6 60   �� 5�      � ��# � . 6+   �� 5�      � ��$ Center=�6;   �� 5�      � ��$ Center=�69   �� 5�      � ��# � 7 6(   �� 5�      �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5�      � �� 5�     �� 5�     " 	�6&   .R�5�     d� 9 6'   �� *	IsChecked+& �� *TemplatedParent+$: TwoWay=���6�   �� *	Content+& �� *TemplatedParent+$: TwoWay=���5�  '   �� *
Background+& �� *TemplatedParent+$: TwoWay=�z�5�     V� 5�  "   .~�5�  &   �� �� 5�  &   �� 5�  &   T� 5�  &   5�  #   5�      5�     P� 5�      �@d�	IsChecked$
 TrueY�6;   . �5�  "   �� # � 0 6?    � ��5�     P� 5�      �@d�	IsChecked$ FalseY�6;   . �5�  "   �� # � - 6?    � ��5�     5�     5�     5�     �� 5�  
   "
 ��6   .�5�     ��  �@�FocusVisualStyle 61   Z� �� 5�      � ��# � - 6+   �� 5�      � ��# � , 6,   �� 5�      � ��# � 6 60   �� 5�      � ��# � . 6+   �� 5�      � ��$ Center=�6;   �� 5�      � ��$ Center=�69   �� 5�      � ��# � 7 6(   �� 5�      �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5�      � �� 5�     �� 5�     " ��6&   .R�5�     � $��Panel��6   .+�5�     �� $0 ContentSite��6/   $��Center=�6D   $��Center=�6_   $��Header��6|   $��10, 2q�6�   5�      5�     P� 5�      �@��
IsSelected . . �5�  "   �� $ Panel��6)   # � 0 6R    � ��5�     P� 5�      �@��
IsSelected .  . �5�  "   �� $ Panel��6)   # � - 6R    � ��5�     :� 5�     $ Mouse.MouseEnter��6+   .[�5�  "   �� .��5�  &   �� .��5�  *   U� $ 00:00:00X�6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6]   .\�5�  .   �� $ 00:00:00.2000000��6C    1.26^   5�  +   U� 5�  *   $ 00:00:00X�6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6]   .\�5�  .   �� $ 00:00:00.2000000��6C    1.26^   5�  +   5�  '   5�  #   5�     :� 5�     $ Mouse.MouseLeave��6+   .[�5�  "   �� .��5�  &   �� .��5�  *   U� $ 00:00:00X�6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6]   .\�5�  .   �� $ 00:00:00��6C    1.26V   �� 5�  .   $ 00:00:00.2000000��6C    16^   5�  +   U� 5�  *   $ 00:00:00X�6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6]   .\�5�  .   �� $ 00:00:00��6C    1.26V   �� 5�  .   $ 00:00:00.2000000��6C    16^   5�  +   5�  '   5�  #   5�     5�     5�     5�     �� 5�  
   "
 d�6   .�5�     ��  �@�FocusVisualStyle 61   Z� �� 5�      � ��# � - 6+   �� 5�      � ��# � , 6,   �� 5�      � ��# � 6 60   �� 5�      � ��# � . 6+   �� 5�      � ��$ Center=�6;   �� 5�      � ��$ Center=�69   �� 5�      � ��# � 7 6(   �� 5�      �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5�      � �� 5�     �� 5�     " d�6&   .R�5      �� $��Chrome��6!   #��z��6/   #��z��6Y   #��z��6�    . ._�5     �� $��	Presenter��6/   #��z��6@   #��z��6c   #��z��6�   ��. # z 5  /   5      5     P� 5      � {� .  . �5  "   �� # � $ 6?    � ���� 5  "   # � % 6?    � ��5     P� 5	      �@J�IsMouseOver . . �5
  "   �� # � / 6?    � ��5     P� 5      �@d�	IsChecked$
 TrueY�6;   . �5  "   �� # � 0 6?    � ��5     P� 5      �@J�	IsFocused . . �5  "   �� $ Chrome��6)   # � 1 6T    � ��5     5     5      5     �� 5      6   �� $ IsValid�	 False6?   .a�5     ��  � ��# � ( 63   �� 5      � ��# � ) 63   5     :� 5     $ Mouse.MouseEnter��6   .[�5     �� .��5     �� .��5     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5  "   �� $ 00:00:00.2000000��67    1.26R   5      U� 5!     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5"  "   �� $ 00:00:00.2000000��67    1.26R   5#     5$     5%     5&     :� 5'     $ Mouse.MouseLeave��6   .[�5(     �� .��5)     �� .��5*     U� $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6Q   .\�5+  "   �� $ 00:00:00��67    1.26J   �� 5,  "   $ 00:00:00.2000000��67    16R   5-     U� 5.     $ 00:00:00X�6<   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6Q   .\�5/  "   �� $ 00:00:00��67    1.26J   �� 50  "   $ 00:00:00.2000000��67    16R   51     52     53     54     56     57     58     