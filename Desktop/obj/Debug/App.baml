   M S B A M L   `   `   `  ����E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:De.HsFlensburg.Client078.Ui.Desktop#De.HsFlensburg.Client078.Ui.Desktop  5      C ?Logic.Ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullmDclr-namespace:De.HsFlensburg.ClientApp078.Logic.Ui;assembly=Logic.Ui$De.HsFlensburg.ClientApp078.Logic.Ui 5      Dclr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop.MessageBusLogic6De.HsFlensburg.ClientApp078.Ui.Desktop.MessageBusLogic  5      -    'De.HsFlensburg.Client078.Ui.Desktop.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Clocal1clr-namespace:De.HsFlensburg.Client078.Ui.Desktop     5      [
viewModelsDclr-namespace:De.HsFlensburg.ClientApp078.Logic.Ui;assembly=Logic.Ui     5      XdesktopDclr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop.MessageBusLogic     5        �� 	Resources  5      ;  5De.HsFlensburg.ClientApp078.Logic.Ui.ViewModelLocator   ViewModelLocatorL   FDe.HsFlensburg.ClientApp078.Ui.Desktop.MessageBusLogic.MessageListener  MessageListener  H1 �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels �� Triggers P� Property	 P� Value  FocusVisual
 �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background 	 Button.Pressed.Border 
 Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  RoundeButton ��Name �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   	Direction   Color   Opacity   
BlurRadius ��Name �� 
TargetName  TextBox.Static.Border  TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxStyle-  'System.Windows.Input.KeyboardNavigation ��Name �� Triggers ]� 
Conditions �� Property �� Value  
LabelStyle��%�  &	        &	      &	 &     &	 V    &	      &	     &	 B    &	 c    &	 �    &		 �    &	
 �    &	 �    &	     &	 5    7  7  7  7  7  7  7 	 7 
 7  7  &	 �	    &	 
    &	 <
    &	 _
    7  7  7  &	 �      5	   
   6A     5
   
   6<   �� 5   
   " ��6   .�5      ��  � ��# � ��6+   �� 5       � ��
 ���� 6+   �� 5       � ��$ 5q�6(   �� 5       � ��$
 Left=�6;   �� 5       � ��$	 Top=�69   �� 5       � ��$ 20(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   # z��6�    . ._�5      �� #��z��6/   ��. # z 6�   #��z��6�   5       5      P� 5       � {�	 .  . �5   "   �� # � ��6?    � ��5      5      5!      5"      �� 5#   
   .�5$      ��  � �� 5%      �� 5&      .R�5'      �� $��2q�6$    . #��� ��6J   $��1��6�   $	
 1 2R�6�   5(      5*      5+      �� 5,   
   $ white��6;   �� 5-   
   $ 	#FF707070��67   �� 5.   
   $ #79a4e4��6>   �� 5/   
   $ 	#FF3C7FB1��6:   �� 50   
   $ 	#FFC4E5F6��6<   �� 51   
   $ 	#FF2C628B��68   �� 52   
   $ 	#FFF4F4F4��6=   �� 53   
   $ 	#FFADB2B5��69   �� 54   
   $ 	#FF838383��6=   �� 55   
   " ��6%   .�56      ��  �@�FocusVisualStyle8   61   �� 57       � ��8  6+   �� 58       � ��8  6,   �� 59       � �� �#1426456+   �� 5:       � ��$ 2q�60   �� 5;       � ��$ Center=�6;   �� 5<       � ��$ Center=�69   �� 5=       � ��$ 15q�6(   �� 5>       � ��$ Roboto)�6+   �� 5?       � ��$
 Bold"�6+   �� 5@       � ��$ 10q�6'   �� 5A       � �� 5B      �� 5C      " ��6&   .R�5D      �� $ border��6!   $ 5��61   #��z��6B   #��z��6n   #��z��6�    .  5E        5F   "   $ 0Q�5G      $ 0Q�5H      $ black��5I      $
 0.15Q�5J      $ 10Q�5K      ._�5M      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5N       5O      P� 5P       �@��IsDefaulted	 . . �5Q   "   �� $ border��6@   # � ��6T    � ��5R      P� 5S       �@J�IsMouseOver	 . . �5T   "   �� $ border��6?   8   � ��6S   �� 5U   "   $ border��6@   8   � ��6T   5V      P� 5W       � ��	 . . �5X   "   �� $ border��6?   8   � ��6S   �� 5Y   "   $ border��6@   8   � ��6T   5Z      P� 5[       � {�	 .  . �5\   "   �� $ border��6?   8   � ��6S   �� 5]   "   $ border��6@   8   � ��6T   �� 5^   "   $ contentPresenter��6K   8 	  � ��6i   5_      5a      5c      5d      �� 5e   
   $ 	#FFABAdB3��68   �� 5f   
   $ 	#FF7EB4EA��6;   �� 5g   
   $ 	#FF569DE5��67   �� 5h   
   " ��6%   .�5i      ��  � ��
 �����6+   �� 5j       � ��8   6,   �� 5k       � ��# � ��6+   �� 5l       � ��$ 0q�60   �� 5m       �@ TabNavigation$
 None=�6A   �� 5n       � ��$
 Left=�6;   �� 5o       �@�FocusVisualStyle 61   Z� �� 5p       �@J�	AllowDrop . 6*   �� 5q       �@��PanningMode$ VerticalFirst=�69   �� 5r       �@��IsFlicksEnabled .  67   �� 5s       � ��$	 200��6)   �� 5t       � ��$ 10q�6(   �� 5u       � �� 5v      �� 5w      " ��6&   .R�5x      �� $ border��6!   $ 5��61   #��z��6B   #��z��6l   #��z��6�    .  5y        5z   "   $ 0Q�5{      $ 0Q�5|      $ black��5}      $
 0.15Q�5~      $ 10Q�5      ._�5�      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5�       5�      P� 5�       � {�	 .  . �5�   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5�      P� 5�       �@J�IsMouseOver	 . . �5�   "   �� $ border��6@   8   � ��6T   5�      P� 5�       �@J�IsKeyboardFocused	 . . �5�   "   �� $ border��6@   8   � ��6T   5�      5�      5�       5�      P� 5�       �@��
IsReadOnly	 . . �5�      ��  � �� �#66663   5�      ]� 5�       5�      �� 5�      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5�       �@��IsSelectionActive .  6A   ./�5�      ��  �@��SelectionBrush# � /�67   5�      5�      �� 5�   
   " ��6#   .�5�      ��  � �� �#1426456+   �� 5�       � ��
 ���� 6+   �� 5�       � ��$
 0 10q�6(   �� 5�       � ��$
 Left=�6;   �� 5�       � ��$	 Top=�69   �� 5�       � ��$
 bold"�6+   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   #��z��6K   #��z��6w   # z��6�    . ._�5�      �� #��z��6/   ��. # z 6�   #��z��6�   5�       5�      P� 5�       � {�	 .  . �5�   "   �� # � ��6?    � ��5�      5�      5�      5�      5�      5�      