//
// ICommand
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
namespace Bimbo.Commands
{
    /// <summary>
    /// Commands to execute inside the system
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets or sets the user identifier that launch the command.
        /// </summary>
        /// <value>The user identifier.</value>
        string UserId { get; set; }

        /// <summary>
        /// Gets or sets the source origin from where command was requested.
        /// </summary>
        /// <value>The source.</value>
        string Source { get; set; }

        /// <summary>
        /// if true a command validation will be called in order to ensure
        /// that command is valid or else.
        /// </summary>
        /// <value>The do validation.</value>
        bool? DoValidation { get; set; }

        /// <summary>
        /// if pubish it will publish the command events into the used BUS
        /// </summary>
        /// <value>The publish events.</value>
        bool? PublishEvents { get; set; }
    }
}
