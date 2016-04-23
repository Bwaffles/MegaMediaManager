using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaMediaManager.Model;
using FluentAssertions;

namespace MegaMediaManager.Tests.Unit
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CanCreateInstanceOfUser()
        {
            var user = new User();
            user.Should().NotBeNull();
            user.UserName.Should().BeNull();
        }

        //[TestMethod]
        //public void UsernameIsRequired()
        //{
        //    var user = new User();
        //    //user.Validate().Count(x => x.MemberNames.Contains("Username")).Should().BeGreaterThan(0);
        //}

        //private static User CreatePerson()
        //{
        //    return new User { Username = "testguy", Email = "testguy@test.com", Password = "987654321" };
        //}
    }
}
