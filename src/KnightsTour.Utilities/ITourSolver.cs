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
    /// Defines the contract for a tour solver, responsible for solving the Knight's Tour problem on a chessboard.
    /// Implementing classes should provide a specific algorithm to solve the problem and count the number of possible tours.
    /// </summary>
    public interface ITourSolver
    {
        /// <summary>
        /// Solves the Knight's Tour problem on the provided chessboard and calculates the number of possible tours, considering 
        /// whether to count only unique solutions or not.
        /// </summary>
        /// <param name="board">The chessboard on which to solve the Knight's Tour problem.</param>
        /// <param name="unique">If true, the method should count only unique solutions, ignoring rotations and reflections.
        /// If false, all solutions including reflections and rotations should be counted.</param>
        /// <returns>The number of possible tours on the given chessboard.</returns>
        int Solve(IChessBoard board, bool unique);
    }

}
