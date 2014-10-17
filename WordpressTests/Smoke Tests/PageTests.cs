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
    public class PageTests : WordPressTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            ListPostPage.Goto(PostType.page);
            ListPostPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(),"Was not in Edit Mode");
            Assert.AreEqual("Sample Page",NewPostPage.Title,"Title Does not match");

        }
    }
}
