using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class SignInORSignUp_POM
    {
        private IWebDriver driver;

        By loginButton = By.XPath("/html/body/div[6]/section/div/button[1]");
        By loginField = By.XPath("/html/body/div[6]/section/div/div[2]/div[1]/input");
        By passwordField = By.CssSelector("#password");
        By enterButton = By.CssSelector("#login_modal > section > div > button.checkout-button-main-l--login");

        public SignInORSignUp_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SignInORSignUp_POM ClickOnLogInButton()
        {
            driver.FindElement(loginButton).Click();
            return this;
        }

        public SignInORSignUp_POM FillLogInField(string login)
        {
            driver.FindElement(loginField).SendKeys(login);
            return this;
        }

        public SignInORSignUp_POM FillPassInField(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
            return this;
        }

        public SignInORSignUp_POM ClickInButtonEnter()
        {
            driver.FindElement(enterButton).Click();
            return this;
        }
    }
}
