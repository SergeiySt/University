   M S B A M L   `   `   `  ����L  HStudentAndCourses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentAndCoursesStudentAndCourses  5   	   "    StudentAndCourses.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StudentAndCourses     5   	   -   5          � 
ResizeMode$  NoResize=�5   
    � Title$ 
MainWindow��5	   	   $	��426��6   $	��389��6)    � WindowStartupLocation$ CenterScreen=�65    � Icon$" /Picture/Login_374444128.ico��6Z    � 	Resources 5
         LabelAnimation W� From	 W� To g� Duration �� 
TargetName	 �� TargetProperty
 g� 	BeginTime  ImageAnimation  ButtonAnimation��%L  &	        &	 �     &	 t    �� 5   
   .��5      W� $ 0X�6   $ 1X�6'   $ 0:0:4D�6.   $ label1��6?   $	 Opacity�6^   W� 5      $ 0X�6   $ 1X�6'   $ 0:0:4D�6.   $ label2��6?   $	 Opacity�6^   $
 0:0:4X�6�   5      �� 5   
   .��5      W� $ 0X�6   $ 1X�6'   $ 0:0:4D�6.   $ 
pictureBox��6?   $	 Opacity�6b   $
 0:0:4X�6�   5      �� 5   
   .��5      W� $	 150X�6   $ 1X�6)   $ 0:0:7D�60   $ 
buttonExit��6A   $8	 2(UIElement.RenderTransform).(TranslateTransform.Y)�6e   $
 0:0:5X�6�   5      5      .��5      � $	��376��6   $��Center=�6   .+�5   
   �� -   5         ��Name$ label1��5      $/��)Вітаємо Вас у програмі��6    $��Center=�6A   $��0,27,0,0q�6^   $	��Top=�6p   $��24(�6�   $
��Bold"�6�   ���	#FF2569EF$��45��6�    J� Opacity$ 0Q�6�   �� 5   
   -   5         ��Name$ 
buttonExit��5      $��Почати!��6%   $��Center=�67   $��	0,327,0,0q�6T   $	��Top=�6g   $	��131��6   $��20(�6�    J� RenderTransformOrigin$ 0.45,-0.152&�6�   $��39��6�   z�5      T� 5       T� Y$	 100Q�6%   5      �� 5   
   -   5         ��Name$ 
pictureBox��5      $
��Left=�6$   $	��189��6?   $	��Top=�6L   $	��223��6d   $��/Picture/smail.png��6p   $��
68,125,0,0q�6�   $ 0Q�6�   �� 5    
   -   5        $ label2��5       $��"UNIVERSITY"!��6    $��Center=�6B   $��0,72,0,0q�6_   $	��Top=�6q   $��24(�6�   $
��Bold"�6�   ���	#FF2569EF$ 0Q�6�   5!      5"      