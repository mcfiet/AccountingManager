   M S B A M L   `   `   `  ����  
Ui.Desktop7    1De.HsFlensburg.ClientApp078.Ui.Desktop.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	    � SizeToContent$ Width=�5   	   
�������$��Arial)�5
   	    � DataContext 5      �� 5   
      ViewModelLocator �� Source# [  6    �� Path$ TheMainWindowViewModel�6=   6]   {�5      �� 5   
     MessageListener# [ 6   $ BindableProperty�6>   6Y   .��5      �� .��5   
   � .+�5      �� $��30q�6   .+�5      �� .@�5      �� $��Angebote��6   .��5      �� 
�������.+�5      �� $��10q�6)   .+�5   "   ��   H1#���  6(   .��6E   
Angebote6O   A� 5   "    A� Columns$ 4��6.   $��0 0 0 30q�6:   .+�5   &   �� 
���  ��
�������  RoundeButton#���  6�   ��6-   �� *Commands.DeleteOffersCommand+.��6�    Ausgewählte Angebote löschen6�   �� 5   &   #���  6q   ��6-   �� *$"Commands.OpenNewOfferWindowCommand+ �� Mode$ OneWay=�.��6�   Neues Angebot anlegen6�   5   #   &   System.Windows.Controls.DataGrid  5   "   -   5        $��offerDataGrid��5   !      AutoGenerateColumns .     CanUserAddRows .  ��5   !   �� $' !TheAdministrationViewModel.Offers�	   Columns	 5#   &   4  .System.Windows.Controls.DataGridTemplateColumn  5$   *   
   CellTemplate
 5%   .   �� 5&   2   .R�5'   6   �� ��6=   �� *'%DataContext.Commands.OpenOfferCommand+ �� RelativeSource ��  �� AncestorType" ���6�   �� .��6�   	Öffnen6�   5(   3   5*   +   4  .System.Windows.Controls.DataGridCheckBoxColumn  5+   *   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .     Header$ 
Auswählen��6s   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *
IsSelected+6s   0  *System.Windows.Controls.DataGridTextColumn  5,   *    . $ Angebotsnr.��6k    6O   �� *	OfferNr+6�     5-   *    . $ Betreff��6m    6O   �� *	Reference+6�     5.   *    . $ Datum��6�    6O   �� *Date+ �� StringFormat$ 
dd.MM.yyyy��6�     5/   *    . $ Kunde��6s    6O   �� *Client.LastName+6�     50   *   
 51   .   �� 52   2   .R�53   6   �� 
���������6W   �� *,*DataContext.Commands.ConvertToOrderCommand+ �� " ���6�   �� .��6�   Auftrag erteilen6  54   3   56   +     57   *    . $ Umgewandelt in Auftrag��6o    6S   �� *	IsOrder+6o   59   #   5:      5;      5<      �� 5=      $��	Aufträge��6   .��5>      �� 
�������.+�5?      �� $��10q�6)   .+�5@   "   �� #���  6(   .��6E   	Aufträge6O   A� 5A   "   $ 3��6.   $��0 0 0 30q�6:   .+�5B   &   �� 
���  ��
�������#���  6�   ��6-   �� *Commands.DeleteOrdersCommand+.��6�   !Ausgewählte Aufträge löschen6�   5C   #     5D   "   -   5        $��orderDataGrid��5E   !    .   .  ��5F   !   �� $' !TheAdministrationViewModel.Orders�	 5J   &     5K   *   
 5L   .   �� 5M   2   .R�5N   6   �� ��6=   �� *'%DataContext.Commands.OpenOrderCommand+ �� " ���6�   �� .��6�   	Öffnen6�   5O   3   5Q   +     5R   *    .  $ 
Auswählen��6s    6T   �� *
IsSelected+6s     5S   *    . $ Auftragsnr.��6k    6O   �� *	OrderNr+6�     5T   *    . $ Betreff��6m    6O   �� *	Reference+6�     5U   *    . $ Datum��6�    6O   �� *Date+$ 
dd.MM.yyyy��6�     5V   *    . $ Kunde��6s    6O   �� *Client.LastName+6�     5W   *   
 5X   .   �� 5Y   2   .R�5Z   6   �� 
���������6W   �� *.,DataContext.Commands.ConvertToInvoiceCommand+ �� " ���6�   �� .��6�   Rechnung schreiben6  5[   3   5]   +     5^   *    . $ Umgewandelt in Rechnung��6q    6S   �� *	IsInvoice+6q   5a   #   5b      5c      5d      �� 5e      $��
Rechnungen��6   .��5f      �� 
�������.+�5g      �� $��10q�6)   .+�5h   "   �� #���  6(   .��6E   
Rechnungen6Q   A� 5i   "   $ 3��6.   $��0 0 0 30q�6:   .+�5j   &   �� $
��Left=�6`   
���  ��
�������#���  6�   ��6-   �� * Commands.DeleteInvoicesCommand+.��6�   " Ausgewählte Rechnungen löschen6�   5k   #     5l   "   -   5        $��invoiceDataGrid��5m   !    .   .  ��5n   !   �� $) #TheAdministrationViewModel.Invoices�   RowStyle 5r   &   �� 5s   *    �� 
TargetType)  #System.Windows.Controls.DataGridRow"  60    �� Triggers 5t   .   �� 5u   2    �� Binding 6>   �� *	IsPayed+ �� Value	 false6Z   .a�5v   6   ��  �� Property � �� �� Value
 �  ��6a   5w   3   �� 5x   2    6>   �� *	IsPayed+ true6Z   .a�5y   6   ��  � ��
 � � �6c   5z   3   5|   +   	 5~   &     5   *   
 5�   .   �� 5�   2   .R�5�   6   �� ��6=   �� *)'DataContext.Commands.OpenInvoiceCommand+ �� " ���6�   �� .��6�   	Öffnen6�   5�   3   5�   +     5�   *    .  $ 
