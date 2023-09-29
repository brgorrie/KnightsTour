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

namespace KnightsTour.Services
{
    /// <summary>
    /// Defines a contract for a service that solves the Knight's Tour problem,
    /// providing the functionality to count the number of possible tours on a chessboard.
    /// </summary>
    public interface IKnightsTourService
    {
        /// <summary>
        /// Counts the number of tours possible on the given chessboard, 
        /// considering whether to count only unique solutions or not.
        /// </summary>
        /// <param name="board">The chessboard on which to count the tours.</param>
        /// <param name="unique">If true, only unique solutions are counted. 
        /// If false, all solutions including reflections and rotations are counted.</param>
        /// <returns>The number of possible tours on the given chessboard.</returns>
        int CountTours(IChessBoard board, bool unique);
    }

}
