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
using KnightsTour.Services;
using KnightsTour.Utilities;
using Moq;
using Xunit;

namespace KnightsTour.Tests
{
    public class KnightsTourRunnerTests
    {
        [Theory]
        [InlineData(5, true, true, 10)] // Use real values here
        public void Run_ShouldReturnCorrectCount(int n, bool unique, bool useWarnsdorff, int expectedCount)
        {
            // Arrange
            var mockBoard = new Mock<IChessBoard>();
            var mockSolver = new Mock<ITourSolver>();
            var mockService = new Mock<IKnightsTourService>();

            mockService.Setup(service => service.CountTours(It.IsAny<IChessBoard>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(expectedCount);

            var runner = new KnightsTourRunner(mockBoard.Object, mockSolver.Object, mockService.Object);

            // Act
            var count = runner.Run(n, unique, useWarnsdorff);

            // Assert
            Assert.Equal(expectedCount, count);
        }
    }

}
