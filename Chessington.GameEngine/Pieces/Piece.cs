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

        IDictionary<string, string> directions = new Dictionary<string, string>()
            {
                {"up", "-1,0" },
                {"down", "1,0" },
                {"left", "0,-1" },
                {"right", "0,1" },
                {"upleft", "-1,-1" },
                {"upright", "-1,1" },
                {"downleft", "1,-1" },
                {"downright", "1,1" }
            };

        public int[] convertDirectionToUnitVector(string directionAsWord)
        {
            string directionAsString;
            directions.TryGetValue(directionAsWord, out directionAsString);
            int[] directionAsArray = directionAsString.Split(',').Select(str => int.Parse(str)).ToArray();
            return directionAsArray;
        }


        public List<Square> IdentifyFreeSquares (Board board, List<int[]> unitVectors)
        {
            List<Square> availableMoves = new List<Square>();

            var currentSquare = board.FindPiece(this);
            foreach (int[] unitVector in unitVectors)
            {
                List<Square> squaresInLine = new List<Square>();

                int candidateRow = currentSquare.Row + unitVector[0];
                int candidateCol = currentSquare.Col + unitVector[1];
                Square candidateSquare = new Square(candidateRow, candidateCol);

                while(candidateSquare.isOnBoard())
                {
                    squaresInLine.Add(candidateSquare);
                    candidateSquare.Row += unitVector[0];
                    candidateSquare.Col += unitVector[1];
                }

                foreach(Square square in squaresInLine)
                {
                    if (square.isEmpty(board)) availableMoves.Add(square);
                    else
                    {
                        if (board.GetPiece(square).Player != this.Player) availableMoves.Add(square);
                        break;
                    }
                }

            }

            return availableMoves;
        }
    }
}