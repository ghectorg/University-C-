   M S B A M L   `   `   `  ����H  DUniversityWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UniversityWPF.ViewsUniversityWPF.Views  5   	   )    #UniversityWPF.Views.ListInscription   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:UniversityWPF.Views     5   	     � Title$  Inscripciones��5   	   $	��482��6   $	��800��6,   .��5	      �  � 	Resources 5
   
      ActionTemplate ��Name ��Name��%P  &	        �� 5      .R�5      �� $ ComboBtn��6   .@�5      �� $ EditBtn��6   -   5        
�������
�������$��50��5      $��25��6(   .��64   Editar6<   �� 5      $ 	deleteBtn��6   -   5        
�������
�������$��50��5   D   $��25��6O   .��6[   
Eliminar5      5      5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridInscription��5         CanUserAddRows .     AutoGenerateColumns .  $
��Left=�5   G   $	��184��6b   $��
50,184,0,0q�6o   $	��Top=�6�   $	��685��6�   ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Curso��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *
NameMatter+  5"      $ Persona��6%   	 67   �� *
NamePerson+  5#      $ Activo��6%   	 65   �� *
IsActive+4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ Acciones��6)   
   CellTemplate#
 [  6;   5'      �� 5(   
   $��Inscripciones��6   $
��Left=�6(   $��
318,10,0,0q�6C   $	��Top=�6W   $��24(�6o   $
��Bold"�6}   �� 5)   
   -   5        $��Crear Nuevo��5*      $
��Left=�6#   $��340,383,0,0q�6>   $	��Top=�6S   $	��135��6k   $��14(�6w   $
��Bold"�6�   $��48��6�   �� 5+   
   -   5        $ 	BuscarBtn��5+      $��Buscar��5,      $
��Left=�6   $��
440,89,0,0q�69   $	��Top=�6M   $	��130��6e   $��40��6q   $��14(�6}   $
��Bold"�6�   �� 5-   
   -   5         ��Name$ content��5-      $
��Left=�6&   $	��121��6A   $��
180,63,0,0q�6N   $	��Top=�6b   $	��235��6z   .+�5.      �� $��Nombre de persona��6   $��14(�60   $
��Bold"�6>   �� 5/      -   5         ��Name$ namePersonSearch_txt��5/      $��23��50       �� TextWrapping$
 Wrap=�6   $�� ��61   $��14(�69   �� 51      $��Nombre de Curso��6   $��14(�6.   $
��Bold"�6<   �� 52      -   5        $ nameMatterSearch_txt��52      $��23��53      $
 Wrap=�6   $�� ��61   $��14(�69   54      55      56      