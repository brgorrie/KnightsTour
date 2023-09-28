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
        [Fact]
        public void Run_ShouldCallCountToursAndWriteToConsole()
        {
            // Arrange
            var mockBoard = new Mock<IChessBoard>();
            var mockService = new Mock<IKnightsTourService>();
            var mockOutputService = new Mock<IOutputService>();

            mockService
                .Setup(service => service.CountTours(It.IsAny<IChessBoard>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(123); // You can put any number here as a dummy return value.

            var runner = new KnightsTourRunner(mockBoard.Object, mockService.Object, mockOutputService.Object);
            var originalOut = Console.Out; // keep original console to restore later

            try
            {

                // Act
                runner.Run(5, true, true); // You can put any valid values here, as they won't impact the mocked methods.

                // Assert
                mockService.Verify(service => service.CountTours(mockBoard.Object, true, true), Times.Once);
                mockOutputService.Verify(writer => writer.Write(It.Is<string>(s => s.Contains("123"))), Times.Once); // Verify that the console received the expected output.
            }
            finally
            {
                Console.SetOut(originalOut); // restore original console
            }
        }
    }

}
