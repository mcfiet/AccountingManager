   M S B A M L   `   `   `  ����E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop&De.HsFlensburg.ClientApp078.Ui.Desktop  5   	   8    2De.HsFlensburg.ClientApp078.Ui.Desktop.OrderWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop     5   	     � Title$  OrderWindow��5   	    � SizeToContent$ Width=�5	   	   $	��800��5
   	   
�������$��Arial)�5   	    � DataContext 5      �� 5   
      ViewModelLocator �� Source# [  6    �� Path$ TheOrderWindowViewmodel�6=   6^   .��5      �� .��5   
   � .+�5      �� $��30q�6   .+�5      A� $��0��6    A� Columns$ 2��6/   .+�5      �� $��0 0 20 0q�6"   .+�5      �� $��0 15 0 0q�6%   .+�5      ��   
LabelStyle#���  6$   $��Center=�6I   $
��Left=�6d   .��6   	Kundennr.6�   �� 5        TextBoxStyle#���  6&    �� 
IsReadOnly . $��Center=�6�   ��6M   �� *IncomingOrder.Client.Id+6�   5      �� 5      $��0 15 0 0q�6%   .+�5      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   Name6�   �� 5      #���  6&    . $��Center=�6�   ��6M   �� *IncomingOrder.Client.Name+6�   5      �� 5!      $��0 15 0 0q�6%   .+�5"      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   	Straße6�   �� 5#      #���  6&    . $��Center=�6�   ��6M   �� *IncomingOrder.Client.Street+6�   5$      �� 5&      $��0 15 0 0q�6%   .+�5'      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   PLZ und Ort6�   �� 5(      #���  6&    . $��Center=�6�   ��6M   �� *IncomingOrder.Client.ZipCode+6�   5)      5+      �� 5,      .+�5.      �� $��0 15 0 0q�6%   .+�5/      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   	Betreff6�   �� 50      #���  6&   $��Center=�6v   ��6M   �� *IncomingOrder.Reference+6�   51      A� 52      $��0��6'   $ 2��67   .+�54      �� $��	0 15 10 0q�6)   .+�55   "   �� #���  6(   $��Center=�6M   $
��Left=�6h   .��6�   Angebotsnr.6�   �� 56   "   #���  6*    . $��Center=�6�   ��6Q   �� *IncomingOrder.OrderNr+6�   57      �� 59      $��	10 15 0 0q�6)   .+�5:   "   �� #���  6(   $��Center=�6M   $
��Left=�6h   .��6�   Datum6�   (  "System.Windows.Controls.DatePicker  5;   "      SelectedDate 6-   �� *IncomingOrder.Date+6[   5<      5>      5@      5B      �� 5C      $��	0 15 0 80q�6   .+�5D      �� #���  6   $��Center=�6A   $
��Left=�6\   .��6w   Anschreiben6�   �� 5E      #���  6   $��Center=�6j   $	��200��6�    �� TextWrapping$
 Wrap=�6�   	 �� AcceptsReturn	 . ��6F   �� *IncomingOrder.Text+6�   5F      �� 5G      .+�5H      ��   H1#���  6   .��69   
Positionen6E   &   System.Windows.Controls.DataGrid  5I      -   5        $��positionssDataGrid��5J      
   AutoGenerateColumns
 .     CanUserAddRows .  ��5K      �� *IncomingOrder.Positions+   Columns 5O      4  .System.Windows.Controls.DataGridCheckBoxColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Auswählen��6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
IsSelected+6T   0  *System.Windows.Controls.DataGridTextColumn  5Q      $ Positionsnr.��6P    61   �� *
PositionNr+6h     5R      $ Artikel��6R    61   �� *Article.Name+6e     5S      $ Anzahl��6N    61   �� *
Quantity+6`     5T      $ Einzelpreis��6S    61   �� *Article.Price+6j     5U      $ Gesamtpreis��6P    61   �� *
TotalPrice+6g   5W      A� 5X      $
��Left=�6"   $��Center=�6=   $ 2��6X   .+�5Y      ��   RoundeButton#���  6R   ��6!   �� *OpenAddPositionWindowCommand+.��6y   Position hinzufügen6�   �� 5Z      $��Right=�6L   
���  ��
�������#���  6�   ��6!   �� *DeletePositionsCommand+.��6�   " Ausgewählte Positionen löschen6�   5[      �� 5\      $��Gesamtpreis:��6     �� TextAlignment$ Right=�64   6L   �� 5]      $ Right=�6J   ��6    �� *IncomingOrder.TotalPrice+6b   5^      �� 5_      #���  6>   ��6   �� *ExportPdfCommand+.��6e   als PDF exportieren6z   5`      5a      5b      5c      