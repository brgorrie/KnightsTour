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

using CommandLine;

namespace KnightsTour
{
    /// <summary>
    /// Represents the configurable options for a Knight's Tour program.
    /// This class holds the user-defined settings that influence the execution of the Knight's Tour algorithm.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Gets or sets the size of the chess board. This is a required parameter.
        /// </summary>
        /// <value>
        /// The size of the chess board. For a standard chess board, this would be 8.
        /// </value>
        [Option('n', "boardSize", Required = true, HelpText = "Size of the chess board.")]
        public int BoardSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use Warnsdorff’s algorithm. This is a required parameter.
        /// </summary>
        /// <value>
        /// True if Warnsdorff’s algorithm should be used, false otherwise.
        /// </value>
        [Option('w', "useWarnsdorff", Required = true, HelpText = "Use Warnsdorff’s algorithm.")]
        public bool UseWarnsdorff { get; set; }

    }

}
