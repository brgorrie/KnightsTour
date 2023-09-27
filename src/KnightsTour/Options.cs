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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine.Text;
using CommandLine;

namespace KnightsTour
{
    public class Options
    {
        [Option('n', "boardSize", Required = true, HelpText = "Size of the chess board.")]
        public int BoardSize { get; set; }

        [Option('u', "unique", Required = true, HelpText = "Consider unique solutions only.")]
        public bool Unique { get; set; }

        [Option('w', "useWarnsdorff", Required = true, HelpText = "Use Warnsdorff’s algorithm.")]
        public bool UseWarnsdorff { get; set; }
    }

}
