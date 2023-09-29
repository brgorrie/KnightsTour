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
    /// Defines a contract for services that handle output operations, providing a mechanism
    /// to output messages, typically to the user or another output medium.
    /// </summary>
    public interface IOutputService
    {
        /// <summary>
        /// Writes the specified message to the output medium handled by the implementing class.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        void Write(string message);
    }

}
