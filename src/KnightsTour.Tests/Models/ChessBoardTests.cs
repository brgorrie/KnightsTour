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

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidSize(int n)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessBoard(n));
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
        [InlineData(8, 4, -1, 4)]
        [InlineData(8, 4, 4, -1)]
        [InlineData(8, 4, 8, 4)]
        [InlineData(8, 4, 4, 8)]
        [InlineData(5, 2, 5, 2)]
        [InlineData(5, 2, 2, 5)]
        public void Indexer_ShouldThrowIndexOutOfRangeException_ForInvalidIndex(int n, int value, int row, int col)
        {
            // Arrange
            var chessBoard = new ChessBoard(n);

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => { chessBoard[row, col] = value; });
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = chessBoard[row, col]; });
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 4)]
        [InlineData(7, 7)]
        public void IsValidMove_ShouldReturnTrue_ForValidMove(int row, int col)
        {
            // Arrange
            var chessBoard = new ChessBoard(8);

            // Act
            var isValid = chessBoard.IsValidMove(row, col);

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 4)]
        [InlineData(7, 7)]
        public void IsValidMove_ShouldReturnFalse_ForVisitedSquare(int row, int col)
        {
            // Arrange
            var chessBoard = new ChessBoard(8);
            chessBoard[row, col] = 1; // Mark the square as visited

            // Act
            var isValid = chessBoard.IsValidMove(row, col);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(-1, 4)]
        [InlineData(4, -1)]
        [InlineData(8, 4)]
        [InlineData(4, 8)]
        public void IsValidMove_ShouldReturnFalse_ForInvalidMove(int row, int col)
        {
            // Arrange
            var chessBoard = new ChessBoard(8);

            // Act
            var isValid = chessBoard.IsValidMove(row, col);

            // Assert
            Assert.False(isValid);
        }
    }

}
