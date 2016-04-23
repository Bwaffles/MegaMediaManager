using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using Infrastructure;
using MegaMediaManager.Model.Repositories;
using MegaMediaManager.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace MegaMediaManager.DAL
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> GetUserManager()
        {
            return new UserManager<User>(new UserStore<User>(MegaMediaManager.DAL.DataContextFactory.GetDataContext()));
        }

        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the item in the database.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        public virtual User FindById(string id, params Expression<Func<User, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="username">The unique username of the item in the database.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        public async virtual Task<User> FindByUserNameAsync(string username)
        {
            return await GetUserManager().FindByNameAsync(username);
        }

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public virtual IQueryable<User> FindAll(params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> items = DataContextFactory.GetDataContext().Set<User>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        /// <summary>
        /// Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> items = DataContextFactory.GetDataContext().Set<User>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        /// <summary>
        /// Adds an entity to the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be added.</param>
        public virtual void Add(User entity)
        {
            DataContextFactory.GetDataContext().Set<User>().Add(entity);
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        public virtual void Remove(User entity)
        {
            DataContextFactory.GetDataContext().Set<User>().Remove(entity);
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext. Calls <see cref="FindById" /> to resolve the item.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        public virtual void Remove(string id)
        {
            Remove(FindById(id));
        }

        /// <summary>
        /// Disposes the underlying data context.
        /// </summary>
        public void Dispose()
        {
            if (DataContextFactory.GetDataContext() != null)
            {
                DataContextFactory.GetDataContext().Dispose();
            }
        }
    }
}
