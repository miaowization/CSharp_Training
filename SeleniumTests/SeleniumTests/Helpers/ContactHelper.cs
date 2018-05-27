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
using SeleniumTests;


namespace SeleniumTests
{
    public class ContactHelper:HelperBase
    {
        public ContactHelper(AppManager manager) : base(manager) { }

        public void CreateNewContact(ContactData contact)
        {
            Click(AddNewButton);
            EnterContactData(contact);
            Click(EnterButton);
        }




        private void EnterContactData(ContactData contact)
        {
            if (contact.FirstName != null)
            {
                Type(ContactFirstNameField, contact.FirstName);
            }
            if (contact.MiddleName != null)
            {
                Type(ContactMiddleNameField, contact.MiddleName);
            }
            if (contact.LastName != null)
            {
                Type(ContactLastNameField, contact.LastName);
            }
            if (contact.NickName != null)
            {
                Type(ContactNicknameField, contact.NickName);
            }
        }

        public ContactData GetCreatedContactData()
        {
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            return new ContactData(firstName, middleName, lastName, nickName);
        }
        public void DeleteContact()
        {
            Click(DeleteContactButton);

        }
        public void EditLastCreatedContact(ContactData contact)
        {
            SelectContactByIndex(FindLastCreatedContact());
            EnterContactData(contact);
            Click(UpdateButton);
        }

        public void SelectContactByIndex(int index)
        {
            Click(By.XPath("(//img[@alt='Edit'])[" + index + "]"));
        }

        public void OpenLastCreatedContact()
        {
            SelectContactByIndex(FindLastCreatedContact());
        }
        public int FindLastCreatedContact()
        {
            IList<IWebElement> checkboxes = driver.FindElements(By.XPath("(//input[@name='selected[]'])"));
            int size = checkboxes.Count;
            int[] values = new int[size];

            for (int i = 0; i < size; i++)
            {
                int.TryParse(checkboxes[i].GetAttribute("value"), out values[i]);
            }
            int value = 0;
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (values[i] > value)
                {
                    value = values[i];
                    index = i + 1;
                }
            }

            return index;
        }
    }
}
