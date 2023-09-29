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
using KnightsTour.Models;

namespace KnightsTour.Tests.Models
{
    public class ChessBoardTests
    {
        [Fact]
        public void Constructor_ShouldSetNProperty()
        {
            // Arrange
            var n = 8;

            // Act
            var chessBoard = new ChessBoard(n);

            // Assert
            Assert.Equal(n, chessBoard.N);
        }

        [Fact]
        public void Indexer_ShouldGetAndSetValue()
        {
            // Arrange
            var chessBoard = new ChessBoard(8);

            // Act
            chessBoard[3, 4] = 5;

            // Assert
            Assert.Equal(5, chessBoard[3, 4]);
        }

        [Theory]
        [InlineData(-1, 4)]
        [InlineData(4, -1)]
        [InlineData(8, 4)]
        [InlineData(4, 8)]
        public void Indexer_ShouldThrowIndexOutOfRangeException_ForInvalidIndex(int row, int col)
        {
            // Arrange
            var chessBoard = new ChessBoard(8);

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = chessBoard[row, col]; });
        }
    }

}
