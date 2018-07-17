using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> pawnAvailableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            int adjacentRow, adjacentCol;
            adjacentCol = currentSquare.Col;

            if (base.Player == Player.Black) adjacentRow = currentSquare.Row + 1;
            else adjacentRow = currentSquare.Row - 1;

            Square adjacentSquare = new Square(adjacentRow, adjacentCol);
            pawnAvailableMoves.Add(adjacentSquare);

            return pawnAvailableMoves;
        }
    }
}