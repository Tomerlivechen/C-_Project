   M S B A M L   `   `   `  ���� J  FPriorityDefiner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PriorityDefiner.windowsPriorityDefiner.windows  '    !PriorityDefiner.windows.Show_list   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:PriorityDefiner.windows       � Icon$4  .pack://application:,,,/Resources/Indexicon.ico�� � Title$ 	Show_list��$	��500��$
��1000�����#008080.���  � RowDefinitions �� $
��Auto ��� $
��0.3* ��� �� �� $
��0.2* � � ColumnDefinitions �� .+�o� .@�m� $��_File��$��20(�.@�m� -   $��_Save��$��20(�m� -   $��_Close��$��20(��� -   $��	ListTitle��$��1��$��10q�$��27(�$��DemiBold"�&   System.Windows.Controls.DataGrid  -   $��Task_DataGrid��   SelectionUnit$ FullRow=�   SelectionMode$ Single=�   
IsReadOnly$
 True��   AutoGenerateColumns$ False��$��0��$��2��$��10q�$��2��$��20(� � 	Resources    CenteredCellStyle	 �� 
TargetType
 �� Property �� Value��%1   &	        �� "	 ��.��� 
 � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Priority��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [     Binding �� *
priority+  $
 Task��$
 Auto # [   �� *task+  $ In Progress��$
 Auto # [   �� *
inProgress+  $
 Done��$
 Auto # [   �� *done+4  .System.Windows.Controls.DataGridTemplateColumn  $ Set progress��$ *    CellTemplate �� .R��� -   $��In progress��  $ Complete��$ *  �� .R��� -   $��Complete��  $ Delete��$ *  �� .R��� -   $��Delete��  $ Increase Priority��$ *  �� .R��� -   $��Increase��  $ Decrease Priority��$ *  �� .R��� -	   $��Decrease��