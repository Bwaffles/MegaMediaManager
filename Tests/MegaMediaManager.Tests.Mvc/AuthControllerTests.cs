using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using MegaMediaManager.Mvc.Controllers;
using System.Web.Mvc;
using MegaMediaManager.Mvc.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;

namespace MegaMediaManager.Tests.Mvc
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AuthControllerTests : PresentationTestBase
    {
        [TestMethod]
        public void GetRegister()
        {
            var controller = new AuthController();
            var result = controller.Register() as ActionResult;
            result.Should().NotBeNull();
        }

        [TestMethod]
        public async Task PostRegister()
        {
            var controller = new AuthController();
            var regModel = new RegisterViewModel() { UserName = "testguy", Email = "t@t.com", PasswordHash = "greedy11", ConfirmPassword = "greedy11" };
            var result = await controller.Register(regModel) as RedirectToRouteResult;
            //result.Should().NotBeNull();
            //var context = MegaMediaManager.DAL.DataContextFactory.GetDataContext();
            //using( new MegaMediaManager.DAL.EFUnitOfWorkFactory().Create())
            //{
            //    context.Users.Remove(context.Users.Single(u => u.LoginId == "testguy"));
            //}
        }

    }
}
