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
    /// Implements the <see cref="ITourSolver"/> interface to provide a solver for the Knight's Tour problem using Warnsdorff's heuristic.
    /// Warnsdorff's rule is a heuristic for finding a single knight's tour. The knight is moved so that it always proceeds to the square from which the knight will have the fewest onward moves.
    /// </summary>
    public class WarnsdorffTourSolver : ITourSolver
    {
        /// <summary>
        /// Defines the possible moves of a knight on a chessboard.
        /// </summary>
        private static readonly (int, int)[] s_moves = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };

        /// <summary>
        /// Solves the Knight's Tour problem on the given chessboard using Warnsdorff's heuristic and calculates the number of possible tours.
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
                    board[row, col] = 1; // Mark the starting point of the knight.
                    if (FindTour(board, row, col, 1))
                        count++;
                    board[row, col] = 0; // Reset the starting point after finding a tour.
                }
            }

            // Adjust the count if unique solutions are requested to account for rotations and reflections.
            return unique ? count / 8 : count;
        }

        /// <summary>
        /// Attempts to solve the Knight's Tour problem recursively using Warnsdorff's heuristic from the given position.
        /// </summary>
        /// <param name="board">The chessboard.</param>
        /// <param name="row">The current row position of the knight.</param>
        /// <param name="col">The current column position of the knight.</param>
        /// <param name="numMoves">The number of moves made so far.</param>
        /// <returns>True if a tour is found from this position; false otherwise.</returns>
        private static bool FindTour(IChessBoard board, int row, int col, int numMoves)
        {
            if (numMoves == board.N * board.N) return true;  // A tour is completed.

            var neighborDegrees = new List<(int row, int col, int degree)>();

            // Calculate the degree of each valid neighbor.
            for (var i = 0; i < 8; i++)
            {
                var (newRow, newCol) = (row + s_moves[i].Item1, col + s_moves[i].Item2);
                if (IsValidMove(board, newRow, newCol))
                    neighborDegrees.Add((newRow, newCol, GetDegree(board, newRow, newCol)));
            }

            // Order neighbors by degree and attempt the tour.
            foreach (var (nextRow, nextCol, _) in neighborDegrees.OrderBy(n => n.degree))
            {
                board[nextRow, nextCol] = numMoves + 1;
                if (FindTour(board, nextRow, nextCol, numMoves + 1)) return true;  // Continue if a tour is found.
                board[nextRow, nextCol] = 0; // Backtrack if no tour is found.
            }

            return false;  // No tour is found.
        }

        /// <summary>
        /// Calculates the degree of a position on the board, representing the number of valid moves from that position.
        /// </summary>
        /// <param name="board">The chessboard.</param>
        /// <param name="row">The row position to calculate the degree for.</param>
        /// <param name="col">The column position to calculate the degree for.</param>
        /// <returns>The degree of the position on the board.</returns>
        private static int GetDegree(IChessBoard board, int row, int col)
        {
            var degree = 0;
            for (var i = 0; i < 8; i++)
            {
                var (newRow, newCol) = (row + s_moves[i].Item1, col + s_moves[i].Item2);
                if (IsValidMove(board, newRow, newCol)) degree++;
            }
            return degree;
        }

        /// <summary>
        /// Checks if the proposed move is valid - within the bounds of the board and onto an unvisited square.
        /// </summary>
        /// <param name="board">The chessboard.</param>
        /// <param name="row">The proposed row position of the knight.</param>
        /// <param name="col">The proposed column position of the knight.</param>
        /// <returns>True if the move is valid; false otherwise.</returns>
        private static bool IsValidMove(IChessBoard board, int row, int col)
        {
            return row >= 0 && row < board.N && col >= 0 && col < board.N && board[row, col] == 0;
        }

    }

}
