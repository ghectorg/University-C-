   M S B A M L   `   `   `  ����H  DUniversityWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UniversityWPF.ViewsUniversityWPF.Views  5   	   $    UniversityWPF.Views.ListPerson   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:UniversityWPF.Views     5   	     � Title$  Personas��5   	   $	��492��6   $	��944��6'   .��5
      �  � 	Resources 5   
      ActionTemplate ��Name ��Name��%P  &	        �� 5      .R�5      �� $ ComboBtn��6   .@�5      �� $ editBtn��6   -   5        
�������
�������$��50��5      $��25��6(   .��64   Editar6<   �� 5      $ 	deleteBtn��6   -   5        
�������
�������$��50��5   D   $��25��6O   .��6[   
Eliminar5      5      5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridPerson��5         CanUserAddRows .     AutoGenerateColumns .  $
��Left=�5   G   $	��233��6b   $��
40,135,0,0q�6o   $	��Top=�6�   $	��840��6�   ��6   ��    Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Documento de Identidad��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6F   �� *DocIdentity+  5$      $ Primer Nombre��6%   	 6=   �� *Name1+  5%      $ Segundo Nombre��6%   	 6>   �� *Name2+  5&      $ Primer Apellido��6%   	 6?   �� *	Lastname1+  5'      $ Segundo Apellido��6%   	 6@   �� *	Lastname2+  5(      $ Fecha nacimiento��6%   	 6@   �� *
BirthayDay+
 �� StringFormat$
 {0:dd.MM.yy}��  5)      $ Activo��6%   	 65   �� *
IsActive+4  .System.Windows.Controls.DataGridTemplateColumn  5*      -   5        ColumnAction��$ Acciones��5*   ?      CellTemplate# [  6Q   5-      �� 5.   
   $��Personas��6   $
��Left=�6#   $��
404,10,0,0q�6>   $	��Top=�6R   $��52��6j   $	��121��6v   $��24(�6�   $
��Bold"�6�   �� 5/   
   -   5        $ CrearBtn��5/      $��Crear nuevo��50      $
��Left=�6'   $��384,390,0,0q�6B   $	��Top=�6W   $	��160��6o   $��14(�6{   $
��Bold"�6�   $��37��51   *   �� 52   
   -   5        $ 	BuscarBtn��52      $��Buscar��53      $
��Left=�6   $��
550,78,0,0q�69   $	��Top=�6M   $	��130��6e   $��33��6q   $��14(�6}   $
��Bold"�6�   �� 54   
   -   5         ��Name$ content��54      $
��Left=�6&   $��55��6A   $��
290,69,0,0q�6M   $	��Top=�6a   $	��235��6y   .+�55      �� $��Nombre��6   $��14(�6%   $
��Bold"�63   �� 56      -   5         ��Name$ nameSearch_txt��56      $��23��57       �� TextWrapping$
 Wrap=�6   $�� ��61   $��14(�69   58      5:      5;      