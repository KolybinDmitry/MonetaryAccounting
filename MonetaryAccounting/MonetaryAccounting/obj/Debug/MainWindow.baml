   M S B A M L   `   `   `  ����M  IMonetaryAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MonetaryAccountingMonetaryAccounting  5   	   #    MonetaryAccounting.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MonetaryAccounting     5   	     � Title$  
MainWindow��5   	   $	��470��6   $	��800��6)   
�������.��5	      � .+�5
   
   �� -   5         ��Name$ buttonCreateNewNode��5
      $,��&Создать новую запись��6.   $
��Left=�6M   $��
10,285,0,0q�6h   $	��Top=�6|   $��31��6�   $	��140��6�   6�   �� 5   
   -   5        $ buttonNewTypeNode��5      $$��Новый тип записи��6,   $
��Left=�6G   $��
10,172,0,0q�6b   $	��Top=�6v   $��31��6�   $	��140��6�   6�   �� 5   
   -   5        $ buttonDeleteNode��5      $!��Удалить запись��6+   $
��Left=�6D   $��
10,357,0,0q�6_   $	��Top=�6s   $��31��6�   $	��140��6�   6�   �� 5   
   -   5        $ buttonDeleteAll��5      $��Удалить всё��6*   $
��Left=�6@   $��
10,393,0,0q�6[   $	��Top=�6o   $��31��6�   $	��140��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $��Center=�6)   $��0,10,0,0q�6F   $	��Top=�6X   $	��780��6p   $��44��6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��166,64,10,66q�6P      CanUserReorderColumns .     CanUserAddRows .     CanUserDeleteRows .   J� 	AllowDrop . 6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
10,136,0,0q�6@   $	��Top=�6T   $	��140��6l   $��31��6x   �� 5   
   -   5        	 ��Name$	 textBoxNodeTitle��5      $
��Left=�6,   $��
10,100,0,0q�6G   
 �� TextWrapping$

 Wrap=�6[   $��TextBox��6o   $	��Top=�6~   $	��140��6�   $��31��6�   �� 5   
   $%��Название заметки��6   $
��Left=�6+   $��	10,64,0,0q�6F   $	��Top=�6Y   $��31��6q   $	��140��6}   �� 5   
   $��Сумма денег��6   $
��Left=�6&   $��
10,208,0,0q�6A   $	��Top=�6U   $��31��6m   $	��140��6y   �� 5   
   -	   5        $	 textBoxMoney��5      $
��Left=�6(   $��
10,244,0,0q�6C   $

 Wrap=�6W   $��TextBox��6k   $	��Top=�6z   $	��140��6�   $��31��6�   �� 5   
   -
   5        $ buttonChangeNode��5      $%��Изменить заметку��6+   $
��Left=�6F   $��
10,321,0,0q�6a   $	��Top=�6u   $��31��6�   $	��140��6�   6�   �� 5   
   $��
Итог: ��6   $
��Left=�6!   $��402,393,0,0q�6<   $	��Top=�6Q   $��31��6i   $��42��6u   �� 5   
   -   5         ��Name$ labelResult��5      $��0 ��6%   $
��Left=�62   $��449,393,0,0q�6M   $	��Top=�6b   $��31��6z   $��42��6�   5      5      