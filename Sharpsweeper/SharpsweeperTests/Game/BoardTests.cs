using NUnit.Framework;
using Sharpsweeper.Board;
using Sharpsweeper.Board.Data;
using Sharpsweeper.Tile;

namespace SharpsweeperTests.Game
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(5, 5)]
        [TestCase(50, 10)]
        public void BoardDoesCreateCorrectNumberOfTilesForSize(int xSize, int ySize)
        {
            Board board = new Board(
                CreateBoardData(xSize, ySize, 0), 
                null,
                0);
            
            Assert.AreEqual(xSize * ySize, board.tiles.Length, 
                "Board is not created with correct number of tiles based on size parameters.");
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void BoardSeedDoesEnsureIdenticalBoard(int seed)
        {
            Board board1 = new Board(
                CreateBoardData(5, 5, 0.2f), 
                null,
                seed);
            Board board2 = new Board(
                CreateBoardData(5, 5, 0.2f), 
                null,
                seed);
            
            Assert.AreEqual(board1, board2, 
                "Boards with identical seeds are not identically constructed.");
        }

        [Test]
        public void TilesDoHaveValidNeighborCounts()
        {
            Board board = new Board(
                CreateBoardData(50, 50, 0.15f), 
                null,
                0);
            
            bool pass = true;
            foreach (ITileSimulation tile in board.tiles)
            {
                int i = tile.neighbors.Length;
                if (i != 8 &&
                    i != 3 &&
                    i != 5)
                {
                    pass = false;
                    break;
                }
            }
            
            Assert.IsTrue(pass, "Tiles have invalid number of neighbors!");
        }

        [Test]
        public void BlankTilesAreNotAdjacentToBombs()
        {
            Board board = new Board(
                CreateBoardData(50, 50, 0.15f), 
                null,
                0);

            //
            bool pass = true;
            foreach (ITileSimulation tile in board.tiles)
            {
                if (tile != null && tile.tileType == Tile.TileType.Blank)
                {
                    foreach (var t in tile.neighbors)
                    {
                        if (t != null && t.tileType == Tile.TileType.Bomb)
                        {
                            pass = false;
                            break;
                        }
                    }

                    if (!pass)
                        break;
                }
            }
            
            Assert.IsTrue(pass, "Some blank tiles have adacent bombs!");
        }

        [Test]
        public void TestGetNumberOfFlaggedBombs()
        {
            
        }
        
        
        private static BoardData CreateBoardData(int x, int y, float p)
        {
            return new BoardData
            {
                xSize = x,
                ySize = y,
                bombProbability = p
            };
        }
    }
    
    
    
}