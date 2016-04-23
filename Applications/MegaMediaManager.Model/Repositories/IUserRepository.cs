using Infrastructure;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MegaMediaManager.Model.Repositories
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task<User> FindByUserNameAsync(string userName);
    }
}
