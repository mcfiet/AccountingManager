   M S B A M L   `   `   `  ���� E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop&De.HsFlensburg.ClientApp078.Ui.Desktop  8    2De.HsFlensburg.ClientApp078.Ui.Desktop.OfferWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Flocal4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop     -     �Name$  
ThisWindow�� � Title$ OfferWindow�� � SizeToContent$ Width=�$	��800��
�������$��Arial)� � DataContext ��    ViewModelLocator �� Source# [   �� Path$ TheOfferWindowViewmodel�.���� .��� .+��� $��30q�.+��� $��0 0 0 30q�.+���   H1#���  .��Kunden&   System.Windows.Controls.DataGrid  -   $��clientDataGrid��   AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem �� *SelectedClient+���� $( "TheAdministrationViewModel.Clients�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Kundennr.��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $

 Name�� �� *Name+A� $��0�� A� Columns$ 2��.+��� $��0 0 20 0q�.+��� $��0 15 0 0q�.+���   
LabelStyle#���  $��Center=�$
��Left=�.��	Kundennr.��   TextBoxStyle#���   �� 
IsReadOnly . $��Center=����� *SelectedClient.Id+�� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��Name�� #���   . $��Center=����� *SelectedClient.Name+�� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��	Straße�� #���   . $��Center=����� *SelectedClient.Street+�� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��PLZ und Ort�� #���   . $��Center=����� *SelectedClient.ZipCode+�� .+��� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��	Betreff�� #���  $��Center=����� *IncomingOffer.Reference+A� $��0��$ 2��.+��� $��	0 15 10 0q�.+��� #���  $��Center=�$
��Left=�.��Angebotsnr.�� #���   . $��Center=����� *IncomingOffer.OfferNr+�� $��	10 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��Datum(  "System.Windows.Controls.DatePicker     SelectedDate �� *IncomingOffer.Date+�� $��	0 15 0 80q�.+��� #���  $��Center=�$
��Left=�.��Anschreiben�� #���  $��Center=�$	��200�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . ���� *IncomingOffer.Text+�� .+��� #���  .��
Positionen  -   $��positionssDataGrid�� .     CanUserAddRows .  ���� *IncomingOffer.Positions+	 4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 
Auswählen�� �� *
IsSelected+     
IsReadOnly . $
 Positionsnr.�� �� *
PositionNr+   . $
 Artikel�� �� *Article.Name+   .  $
 Anzahl�� �� *
Quantity+   . $
 Einzelpreis�� �� *Article.Price+   . $
 Gesamtpreis�� �� *
TotalPrice+A� $
��Left=�$��Center=�$ 2��.+��� $
��Left=�  RoundeButton#���  ���� *OpenAddPositionWindowCommand+.��Position hinzufügen�� $��Right=�
���  ��
�������#���  ���� *DeletePositionsCommand+.��" Ausgewählte Positionen löschen�� $��Gesamtpreis:�� �� TextAlignment$ Right=��� $ Right=����� *IncomingOffer.TotalPrice+A� $��0��$ 2��$��0 50 0 0q�.+�� $
��Left=�.+��� #���  ���� *ExportPdfCommand+.��als PDF exportieren� -    �Name$ OfferButtons��$��Right=