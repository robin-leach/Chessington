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
            string[] possibleMovements = {"upleft", "upright", "downleft", "downright" };
            List<int[]> unitVectors = new List<int[]>();
            foreach (string direction in possibleMovements) unitVectors.Add(convertDirectionToUnitVector(direction));
            return IdentifyFreeSquares(board, unitVectors);
        }
    }
}