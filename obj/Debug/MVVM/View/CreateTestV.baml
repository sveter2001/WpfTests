   M S B A M L   `   `   `  ����C  ?WpfTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfTests.MVVM.ViewModelWpfTests.MVVM.ViewModel  5      $    WpfTests.MVVM.View.CreateTestV   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;	viewmodel%clr-namespace:WpfTests.MVVM.ViewModel     5      
������ .��5      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��10,0,0,0q�6    �� Orientation$ 
Horizontal=�6'   $��Center=�6@   $��0��6[   .+�5      �� -   5         ��Name$ 
CreateTest��5      $	��150��5      $��20��5      $��Создать��5      
��� �����5      ��  �� Path$ CreateTest_Click��� 5      -   5        $ OpenTest��5      $	��150��5      $��20��5      $��Открыть��5      
��� ���$��20,0,0,0q�5      ��5      �� $ OpenTest_Click��� 5      -   5        $ SaveTest��5      $	��150��5       $��20��5!      $��Сохранить��5"      
��� ���$��20,0,0,0q�5$      ��5%      �� $ SaveTest_Click�5&      �� 5(   
   $��1��6   $��10,10,250,10q�5)      ��5*      �� *currentView1+�� 5+   
   $��1��6   $��717,10,10,20q�5,      ��5-      �� *currentView2+5.      51      