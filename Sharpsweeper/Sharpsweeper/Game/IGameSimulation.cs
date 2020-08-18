using Sharpsweeper.Board;

namespace Sharpsweeper.Game
{
    public interface IGameSimulation
    {
        #region Properties

        IBoardSimulation board { get; }
        GameState state { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Tells the game to update/send update to view.
        /// </summary>
        void OnClientGameUpdate();
        void OnClientGameBegin();
        
        void GameLost();
        void GameWon();

        #endregion Methods
    }
}