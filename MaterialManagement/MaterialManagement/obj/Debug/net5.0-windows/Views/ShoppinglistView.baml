   M S B A M L   `   `   `  ����M  IMaterialManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MaterialManagement.ViewModelsMaterialManagement.ViewModels  5      /    )MaterialManagement.Views.ShoppinglistView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      B
viewModels+clr-namespace:MaterialManagement.ViewModels     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f!cmhttp://caliburnmicro.com  5      $	��550��5	      $	��800��6     � 	Resources  5         ButtonWithRoundedCorner �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��60   .�5      ��  � �� �#736D6C6+   �� 5       � ��
 �����6;   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 15��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#534F4E63   5      5      5      .��5!      � $��30,30,30,50q�6   	 � ColumnDefinitions	 5"   
   �� 5#      6!   �� 5$      6!   
 � RowDefinitions
 5&   
   �� 5'      $��1* �6   6*   �� 5(      $��5* �6   6*   .+�5+   
   �� $��0��6   $��0��6   $��25(�6-   $��10q�6;   $��Materialmanagement��6G   6f   �� 5,   
   -   5         ��Name$&  NavigateToMaterialManagementView��5,      #��[  6;   $��0��6l   $��1��5-      $��30��6!   $	��120��6-   $��Right=�69   $
��40,0q�6U   $��Material��6c   5.      � 5/   
   $��1��6   $��0��6   $��2��6,   
 50      �� 51      $
��Auto �6    60   �� 52      6"   .+�54      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��Center=�6?   .+�55      �� $��Material hinzufügen:��6   $��0,0,10,0q�67   6K   �� 56      -   5         ��Name$ ShoppingListTextBox��56      $	��300��67   $��25��6C   $��Center=�6O     Caliburn.Micro.Message   Attach$E ?[Event KeyDown] = [Action AddToShoppingList($executionContext)]��57      .��6n   58      59      � 5:      $��1��6   $��30,10q�6    
 5;      �� 5<      $
��Auto �6$   64   �� 5=      6&   .+�5?      �� $��0��6   $��15(�6%   $��Einkaufsliste:��63   6N   �� 5@      $��1��6   ��6(   �� *
Material+ �� View 5A      �� 5B      .P�5C      �� $��Material��6-    �� DisplayMemberBinding 6?   �� *Name+�� 5D      $��Menge��6-    6<   �� *ToBeOrdered+�� 5E      $��Hinzufügen��6-    �� CellTemplate 5F   "   5  -System.Windows.Controls.ItemContainerTemplate�  5G   &   .R�5H   *   �� $ [Action Add($this)]��61   
������ 
������ .��5J   .   F� $��10��63   $��10��6?   ����� u u�        ����    Ӏ��     ��� ����    h~g���  u��� uӀzg u uh~g u���� u��� �zg����vK ?�� ?� ?�� ?��S� ?�@�c ��@�q���@�q� �{@�q 6n@�c 6n�S� 6n ?��`��  ?���%�  ?��y�  ���y� �����y�  �{�%�  6n`��  6n� 6n 6n� 6n��� � 6n ��  �{ � ��� � � �� �  ?� ��  ?���� � ?� 6nѠvK 6n� O\ 6n �i �{ �i���� �i �� O\ ?��vK ?����#000000 �� Stretch$
 Fill=�5M   3   5N   /   5O   +   5P   '   5R      �� 5S      $��	Entfernen��6-    5T   "     5U   &   .R�5V   *   �� $ [Action Remove($this)]��61   
������ 
������ .��5X   .   F� $��10��63   $��10��6?   �����Ȓ~Ȓ~�        �XK?	�  �H�%�  H�%XK?	�    ��XH�%Ȓ~XK?	Ȓ~�h�XȒ~��~��X��~XK?	�Ȓ~H�%h�X�  XK?	�  �S��8
ӘS��(|
�V�
�A�
��\�
�`��
� ��(|
� ��8
�� ��P�� ��C`�-���o`@�\-���o`@Q�A-���o`@S�V-���o`@�S��C�S��PјS��8
���#000000$
 Fill=�5[   3   5\   /   5]   +   5^   '   5`      �� 5a       5b   "     5c   &   .R�5d   *   �� $ [Action Delete($this)]��61   $��Right=�6\   
������ 
������ .��5f   .   F� $��10��5g   1   $��10��6=   ����� $�  $� �        �Ⱥ Ⱥ �8N) Ⱥ �� z �~d ���� Ⱥ �8i� 8N) ��p��  z �8i� ��� ���� 8i� �� z p�� �8N) 8i� �Ⱥ ��� �ѐ~d  z �Ⱥ 8N) �Ⱥ Ⱥ ����#000000$
 Fill=�5j   1   5k   /   5l   +   5m   '   5o      5p      5r      5s      5t      5u      5v      