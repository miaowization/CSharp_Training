using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SeleniumTests
{
    class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            AccountData user = new AccountData("admin", "secret");
            app.Auth.Login(user);
            Assert.True(app.Auth.IsLoggedIn(user.Username));
        }
        [Test]
        public void LoginWithInvalidData()
        {
            AccountData user = new AccountData("admin", "admin");
            app.Auth.Login(user);
            Assert.False(app.Auth.IsLoggedIn());
        }
    }
}
