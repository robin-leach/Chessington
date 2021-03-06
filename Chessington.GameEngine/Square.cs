﻿namespace Chessington.GameEngine
{
    public struct Square
    {
        public int Row;
        public int Col;

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public static Square At(int row, int col)
        {
            return new Square(row, col);
        }

        public bool Equals(Square other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Square && Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }

        public static bool operator ==(Square left, Square right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Square left, Square right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }

        public bool isOnBoard()
        {
            if (Row < 0 || Row > 7 || Col < 0 || Col > 7) return false;
            else return true;
        }

        public bool isEmpty(Board board)
        {
            if (board.GetPiece(this) == null) return true;
            else return false;

        }
    }
}