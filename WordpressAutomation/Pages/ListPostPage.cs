using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.Collections;
using System.Collections.ObjectModel;


namespace WordpressAutomation
{
    public class ListPostPage
    {
        public static int lastCount;

        public static int PreviousPostCount
        {
            get
            {
                return lastCount;
            }
        }

        public static int CurrentPostCount
        {
            get
            {
                return GetPostCount();
            }
        }
        public static void Goto(PostType postType)
        {
            switch (postType)
            {
                case PostType.page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Pages.AllPosts.Select();
                    break;
                    
            }

        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        public static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistsWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));

            foreach(var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = Driver.Instance.FindElements(By.LinkText(title)));

                if(links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    Driver.Wait(TimeSpan.FromSeconds(5));
                    var rowActions = row.FindElement(By.ClassName("row-actions"));
                    rowActions.FindElement(By.ClassName("submitdelete")).Click();
                }
            }
        }

        public static void SearchPost(string searchString)
        {
            var searchTextBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchTextBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }

    }

    public enum PostType
    {
        page,

        Posts
    }
}
