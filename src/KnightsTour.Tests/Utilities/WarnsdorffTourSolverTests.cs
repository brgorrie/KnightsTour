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

using Moq;
using Xunit;
using KnightsTour.Models;
using KnightsTour.Services;
using KnightsTour.Utilities;

namespace KnightsTour.Tests.Utilities
{
    public class WarnsdorffTourSolverTests
    {

        [Fact]
        public void Solve_ShouldReturnCorrectCount_For1x1Board()
        {
            // Arrange
            var mockBoard = new Mock<IChessBoard>();
            mockBoard.Setup(b => b.N).Returns(1);
            var solver = new WarnsdorffTourSolver();

            // Act
            var count = solver.Solve(mockBoard.Object, false);

            // Assert
            Assert.Equal(1, count); // 1x1 board has only one possible tour
        }

        [Fact]
        public void Solve_ShouldReturnCorrectCount_For5x5Board()
        {
            // Arrange
            var board = new ChessBoard(5);
            var solver = new WarnsdorffTourSolver();

            // Act
            var count = solver.Solve(board, false);

            // Assert
            Assert.Equal(25, count); 
        }

    }

}
