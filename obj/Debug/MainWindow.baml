   M S B A M L   `   `   `  ����C  ?WpfTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfTests.MVVM.ViewModelWpfTests.MVVM.ViewModel  5   	   #clr-namespace:WpfTestsWpfTests  5   	       WpfTests.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ;	viewModel%clr-namespace:WpfTests.MVVM.ViewModel     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfTests     5   	   $	��600��5	   	   $
��1200��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   %    � DataContext 5      $  WpfTests.MVVM.ViewModel.MainVM  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5       �� -   5        
������ $��75��5    U   $��2��6a   �� 5!      $��MyTests��6   $��Center=�5"      $
��Left=�5#      
�������$��22(�5%      $��20,0,0,0q�5&      �� 5(      $��1��6   .+�5)      	� $��Пройти тест��6   $��50��5*      
�������$��14(�5,         MenuButtonTheme#��[  5-       d� 	IsChecked$
 TrueY�5.      ��5/      �� *TakeTestCommand+	� 51      $��Создать тест��6   $��50��52      
�������$��14(�54      #��[  55      ��56      �� *CreateTestCommand+	� 59      -   5        $��
Выход��59      $��50��5:      
�������$��14(�5<      #��[  5=      6G   5>      �� 5@      $��1��6   $��1��5A      $��10q�5B      ��5C      �� *currentView+5D      5F      5G      