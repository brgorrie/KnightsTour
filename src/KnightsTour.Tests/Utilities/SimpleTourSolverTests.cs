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
            var useWarnsdorff = false;

            // Act
            var count = solver.Solve(board, unique, useWarnsdorff);

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
            var useWarnsdorff = true;

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => solver.Solve(board, unique, useWarnsdorff));
        }

        [Fact]
        public void Solve_ShouldReturnCorrectCountFor5x5Board_UniqueFalse()
        {
            // Arrange
            var solver = new SimpleTourSolver();
            var board = new ChessBoard(5);
            var unique = false;
            var useWarnsdorff = false;

            // Act
            var count = solver.Solve(board, unique, useWarnsdorff);

            // Assert
            // Depending on your implementation details and the problem constraints,
            // this count might vary.
            // Replace the expected count with the correct value according to your implementation.
            var expectedCount = 1728; // Replace with the actual count
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public void Solve_ShouldReturnCorrectCountFor5x5Board_UniqueTrue()
        {
            // Arrange
            var solver = new SimpleTourSolver();
            var board = new ChessBoard(5);
            var unique = true;
            var useWarnsdorff = false;

            // Act
            var count = solver.Solve(board, unique, useWarnsdorff);

            // Assert
            // Depending on your implementation details and the problem constraints,
            // this count might vary.
            // Replace the expected count with the correct value according to your implementation.
            var expectedCount = 216; // Replace with the actual count
            Assert.Equal(expectedCount, count);
        }

    }

}
