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

namespace KnightsTour;

/// <summary>
/// Defines a contract for a class that runs the Knight's Tour algorithm.
/// The Knight's Tour is a sequence of moves of a knight on a chessboard 
/// such that the knight visits every square only once.
/// </summary>
public interface IKnightsTourRunner
{

    /// <summary>
    /// Runs the Knight's Tour algorithm and returns the number of tours found.
    /// </summary>
    /// <param name="n">
    /// The size of the chessboard. A standard chessboard would have n = 8, 
    /// representing an 8x8 board.
    /// </param>
    /// <returns>
    /// The number of tours found. If <paramref name="shouldFindUniqueTours"/> is true,
    /// this represents the number of unique tours found.
    /// </returns>
    int Run(int n);

}
