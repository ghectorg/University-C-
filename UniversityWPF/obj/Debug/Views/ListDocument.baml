   M S B A M L   `   `   `  ����H  DUniversityWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UniversityWPFUniversityWPF  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   &     UniversityWPF.Views.ListDocument   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UniversityWPF     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Tipos de documentos��5	   	   $	��517��6%   $	��800��62    � 	Resources 5       
  myEnum S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName��%t   &	        S� 5   
   $ 	GetValues��6,   "  6C    5      M� 5      $ local:Actions��6   5      5      .��5      �  5   
     ActionTemplate ��Name ��Name��%P  &	       �� 5      .R�5      �� $ ComboBtn��6   .@�5      �� $ EditBtn��6   -   5        
�������
�������$��50��5      $��25��6(   .��64   Editar6<   �� 5      $ 	deleteBtn��6   -   5        
�������
�������$��50��5   D   $��25��6O   .��6[   
Eliminar5      5#      5$      5%      .+�5'   
   �� $��Tipos de Documentos��6   $
��Left=�6.   $��	276,0,0,0q�6I   $	��Top=�6\   $��24(�6t   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ datagridDocuments��5(      	   CanUserAddRows	 .  
   AutoGenerateColumns
 .  $
��Left=�5+   /   $	��215��6J   $��
50,170,0,0q�6W   $	��Top=�6k   $	��695��6�   ��5*      ��    Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Code+  50      $ Nombre��6%    66   �� *Name+  51      $ Descripción��6%    6;   �� *Description+  52      $ Activo��6%    65   �� *
IsActive+4  .System.Windows.Controls.DataGridTemplateColumn  53      $ Acciones��6)      CellTemplate# [ 6;   56      �� 57   
   -   5        $��Crear Nuevo��57      $
��Left=�6'   $��340,410,0,0q�6B   $	��Top=�6W   $	��120��6o   $��14(�6{   $��35��6�   $
��Bold"�6�   58      �� 59   
   -   5        $ 	BuscarBtn��59      $��Buscar��5:      $
��Left=�6   $��
490,80,0,0q�69   $	��Top=�6M   $	��130��6e   $��40��6q   $��14(�6}   $
��Bold"�6�   �� 5;   
   -   5         ��Name$ content��5;      $
��Left=�6&   $	��121��6A   $��
230,54,0,0q�6N   $	��Top=�6b   $	��235��6z   .+�5<      �� $��Nombre��6   $��14(�6%   $
��Bold"�63   �� 5=      -   5         ��Name$ nameSearch_txt��5=      $��23��5>       �� TextWrapping$
 Wrap=�6   $�� ��61   $��14(�69   �� 5?      $��Código��6   $��14(�6%   $
��Bold"�63   �� 5@      -   5        $ codeSearch_txt��5@      $��23��5A      $
 Wrap=�6   $�� ��61   $��14(�69   5B      5D      5G      