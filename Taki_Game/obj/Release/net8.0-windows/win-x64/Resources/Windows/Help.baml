   M S B A M L   `   `   `  ���� D  @Taki_Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Taki_Game.Resources.WindowsTaki_Game.Resources.Windows  &     Taki_Game.Resources.Windows.Help   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:Taki_Game.Resources.Windows       � Icon$4  .pack://application:,,,/Resources/Indexicon.ico�� � Title$
 Help��$	��450��$	��900��.���  � RowDefinitions �� $
��0.2* ���  � ColumnDefinitions �� $��0.05* ��� �� $��0.05* �.+��� ���#3DB1A1$��0��$��3��$��3���� ���#108D89$��1��$��1���� $��About the application��$��23(�$��
ExtraBlack"�$��Center=�$��Center=�$��1��$��0���� $��1��$��1��.���� .+��� $��18(�$��SemiBold"�$
��Wrap=�$����This application was developed for playing the game TAKI using WPF for up to 4 players on one computer. Originally, I wanted to make all players' decks visible but only the player whose turn it was could view their deck. However, due to screen size limitations, only one deck is viewable at a time. It utilizes object-oriented programming, static classes, and custom message boxes and input boxes. The assets were taken from the original game website. The rules of the game here remain as they were in the original V1 game (the current public game version is V3).���� $��18(�$��SemiBold"�$
��Wrap=�$�� ���� $��18(�$��SemiBold"�$
��Wrap=�$?��9The rules and gameplay as they appear on the TAKI website���� $��18(�$��SemiBold"�$
��Wrap=�$����GAMEPLAY: Each player must follow the top card of the Discard Pile with a card of the same color or figure. Action Cards can change the direction of play, skip a player's turn, force other players to draw cards, change the color, or allow a player to discard more than one card.���� $��18(�$��SemiBold"�$
��Wrap=�$G��ATHE OBJECT OF THE GAME: To get rid of all the cards in your hand.���� $��18(�$��SemiBold"�$
��Wrap=�$����ACTION CARDS: The cards that are not regular number cards are called Action Cards. An Action Card can affect the player who uses it, the next player, or all the players. These cards are the heart of the game, and using them wisely is the key to winning.����  �� Orientation$ 
Horizontal=�.+��� -   $��B_Taki��$"��/Resources/Images/B_Taki.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$����TAKI: Playing a TAKI card allows the player to follow it with all their cards of the same color as the TAKI. Important: a TAKI card must be closed after playing the last card by declaring: “Closed TAKI!” If the player does not close the TAKI, it is considered an “Open TAKI” and the next player may use it to get rid of all their cards of that color. The TAKI remains open until one of the players who used it declares: “Closed TAKI” or until a card of a different color is played.���� $ 
Horizontal=�.+��� -   $
��Taki��$ ��/Resources/Images/Taki.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$����SUPERTAKI: A wild TAKI which automatically receives the color of the Leading Card. It does not change the color of the Leading Card. You may play the Super-TAKI card on any card except on a +2 and +3 which are still active.���� $ 
Horizontal=�.+��� -   $��R_COrder��$$��/Resources/Images/R_COrder.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$7��1CHANGE DIRECTION: Reverses the direction of play.���� $ 
Horizontal=�.+��� -   $��R_Stop��$"��/Resources/Images/R_Stop.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$-��'STOP: The next player loses their turn.���� $ 
Horizontal=�.+��� -   $��_Color��$!��/Resources/Images/Color.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$����CHANGE COLOR: Allows the user to determine the color to be played by the next player. This card can be played at any time, except after the +2 cards which are still active.���� $ 
Horizontal=�.+��� -   $
��Y_2P��$ ��/Resources/Images/Y_2+.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$����+2: Forces the next player to draw 2 cards or play another +2, forcing the next player to draw 4 cards or follow with a +2 as well, etc. The first player who cannot follow with a +2 must draw 2 cards for every +2 card that was played. After collecting the cards, the +2 is no longer active and the next player should treat it as a regular number card.���� $ 
Horizontal=�.+��� -   $��Change��$"��/Resources/Images/Change.png��$��80��$
��Left=��� $��18(�$��SemiBold"�$
��Wrap=�$	��710��$��Center=�$B��<SWITCH DECKS: Exchanges decks with the player to your right.��