# Sharpsweeper
Minesweeper in C#

Pure C# implementation of a basic minesweeper game.

---

USAGE:

Create an instance of a Game, passing in an IGameView reference and a BoardData struct. You can then use the board data created in the Game constructor to instantiate/create the view for the board and tiles. Make sure the tile objects have a way to respond to input via the ITileView interface.

```
// Required for game construction
IGameView view;
BoardData data;
int seed;

// Create game instance
IGameSimulation myGame = new Sharpsweeper.Game.Game(
  view,
  data,
  seed);
  
// ...
// Construct board/tiles view objects here
// Use myGame.board for access to parameters/board tiles
// ...

// Start the game
myGame.OnClientGameBegin();
```

Your tile objects should be able to respond to user input; by implementing the ITileView interface, they can report player actions to the simulation.

You can update the game simulation from the client through the IGameSimulation.OnClientGameUpdate() method. Do this every frame/tick to update time elapsed and trigger any view changes.

You can listen to simulation updates in the client through the IGameView.OnGameUpdate(GameProgressData data) method. Do this to respond to simulation changes in the view.

When the game is won or lost, the IGameView.OnGameFinished(GameSummaryData data) method will be called from the simulation. Use the data parameter to display scores, check for new records, etc.

See the implementations below for practical examples.

---

IMPLEMENTATIONS:

UNITY
https://github.com/mjstephens/Unity_Minesweeper
