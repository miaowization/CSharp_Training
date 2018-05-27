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
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        public void CreateNewGroup()
        {
            //AccountData user = new AccountData("admin", "secret");
            GroupData group1 = new GroupData("newgroup1", "header", "footer");
            app.Navigation.OpenHomePage();
            //app.Auth.Login(user);
            app.Navigation.OpenGroupsPage();
            app.Group.CreateNewGroup(group1);
            app.Navigation.OpenGroupsPage();
            app.Group.FindLastCreatedGroup();
            app.Group.OpenGroup();
            GroupData newgroup = app.Group.GetCreatedGroupData();
            app.Auth.Logout();
            Assert.AreEqual(group1.Name, newgroup.Name);
            Assert.AreEqual(group1.Header, newgroup.Header);
            Assert.AreEqual(group1.Footer, newgroup.Footer);

        }

        [Test]
        public void CreateNewContact()
        {
            AccountData user = new AccountData("admin", "secret");
            ContactData contact1 = new ContactData("Test", "Test", "Testovich", "Testik");
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
            app.Contact.CreateNewContact(contact1);
            app.Contact.Wait(3000);
            app.Contact.OpenLastCreatedContact();
            ContactData newcontact = app.Contact.GetCreatedContactData();
            Assert.AreEqual(contact1.FirstName, newcontact.FirstName);
            Assert.AreEqual(contact1.MiddleName, newcontact.MiddleName);
            Assert.AreEqual(contact1.LastName, newcontact.LastName);
            Assert.AreEqual(contact1.NickName, newcontact.NickName);
            app.Auth.Logout();
        }

        [Test]
        public void DeleteLastContact()
        {
            AccountData user = new AccountData("admin", "secret");
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
            if (app.Contact.IsElementPresent(By.Name("entry")) != true)
            {
                app.Contact.CreateNewContact(new ContactData("FirstName", "MiddleName", "LastName", "NickName"));
                app.Navigation.OpenHomePage();
            }
            int index = app.Contact.FindLastCreatedContact(); 
            app.Contact.SelectContactByIndex(index);
            app.Contact.DeleteContact();
            app.Contact.Wait(3000);
            Assert.That(app.Contact.IsElementPresent(By.XPath("(//img[@alt='Edit'])[" + index + "]")) == false);
            app.Auth.Logout();
        }
        
        [Test]
        public void DeleteLastGroup()
        {
            AccountData user = new AccountData("admin", "secret");
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
            app.Navigation.OpenGroupsPage();
            if (app.Group.IsElementPresent(By.ClassName("group")) == false)
            {
                app.Group.CreateNewGroup(new GroupData("NewGroup"));
                app.Navigation.OpenGroupsPage();
            }
            int value = app.Group.FindLastCreatedGroup();
            app.Group.SelectGroupByValue(value);
            app.Group.DeleteGroup();
            app.Navigation.OpenGroupsPage();
            Assert.That(app.Group.IsElementPresent(By.XPath("//input[@value='" + value.ToString() + "']")) == false);
            app.Auth.Logout();
        }

        [Test]
        public void EditLastGroup()
        {
            AccountData user = new AccountData("admin", "secret");
            
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
            app.Navigation.OpenGroupsPage();
            if (app.Group.IsElementPresent(By.ClassName("group")) == false)
            {
                app.Group.CreateNewGroup(new GroupData("NewGroup"));
                app.Navigation.OpenGroupsPage();
            }
            int value = app.Group.FindLastCreatedGroup();
            app.Group.SelectGroupByValue(value);
            app.Group.OpenGroup();
            GroupData oldGroupData = app.Group.GetCreatedGroupData();
            app.Navigation.OpenGroupsPage();
            value = app.Group.FindLastCreatedGroup();
            app.Group.SelectGroupByValue(value);
            GroupData group = new GroupData(oldGroupData.Name+"Edited");
            app.Group.EditGroup(group);
            app.Navigation.OpenGroupsPage();
            app.Group.SelectGroupByValue(value);
            app.Group.OpenGroup();
            GroupData newGroupData = app.Group.GetCreatedGroupData();
            app.Auth.Logout();
            Assert.AreEqual(oldGroupData.Name+"Edited", newGroupData.Name);
            //
        }
        
        [Test]
        public void EditLastContact()
        {
            
            AccountData user = new AccountData("admin", "secret");
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
            app.Navigation.OpenHomePage();
            if (app.Contact.IsElementPresent(By.Name("entry")) != true)
            {
                app.Contact.CreateNewContact(new ContactData("FirstName", "MiddleName", "LastName", "NickName"));
                app.Navigation.OpenHomePage();
            }
            int index = app.Contact.FindLastCreatedContact();
            app.Contact.SelectContactByIndex(index);
            ContactData oldContactData = app.Contact.GetCreatedContactData();
            app.Navigation.OpenHomePage();
            ContactData contact = new ContactData(oldContactData.FirstName + "edited", oldContactData.MiddleName+"edited", oldContactData.LastName+"edited", oldContactData.NickName+"edited");
            app.Contact.EditLastCreatedContact(contact);
            app.Navigation.OpenHomePage();
            app.Contact.OpenLastCreatedContact();
            ContactData newContactData = app.Contact.GetCreatedContactData();
            app.Auth.Logout();
            Assert.AreEqual(oldContactData.FirstName + "edited", newContactData.FirstName);
            Assert.AreEqual(oldContactData.MiddleName + "edited", newContactData.MiddleName);
            Assert.AreEqual(oldContactData.LastName + "edited", newContactData.LastName);
            Assert.AreEqual(oldContactData.NickName + "edited", newContactData.NickName);
            //
        }
    }
}
