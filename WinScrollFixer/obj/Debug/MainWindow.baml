   M S B A M L   `   `   `  ����I  EWinScrollFixer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WinScrollFixerWinScrollFixer  5   	       WinScrollFixer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WinScrollFixer     5   	     � Title$  WinScrollHolder��5   	   $	��180��6!   $	��430��6.    � 
ResizeMode$ NoResize=�6:   .��5	      � .+�5
   
   �� $��Timer��6   $
��Left=�6    $��	10,0,0,42q�6;   $��48��6N   $��18(�6Y   $��0q�6g   $��27��6s   $��Bottom=�6   �� 5   
   $��50��6   $��
10,10,10,0q�6   $	��Top=�60   $��18(�6H   $��0q�6V   .��5      �� -   5         ��Name$ 
accessText��5       �� TextWrapping$ WrapWithOverflow=�6-   .��6N   LJ_Set vertical scroll to 10 every 1 second(s) until timer reach 10 seconds.5      5      �� 5   
   -   5         ��Name$ 	testLabel��5      $��0��6#   $
��Left=�6/   $��	63,0,0,42q�6J   $��43��6]   $��18(�6h   $��0q�6v   $��27��6�   $��Bottom=�6�   �� 5   
   -   5         ��Name$ tbxScrollValue��5      $
��Left=�6*   $��
254,0,0,43q�6E    �� TextWrapping$
 Wrap=�6Y   $��10��6m   $��45��6w   $��18(�6�   $��27��6�   $��Bottom=�6�    �� 	MaxLength$ 3��6�   �� 5   
   -   5        $ tbxTickValue��5      $
��Left=�6(   $��
304,0,0,43q�6C   $
 Wrap=�6W   $��1��6k   $��45��6t   $��18(�6   $��27��6�   $��Bottom=�6�   $ 9��6�   �� 5   
   -   5        $ 
tbxEndTime��5      $��354,0,10,43q�6&   $
 Wrap=�6;   $��10��6O   $��18(�6Y   $��27��6�   $��Bottom=�6�   $ 9��6�   �� 5   
   -   5         ��Name$ slider��5      $��
10,0,10,10q�6!   	 � Maximum$		 100Q�65   
 � Minimum$
 1Q�6C    �� IsSnapToTickEnabled . $��21��6j   $��Bottom=�6v    � Value$ 10Q�6�    �� IsMoveToPointEnabled . 6�   5      5      