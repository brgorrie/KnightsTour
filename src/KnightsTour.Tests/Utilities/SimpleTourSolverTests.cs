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
            var unique = false;

            // Act
            var count = solver.Solve(board, unique);

            // Assert
            // There are no possible complete tours on a 3x3 board.
            Assert.Equal(0, count);
        }

        [Fact]
        public void Solve_ShouldThrowNotSupportedException_ForWarnsdorff()
        {
            // Arrange
            var solver = new SimpleTourSolver();
            var board = new ChessBoard(3);
            var unique = false;

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => solver.Solve(board, unique));
        }

        [Theory]
        [InlineData(5, false, 1728)]
        [InlineData(5, true, 216)]
        [InlineData(8, false, 1728)]
        [InlineData(8, true, 216)]
        public void Solve_ShouldReturnCorrectCountFor5x5Board_UniqueFalse(int n, bool unique, int expectedCount)
        {
            // Arrange
            var solver = new SimpleTourSolver();
            var board = new ChessBoard(n);

            // Act
            var count = solver.Solve(board, unique);

            // Assert
            Assert.Equal(expectedCount, count);
        }

    }

}
