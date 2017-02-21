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

            foreach(int[] unitVector in unitVectors)
            {
                bool hasFoundPieceOrBoundary = false;
                int magnitude = 0;

                while (hasFoundPieceOrBoundary == false)
                {
                    magnitude++;
                    int candidateRow = currentSquare.Row + magnitude * unitVector[0];
                    int candidateCol = currentSquare.Col + magnitude * unitVector[1];
                    Square candidateSquare = new Square(candidateRow, candidateCol);
                    if (candidateSquare.isOnBoard() && candidateSquare.isEmpty(board)) rookAvailableMoves.Add(candidateSquare);
                    else hasFoundPieceOrBoundary = true;
                }
            }

            return rookAvailableMoves;
        }
    }
}