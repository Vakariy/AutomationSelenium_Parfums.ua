using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class HeaderAutorazation_POM
    {
        private IWebDriver driver;
        By profileButton = By.CssSelector("#profile_desktop > button");
        By myAccount = By.CssSelector("#profile_desktop > div > ul > li:nth-child(2) > a");
        By binWithProduct = By.XPath(@"/html/body/header/section[2]/div/div[3]/div[3]/a");
        By myFavoritessBotton = By.CssSelector("#favorites");
        By personalizyList = By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > nav > ul > li:nth-child(4)");

        public HeaderAutorazation_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

       public HeaderAutorazation_POM ClickProfileButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(profileButton).Click();
            return this;
        }

        public HeaderAutorazation_POM ClickMyAccountSettings()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(myAccount).Click();
            return this;
        }

        public HeaderAutorazation_POM GoToBinWithProduct()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(binWithProduct).Click();
            return this;
        }

        public HeaderAutorazation_POM ClickOnTheFavoritesButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(myFavoritessBotton).Click();
            return this;
        }

        public HeaderAutorazation_POM ClickOnTheOrdersList()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(personalizyList).Click();
            return this;
        }

    }
}
