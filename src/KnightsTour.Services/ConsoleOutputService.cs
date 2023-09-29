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

namespace KnightsTour.Services
{
    /// <summary>
    /// Represents a service that provides output operations to the console.
    /// Implements the <see cref="IOutputService"/> interface.
    /// </summary>
    public class ConsoleOutputService : IOutputService
    {
        /// <summary>
        /// Writes the specified message to the console.
        /// </summary>
        /// <param name="message">The message to be written to the console.</param>
        public void Write(string message) => Console.WriteLine(message);
    }

}
