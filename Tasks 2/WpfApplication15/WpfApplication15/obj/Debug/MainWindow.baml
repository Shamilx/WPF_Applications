   M S B A M L   `   `   `  ����K  GWpfApplication15, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CustomcontrolsCustomcontrols  5   	   !    WpfApplication15.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:Customcontrols     5   	   -   5        $��cc��5   5     � Title$  
MainWindow��6	   $	��300��6   $	��600��6)   .��5      �  � RowDefinitions 5	   
   �� 5
      6   �� 5      6   .+�5   
       Customcontrols.Colorpicker  -   5          Name$ 
superCombo��5      $��0��61   6@   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��
ExtraBlack"�6   $��You selected��5      $��20��6   $��91��6#   5      �� 5      -   5         ��Name$ 
TextBlock1��5      $	��100��6,   $	��100��68   ��5      ��  �� ElementName$ 
superCombo�� �� Path$ SelectedColor�5      5      5      5      