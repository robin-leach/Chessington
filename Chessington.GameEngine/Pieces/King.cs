using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> kingAvailableMoves = new List<Square>();

            int[][] unitVectors = { new[] { -1, -1 }, new[] { -1, 0 }, new[] { -1, 1 }, new[] { 0, -1 } ,
            new [] {0, 1 }, new[] {1, -1 }, new[] {1, 0 }, new[] {1,1 } };

            var currentSquare = board.FindPiece(this);
            foreach (int[] unitVector in unitVectors)
            {
                int candidateRow = currentSquare.Row + unitVector[0];
                int candidateCol = currentSquare.Col + unitVector[1];
                Square candidateSquare = new Square(candidateRow, candidateCol);
                if (candidateSquare.isOnBoard()) kingAvailableMoves.Add(candidateSquare);
            }


            return kingAvailableMoves;
        }
    }
}