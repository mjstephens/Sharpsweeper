# Sharpsweeper
Minesweeper in C#

Pure C# implementation of a basic minesweeper game. Create a game with board data to define board size, difficulty, etc.

---

To use, you need to create an instance of the Game class and pass in a valid IGameView (implemented in the client) and BoardData, which defines the size of the board as well as the difficulty. Use that data to construct the board/view in the client. Make sure tile objects implement the ITIleView interface to send game events (such as selecting/flagging tiles) back to the simulation.

UNITY IMPLEMENTATION:
https://github.com/mjstephens/Unity_Minesweeper
