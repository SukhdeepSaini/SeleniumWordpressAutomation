using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests : WordPressTest
    {
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            NewPostPage.Goto();
            NewPostPage.CreatePost("This is the Title")
                .WithBody("I am the body").Publish();

            NewPostPage.GotoNewPost();

            Assert.AreEqual(PostPage.Title, "THIS IS THE TITLE" ,"Title is not matching");
            
        }
    }
}
