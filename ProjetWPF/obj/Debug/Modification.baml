   M S B A M L   `   `   `  ����D  @ProjetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProjetWPF	ProjetWPF  5   	       ProjetWPF.Modification   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ProjetWPF     5   	   -   5          � Title$  Modification��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\   .��5	      � ��5
   
   �� 5       �� ImageSource$ 	modif.jpg��6    j� Stretch$ UniformToFill=�61   .+�5   
   �� $��N° de réservation :��6   $
��Left=�6.   $	��Top=�6I   $��
239,45,0,0q�6a   �� 5   
   -   5         ��Name$ comboBoxIdRes��5      $
��Left=�6*   $��
382,45,0,0q�6E   $	��Top=�6Y   $	��149��6q   $��26��6}   6�   �� 5   
   $��Date d'arrivée :��6   $
��Left=�6+   $	��Top=�6F   $��239,105,0,0q�6^   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePickerArriver��5      $
��Left=�60   $	��Top=�6K   $��382,105,0,0q�6c   $��26��6x   �� 5   
   $��Durée :��6   $
��Left=�6"   $	��Top=�6=   $��239,136,0,0q�6U   �� 5   
   -   5         ��Name$ textBoxDuree��5      $
��Left=�6(   $��26��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��149��6{   $��382,136,0,0q�6�   �� 5   
   -   5        	 ��Name$	 
btnConfirm��5      $��	Confirmer��6%   $
��Left=�69   $	��Top=�6T   $	��149��6l   $��382,167,0,0q�6x   $��28��6�   6�   �� 5   
   $��Hebergement :��6   $
��Left=�6(   $	��Top=�6C   $��239,210,0,0q�6[   �� 5   
   -   5        $ comboBoxHebergement��5      $
��Left=�60   $	��Top=�6K   $	��149��6c   $��382,210,0,0q�6o   $��26��6�   �� 5   
   -   5        $	 btnAjoutHebergement��5      $��Ajouter��6.   $
��Left=�6@   $	��Top=�6[   $	��149��6s   $��382,241,0,0q�6   $��28��6�   6�   �� 5   
   -   5        $ comboBoxHebergementChoix��5      $
��Left=�65   $	��Top=�6P   $	��149��6h   $��536,210,0,0q�6t   $��26��6�   �� 5   
   -	   5        $	 btnSupprHebergement��5      $��	Supprimer��6.   $
��Left=�6B   $	��Top=�6]   $	��149��6u   $��536,241,0,0q�6�   $��28��6�   6�   �� 5   
   $��Nom de la personne :��6   $
��Left=�6/   $	��Top=�6J   $��239,302,0,0q�6b   �� 5   
   -
   5        $ textBoxNomPersonne��5      $
��Left=�6.   $��26��6I   $
 Wrap=�6U   $	��Top=�6i   $	��149��6�   $��382,302,0,0q�6�   �� 5    
   -   5        $	 	btnUpdate��5       $��Update��6$   $
��Left=�65   $	��Top=�6P   $��72��6h   $��459,353,0,0q�6s   6�   �� 5!   
   -   5        $	 
btnAnnuler��5!      $��Annuler��6%   $
��Left=�67   $	��Top=�6R   $��72��6j   $��382,353,0,0q�6u   6�   5"      5#      