using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;


namespace WINAPP
{
    public class logic
    {
        public const string app_name =
            "windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel";

        public const string windows_driver_url = "http://127.0.0.1:4723";

        // public const string aget = @"C:\Program Files (x86)\AirWatch\AgentUI\NativeEnrollment.exe";
        public static WindowsDriver<WindowsElement> session;
        public static WindowsDriver<WindowsElement> session1;

        public void setDriver()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "Root");
            appCapabilities.SetCapability("deviceName", "WindowsPC");

            session = new WindowsDriver<WindowsElement>(new Uri(windows_driver_url), appCapabilities);
            Thread.Sleep(TimeSpan.FromSeconds(10));


            // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
            session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

        }

        public void dmEnroll(string ds,string group, string user, string pass)
        {
            DesiredCapabilities appCapabilities1 = new DesiredCapabilities();
            appCapabilities1.SetCapability("app", app_name);
            appCapabilities1.SetCapability("deviceName", "WindowsPC");

            session1 = new WindowsDriver<WindowsElement>(new Uri(windows_driver_url), appCapabilities1);
            var dsurl = ds;
            var gid = group;
            var userName = user;
            var passWord = pass;
            session1.FindElementByName("Accounts").Click();
            Thread.Sleep(2000);
            session1.FindElementByName("Access work or school").Click();

            session1.FindElementByAccessibilityId("SystemSettings_WorkAccess_AddWorkOrSchoolAccount_Button").Click();
            Thread.Sleep(7000);
            session1.FindElementByAccessibilityId("userNameField").Click();

            session1.FindElementByAccessibilityId("userNameField").Clear();
            session1.FindElementByAccessibilityId("userNameField").SendKeys("sds@7yysdsdyyysd.com");

           session1.FindElementByAccessibilityId("NextButton").Click();
            Thread.Sleep(15000);
          
            session1.FindElementByAccessibilityId("serverUrlField").Clear();
            session1.FindElementByAccessibilityId("serverUrlField").SendKeys(ds.ToLower());
            session1.FindElementByAccessibilityId("NextButton").Click();
            
            Thread.Sleep(5000);
            session1.FindElementByAccessibilityId("SessionGroupIdentifier").Clear();
            session1.FindElementByAccessibilityId("SessionGroupIdentifier").SendKeys(gid);
            session1.FindElementByName("Next").Click();
            Thread.Sleep(3000);
            session1.FindElementByName("User name").Clear();
            session1.FindElementByName("Password").Clear();
            session1.FindElementByName("User name").SendKeys(user);
            session1.FindElementByName("Password").SendKeys(pass);
            session1.FindElementByName("Next").Click();
            Thread.Sleep(5000);

            session1.FindElementByAccessibilityId("DontSaveCreds").Click();
            Thread.Sleep(5000);
            session1.FindElementByAccessibilityId("FinishedButton").Click(); 

        }

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
    

