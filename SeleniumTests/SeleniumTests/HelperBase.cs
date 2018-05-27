using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class HelperBase
    {
        #region Fieldnames

        private const string NEW_CONTACT_BUTTON = "add new";
        private const string NEW_GROUP_BUTTON = "new";
        private const string GROUP_NAME_FIELD = "group_name";
        private const string GROUP_HEADER_FIELD = "group_header";
        private const string GROUP_FOOTER_FIELD = "group_footer";
        private const string CONTACT_FIRST_NAME = "firstname";
        private const string CONTACT_MIDDLE_NAME = "middlename";
        private const string CONTACT_LAST_NAME = "lastname";
        private const string CONTACT_NICK_NAME = "nickname";
        private const string EDIT_CONTACT_BUTTON = "";
        private const string EDIT_GROUP_BUTTON = "edit";
        private const string UPDATE_BUTTON = "update";
        private const string ENTER_BUTTON = "submit";
        private const string ADD_NEW_BUTTON = "add new";
        private const string DELETE_CONTACT_BUTTON = "//input[@value='Delete']";
        private const string USERNAME_FIELD = "user";
        private const string PASSWORD_FIELD = "pass";
        private const string LOGIN_BUTTON = "input[type=\"submit\"]";
        private const string LOGOUT_BUTTON = "Logout";
        private const string GROUPS_BUTTON = "groups";
        private const string DELETE_GROUP_BUTTON = "(//input[@name='delete'])[2]";
        private const string ENTER_INFORMATION_BUTTON = "submit";

        #endregion


        #region Fields
        private By newContactButton;
        private By newGroupButton;
        private By groupNameField;
        private By groupHeaderField;
        private By groupFooterField;
        private By contactFirstNameField;
        private By contactMiddleNameField;
        private By contactLastNameField;
        private By contactNicknameField;
        private By editContactButton;
        private By editGroupButton;
        private By updateButton;
        private By enterButton;
        private By addNewButton;
        private By deleteContactButton;
        private By userNameField;
        private By passwordField;
        private By loginButton;
        private By logoutButton;
        private By groupsButton;
        private By deleteGroupButton;
        private By enterInformationButton;



        #endregion


        #region Properties

        public By EnterInformationButton
        {
            get
            {
                if (enterInformationButton == null)
                {
                    enterInformationButton = By.Name(ENTER_INFORMATION_BUTTON);
                }
                return enterInformationButton;
            }
        }
        public By GroupsButton
        {
            get
            {
                if (groupsButton == null)
                {
                    groupsButton = By.LinkText(GROUPS_BUTTON);
                }
                return groupsButton;
            }
        }

        public By UserNameField
        {
            get
            {
                if (userNameField == null)
                {
                    userNameField = By.Name(USERNAME_FIELD);
                }
                return userNameField;
            }
        }
        public By PasswordField
        {
            get
            {
                if (passwordField == null)
                {
                    passwordField = By.Name(PASSWORD_FIELD);
                }
                return passwordField;
            }
        }


        public By NewContactButton
        {
            get
            {
                if (newContactButton == null)
                {
                    newContactButton = By.LinkText(NEW_CONTACT_BUTTON);
                }
                return newContactButton;
            }
        }

        public By NewGroupButton
        {
            get
            {
                if (newGroupButton == null)
                {
                    newGroupButton = By.Name(NEW_GROUP_BUTTON);
                }
                return newGroupButton;
            }
        }
        public By GroupNameField
        {
            get
            {
                if (groupNameField == null)
                {
                    groupNameField = By.Name(GROUP_NAME_FIELD);
                }
                return groupNameField;
            }
        }
        public By GroupHeaderField
        {
            get
            {
                if (groupHeaderField == null)
                {
                    groupHeaderField = By.Name(GROUP_HEADER_FIELD);
                }
                return groupHeaderField;
            }
        }
        public By GroupFooterField
        {
            get
            {
                if (groupFooterField == null)
                {
                    groupFooterField = By.Name(GROUP_FOOTER_FIELD);
                }
                return groupFooterField;
            }
        }
        public By ContactFirstNameField
        {
            get
            {
                if (contactFirstNameField == null)
                {
                    contactFirstNameField = By.Name(CONTACT_FIRST_NAME);
                }
                return contactFirstNameField;
            }
        }
        public By ContactMiddleNameField
        {
            get
            {
                if (contactMiddleNameField == null)
                {
                    contactMiddleNameField = By.Name(CONTACT_MIDDLE_NAME);
                }
                return contactMiddleNameField;
            }
        }
        public By ContactLastNameField
        {
            get
            {
                if (contactLastNameField == null)
                {
                    contactLastNameField = By.Name(CONTACT_LAST_NAME);
                }
                return contactLastNameField;
            }
        }
        public By ContactNicknameField
        {
            get
            {
                if (contactNicknameField == null)
                {
                    contactNicknameField = By.Name(CONTACT_NICK_NAME);
                }
                return contactNicknameField;
            }
        }


        public By EditContactButton
        {
            get
            {
                if (editContactButton == null)
                {
                    editContactButton = By.Name(EDIT_CONTACT_BUTTON);
                }
                return editContactButton;
            }
        }
        public By EditGroupButton
        {
            get
            {
                if (editGroupButton == null)
                {
                    editGroupButton = By.Name(EDIT_GROUP_BUTTON);
                }
                return editGroupButton;
            }
        }

        public By UpdateButton
        {
            get
            {
                if (updateButton == null)
                {
                    updateButton = By.Name(UPDATE_BUTTON);
                }
                return updateButton;
            }
        }

        public By EnterButton
        {
            get
            {
                if (enterButton == null)
                {
                    enterButton = By.Name(ENTER_BUTTON);
                }
                return enterButton;
            }
        }

        public By AddNewButton
        {
            get
            {
                if (addNewButton == null)
                {
                    addNewButton = By.LinkText(ADD_NEW_BUTTON);
                }
                return addNewButton;
            }
        }
        public By DeleteContactButton
        {
            get
            {
                if (deleteContactButton == null)
                {
                    deleteContactButton = By.XPath(DELETE_CONTACT_BUTTON);
                }
                return deleteContactButton;
            }
        }
        public By DeleteGroupButton
        {
            get
            {
                if (deleteGroupButton == null)
                {
                    deleteGroupButton = By.XPath(DELETE_GROUP_BUTTON);
                }
                return deleteGroupButton;
            }
        }
        public By LoginButton
        {
            get
            {
                if (loginButton == null)
                {
                    loginButton = By.CssSelector(LOGIN_BUTTON);
                }
                return loginButton;
            }
        }
        public By LogoutButton
        {
            get
            {
                if (logoutButton == null)
                {
                    logoutButton = By.LinkText(LOGOUT_BUTTON);
                }
                return logoutButton;
            }
        }




        #endregion

        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected bool acceptNextAlert = true;
        protected AppManager manager;




        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
