   M S B A M L   `   `   `  ����   
Ui.Desktop7    1De.HsFlensburg.ClientApp078.Ui.Desktop.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  
MainWindow�� � SizeToContent$ Width=�
�������$��Arial)� � DataContext ��    ViewModelLocator �� Source# [   �� Path$ TheMainWindowViewModel�{���   MessageListener# [ $ BindableProperty�.���� .��� .+��� $��30q�.+��� .@��� $��Angebote��.���� 
�������.+��� $��10q�.+���   H1#���  .��
AngeboteA�  A� Columns$ 4��$��0 0 0 30q�.+��� 
���  ��
�������  RoundeButton#���  ���� *Commands.DeleteOffersCommand+.�� Ausgewählte Angebote löschen�� #���  ���� *$"Commands.OpenNewOfferWindowCommand+ �� Mode$ OneWay=�.��Neues Angebot anlegen&   System.Windows.Controls.DataGrid  -   $��offerDataGrid��   AutoGenerateColumns .     CanUserAddRows .  ���� $' !TheAdministrationViewModel.Offers�	   Columns	 4  .System.Windows.Controls.DataGridTemplateColumn  
   CellTemplate
 �� .R��� ���� *'%DataContext.Commands.OpenOfferCommand+ �� RelativeSource ��  �� AncestorType" ����� .��	Öffnen4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .     Header$ 
Auswählen��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IsSelected+0  *System.Windows.Controls.DataGridTextColumn   . $ Angebotsnr.�� �� *	OfferNr+   . $ Betreff�� �� *	Reference+   . $ Datum�� �� *Date+ �� StringFormat$ 
dd.MM.yyyy��   . $ Kunde�� �� *Client.Name+  
 �� .R��� 
����������� *,*DataContext.Commands.ConvertToOrderCommand+ �� " ����� .��Auftrag erteilen   . $ Umgewandelt in Auftrag�� �� *	IsOrder+�� $��	Aufträge��.���� 
�������.+��� $��10q�.+��� #���  .��	AufträgeA� $ 3��$��0 0 0 30q�.+��� 
���  ��
�������#���  ���� *Commands.DeleteOrdersCommand+.��!Ausgewählte Aufträge löschen  -   $��orderDataGrid�� .   .  ���� $' !TheAdministrationViewModel.Orders�	   
 �� .R��� ���� *'%DataContext.Commands.OpenOrderCommand+ �� " ����� .��	Öffnen   .  $ 
Auswählen�� �� *
IsSelected+   . $ Auftragsnr.�� �� *	OrderNr+   . $ Betreff�� �� *	Reference+   . $ Datum�� �� *Date+$ 
dd.MM.yyyy��   . $ Kunde�� �� *Client.Name+  
 �� .R��� 
����������� *.,DataContext.Commands.ConvertToInvoiceCommand+ �� " ����� .��Rechnung schreiben   . $ Umgewandelt in Rechnung�� �� *	IsInvoice+�� $��
Rechnungen��.���� 
�������.+��� $��10q�.+��� #���  .��
RechnungenA� $ 3��$��0 0 0 30q�.+��� $
��Left=�
���  ��
�������#���  ���� * Commands.DeleteInvoicesCommand+.��" Ausgewählte Rechnungen löschen  -   $��invoiceDataGrid�� .   .  ���� $) #TheAdministrationViewModel.Invoices�   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"   �� Triggers ��  �� Binding �� *	IsPayed+ �� Value	 false.a���  �� Property � �� �� Value
 �  ����  �� *	IsPayed+ true.a���  � ��
 � � �	   
 �� .R��� ���� *)'DataContext.Commands.OpenInvoiceCommand+ �� " ����� .��	Öffnen   .  $ 
Auswählen�� �� *
IsSelected+   . $ Auftragsnr.�� �� *	OrderNr+   . $ Rechnungsnr.�� �� *	InvoiceNr+   . $ Betreff�� �� *	Reference+   . $ Datum�� �� *Date+$ 
dd.MM.yyyy��   . $ Kunde�� �� *Client.Name+   .  $ Bezahlt�� �� *	IsPayed+�� $��0 30 0 0q�.@��� $��Artikel��.���� .+�A� $ 4��$��0 0 0 30q�.+��� #���  ���� *&$Commands.OpenNewArticleWindowCommand+$ OneWay=�.��Neuen Artikel hinzufügen�� #���  ���� * Commands.ImportArticlesCommand+$ OneWay=�.��XML importieren�� #���  ���� *%#Commands.ExportArticlesToXmlCommand+$ OneWay=�.��XML exportieren�� 
���  ��
�������#���  ���� * Commands.DeleteArticlesCommand+.��Ausgewählte Artikel löschen�� #���  .��	Artikel  -   $��articlesDataGrid�� .   .  ���� $) #TheAdministrationViewModel.Articles�	    .  $ 
Auswählen�� �� *
IsSelected+   . $ 
Articlenr.�� �� *Id+   . $
 Name�� �� *Name+   . $ Beschreibung��   MaxWidth$	 150Q� �� *Description+   ElementStyle �� .���  � ��$
 Wrap=�  $ Preis�� �� *Price+�� $��Kunden��.���� .+�A� $ 4��$��0 0 0 30q�.+��� #���  ���� *%#Commands.OpenNewClientWindowCommand+$ OneWay=�.��Neuen Kunden anlegen�� #���  ���� *Commands.ImportClientsCommand+.��XML importieren�� #���  ���� *$"Commands.ExportClientsToXmlCommand+$ OneWay=�.��XML exportieren�� 
���  ��
�������#���  ���� *Commands.DeleteClientsCommand+.��Ausgewählte Kunden löschen�� #���  .��Kunden  -   $��clientDataGrid�� .   .  ���� $( "TheAdministrationViewModel.Clients�	    .  $ 
Auswählen�� �� *
IsSelected+   . $ 	Kundennr.�� �� *Id+   . $
 Name�� �� *Name+A� $ 4��.+��� #���  ���� *Commands.LoadCommand+.��Load�� $��	10 20 0 0q�#���  ���� *Commands.SaveCommand+.��Save