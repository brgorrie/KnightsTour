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

using KnightsTour.Models;

namespace KnightsTour.Utilities
{
    /// <summary>
    /// Implements the <see cref="ITourSolver"/> interface to provide a simple solver for the Knight's Tour problem.
    /// This solver iteratively attempts all possible moves from each position on the board until it either finds a solution or exhausts all possibilities.
    /// </summary>
    public class SimpleTourSolver : ITourSolver
    {
        /// <summary>
        /// Defines the possible moves of a knight on a chessboard.
        /// </summary>
        private static readonly (int, int)[] s_moves = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };

        /// <summary>
        /// Solves the Knight's Tour problem on the given chessboard and calculates the number of possible tours.
        /// </summary>
        /// <param name="board">The chessboard on which to solve the Knight's Tour problem.</param>
        /// <param name="unique">Indicates whether to count only unique solutions, ignoring rotations and reflections.</param>
        /// <returns>The number of possible tours on the given chessboard.</returns>
        public int Solve(IChessBoard board, bool unique)
        {
            var count = 0;
            for (var row = 0; row < board.N; row++)
            {
                for (var col = 0; col < board.N; col++)
                {
                    board[row, col] = 1;  // Mark the starting point of the knight.
                    count += Solve(board, row, col, 1);  // Start the tour from this point and add to count.
                    board[row, col] = 0;  // Clear the starting point after attempting all possibilities.
                }
            }
            // Adjust the count if unique solutions are requested to account for rotations and reflections.
            return unique ? count / 8 : count;
        }

        /// <summary>
        /// Attempts to solve the Knight's Tour problem recursively from the given position.
        /// </summary>
        /// <param name="board">The chessboard.</param>
        /// <param name="row">The current row position of the knight.</param>
        /// <param name="col">The current column position of the knight.</param>
        /// <param name="numMoves">The number of moves made so far.</param>
        /// <returns>The number of solutions found from this position.</returns>
        public int Solve(IChessBoard board, int row, int col, int numMoves)
        {
            if (numMoves == board.N * board.N) return 1;  // A tour is completed.

            var count = 0;
            for (var i = 0; i < 8; i++)  // Attempt each possible knight move.
            {
                var (newRow, newCol) = (row + s_moves[i].Item1, col + s_moves[i].Item2);

                if (!board.IsValidMove(newRow, newCol))
                {
                    continue;
                }

                board[newRow, newCol] = numMoves + 1;  // Make a move.
                count += Solve(board, newRow, newCol, numMoves + 1);  // Recur with the new position.
                board[newRow, newCol] = 0;  // Backtrack after attempting all possibilities from the new position.
            }
            return count;
        }

    }

}
