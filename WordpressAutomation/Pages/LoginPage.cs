using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WordpressAutomation
{
   public class LoginPage
    {


       public static void Goto()
       {   
           Driver.Instance.Navigate().GoToUrl(Driver.BaseUrl + "wp-login.php");
       }

       public static LoginCommand LoginAs(string userName)
       {
           return new LoginCommand(userName);
       }
    }

    public class LoginCommand
    {
        private readonly string UserName;
        private string Password;

        public LoginCommand(string userName)
        {
            this.UserName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.Password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            loginInput.SendKeys(UserName);

            var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
            passwordInput.SendKeys(Password);

            var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();
        }

    }
}
