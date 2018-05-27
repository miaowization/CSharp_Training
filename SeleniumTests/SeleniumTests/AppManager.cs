using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class AppManager
    {
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private NavigationHelper navigation;
        private ContactHelper contact;
        private GroupHelper group;
        private LoginHelper auth;

        public static AppManager GetInstance()
        {
            if(!app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        private AppManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
            group = new GroupHelper(this);
            contact = new ContactHelper(this);
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
        }

        public void Stop()
        {
            driver.Quit();
        }



        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return auth;
            }
        }

        public ContactHelper Contact
        {
            get
            {
                return contact;
            }
        }
        public GroupHelper Group
        {
            get
            {
                return group;
            }
        }

        ~AppManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
