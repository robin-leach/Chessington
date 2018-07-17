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
            var currentSquare = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            string[] possibleMovements = { "upupleft", "upupright", "upleftleft", "uprightright",
                "downdownleft", "downdownright", "downleftleft", "downrightright" };
            List<int[]> unitVectors = new List<int[]>();
            foreach (string direction in possibleMovements) unitVectors.Add(convertDirectionToUnitVector(direction));

            foreach (int[] unitVector in unitVectors)
            {
                int candidateRow = currentSquare.Row + unitVector[0];
                int candidateCol = currentSquare.Col + unitVector[1];
                Square candidateSquare = new Square(candidateRow, candidateCol);

                if (candidateSquare.isOnBoard())
                {
                    if(candidateSquare.isEmpty(board)) availableMoves.Add(candidateSquare);
                    else if(board.GetPiece(candidateSquare).Player != this.Player) availableMoves.Add(candidateSquare);
                }
            }
            return availableMoves;
        }
    }
}