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
    public class NewPostPage
    {

        public static void Goto()
        {
           LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GotoNewPost()
        {
           var message =  Driver.Instance.FindElement(By.Id("message"));
           var newPostLink = message.FindElements(By.TagName("a"))[0];
           newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            var h2 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[3]/div[2]/div/div[4]/h2"));
            var link = h2.FindElement(By.LinkText("Add New"));
            return link != null;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }
    }
    

    public class CreatePostCommand
    {
        private string Title;
        public string Body;

        public CreatePostCommand(string title)
        {
            this.Title = title; 
        }

        public CreatePostCommand WithBody(string body)
        {
            this.Body = body;
            return this;            
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(Title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(Body);
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(5));
            var publish =  Driver.Instance.FindElement(By.Id("publish"));
            publish.Click();
        }
    }
}
