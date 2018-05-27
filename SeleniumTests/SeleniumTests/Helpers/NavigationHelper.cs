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
    public class NavigationHelper:HelperBase
    {
        public NavigationHelper(AppManager manager, string baseURL) : base(manager) 
        {
            
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void OpenGroupsPage()
        {
            
            Click(GroupsButton);
        }
    }
}
