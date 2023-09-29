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

namespace KnightsTour.Models
{
    /// <summary>
    /// Represents a chessboard for the Knight's Tour problem. It provides the necessary properties and indexer
    /// to interact with the chessboard during the problem-solving process.
    /// </summary>
    public interface IChessBoard
    {
        /// <summary>
        /// Gets the size of the chessboard, i.e., the number of cells in each row or column.
        /// </summary>
        int N { get; }

        /// <summary>
        /// Gets or sets the value in the chessboard cell at the specified row and column.
        /// </summary>
        /// <param name="row">The row of the cell to access.</param>
        /// <param name="col">The column of the cell to access.</param>
        /// <returns>The value in the chessboard cell at the specified row and column.</returns>
        int this[int row, int col] { get; set; }

    }

}
