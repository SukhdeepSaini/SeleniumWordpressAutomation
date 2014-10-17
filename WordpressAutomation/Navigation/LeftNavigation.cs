using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System.Threading;

namespace WordpressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "Add New");
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "All Pages");
                }
            }

            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "All Posts");
                }
            }
        }
    }

    public class MenuSelector
    {
        public static void Select(string topLevelSelectorId,string secondLevelSelectorId)
        {
            Driver.Instance.FindElement(By.Id(topLevelSelectorId)).Click();
            Driver.Instance.FindElement(By.LinkText(secondLevelSelectorId)).Click();
        }
    }
}
