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

namespace KnightsTour
{
    /// <summary>
    /// Represents a runner for the Knight's Tour problem, responsible for executing the algorithm
    /// and orchestrating the interaction between the service layer and the output layer.
    /// </summary>
    public class KnightsTourRunner : IKnightsTourRunner
    {
        private readonly IChessBoard _board;
        private readonly IKnightsTourService _service;
        private readonly IOutputService _outputService;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnightsTourRunner"/> class with 
        /// the specified chessboard, Knight's Tour service, and output service.
        /// </summary>
        /// <param name="board">
        /// The chessboard on which the Knight's Tour will be performed.
        /// </param>
        /// <param name="service">
        /// The service containing the logic to solve the Knight's Tour problem.
        /// </param>
        /// <param name="outputService">
        /// The service responsible for handling the output of the results.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="board"/>, <paramref name="service"/>, or 
        /// <paramref name="outputService"/> is null.
        /// </exception>
        public KnightsTourRunner(IChessBoard board, IKnightsTourService service, IOutputService outputService)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        }

        /// <summary>
        /// Executes the Knight's Tour algorithm on the provided chessboard and writes the result 
        /// using the output service. It returns the number of tours found.
        /// </summary>
        /// <param name="n">
        /// The size of the chessboard. For a standard chessboard, n = 8.
        /// </param>
        /// <returns>
        /// The number of tours found. If <paramref name="shouldFindUniqueTours"/> is true,
        /// this represents the number of unique tours found.
        /// </returns>
        public int Run(int n)
        {
            var count = _service.CountTours(_board);
            _outputService.Write($"Number of tours: {count}");
            return count;
        }

    }

}
