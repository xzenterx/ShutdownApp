   M S B A M L   `   `   `  ���� F  BShutdownApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ShutdownAppShutdownApp      ShutdownApp.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ShutdownApp     -     � 
ResizeMode$  CanMinimize=� � Title$ Shutdown��$	��240��$	��329��.��� $	��230��.+��� $��Center=�$	��114��$��0,14,0,0q�
���   �$	��Top=�$	��300���� $��Center=�$��50��$��	0,134,0,0q�
���   �$	��Top=�$	��300���� $4��.Enter the time before turning off the computer��$��
25,14,24,0q�$	��Top=��� -    ��Name$ textSetMinutes��$��146,43,131,0q�$��60�� �� TextWrapping$
 Wrap=�$	��Top=��� $��minutes��$
��Left=�$��
213,38,0,0q�$	��Top=�$��23���� -    ��Name$ 	buttonSet��$��Set Shutdown��$
��Left=�$��	30,68,0,0q�$	��Top=�$	��120���� -   $ buttonCancel��$��Cancel Shutdown��$
��Left=�$��	30,93,0,0q�$	��Top=�$	��120��${�False���� -    ��Name$ timer��$��0��$��Center=�$��	0,146,0,0q�$	��Top=�$	��181��$��Center=�$��Center=��� $��hours��$
��Left=�$��	97,38,0,0q�$	��Top=�$��23���� -   $��textSetHours��$
��Left=�$��	30,43,0,0q�$��0��$
 Wrap=�$	��Top=�$��60��