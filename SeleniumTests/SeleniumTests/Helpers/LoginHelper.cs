using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class LoginHelper:HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager) { }


        public void Logout()
        {
            Click(LogoutButton);
        }

        public void Login(AccountData user)
        {
            if(IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                    return;
                Logout();
            }
            Type(UserNameField, user.Username);
            Type(PasswordField, user.Password);
            Click(LoginButton);
        }

        public bool IsLoggedIn()
        {
            return driver.FindElements(By.LinkText("Logout")).Count > 0;
        }

        public bool IsLoggedIn(string username)
        {
            return driver.FindElement(By.XPath("//div/div[1]/form/b")).Text == "(" + username + ")";
        }


    }
}
