   M S B A M L   `   `   `  ���� E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop&De.HsFlensburg.ClientApp078.Ui.Desktop  >    8De.HsFlensburg.ClientApp078.Ui.Desktop.AddPositionWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Flocal4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop     -     �Name$  
ThisWindow�� � Title$ AddPositionWindow�� � SizeToContent$ Width=�$
��1000��
�������$��Arial)� � DataContext ��    ViewModelLocator �� Source# [   �� Path$# TheAddPositionWindowViewModel�.���� .��� .+��� $��30q�.+��� .+���   H1#���  .��	Artikel&   System.Windows.Controls.DataGrid  -   $��articleDataGrid��   AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem �� *SelectedArticle+���� $) #TheAdministrationViewModel.Articles�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Articlenr.��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $

 Name�� �� *Name+  $
 Beschreibung�� �� *Description+  $
 Preis�� �� *Price+�� $��0 20 0 0q�.+���   
LabelStyle#���  $��Center=�$
��Left=�.��	Artikel��   TextBoxStyle#���   �� 
IsReadOnly . $��Center=�����  �� ElementName$ articleDataGrid��$ SelectedItem.Name��� $��0 20 0 0q�.+��� #���  $��Center=�$
��Left=�.��Anzahl�� #���  $��Center=����� *
Quantity+�� $��0 20 0 0q�.+��� #���  $��Center=�$
��Left=�.��Einzelpreis�� #���   . $��Center=����� $ articleDataGrid��$ SelectedItem.Price�� $	��NaN��$	��NaN��$��Center=�$��Center=�$��0 50 0 0q�.+���   RoundeButton#���  ���� *AddPositionCommand+.��Position hinzufügen� $	��NaN��$	��NaN��$��Center=�$��Center=�$��0 50 0 0q�.+��� #���  ���� *CloseWindowCommand+���� $ 
ThisWindow��.��Fenster schließen