   M S B A M L   `   `   `  ����L  HStudentAndCourses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentAndCoursesStudentAndCourses  5   	   %    StudentAndCourses.WTableStudent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StudentAndCourses     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$' !Таблиця студентів��5	   	   $	��351��6#   $	��800��60    � WindowStartupLocation$ CenterScreen=�6<    � Icon$= 7/Picture/mimetypes_office_spreadsheet_table_xls_381.ico��6a   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridStudent��5      $��
10,40,10,0q�6,      AutoGenerateColumns .     
IsReadOnly . $	��205��6n   $	��Top=�6{      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 0 61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *id_students+  5      $ Ім'я��6%   $	 * 64   
 6>   �� *SName+  5      $ Прізвище��6%   $	 * 68   
 6B   �� *
SSurname+  5      $ Вік��6%   $	 * 63   
 6=   �� *SAge+5      �� 5   
   $.��(Список усіх студентів��6   $
��Left=�60   $��10,3,0,0q�6K   $	��Top=�6]   $��20(�6u   $
��Bold"�6�   ���	#FF2569EF6�   �� 5   
   -   5         ��Name$ buttonExport��5      $2��,Експортувати у формат CSV��6'   $��603,259,10,0q�6K   $��20��6a   $	��Top=�6m   $	��NaN��6�   �� 5   
   -   5        $ buttonExportExcel��5      $4��.Експортувати у формат Excel��6,   $
��Left=�6R   $��400,259,0,0q�6m   $	��Top=�6�   6�   5      5      