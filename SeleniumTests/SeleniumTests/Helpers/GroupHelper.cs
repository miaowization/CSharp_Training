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
    public class GroupHelper:HelperBase
    {
        public GroupHelper(AppManager manager) : base(manager) { }

        public void DeleteGroup()
        {
            Click(DeleteGroupButton);
        }

        public void CreateNewGroup(GroupData group)
        {
            Click(NewGroupButton);
            EnterGroupData(group);
            Click(EnterInformationButton);
        }


        public void OpenGroup()
        {
            Click(EditGroupButton);
        }

        public void SelectGroupByValue(int value)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])")).FindElement(By.XPath("//input[@value='" + value.ToString() + "']")).Click();
        }
        public int FindLastCreatedGroup()
        {
            IList<IWebElement> checkboxes = driver.FindElements(By.XPath("(//input[@name='selected[]'])"));
            int size = checkboxes.Count;
            int[] values = new int[size];

            for (int i = 0; i < size; i++)
            {
                int.TryParse(checkboxes[i].GetAttribute("value"), out values[i]);
            }
            int value = 0;
            for (int i = 0; i < size; i++)
            {
                if (values[i] > value) value = values[i];
            }

            
            return value;
        }

        public void EnterGroupData(GroupData group)
        {
            if (group.Name != null)
            {
                Type(GroupNameField, group.Name);
            }
            if (group.Header != null)
            {
                Type(GroupHeaderField, group.Header);
            }
            if (group.Footer != null)
            {
                Type(GroupFooterField, group.Footer);
            }
        }
        public void EditGroup(GroupData group)
        {
            Click(EditGroupButton);
            EnterGroupData(group);
            Click(UpdateButton);
        }

        public GroupData GetCreatedGroupData()
        {
            string groupName = driver.FindElement(By.Name("group_name")).GetAttribute("value");
            string header = driver.FindElement(By.Name("group_header")).Text;
            string footer = driver.FindElement(By.Name("group_footer")).Text;
            return new GroupData(groupName) { Header = header, Footer = footer };        
        }
    }
}
