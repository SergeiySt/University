   M S B A M L   `   `   `  ����L  HStudentAndCourses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentAndCoursesStudentAndCourses  5   	   %    StudentAndCourses.WTableCourses   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StudentAndCourses     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$! Таблиця курсів��5	   	   $	��351��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCourses��5      $	��202��6,   $	��Top=�69   $��
10,43,10,0q�6Q      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 61   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6>   �� *
id_courses+  5      $ Назва курса��6%   $ * 6;   	 6E   �� *CName+  5      $ Викладач��6%   $ * 68   	 6B   �� *
CTeacher+5      �� 5   
   $(��"Список усіх курсів��6   $
��Left=�6-   $��10,3,0,0q�6H   $	��Top=�6Z   $��20(�6r   $
��Bold"�6�   ���	#FF2569EF6�   �� 5   
   -   5        
 ��Name$
 buttonExportCSV��5      $2��,Експортувати у формат CSV��6*   $��607,271,10,0q�6N   $	��Top=�6d   $	��NaN��6|   6�   �� 5   
   -   5        $
 buttonExportExcel��5      $4��.Експортувати у формат Excel��6,   $
��Left=�6R   $��414,271,0,0q�6m   $	��Top=�6�   $	��174��6�   6�   5      5      