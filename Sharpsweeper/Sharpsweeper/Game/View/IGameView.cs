using Sharpsweeper.Game.Data;

namespace Sharpsweeper.Game.View
{
    /// <summary>
    /// Implement this interface client-side to respond to game updates.
    /// </summary>
    public interface IGameView
    {
        void OnGameSet(GameConfigurationData data);
        void OnGameUpdated(GameProgressData data);
        void OnGameFinished(GameSummaryData data);
    }
}