Auswählen��6s    6T   �� *
IsSelected+6s     5�   *    . $ Auftragsnr.��6k    6O   �� *	OrderNr+6�     5�   *    . $ Rechnungsnr.��6m    6O   �� *	InvoiceNr+6�     5�   *    . $ Betreff��6m    6O   �� *	Reference+6�     5�   *    . $ Datum��6�    6O   �� *Date+$ 
dd.MM.yyyy��6�     5�   *    . $ Kunde��6s    6O   �� *Client.LastName+6�     5�   *    .  $ Bezahlt��6p    6T   �� *	IsPayed+6p   5�   #   5�      5�      5�      5�      �� 5�      $��0 30 0 0q�6   .@�5�      �� $��Artikel��6   .��5�      �� .+�5�      A� $ 4��6*   $��0 0 0 30q�66   .+�5�   "   �� #���  6o   ��6)   �� *&$Commands.OpenNewArticleWindowCommand+$ OneWay=�.��6�   Neuen Artikel hinzufügen6�   �� 5�   "   #���  6i   ��6)   �� * Commands.ImportArticlesCommand+$ OneWay=�.��6�   XML importieren6�   �� 5�   "   #���  6n   ��6)   �� *%#Commands.ExportArticlesToXmlCommand+$ OneWay=�.��6�   XML exportieren6�   �� 5�   "   
���  ��
�������#���  6�   ��6)   �� * Commands.DeleteArticlesCommand+.��6�   Ausgewählte Artikel löschen6�   5�      �� 5�      #���  6$   .��6A   	Artikel6J     5�      -   5        $��articlesDataGrid��5�   !    .   .  ��5�   !   �� $) #TheAdministrationViewModel.Articles�	 5�   "     5�   &    .  $ 
Auswählen��6o    6P   �� *
IsSelected+6o     5�   &    . $ 
Articlenr.��6b    6K   �� *Id+6x     5�   &    . $
 Name��6d    6K   �� *Name+6t     5�   &    . $ Beschreibung��6k      MaxWidth$	 150Q�6�    6K   �� *Description+   ElementStyle 5�   *   �� 5�   .   .�5�   2   ��  � ��$
 Wrap=�6[   5�   /   5�   '     5�   &   $ Preis��6S    69   �� *Price+6d   5�      5�      5�      �� 5�      $��Kunden��6   .��5�      �� .+�5�      A� $ 4��6*   $��0 0 0 30q�66   .+�5�   "   �� #���  6n   ��6)   �� *%#Commands.OpenNewClientWindowCommand+$ OneWay=�.��6�   Neuen Kunden anlegen6�   �� 5�   "   #���  6\   ��6)   �� *Commands.ImportClientsCommand+.��6�   XML importieren6�   �� 5�   "   #���  6m   ��6)   �� *$"Commands.ExportClientsToXmlCommand+$ OneWay=�.��6�   XML exportieren6�   �� 5�   "   
���  ��
�������#���  6   ��6)   �� *Commands.DeleteClientsCommand+.��6�   Ausgewählte Kunden löschen6�   5�      �� 5�      #���  6$   .��6A   Kunden6I     5�      -   5        $��clientDataGrid��5�   !    .   .  ��5�   !   �� $( "TheAdministrationViewModel.Clients�	 5�   "     5�   &    .  $ 
Auswählen��6o    6P   �� *
IsSelected+6o     5�   &    . $ 	Kundennr.��6b    6K   �� *Id+6w     5�   &    . $
 Name��6h    6K   �� *
LastName+6x   5�      5�      5�      5�      A� 5�      $ 4��6   .+�5�      �� #���  6F   ��6   �� *Commands.LoadCommand+.��6m   Load6s   �� 5�      #���  6F   ��6   �� *Commands.SaveCommand+.��6m   Save6s   5�      5�      5�      5�      5�      