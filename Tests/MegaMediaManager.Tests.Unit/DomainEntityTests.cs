using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using FluentAssertions;

namespace MegaMediaManager.Tests.Unit
{
    [TestClass]
    public class DomainEntityTests
    {
        #region Nested helper classes

        internal class PersonWithIntAsId : DomainEntity<int>
        {
            public override System.Collections.Generic.IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
            {
                throw new NotImplementedException();
            }
        }

        internal class PersonWithGuidAsId : DomainEntity<Guid>
        {
            public override System.Collections.Generic.IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        [TestMethod]
        public void TransientLeftIsNotEqual()
        {
            var personLeft = new PersonWithIntAsId();
            var personRight = new PersonWithIntAsId { Id = 1 };
            personLeft.Equals(personRight).Should().BeFalse();
        }

        [TestMethod]
        public void TwoTransientsAreNotEqual()
        {
            var personLeft = new PersonWithIntAsId();
            var personRight = new PersonWithIntAsId();
            personLeft.Equals(personRight).Should().BeFalse();
        }

        [TestMethod]
        public void NewPersonWithIntAsIdIsTransient()
        {
            var person = new PersonWithIntAsId();
            person.IsTransient().Should().BeTrue();
        }

        [TestMethod]
        public void PersonWithIntAsIdWithValueIsNotTransient()
        {
            var person = new PersonWithIntAsId { Id = 4 };
            person.IsTransient().Should().BeFalse();
        }

        [TestMethod]
        public void NewPersonWithGuidAsIdIsTransient()
        {
            var person = new PersonWithGuidAsId();
            person.IsTransient().Should().BeTrue();
        }

        [TestMethod]
        public void PersonWithGuidAsIdWithValueIsNotTransient()
        {
            var person = new PersonWithGuidAsId { Id = Guid.NewGuid() };
            person.IsTransient().Should().BeFalse();
        }

        //[TestMethod()]
        //public void EntitiesWithSameIdentityShouldBeEqual()
        //{
        //    var entityLeft = new PersonWithIntAsId { ID = 1 };
        //    var entityRight = new PersonWithIntAsId { ID = 1 };

        //    bool resultOnEquals = entityLeft.Equals(entityRight);
        //    bool resultOnOperator = entityLeft == entityRight;

        //    resultOnEquals.Should().BeTrue();
        //    resultOnOperator.Should().BeTrue();
        //}
    }
}
