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
    public class WarnsdorffTourSolver : ITourSolver
    {
        private static readonly int[] RowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private static readonly int[] ColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public int Solve(IChessBoard board, bool unique)
        {

            int count = 0;

            for (var row = 0; row < board.N; row++)
            {
                for (var col = 0; col < board.N; col++)
                {
                    board[row, col] = 1; // mark the starting point
                    if (FindTour(board, row, col, 1))
                        count++;
                    board[row, col] = 0; // reset the starting point
                }
            }

            return unique ? count / 8 : count;
        }

        private bool FindTour(IChessBoard board, int row, int col, int numMoves)
        {
            if (numMoves == board.N * board.N)
                return true;

            var neighborDegrees = new List<(int row, int col, int degree)>();

            for (var i = 0; i < 8; i++)
            {
                var newRow = row + RowMoves[i];
                var newCol = col + ColMoves[i];

                if (IsValidMove(board, newRow, newCol))
                {
                    var degree = GetDegree(board, newRow, newCol);
                    neighborDegrees.Add((newRow, newCol, degree));
                }
            }

            foreach (var (nextRow, nextCol, _) in neighborDegrees.OrderBy(n => n.degree))
            {
                board[nextRow, nextCol] = numMoves + 1;
                if (FindTour(board, nextRow, nextCol, numMoves + 1))
                    return true;
                board[nextRow, nextCol] = 0; // backtrack
            }

            return false;
        }

        private int GetDegree(IChessBoard board, int row, int col)
        {
            int degree = 0;
            for (int i = 0; i < 8; i++)
            {
                var newRow = row + RowMoves[i];
                var newCol = col + ColMoves[i];

                if (IsValidMove(board, newRow, newCol))
                    degree++;
            }
            return degree;
        }

        private bool IsValidMove(IChessBoard board, int row, int col)
        {
            return row >= 0 && row < board.N && col >= 0 && col < board.N && board[row, col] == 0;
        }
    }

}
