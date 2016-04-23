using FluentAssertions;
using MegaMediaManager.DAL;
using MegaMediaManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaMediaManager.Tests.Integration
{
    [TestClass]
    public class MegaMediaManagerContextTests : IntegrationTestBase
    {
        [TestMethod]
        public void CanAddUserUsingMegaMediaManagerContext()
        {
            using (new EFUnitOfWorkFactory().Create())
            {
                var context = DataContextFactory.GetDataContext();
                var user = new User { UserName = "joe", Email = "tannis@test.com", PasswordHash = "123456" };
                context.Users.Add(user);
                context.Users.Remove(user);
            }
        }

        [TestMethod]
        public void CanExecuteQueryAgainstDataContext()
        {
            using (var uow = new EFUnitOfWorkFactory().Create())
            {
                var context = DataContextFactory.GetDataContext();
                string username = Guid.NewGuid().ToString().Substring(0, 10);
                var user = new User { UserName = username, Email = "tannis@test.com", PasswordHash = "123456" };
                context.Users.Add(user);
                uow.Commit(false);
                var personCheck = context.Users.SingleOrDefault(x => x.UserName == username);
                personCheck.Should().NotBeNull();
                context.Users.Remove(user);
            }
        }
    }
}
