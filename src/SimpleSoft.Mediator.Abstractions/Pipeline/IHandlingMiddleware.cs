﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2017 Simplesoft.pt
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System.Threading;
using System.Threading.Tasks;

namespace SimpleSoft.Mediator.Pipeline
{
    /// <summary>
    /// Handling middleware that can be used to intercept commands and events
    /// </summary>
    public interface IHandlingMiddleware
    {
        /// <summary>
        /// Method invoked when an <see cref="ICommand"/> is published.
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <param name="next">The next middleware into the chain</param>
        /// <param name="cmd">The command published</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited</returns>
        Task OnCommandAsync<TCommand>(HandlingCommandDelegate<TCommand> next, TCommand cmd, CancellationToken ct)
            where TCommand : ICommand;

        /// <summary>
        /// Method invoked when an <see cref="ICommand{TResult}"/> is published.
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="next">The next middleware into the chain</param>
        /// <param name="cmd">The command published</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited for the result</returns>
        Task<TResult> OnCommandAsync<TCommand, TResult>(HandlingCommandDelegate<TCommand, TResult> next, TCommand cmd, CancellationToken ct)
            where TCommand : ICommand<TResult>;

        /// <summary>
        /// Method invoked when an <see cref="IEvent"/> is broadcast.
        /// </summary>
        /// <typeparam name="TEvent">The event type</typeparam>
        /// <param name="next">The next middleware into the chain</param>
        /// <param name="evt">The event broadcasted</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited</returns>
        Task OnEventAsync<TEvent>(HandlingEventDelegate<TEvent> next, TEvent evt, CancellationToken ct)
            where TEvent : IEvent;
    }
}