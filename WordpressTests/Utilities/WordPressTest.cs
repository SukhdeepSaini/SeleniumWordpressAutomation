using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
   public class WordPressTest
    {
       [TestInitialize]      
       public void InIt()
       {
           Driver.Initalize();
           LoginPage.Goto();
           LoginPage.LoginAs("Sukhdeep_Saini").WithPassword("(sukhd33p)").Login();
       }

       [TestCleanup]
       public void CleanUp()
       {
           Driver.Close();
       }
    }
}
