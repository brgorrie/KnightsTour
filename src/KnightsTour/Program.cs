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

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(args[0]);
        var unique = bool.Parse(args[1]);
        var useWarnsdorff = bool.Parse(args[2]);

        IChessBoard board = new ChessBoard(n);
        var solver = useWarnsdorff ? (ITourSolver)new WarnsdorffTourSolver() : new SimpleTourSolver();
        IKnightTourService service = new KnightTourService(solver);

        var count = service.CountTours(board, unique, useWarnsdorff);
        Console.WriteLine($"Number of tours: {count}");
    }
}
