   M S B A M L   `   `   `  ����@  <Mylly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyllyMylly  5   	       Mylly.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Mylly     5   	     � Title$  
MainWindow��5   	   $	��700��6   $	��700��6)   $	��500��65   $	��500��6E    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ local:Commands.NewPiece��5
      6\     5   
   -   5        $  local:Commands.RemovePiece��5      6b     5   
   -   5        $ local:Commands.NewGame��5      6Z     5   
   -   5        $ local:Commands.MovePiece��5      6^     5   
   -   5        $ local:Commands.Print��5      68   .��5      � .+�5   
   o� $	��Top=�6   $��Stretch=�6'   $��20��6E   .@�5      m� $��_File��6   .@�5      m� $��	_New Game��6    m� Command$ local:Commands.NewGame��6.   m� 5      $��_Print��6   $ local:Commands.Print��6+   5      m� 5      $��_Game��6   .@�5      m� -   5         m�Name$ menuItemInsert��5      $��
_Add Piece��64   $ local:Commands.NewPiece��6H   m� 5      -   5        $ menuItemRemove��5      $��_Remove Piece��63   $  local:Commands.RemovePiece��6J   m� 5      -   5        $ menuItemMove��5      $��_Move Piece��61   $ local:Commands.MovePiece��6F   5      m� 5      $��_Tools��6   .@�5      m� -	   5        $��	_Settings��5      6.   5      m� 5      $��_Help��6   .@�5      m� -
   5        $��_About��5      6+   m� 5       -   5        $��_Help��5       6*   5!      5"      � 5#   
   $��0,20,0,0q�6    � ColumnDefinitions 5$      �� 5%      $��3* �6#   �� 5&      $��1* �6#   .+�5(         Mylly.MyllyBoard  -   5          Name$ myllyBoard1��5(      $��Stretch=�64   $��Stretch=�6P   $��0��6n   � 5)      $��1��6   $	��119��6#   $��
30,30,30,0q�60   $	��Top=�6D   $��Stretch=�6\    � RowDefinitions 5*      �� 5+      $��1* �6$   �� 5,      $��1* �6$   �� 5-      $��1* �6$   .+�5/      �� -   5         ��Name$ buttonInsert��5/      $��0��6/   $��Insert piece��6<      Mylly.Commands	   NewPiece#��Z	 6S   �� 50      -   5        $ buttonRemove��50      $��1��6/   $��Remove piece��6<   
   RemovePiece#��Z
 6S   �� 51      -   5        $ 
buttonMove��51      $��2��6-   $��
Move piece��6:      	MovePiece#��Z 6O   52      53      54      55      