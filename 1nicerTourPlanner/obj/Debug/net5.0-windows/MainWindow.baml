   M S B A M L   `   `   `  ����L  H1nicerTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:_1nicerTourPlanner.ViewModels_1nicerTourPlanner.ViewModels  5   	   #    _1nicerTourPlanner.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   B
viewmodels+clr-namespace:_1nicerTourPlanner.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $	��100��6   $��5,5,5,0q�6"   ��63   �� *NewTourCommand+.��6V   
Add Tour5      �� 5      $	��100��6   $��5,5,5,0q�6"   ��63   �� *DeleteTourCommand+.��6Y   Delete Tour5      �� 5      $	��100��6   $��5,5,5,0q�6"   ��63   �� *ModifyTourCommand+.��6Y   Modify Tour5      �� 5      $	��100��6   $��5,5,5,0q�6"   ��63   �� *CopyTourCommand+.��6W   	Copy Tour5      �� 5      $	��100��6   $��5,5,5,0q�6"   ��63   �� *ImportTourCommand+.��6Y   Import Tour5      �� 5      $	��100��6   $��5,5,5,0q�6"   ��63   �� *ExportTourCommand+.��6Y   Export Tour5!      �� 5"      $	��100��6   $��5,5,5,0q�6"   ��63   �� *NewLogCommand+.��6U   	Add Log5$      �� 5%      $	��100��6   $��5,5,5,0q�6"   ��63   �� *PrintTourCommand+.��6X   
Print Tour5'      5(      � 5)   
   $��1��6    � RowDefinitions 5*      �� 5+      $
��Auto �6    �� 5,      $��* �6    .+�5.      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5/      �� $��Search:��6   $��	10,10,0,0q�6+   $	��Top=�6>   �� 50      -   5        $��textSearchName��50      $	��Top=�60   $	��400��6H   $��	10,10,0,0q�6T   ��51      �� *
SearchName+ �� Mode$ TwoWay=��� 52      $��50��6   $��5,5,0,0q�6$   ��65   �� *SearchCommand+.��6W   Search54      �� 55      $��50��6   $��5,5,5,0q�6$   ��65   �� *ClearCommand+.��6V   Clear57      58      � 59      $��1��6    5:      �� 5;      $
��Auto �6'   �� 5<      $��* �6'   .+�5>      �� $��0��6   $��5,5,0,0q�6-   $	��200��6>   .+�5?      �� $��
Tour List:��6    $��5,0,5,0q�62   $��Center=�6C   �� 5@      -   5         ��Name$ 	listTours��5@       �� DisplayMemberPath$
 Name��5C   !   $��0,10,0,0q�5D   !   ��5A   !   �� *Tours+ �� SelectedItem 5B   !   �� *CurrentTour+5D   !   5E      �� 5G      $��1��6   $��5,5,0,0q�6-   .+�5H      �  5I      �� 5J      $
��Auto �6/   �� 5K      $��* �6/   .+�5M      �� $��0��6%   .+�5N      �� $��
Tour Data:��6(   $��5,0,5,0q�6:   $��Center=�6K   � 5P       5Q   "   �� 5R   &   $
��Auto �64   �� 5S   &   $
��Auto �64   �� 5T   &   $
��Auto �64   .+�5W   "   �� $��0��6,   $��Name:��69   $��5,0,5,0q�6F   $��Center=�6W   �� 5X   "   -   5        $��tourName��5X   7   $��0��6*   $��80,0,0,0q�6G   $	��250��6Y   $��Center=�6e   ��5Y      �� *CurrentTour.Name+$ TwoWay=��� 5Z   "   $��1��6,   $��Description:��69   $��5,0,5,0q�6M   $��Center=�6^   �� 5[   "   -   5        $��tourDescription��5[   7   $��1��6*   $��80,0,0,0q�6N   $	��250��6`   $��Center=�6l   ��5\      �� *CurrentTour.Description+�� 5]   "   $��2��6,   $��	Distance:��69   $��5,0,5,0q�6J   $��Center=�6[   �� 5^   "   -   5        $��tourDistance��5^   7   $��2��6*   $��80,0,0,0q�6K   $	��250��6]   $��Center=�6i   ��5_      �� *CurrentTour.Distance+5`      5a      �� 5b      $��1��6"   $��Right=�62   5d      &   System.Windows.Controls.DataGrid  5g      -   5        $��LogGrid��5j         AutoGenerateColumns$ False��5g      $��5,10,0,0q�5h      $
��Left=�5i      $	��Top=�5k      $	��430��5l      	   Columns	 5m      0  *System.Windows.Controls.DataGridTextColumn  5n      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Date��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ��  �� Path$
 date�6]     5o      $
 Distance��61   $ 70 6e    6C   �� $ distance�6e     5p      $
 
Total Time��61   $ 70 6i    6E   �� $ 
total_time�6i     5q      $
 Rating��61   $ 70 6a    6A   �� $ rating�6a     5r      $
 Report��61   $	 150 6a    6A   �� $ report�6a   5u      5y      5{      5|      5}      5~      