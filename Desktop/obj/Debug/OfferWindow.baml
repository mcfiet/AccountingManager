   M S B A M L   `   `   `  ����E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop&De.HsFlensburg.ClientApp078.Ui.Desktop  5   	   8    2De.HsFlensburg.ClientApp078.Ui.Desktop.OfferWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop     5   	   -   5          �Name$  
ThisWindow��5	   	    � Title$ OfferWindow��5   	    � SizeToContent$ Width=�5
   	   $	��800��5   	   
�������$��Arial)�5   	    � DataContext 5      �� 5   
      ViewModelLocator �� Source# [  6    �� Path$ TheOfferWindowViewmodel�6=   6^   .��5      �� .��5   
   � .+�5      �� $��30q�6   .+�5      �� $��0 0 0 30q�6   .+�5      ��   H1#���  6   .��69   Kunden6A   &   System.Windows.Controls.DataGrid  5      -   5        $��clientDataGrid��5         AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem 5      �� *SelectedClient+��5      �� $( "TheAdministrationViewModel.Clients�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Kundennr.��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6]     5      $

 Name��6J    61   �� *Name+6Z   5!      5"      A� 5#      $��0��6    A� Columns$ 2��6/   .+�5%      �� $��0 0 20 0q�6"   .+�5&      �� $��0 15 0 0q�6%   .+�5'      ��   
LabelStyle#���  6$   $��Center=�6I   $
��Left=�6d   .��6   	Kundennr.6�   �� 5(        TextBoxStyle#���  6&    �� 
IsReadOnly . $��Center=�6�   ��6M   �� *SelectedClient.Id+6�   5)      �� 5,      $��0 15 0 0q�6%   .+�5-      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   Name6�   �� 5.      #���  6&    . $��Center=�6�   ��6M   �� *SelectedClient.Name+6�   5/      �� 51      $��0 15 0 0q�6%   .+�52      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   	Straße6�   �� 53      #���  6&    . $��Center=�6�   ��6M   �� *SelectedClient.Street+6�   54      �� 56      $��0 15 0 0q�6%   .+�57      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   PLZ und Ort6�   �� 58      #���  6&    . $��Center=�6�   ��6M   �� *SelectedClient.ZipCode+6�   59      5;      �� 5<      .+�5>      �� $��0 15 0 0q�6%   .+�5?      �� #���  6$   $��Center=�6I   $
��Left=�6d   .��6   	Betreff6�   �� 5@      #���  6&   $��Center=�6v   ��6M   �� *IncomingOffer.Reference+6�   5A      A� 5B      $��0��6'   $ 2��67   .+�5D      �� $��	0 15 10 0q�6)   .+�5E   "   �� #���  6(   $��Center=�6M   $
��Left=�6h   .��6�   Angebotsnr.6�   �� 5F   "   #���  6*    . $��Center=�6�   ��6Q   �� *IncomingOffer.OfferNr+6�   5G      �� 5I      $��	10 15 0 0q�6)   .+�5J   "   �� #���  6(   $��Center=�6M   $
��Left=�6h   .��6�   Datum6�   (  "System.Windows.Controls.DatePicker  5K   "      SelectedDate 6-   �� *IncomingOffer.Date+6[   5L      5N      5P      5R      �� 5S      $��	0 15 0 80q�6   .+�5T      �� #���  6   $��Center=�6A   $
��Left=�6\   .��6w   Anschreiben6�   �� 5U      #���  6   $��Center=�6j   $	��200��6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . ��6F   �� *IncomingOffer.Text+6�   5V      �� 5W      .+�5X      �� #���  6   .��69   
Positionen6E     5Y      -   5        $��positionssDataGrid��5Z       .     CanUserAddRows .  ��5[      �� *IncomingOffer.Positions+	 5_      4  .System.Windows.Controls.DataGridCheckBoxColumn  5`      $
 
Auswählen��6T    65   �� *
IsSelected+6T     5a         
IsReadOnly . $
 Positionsnr.��6b    6C   �� *
PositionNr+6z     5b       . $
 Artikel��6d    6C   �� *Article.Name+6w     5c       .  $
 Anzahl��6a    6D   �� *
Quantity+6s     5d       . $
 Einzelpreis��6e    6C   �� *Article.Price+6|     5e       . $
 Gesamtpreis��6b    6C   �� *
TotalPrice+6y   5g      A� 5i      $
��Left=�6"   $��Center=�6=   $ 2��6X   .+�5j      �� $
��Left=�6R     RoundeButton#���  6m   ��6!   �� *OpenAddPositionWindowCommand+.��6�   Position hinzufügen6�   �� 5k      $��Right=�6L   
���  ��
�������#���  6�   ��6!   �� *DeletePositionsCommand+.��6�   " Ausgewählte Positionen löschen6�   5l      �� 5m      $��Gesamtpreis:��6     �� TextAlignment$ Right=�64   6L   �� 5n      $ Right=�6J   ��6    �� *IncomingOffer.TotalPrice+6b   5p      A� 5q      $��0��6   $ 2��6/   $��0 50 0 0q�6;   .+�5r      � $
��Left=�6   .+�5s      �� #���  6F   ��6!   �� *ExportPdfCommand+.��6m   als PDF exportieren6�   5t      � 5u      -   5         �Name$ OfferButtons��5u   7   $��Right=�6   5v      5w      5x      5y      5z      5{      