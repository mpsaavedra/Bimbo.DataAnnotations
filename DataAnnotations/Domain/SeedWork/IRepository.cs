//
// IRepository
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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bimbo.Domain.SeedWork
{
    /// <summary>
    /// Repository interface that will make mandatory the use of many functionalities
    /// included in the descendents, this basic operations will be defined in here so
    /// developers do not had to code them theire selfs. :D
    /// </summary>
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The all.</returns>
        Task<IQueryable<TEntity>> GetAll();

        /// <summary>
        /// /return a <see cref="IQueryable"/> object with a list of entities
        /// that match with the provided predicate, very useful to perform custom
        /// request. For example:
        /// var data = repository.Get(entity => entitty.Id == valueId);
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="predicate">Predicate.</param>
        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// returns a <see cref="IQueryable"/> object with a list of entities
        /// that match with the provided URL parameters.
        /// Like like: [?]param1=value1&param2=value2&param3=value3
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="queryUrlParams">Query url parameters.</param>
        IQueryable<TEntity> Get(string queryUrlParams);

        /// <summary>
        /// returns a <see cref="IQueryable"/> object with a list of entities
        /// that match with the provided dictionary of values
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="includes">Includes.</param>
        IQueryable<TEntity> Get(Dictionary<string, string> includes);

        /// <summary>
        /// Gets the one entity using the specified predicate.
        /// </summary>
        /// <returns>The one.</returns>
        /// <param name="predicate">Predicate.</param>
        Task<TEntity> GetOne(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Insert the specified entity.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="entity">Entity.</param>
        Task<TEntity> Insert(TEntity entity);

        /// <summary>
        /// Delete the specified entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete the specified TEnity by his id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        Task Delete(object id);

        /// <summary>
        /// Update the specified id and entity.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="entity">Entity.</param>
        Task Update(object id, TEntity entity);

        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        IUnitOfWork UnitOfWork { get; set; }
    }
}
