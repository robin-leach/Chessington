using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> bishopAvailableMoves = new List<Square>();

            int[][] unitVectors = { new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, 1 }, new[] { -1, -1 } };

            var currentSquare = board.FindPiece(this);
            for (int magnitude = 1; magnitude < 8; magnitude++)
            {
                foreach (int[] unitVector in unitVectors)
                {
                    int candidateRow = currentSquare.Row + magnitude * unitVector[0];
                    int candidateCol = currentSquare.Col + magnitude * unitVector[1];
                    Square candidateSquare = new Square(candidateRow, candidateCol);
                    if (candidateSquare.isOnBoard()) bishopAvailableMoves.Add(candidateSquare);
                }
            }

            return bishopAvailableMoves;
        }
    }
}