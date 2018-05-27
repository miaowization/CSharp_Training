using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void SetupTest()
        {
            app = AppManager.GetInstance();
            app.Navigation.OpenHomePage();
        }
    }
}
