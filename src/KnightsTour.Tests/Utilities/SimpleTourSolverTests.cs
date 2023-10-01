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

using Xunit;
using KnightsTour.Services;
using KnightsTour.Models;
using KnightsTour.Utilities;

namespace KnightsTour.Tests.Utilities
{
    public class SimpleTourSolverTests
    {
        [Fact]
        public void Solve_ShouldReturnCorrectCountFor3x3Board_UniqueFalse()
        {
            // Arrange
            var solver = new SimpleTourSolver();
            var board = new ChessBoard(3);

            // Act
            var count = solver.Solve(board);

            // Assert
            // There are no possible complete tours on a 3x3 board.
            Assert.Equal(0, count);
        }

        [Theory]
        [InlineData(5, 1728)]
        [InlineData(1, 1)]
        public void Solve_ShouldReturnCorrectCountFor5x5Board_UniqueFalse(int n, int expectedCount)
        {
            // Arrange
            var solver = new SimpleTourSolver();
            var board = new ChessBoard(n);

            // Act
            var count = solver.Solve(board);

            // Assert
            Assert.Equal(expectedCount, count);
        }

    }

}
