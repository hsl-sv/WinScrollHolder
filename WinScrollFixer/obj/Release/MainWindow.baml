   M S B A M L   `   `   `  ���� I  EWinScrollFixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WinScrollFixerWinScrollFixer      WinScrollFixer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:WinScrollFixer       � Title$  WinScrollHolder��$	��180��$	��430�� � 
ResizeMode$ NoResize=�.��� .+��� $��Timer��$
��Left=�$��	10,0,0,42q�$��48��$��18(�$��0q�$��27��$��Bottom=��� $��50��$��
10,10,10,0q�$	��Top=�$��18(�$��0q�.���� -    ��Name$ 
accessText�� �� TextWrapping$ WrapWithOverflow=�.��LJ_Set vertical scroll to 10 every 1 second(s) until timer reach 10 seconds.�� -    ��Name$ 	testLabel��$��0��$
��Left=�$��	63,0,0,42q�$��43��$��18(�$��0q�$��27��$��Bottom=��� -    ��Name$ tbxScrollValue��$
��Left=�$��
254,0,0,43q� �� TextWrapping$
 Wrap=�$��10��$��45��$��18(�$��27��$��Bottom=� �� 	MaxLength$ 3���� -   $ tbxTickValue��$
��Left=�$��
304,0,0,43q�$
 Wrap=�$��1��$��45��$��18(�$��27��$��Bottom=�$ 9���� -   $ 
tbxEndTime��$��354,0,10,43q�$
 Wrap=�$��10��$��18(�$��27��$��Bottom=�$ 9���� -    ��Name$ slider��$��
10,0,10,10q�	 � Maximum$		 100Q�
 � Minimum$
 1Q� �� IsSnapToTickEnabled . $��21��$��Bottom=� � Value$ 10Q� �� IsMoveToPointEnabled . 