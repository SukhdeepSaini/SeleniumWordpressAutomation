using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseUrl
        {
            get
            {
                return "http://localhost:58463/";
            }
        }
        public static void Initalize()
        {
            Instance = new FirefoxDriver();
            TurnOnWait();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep(timeSpan);
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void NoWait(Action action)
        {
            TurnOfWait();
            action();
            TurnOnWait();
        }

        public static void TurnOfWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }

        public static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
    }
}
