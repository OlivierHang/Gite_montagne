   M S B A M L   `   `   `  ����D  @ProjetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProjetWPF	ProjetWPF  5   	       ProjetWPF.Resa   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ProjetWPF     5   	   -   5          � Title$  Reservation��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5	      � ��5
   
   �� 5       �� ImageSource$ resa.jpg��6    j� Stretch$ UniformToFill=�60   .+�5   
   �� $��Date d'arrivée :��6   $
��Left=�6+   $	��Top=�6F   $��
239,76,0,0q�6^   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePickerArriver��5      $
��Left=�60   $	��Top=�6K   $��
382,76,0,0q�6c   $��26��6w   �� 5   
   $��Durée :��6   $
��Left=�6"   $	��Top=�6=   $��239,107,0,0q�6U   �� 5   
   -   5         ��Name$ textBoxDuree��5      $
��Left=�6(   $��26��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��149��6{   $��382,107,0,0q�6�   �� 5   
   -   5         ��Name$ 
btnConfirm��5      $��	Confirmer��6%   $
��Left=�69   $	��Top=�6T   $	��149��6l   $��382,138,0,0q�6x   $��28��6�   6�   �� 5   
   $��Hebergement :��6   $
��Left=�6(   $	��Top=�6C   $��239,181,0,0q�6[   �� 5   
   -   5        	 ��Name$	 comboBoxHebergement��5      $
��Left=�60   $	��Top=�6K   $	��149��6c   $��382,181,0,0q�6o   $��26��6�   �� 5   
   -   5        $ btnAjoutHebergement��5      $��Ajouter��6.   $
��Left=�6@   $	��Top=�6[   $	��149��6s   $��382,212,0,0q�6   $��28��6�   6�   �� 5   
   $��Nom de la personne :��6   $
��Left=�6/   $	��Top=�6J   $��239,273,0,0q�6b   �� 5   
   -   5        $ textBoxNomPersonne��5      $
��Left=�6.   $��26��6I   $
 Wrap=�6U   $	��Top=�6i   $	��149��6�   $��382,273,0,0q�6�   �� 5   
   -   5        $ btnReserver��5      $��Reserver��6&   $
��Left=�69   $	��Top=�6T   $��72��6l   $��459,324,0,0q�6w   6�   �� 5   
   -	   5        $ btnAnnulerRes��5      $��Annuler��6(   $
��Left=�6:   $	��Top=�6U   $��72��6m   $��382,324,0,0q�6x   6�   5      5      