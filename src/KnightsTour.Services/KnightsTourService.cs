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
using KnightsTour.Utilities;

namespace KnightsTour.Services
{
    /// <summary>
    /// Represents a service that utilizes a specified tour solver to solve the Knight's Tour problem.
    /// This service counts the number of possible tours on a provided chessboard.
    /// </summary>
    public class KnightsTourService : IKnightsTourService
    {
        /// <summary>
        /// The tour solver used to calculate the number of tours. 
        /// </summary>
        private readonly ITourSolver _solver;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnightsTourService"/> class 
        /// with a specified tour solver.
        /// </summary>
        /// <param name="solver">The tour solver to be used by the service.</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided solver is null.</exception>
        public KnightsTourService(ITourSolver solver)
        {
            _solver = solver ?? throw new ArgumentNullException(nameof(solver));
        }

        /// <summary>
        /// Counts the number of possible tours on the given chessboard, using the 
        /// provided tour solver. It considers whether to count only unique solutions or not.
        /// </summary>
        /// <param name="board">The chessboard on which to count the tours.</param>
        /// <param name="unique">If true, the method counts only unique solutions.
        /// If false, all solutions including reflections and rotations are counted.</param>
        /// <returns>The number of possible tours on the given chessboard.</returns>
        public int CountTours(IChessBoard board, bool unique)
        {
            var count = _solver.Solve(board, unique);
            return count;
        }

    }

}
