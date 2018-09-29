using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels {
    [TestClass]
    public class LoginViewModelTest {
        [TestMethod]
        public void LoginViewModel_ExeLoginEmptyUsername_CanNot() {
            // arrange
            var loginViewModel = new LoginViewModel();

            // act
            var canExe = loginViewModel.CmdLogin.CanExecute();

            // assert
            Assert.IsFalse(canExe);
        }

        [TestMethod]
        public void LoginViewModel_ExeLoginWithUsername_Can() {
            // arrange
            var loginViewModel = new LoginViewModel();

            // act
            loginViewModel.Benutzername = "Bud Spencer";
            var canExe = loginViewModel.CmdLogin.CanExecute();

            // assert
            Assert.IsTrue(canExe);
        }

        [TestMethod]
        public void LoginViewModel_ExeLoginEmptyUsername_Executed() {
            // arrange
            var loginViewModel = new LoginViewModel();

            // act
            loginViewModel.CmdLogin.Execute();

            // assert
            Assert.IsNull(loginViewModel.MainView);
        }

        [TestMethod]
        public void LoginViewModel_ExeLoginWithUsername_Executed() {
            // arrange
            var loginViewModel = new LoginViewModel();

            // act
            loginViewModel.Benutzername = "Bud Spencer";
            loginViewModel.CmdLogin.Execute();

            // assert
            Assert.IsNotNull(loginViewModel.MainView);
        }

        [TestMethod]
        public void LoginViewModel_ExeCancel_Executed() {
            // arrange
            var loginViewModel = new LoginViewModel();

            // act
            var canExe = loginViewModel.CmdAbbrechen.CanExecute();

            // assert
            Assert.IsTrue(canExe);
        }
    }
}
