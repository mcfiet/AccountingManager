   M S B A M L   `   `   `  ���� E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop&De.HsFlensburg.ClientApp078.Ui.Desktop  :    4De.HsFlensburg.ClientApp078.Ui.Desktop.InvoiceWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Flocal4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop       � Title$  InvoiceWindow�� � SizeToContent$ Width=�$	��800��
�������$��Arial)� � DataContext ��    ViewModelLocator �� Source# [   �� Path$ TheInvoiceWindowViewmodel�.���� .��� .+��� $��30q�.+�A� $��0�� A� Columns$ 2��.+��� $��0 0 20 0q�.+��� $��0 15 0 0q�.+���   
LabelStyle#���  $��Center=�$
��Left=�.��	Kundennr.��   TextBoxStyle#���   �� 
IsReadOnly . $��Center=����� *IncomingInvoice.Client.Id+�� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��Name�� #���   . $��Center=����� *IncomingInvoice.Client.Name+�� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��	Straße�� #���   . $��Center=����� *IncomingInvoice.Client.Street+�� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��PLZ und Ort�� #���   . $��Center=����� * IncomingInvoice.Client.ZipCode+�� .+��� $��0 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��	Betreff�� #���  $��Center=����� *IncomingInvoice.Reference+A� $��0��$ 2��.+��� $��	0 15 10 0q�.+��� #���  $��Center=�$
��Left=�.��Auftragsnr.�� #���   . $��Center=����� *IncomingInvoice.OrderNr+�� $��	10 15 0 0q�.+��� #���  $��Center=�$
��Left=�.��Datum(  "System.Windows.Controls.DatePicker     SelectedDate �� *IncomingInvoice.Date+�� $��	0 15 10 0q�.+��� #���  $��Center=�$
��Left=�.��Rechnungsnr.�� #���   . $��Center=����� *IncomingInvoice.InvoiceNr+�� $��	0 15 0 80q�.+��� #���  $��Center=�$
��Left=�.��Anschreiben�� #���  $��Center=�$	��200�� �� TextWrapping$
 Wrap=�	 �� AcceptsReturn	 . ���� *IncomingInvoice.Text+�� .+���   H1#���  .��
Positionen&   System.Windows.Controls.DataGrid  -   $��positionssDataGrid��
   AutoGenerateColumns
 .     CanUserAddRows .  ���� *IncomingInvoice.Positions+   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Auswählen��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IsSelected+0  *System.Windows.Controls.DataGridTextColumn  $ Positionsnr.�� �� *
PositionNr+  $ Artikel�� �� *Article.Name+  $ Anzahl�� �� *
Quantity+  $ Einzelpreis�� �� *Article.Price+  $ Gesamtpreis�� �� *
TotalPrice+A� $
��Left=�$��Center=�$ 2��.+���   RoundeButton#���  ���� *OpenAddPositionWindowCommand+.��Position hinzufügen�� $��Right=�
���  ��
�������#���  ���� *DeletePositionsCommand+.��" Ausgewählte Positionen löschen�� $��Gesamtpreis:�� �� TextAlignment$ Right=��� $ Right=����� *IncomingInvoice.TotalPrice+A� $��0��$ 2��$��0 50 0 0q�.+��� #���  ���� *ExportPdfCommand+.��als PDF exportieren