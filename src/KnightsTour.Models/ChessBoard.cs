// Copyright 2023 Brian Gorrie
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace KnightsTour.Models
{
    /// <summary>
    /// Represents a chessboard for the Knight's Tour problem, providing a concrete implementation of <see cref="IChessBoard"/>.
    /// This class encapsulates the state of the chessboard and allows interaction with individual cells on the board.
    /// </summary>
    public class ChessBoard : IChessBoard
    {
        /// <summary>
        /// Gets the size of the chessboard, i.e., the number of cells in each row or column.
        /// </summary>
        public int N { get; }

        /// <summary>
        /// Represents the internal two-dimensional array that holds the state of each cell in the chessboard.
        /// </summary>
        private int[,] _board;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoard"/> class with a specified size.
        /// </summary>
        /// <param name="n">The size of the chessboard, representing the number of cells in each row or column.</param>
        public ChessBoard(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Size of the chessboard must be a positive integer.");

            N = n;
            _board = new int[n, n];
        }

        /// <summary>
        /// Gets or sets the value in the chessboard cell at the specified row and column.
        /// </summary>
        /// <param name="row">The row of the cell to access.</param>
        /// <param name="col">The column of the cell to access.</param>
        /// <returns>The value in the chessboard cell at the specified row and column.</returns>
        public int this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= N || col < 0 || col >= N)
                    throw new IndexOutOfRangeException("Row and column must be within the bounds of the chessboard.");

                return _board[row, col];
            }
            set
            {
                if (row < 0 || row >= N || col < 0 || col >= N)
                    throw new IndexOutOfRangeException("Row and column must be within the bounds of the chessboard.");

                _board[row, col] = value;
            }
        }

        /// <summary>
        /// Checks if the proposed move is valid - within the bounds of the board and onto an unvisited square.
        /// </summary>
        /// <param name="board">The chessboard.</param>
        /// <param name="row">The proposed row position of the knight.</param>
        /// <param name="col">The proposed column position of the knight.</param>
        /// <returns>True if the move is valid; false otherwise.</returns>
        public bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < this.N && col >= 0 && col < this.N && this[row, col] == 0;
        }


    }

}
