   M S B A M L   `   `   `  ����H  DUniversityWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UniversityWPF.ViewsUniversityWPF.Views  5   	   $    UniversityWPF.Views.ListMatter   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:UniversityWPF.Views     5   	     � Title$  Cursos��5   	   $	��450��6   $	��800��6%   .��5	      �  � 	Resources 5
   
      ActionTemplate ��Name ��Name��%P  &	        �� 5      .R�5      �� $ ComboBtn��6   .@�5      �� $ EditBtn��6   -   5        
�������
�������$��50��5      $��25��6(   .��64   Editar6<   �� 5      $ 	deleteBtn��6   -   5        
�������
�������$��50��5   D   $��25��6O   .��6[   
Eliminar5      5      5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridMatter��5         CanUserAddRows .     AutoGenerateColumns .  $
��Left=�5   G   $	��193��6b   $��
50,135,0,0q�6o   $	��Top=�6�   $	��665��6�   ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *Name+  5"      $ Descripción��6%   	 6;   �� *Description+  5#      $ Activo��6%   	 65   �� *
IsActive+4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ Acciones��6)   
   CellTemplate#
 [  6;   5'      �� 5(   
   $��Cursos��6   $
��Left=�6!   $��
365,10,0,0q�6<   $	��Top=�6P   $��24(�6h   $
��Bold"�6v   �� 5)   
   -   5        $��Crear Nuevo��5*      $
��Left=�6#   $��340,350,0,0q�6>   $	��Top=�6S   $	��128��6k   $��40��6w   $��14(�6�   $
��Bold"�6�   �� 5,   
   -   5        $ 	BuscarBtn��5,      $��Buscar��5-      $
��Left=�6   $��
455,74,0,0q�69   $	��Top=�6M   $	��130��6e   $��40��6q   $��14(�6}   $
��Bold"�6�   �� 5.   
   -   5         ��Name$ content��5.      $
��Left=�6&   $��55��6A   $��
200,68,0,0q�6M   $	��Top=�6a   $	��235��6y   .+�5/      �� $��Nombre��6   $��14(�6%   $
��Bold"�63   �� 50      -   5         ��Name$ nameSearch_txt��50      $��23��51       �� TextWrapping$
 Wrap=�6   $�� ��61   $��14(�69   52      53      54      