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
    public class SimpleTourSolver : ITourSolver
    {
        private static readonly int[] RowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private static readonly int[] ColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public int Solve(IChessBoard board, bool unique, bool useWarnsdorff)
        {
            if (useWarnsdorff)
            {
                // This solver doesn't support Warnsdorff’s algorithm
                throw new NotSupportedException("This solver doesn't support Warnsdorff’s algorithm.");
            }

            var count = 0;
            for (var row = 0; row < board.N; row++)
            {
                for (var col = 0; col < board.N; col++)
                {
                    // Mark the starting point
                    board[row, col] = 1;

                    // Start the tour from this point
                    count += Solve(board, row, col, 1);

                    // Clear the starting point
                    board[row, col] = 0;
                }
            }

            // If unique solutions are required, consider dividing by 8 to account for rotations and reflections
            return unique ? count / 8 : count;
        }

        private int Solve(IChessBoard board, int row, int col, int numMoves)
        {
            if (numMoves == board.N * board.N)
            {
                return 1;
            }

            var count = 0;
            for (var i = 0; i < 8; i++)
            {
                var newRow = row + RowMoves[i];
                var newCol = col + ColMoves[i];

                if (IsValidMove(board, newRow, newCol))
                {
                    board[newRow, newCol] = numMoves + 1;
                    count += Solve(board, newRow, newCol, numMoves + 1);
                    board[newRow, newCol] = 0; // backtrack
                }
            }
            return count;
        }

        private bool IsValidMove(IChessBoard board, int row, int col)
        {
            return row >= 0 && row < board.N && col >= 0 && col < board.N && board[row, col] == 0;
        }
    }

}
