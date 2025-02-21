using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.Tests
{
    public class NineSixtyTests
    {

        [Fact]
        public void DefaultNoNineSixty_IsStandardBoardLayout()
        {
            bool isStandardArrangement = false;
            var standardBoard = new Board(8, true);
            for (int i = 0; i < 960; i++)
            {
                var board = new Board(8, true, false);
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        isStandardArrangement = (board.GetTile(j, k).Piece == null && standardBoard.GetTile(j, k).Piece == null) || (board.GetTile(j, k).Piece.ToString() == standardBoard.GetTile(j, k).Piece.ToString());
                        if (!isStandardArrangement)
                        {
                            Assert.Fail($"{j},{k} was not standard on check #{i + 1}");
                        }
                    }
                }
            }
            Assert.True(isStandardArrangement);
        }
        [Fact]
        public void DefaultWithNineSixty_IsStandardBoardLayout()
        {
            bool isStandardArrangement = false;
            var standardBoard = new Board(8, true);
            for (int i = 0; i < 960; i++)
            {
                var board = new Board(8, true, true);
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        isStandardArrangement = (board.GetTile(j, k).Piece == null && standardBoard.GetTile(j, k).Piece == null) || (board.GetTile(j, k).Piece.ToString() == standardBoard.GetTile(j, k).Piece.ToString());
                        if (!isStandardArrangement)
                        {
                            Assert.Fail($"{j},{k} was not standard on check #{i + 1}");
                        }
                    }
                }
            }
            Assert.True(isStandardArrangement);
        }
        [Fact]
        public void NoDefaultWithNineSixty_IsNotStandardLayout()
        {
            bool isStandardArrangement = true;
            var standardBoard = new Board(8, true);
            for (int i = 0; i < 960; i++)
            {
                var board = new Board(8, false, true);
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        isStandardArrangement = (board.GetTile(j, k).Piece == null && standardBoard.GetTile(j, k).Piece == null) || (board.GetTile(j, k).Piece.ToString() == standardBoard.GetTile(j, k).Piece.ToString());
                        if (!isStandardArrangement)
                        {
                            Assert.True(true);
                            return;
                        }
                    }
                }
            }
            Assert.Fail($"Was standard arrangement on all checks (chance of false negative)");
        }
        [Fact]
        public void KingsDoNotGenerateOnSides()
        {
            for (int i = 0; i < 9600; i++)
            {
                var board = new Board(8, false, true);
                Assert.InRange<int>(board.BlackKingLocation.Column, 1, 6);
            }
        }

    }
}