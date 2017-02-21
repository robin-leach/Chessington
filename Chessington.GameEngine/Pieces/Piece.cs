using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public bool hasMoved = false;

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            hasMoved = true;
        }

        public List<Square> identifyFreeSquaresGivenUnitVectors (Board board, int[][] unitVectors)
        {
            List<Square> availableMoves = new List<Square>();

            var currentSquare = board.FindPiece(this);
            foreach (int[] unitVector in unitVectors)
            {
                bool hasFoundPieceOrBoundary = false;
                int magnitude = 0;

                while (hasFoundPieceOrBoundary == false)
                {
                    magnitude++;
                    int candidateRow = currentSquare.Row + magnitude * unitVector[0];
                    int candidateCol = currentSquare.Col + magnitude * unitVector[1];
                    Square candidateSquare = new Square(candidateRow, candidateCol);

                    if (candidateSquare.isOnBoard() && candidateSquare.isEmpty(board))
                        availableMoves.Add(candidateSquare);
                    else hasFoundPieceOrBoundary = true;
                }
            }

            return availableMoves;
        }
    }
}