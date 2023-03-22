﻿using Core.Pieces;

namespace Core
{
    public abstract class Piece : IDisposable
    {
        #region Fields
        public static List<Piece> Pieces = new List<Piece>();
        public static List<Piece> White_CapturedPieces = new List<Piece>();
        public static List<Piece> Black_CapturedPieces = new List<Piece>();
        private bool disposed;

        //public enum Player { Player_One = 1, Player_Two = 2 }
        #endregion
        #region Properties
        public char Player { get; set; }
        public Tile? CurrentTile { get; set; }
        public List<Tile> CurrentValidMoves { get; set; } = new List<Tile>();
        #endregion
        #region constructor
        public Piece(char player, Tile? tile)
        {
            Player = player;
            CurrentTile = tile;
            Pieces.Add(this);
        }
        #endregion
        #region methods

        public abstract void GetValidMoves(Board board, Tile selTile);
        protected void IgnoreKing(List<Tile> validMoves)
        {
            //for (int i = 0; i < validMoves.Count; i++)
            //    if (validMoves[i].CurrentPiece is King)
            //        validMoves.RemoveAt(i);
        }
        protected void IgnoreFriendlies(List<Tile> moveList, Player currPlayer)
        {
            // remove move if it contains a king or friendly player
            foreach (Tile move in moveList.ToList())
                if (move.CurrPiece != null)
                    if (move.CurrPiece is King || (int)move.CurrPiece.Player == (int)currPlayer)
                    {
                        moveList.Remove(move);
                        //MessageBox.Show($"ignored {move}");
                    }
        }

        #endregion
        #region handle dispose
        public void Dispose()
        {
            Dispose(true);
            Image?.Dispose();
            GC.Collect();
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // CurrentPlayer = null;
                    CurrentTile = null;
                    CurrentValidMoves = null;
                    Image = null;
                    Pieces.Clear();
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }
        #endregion
        #region tostring
        public override string ToString() => $"{Player.ToString().Replace("_", " ")}'s {GetType().Name}";
        #endregion
    }
}
