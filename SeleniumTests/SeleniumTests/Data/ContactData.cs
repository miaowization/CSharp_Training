using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class ContactData
    {
        public ContactData(string firstName, string middleName, string lastName, string nickName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            NickName = nickName;
        }

        public ContactData()
        {
            FirstName = "No";
            MiddleName = "No";
            LastName = "No";
            NickName = "No";
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
    }
}
