//
// VersionService
//
// Author:
//       Michel Perez Saavedra <michel.perez.saavedra@gmail.com>
//
// Copyright (c) 2020 Bimbo Team Software Technologies
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//
using System;
using Bimbo.Exceptions;

namespace Bimbo.Services
{
    /// <inheritdoc/>
    /// <summary>
    /// Version service.
    /// </summary>
    public class VersionService : IVersionService
    {
        ///  <inheritdoc/>
        /// <summary>
        /// Gets the next version.
        /// </summary>
        /// <returns>The next version.</returns>
        /// <param name="aggregateRootId">Aggregate root identifier.</param>
        /// <param name="currentVersion">Current version.</param>
        /// <param name="expectedVersion">Expected version.</param>
        /// <exception cref="T:Bimbo.Exceptions.ConcurrencyException"></exception>
        public int GetNextVersion(Guid aggregateRootId, int currentVersion, int? expectedVersion)
        {
            if (expectedVersion.HasValue && expectedVersion.Value > 0 && expectedVersion.Value != currentVersion)
            {
                throw new ConcurrencyException(aggregateRootId, expectedVersion.Value, currentVersion);
            }

            return currentVersion + 1;
        }
    }
}
