   M S B A M L   `   `   `  ����F  BShutdownApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ShutdownAppShutdownApp  5   	       ShutdownApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ShutdownApp     5   	   -   5          � 
ResizeMode$  CanMinimize=�5   	    � Title$ Shutdown��5	   	   $	��319��6H   $��Center=�6U   $��Center=�6p   $	��349��6�   .��5
      � $	��277��6   $	��330��6   .+�5   
   �� $��Center=�6   $��71��61   $��15,190,15,0q�6=   
���   �$	��Top=�6a   $	��300��6y    �� RadiusX$
 6.04��6�    �� RadiusY$
 6.04��6�   �� 5   
   $��Center=�6   $	��114��61   $��0,13,0,0q�6>   
���   �$	��Top=�6_   $	��300��6w   $ 4��6�   $ 4��6�   �� 5   
   $��Center=�6   $��50��61   $��	0,133,0,0q�6=   
���   �$	��Top=�6_   $	��300��6w   $
 6.04��6�   $
 6.04��6�   �� 5   
   $4��.Enter the time before turning off the computer��6   $��
21,13,28,0q�6I   $	��Top=�6]   �� 5   
   -   5         ��Name$ textSetMinutes��5      $��142,42,135,0q�6*   $��60��6@    �� TextWrapping$
 Wrap=�6J   $	��Top=�6^   �� 5   
   $��minutes��6   $
��Left=�6"   $��
209,37,0,0q�6=   $	��Top=�6Q   $��23��6i   �� 5   
   -   5         ��Name$ 	buttonSet��5      $��Set Shutdown��6$   $
��Left=�6;   $��	26,67,0,0q�6V   $	��Top=�6i   $	��120��6�   6�   �� 5   
   -   5        $ buttonCancel��5      $��Cancel Shutdown��6'   $
��Left=�6A   $��	26,92,0,0q�6\   $	��Top=�6o   $	��120��6�   ${�False��6�   �� 5   
   -   5         ��Name$ timer��5      $��0��6   $��Center=�6+   $��	0,145,0,0q�6H   $	��Top=�6[   $	��124��6s   $��Center=�6   $��Center=�6�   �� 5   
   $��hours��6   $
��Left=�6    $��	93,37,0,0q�6;   $	��Top=�6N   $��23��6f   �� 5   
   -   5        $ textSetHours��5      $
��Left=�6(   $��	26,42,0,0q�6C   $��0��6V   $
 Wrap=�6_   $	��Top=�6s   $��60��6�   �� 5   
   -   5         ��Name$ profilesBox��5      $
��Left=�6(   $��182,199,0,0q�6C   $	��Top=�6X   $	��120��6p   ��6�   �� *Name+�� 5   
   -   5        $��textSetName��5      $
��Left=�6%   $��
26,201,0,0q�6@   $��Name profile��6T   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5   
   -	   5        $��buttonSaveProfile��5      $��Save profile��6*   $
��Left=�6A   $��
26,234,0,0q�6\   $	��Top=�6p   $	��120��6�   6�   �� 5   
   -
   5        $��buttonDeleteProfile��5      $��Delete profile��6,   $
��Left=�6E   $��182,234,0,0q�6`   $	��Top=�6u   $	��120��6�   6�   5      5       