#define USE_NUNIT

using System;
using SpectrumApp;
using System.Linq;
using System.Threading.Tasks;
using SpectrumApp.UnitTests;
using AutoFixture;

#if USE_NUNIT

using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using NUnit.Framework;

#else

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endif

namespace SpectrumApp.UnitTests
{
    [TestClass]
    public class UsersViewModelTests : BaseTextFixture
    {
        [TestMethod]
        public async Task UsersViewModel_Should_load_0_users_after_ExecuteLoadItemsCommand()
        {
            //Arrage
            var vm = new UsersViewModel();

            //Act
            await vm.ExecuteLoadItemsCommand();

            //Assert
            Assert.AreEqual(0, vm.UserList.Count);
        }


        [TestMethod]
        public void UsersViewModel_Should_NOT_have_users_WITHOUT_AddItem()
        {
            //Arrange
            var user = new Fixture().Create<User>();
            var vm = new UsersViewModel();

            //Act

            //Assert
            Assert.AreEqual(0, vm.UserList.Count);
        }


        [TestMethod]
        public async Task UsersViewModel_Should_load_1_users_after_AddItem()
        {
            //Arrange
            var user = new Fixture().Create<User>();
            var vm = new UsersViewModel();

            //Act
            await vm.AddItem(user);
            await vm.ExecuteLoadItemsCommand();

            //Assert
            Assert.AreEqual(1, vm.UserList.Count);
        }

        [TestMethod]
        public async Task UsersViewModel_Should_NOT_load_users_WITHOUT_AddItem()
        {
            //Arrange
            var user = new Fixture().Create<User>();
            var vm = new UsersViewModel();

            //Act
            await vm.ExecuteLoadItemsCommand();

            //Assert
            Assert.AreEqual(0, vm.UserList.Count);
        }


        [TestMethod]
        public async Task UsersViewModel_Should_ValidateUsername()
        {
            //Arrange
            var user = new Fixture().Create<User>();
            var vm = new UsersViewModel();
            await vm.AddItem(user);

            //Act
            var result = vm.ValidateUsername(user.Username + "1");

            //Assert
            Assert.True(result);
        }

        [TestMethod]
        public async Task UsersViewModel_Should_NOT_Validate_THESAME_Username()
        {
            //Arrange
            var user = new Fixture().Create<User>();
            var vm = new UsersViewModel();
            await vm.AddItem(user);

            //Act
            var result = vm.ValidateUsername(user.Username);

            //Assert
            Assert.False(result);
        }


        [TestMethod]
        public void UsersViewModel_Should_ValidatePassword_NumberLetterNoSpecial5to12()
        {
            //Arrange
            var password = "Pas5w";
            var vm = new UsersViewModel();

            //Act
            var result = vm.ValidatePassword(password);

            //Assert
            Assert.True(result);
        }

        [TestMethod]
        public void UsersViewModel_Should_NOT_ValidatePassword_NumberLetterNoSpecialLessThan5()
        {
            //Arrange
            var password = "Pas5";
            var vm = new UsersViewModel();

            //Act
            var result = vm.ValidatePassword(password);

            //Assert
            Assert.False(result);
        }

        [TestMethod]
        public void UsersViewModel_Should_NOT_ValidatePassword_LetterNoSpecialLessThan5()
        {
            //Arrange
            var password = "Pass";
            var vm = new UsersViewModel();

            //Act
            var result = vm.ValidatePassword(password);

            //Assert
            Assert.False(result);
        }

        [TestMethod]
        public void UsersViewModel_Should_NOT_ValidatePassword_NumberLetterSpecial5to12()
        {
            //Arrange
            var password = "Pas5w*";
            var vm = new UsersViewModel();

            //Act
            var result = vm.ValidatePassword(password);

            //Assert
            Assert.False(result);
        }

        [TestMethod]
        public void UsersViewModel_Should_NOT_ValidatePassword_NumberLetterNoSpecialMoreThan12()
        {
            //Arrange
            var password = "01234567891Pa";
            var vm = new UsersViewModel();

            //Act
            var result = vm.ValidatePassword(password);

            //Assert
            Assert.False(result);
        }
    }

}

