   M S B A M L   `   `   `  ����F  BImageViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ImageViewerImageViewer  5   	       ImageViewer.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ImageViewer     5   	   -   5          � Title$  ImageViewer��5   	   $	��450��6   $	��800��6*   .��5	      � $	��Top=�6   $��Stretch=�6#   .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FF2C2C2C$��44��6E   $	��Top=�6Q   .+�5      �� -   5         ��Name$ 
OpenButton��5         ImageButtonStyle#��[  6)    �� 	IsDefault$
 True��6S   $��36��6d   $	��Top=�6p   $��36��6�   .��5      �� $��/img/FolderWhite.png��6   $��Center=�66   $��Center=�6S   $��32��6n   $��32��6y    J� RenderTransformOrigin$ 0,0.079&�6�   $
��Fill=�6�    J� OpacityMask
 �   �6�   5      �� 5      -   5        $ CloseButton��5      #��[  6*   $	��Top=�6T   $��36��6l   $��36��6x   .��5      �� $��32��6   $��32��6$   $��/img/TrashBoxWhite.png��6/   
 �  ��6O   5      5      � 5   
   $��0,44,0,0q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $	��97* �6#   .+�5      �� -   5         ��Name$ 
FileViewer��5      $	��120��6V   $
��Left=�6b   $��2��6�   $��Disabled=�6�    �� View 5      �� 5      .P�5      �� 5       5"      �� 5#      -   5        	 ��Name$	 Image1��5#      $��
106,0,10,0q�6$    �	#FFBF0000$��/img/folder.png��6P   $��1��6i   5$      5%      5&      