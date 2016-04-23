//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using MegaMediaManager.Model;
//using Microsoft.AspNet.Identity;
//using System.Threading.Tasks;
//using System.Data.Entity;

//namespace MegaMediaManager.Mvc.Managers
//{
//    public class ApplicationUserStore : IUserStore<User>
//    {
//        private MegaMediaManager.DAL.MegaMediaManagerContext database;

//        public ApplicationUserStore()
//        {
//            this.database = MegaMediaManager.DAL.DataContextFactory.GetDataContext();
//        }

//        public void Dispose()
//        {
//            this.database.Dispose();
//        }

//        public Task CreateAsync(User user)
//        {
//            var user = await database.Users.Add(user);
//            return user;
//        }
//        public Task UpdateAsync(User user)
//        {
//            // TODO
//            throw new NotImplementedException();
//        }

//        public Task DeleteAsync(User user)
//        {
//            // TODO
//            throw new NotImplementedException();
//        }

//        public async Task<User> FindByIdAsync(string userId)
//        {
//            User user = await this.database.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
//            return user;
//        }

//        public async Task<User> FindByNameAsync(string userName)
//        {
//            User user = await this.database.Users.Where(c => c.LoginId == userName).FirstOrDefaultAsync();
//            return user;
//        }
//    }
//}