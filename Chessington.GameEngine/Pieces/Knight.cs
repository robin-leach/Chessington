using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> knightAvailableMoves = new List<Square>();

            int[][] unitVectors = { new[] { 1, 2 }, new[] { 2, 1 }, new[] { -1, 2 }, new[] { 2, -1 } ,
            new [] {1, -2 }, new[] {-2, 1 }, new[] {-1, -2 }, new[] {-2,-1 } };

            var currentSquare = board.FindPiece(this);
            foreach (int[] unitVector in unitVectors)
            {
                int candidateRow = currentSquare.Row + unitVector[0];
                int candidateCol = currentSquare.Col + unitVector[1];
                Square candidateSquare = new Square(candidateRow, candidateCol);
                if (candidateSquare.isOnBoard()) knightAvailableMoves.Add(candidateSquare);
            }


            return knightAvailableMoves;
        }
    }
}