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
using Moq;
using Xunit;
using KnightsTour.Services;
using KnightsTour.Utilities;

namespace KnightsTour.Tests.Services
{
    public class KnightsTourServiceTests
    {
        [Fact]
        public void CountTours_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockSolver = new Mock<ITourSolver>();
            var mockBoard = new Mock<IChessBoard>();
            var service = new KnightsTourService(mockSolver.Object);

            bool unique = true;
            int expectedCount = 123;

            // Setup mockSolver to return a specific count.
            mockSolver.Setup(solver => solver.Solve(mockBoard.Object, unique))
                .Returns(expectedCount);

            // Act
            var actualCount = service.CountTours(mockBoard.Object, unique);

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void CountTours_ShouldCallSolveMethodWithCorrectParameters()
        {
            // Arrange
            var mockSolver = new Mock<ITourSolver>();
            var mockBoard = new Mock<IChessBoard>();
            var service = new KnightsTourService(mockSolver.Object);

            bool unique = true;

            // Act
            var _ = service.CountTours(mockBoard.Object, unique);

            // Assert
            mockSolver.Verify(solver => solver.Solve(mockBoard.Object, unique), Times.Once);
        }
    }

}
