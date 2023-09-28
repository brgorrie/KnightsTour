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

namespace KnightsTour
{
    public class KnightsTourRunner : IKnightsTourRunner
    {
        private readonly IChessBoard _board;
        private readonly IKnightsTourService _service;
        private readonly IOutputService _outputService;

        public KnightsTourRunner(IChessBoard board, IKnightsTourService service, IOutputService outputService)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        }

        public int Run(int n, bool shouldFindUniqueTours)
        {
            var count = _service.CountTours(_board, shouldFindUniqueTours);
            _outputService.Write($"Number of tours: {count}");
            return count;
        }
    }

}
