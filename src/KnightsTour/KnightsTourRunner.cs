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
    public class KnightsTourRunner
    {
        private readonly IChessBoard _board;
        private readonly ITourSolver _solver;
        private readonly IKnightsTourService _service;

        public KnightsTourRunner(IChessBoard board, ITourSolver solver, IKnightsTourService service)
        {
            _board = board;
            _solver = solver;
            _service = service;
        }

        public int Run(int n, bool unique, bool useWarnsdorff)
        {
            return _service.CountTours(_board, unique, useWarnsdorff);
        }
    }

}
