   M S B A M L   `   `   `  ����E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop&De.HsFlensburg.ClientApp078.Ui.Desktop  5   	   >    8De.HsFlensburg.ClientApp078.Ui.Desktop.AddPositionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:De.HsFlensburg.ClientApp078.Ui.Desktop     5   	   -   5          �Name$  
ThisWindow��5	   	    � Title$ AddPositionWindow��5   	    � SizeToContent$ Width=�5
   	   $
��1000��5   	   
�������$��Arial)�5   	    � DataContext 5      �� 5   
      ViewModelLocator �� Source# [  6    �� Path$# TheAddPositionWindowViewModel�6=   6d   .��5      �� .��5   
   � .+�5      �� $��30q�6   .+�5      �� .+�5      ��   H1#���  6   .��69   	Artikel6B   &   System.Windows.Controls.DataGrid  5      -   5        $��articleDataGrid��5         AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem 5      �� *SelectedArticle+��5      �� $) #TheAdministrationViewModel.Articles�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Articlenr.��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6^     5      $

 Name��6J    61   �� *Name+6Z     5       $
 Beschreibung��6Q    61   �� *Description+6i     5!      $
 Preis��6K    61   �� *Price+6\   5#      5$      �� 5%      $��0 20 0 0q�6   .+�5&      ��   
LabelStyle#���  6   $��Center=�6A   $
��Left=�6\   .��6w   	Artikel6�   �� 5'        TextBoxStyle#���  6    �� 
IsReadOnly . $��Center=�6�   ��6E   ��  �� ElementName$ articleDataGrid��$ SelectedItem.Name�6�   5(      �� 5*      $��0 20 0 0q�6   .+�5+      �� #���  6   $��Center=�6A   $
��Left=�6\   .��6w   Anzahl6   �� 5,      #���  6   $��Center=�6_   ��6E   �� *
Quantity+6|   5-      �� 5/      $��0 20 0 0q�6   .+�50      �� #���  6   $��Center=�6A   $
��Left=�6\   .��6w   Einzelpreis6�   �� 51      #���  6    . $��Center=�6�   ��6E   �� $ articleDataGrid��$ SelectedItem.Price�6�   52      � 53      $	��NaN��6   $	��NaN��6#   $��Center=�60   $��Center=�6M   $��0 50 0 0q�6h   .+�54      ��   RoundeButton#���  6D   ��6   �� *AddPositionCommand+.��6k   Position hinzufügen6�   55      � 56      $	��NaN��6   $	��NaN��6#   $��Center=�60   $��Center=�6M   $��0 50 0 0q�6h   .+�57      �� #���  6y   ��6   �� *CloseWindowCommand+��6D   �� $ 
ThisWindow��.��6�   Fenster schließen6�   58      59      5:      5;      5<      