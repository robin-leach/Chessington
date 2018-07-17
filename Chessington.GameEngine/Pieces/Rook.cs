using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> rookAvailableMoves = new List<Square>();

            int[][] unitVectors = { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 } };

            var currentSquare = board.FindPiece(this);
            for(int i = 1; i < 8; i++)
            {
                foreach(int[] unitVector in unitVectors)
                {
                    int candidateRow = currentSquare.Row + i * unitVector[0];
                    int candidateCol = currentSquare.Col + i * unitVector[1];
                    Square candidateSquare = new Square(candidateRow, candidateCol);
                    if (candidateSquare.isOnBoard()) rookAvailableMoves.Add(candidateSquare);
                }
            }


            return rookAvailableMoves;
        }
    }
}