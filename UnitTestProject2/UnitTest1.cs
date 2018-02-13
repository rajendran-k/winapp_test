using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System.Threading;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
        
    {
        public const string app_name = "windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel";
        public const string windows_driver_url="http://127.0.0.1:4723";
        public const string aget= @"C:\Program Files (x86)\AirWatch\AgentUI\NativeEnrollment.exe";
        public static WindowsDriver<WindowsElement> session;
            public static WindowsDriver<WindowsElement> session1;
        [TestInitialize]

        public void Init_method()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "Root");
              appCapabilities.SetCapability("deviceName", "WindowsPC");
            
            session = new WindowsDriver<WindowsElement>(new Uri(windows_driver_url), appCapabilities);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Assert.IsNotNull(session);

            // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
            session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));
        }

        [TestMethod]
        public void TestMethod1()
        {
           
            session.FindElementByName("AirWatch - 1 running window").Click();

            DesiredCapabilities appCapabilities1 = new DesiredCapabilities();
            appCapabilities1.SetCapability("app", aget);
            appCapabilities1.SetCapability("deviceName", "WindowsPC");

            session1 = new WindowsDriver<WindowsElement>(new Uri(windows_driver_url), appCapabilities1);
            session1.FindElementByAccessibilityId("MasterPage");
            session1.FindElementByAccessibilityId("buttonServer").Click();
            session1.FindElementByAccessibilityId("txtServerName").Click();
            session1.FindElementByAccessibilityId("txtServerName").SendKeys("dsmain.ssdevrd.com");
            session1.FindElementByAccessibilityId("txtGroupId").Click();
            session1.FindElementByAccessibilityId("txtGroupId").SendKeys("wp");

            session1.FindElementByAccessibilityId("btnNext").Click();

            Thread.Sleep(2000);
            

            //// session.FindElementByName("Accounts").Click();
            //session.FindElementByName("Access work or school").Click();

            // session.FindElementByAccessibilityId("SystemSettings_WorkAccess_AddWorkOrSchoolAccount_Button").Click();
            Thread.Sleep(7000);
           // session.FindElementByAccessibilityId("userNameField").Click();
            
           // session.FindElementByAccessibilityId("userNameField").SendKeys("asdsadasd@ddfdd.com");

            //session.FindElementByName("SystemSettings_WorkAccess_AddWorkOrSchoolAccoun

        }
        [TestMethod]

/*public  void testengin()
        {
            session.FindElementByAccessibilityId("num2Button").Click();
            session.FindElementByAccessibilityId("num3Button").Click();
            session.FindElementByAccessibilityId("num4Button").Click();
            session.FindElementByAccessibilityId("num5Button").Click();

        }*/
        [TestCleanup]
        public void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }
        
    }
}
