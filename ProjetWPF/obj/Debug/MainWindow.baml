   M S B A M L   `   `   `  ����D  @ProjetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProjetWPF	ProjetWPF  5   	       ProjetWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ProjetWPF     5   	     � Title$  	Connexion��5   	   $	��450��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J   .��5	      � ��5
   
   �� 5       �� ImageSource$ login_bg.jpg��6    j� Stretch$ UniformToFill=�64   .+�5   
   � $��170,120,170,120q�6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��Login :��6   $
��Left=�6&   $��
172,65,0,0q�6A   $	��Top=�6U   �� 5      -   5         ��Name$ textBoxLogin��5      $��1��6,   $
��Left=�6<   $��23��6W   $��	10,65,0,0q�6c    �� TextWrapping$
 Wrap=�5      $	��Top=�6*   $	��120��6B   �� 5      $��Mot de passe :��6   $
��Left=�6-   $��
130,96,0,0q�6H   $	��Top=�6\   �� 5      -   5        $ 
textBoxMdp��5      $��1��6*   $
��Left=�6:   $��23��6U   $��	10,96,0,0q�6a   $
 Wrap=�5      $	��Top=�6*   $	��120��6B   �� 5      -   5         ��Name$ 	btnCancel��5      $��Cancel��6(   $
��Left=�69   $��142,151,0,0q�5      $	��Top=�6*   $��75��6B   �� 5      -   5        $ btnConnexion��5      $��	Connexion��6+   $
��Left=�6?   $��
10,151,0,0q�5      $	��Top=�6)   $��75��6A   $��1��6L   6\   5      5       5!      