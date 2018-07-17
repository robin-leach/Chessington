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
            int oneRowAway, twoRowsAway;

            if (base.Player == Player.Black)
            {
                oneRowAway = currentSquare.Row + 1;
                twoRowsAway = currentSquare.Row + 2;
            }
            else
            {
                oneRowAway = currentSquare.Row - 1;
                twoRowsAway = currentSquare.Row - 2;
            }

            Square oneSquareAway = new Square(oneRowAway, currentSquare.Col);
            pawnAvailableMoves.Add(oneSquareAway);

            if (!hasMoved)
            {
                Square twoSquaresAway = new Square(twoRowsAway, currentSquare.Col);
                pawnAvailableMoves.Add(twoSquaresAway);
            }

            return pawnAvailableMoves;
        }
    }
}