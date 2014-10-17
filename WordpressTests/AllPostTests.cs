using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordpressTests
{
    [TestClass]
    public class AllPostTests : WordPressTest
    {

        [TestMethod]
        public void AddedPostShowsUp()
        {
        
            //TEST : Added posts Show up

        // Go to All posts page , get the current count and store it
         ListPostPage.Goto(PostType.Posts);
         ListPostPage.StoreCount();

        // Create a new post and publish it
         NewPostPage.Goto();
         NewPostPage.CreatePost("This is the TestTitle, Title")
             .WithBody("This is the test body, Body")
             .Publish();

        // Again go to the All posts page and get the current posts count
         ListPostPage.Goto(PostType.Posts);
         Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Count Does not Increase");

        //Check for the newly added post
         Assert.IsTrue(ListPostPage.DoesPostExistsWithTitle("This is the TestTitle, Title"));

            //Need to fix the below test , trash is not working fine
         // Delete the newly added post
         //ListPostPage.TrashPost("This is the TestTitle, Title");
         //Assert.AreEqual(ListPostPage.PreviousPostCount, ListPostPage.CurrentPostCount, "Newly Added Post is not deleted");
        }

        [TestMethod]
        public void SearchPostTest()
        {
            NewPostPage.Goto();
            NewPostPage.CreatePost("Search Post, Title")
                .WithBody("Search Post , body")
                .Publish();

            ListPostPage.Goto(PostType.Posts);
            ListPostPage.SearchPost("Search Post, Title");

            Assert.IsTrue(ListPostPage.DoesPostExistsWithTitle("Search Post, Title"));
        }

    }
}
