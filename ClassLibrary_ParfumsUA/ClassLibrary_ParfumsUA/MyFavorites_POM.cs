using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class MyFavorites_POM
    {
        private IWebDriver driver;
        By editNameList = By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div.favourites__header.js-favourites-list-container > div > button.favourites_button.js-edit-list");
        By inputNameList = By.CssSelector("#listName");
        By saveButton = By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div.favourites__header.js-favourites-list-container > form > div.favourites__header_btn_wrap > button.js-list-submit.favourites_button");
        public MyFavorites_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MyFavorites_POM EditNameFavoriteListBotton()
        {
            driver.FindElement(editNameList).Click();
            return this;
        }

        public MyFavorites_POM InputNameFavoriteListField(string expectedResult)
        {
            driver.FindElement(inputNameList).Click();
            driver.FindElement(inputNameList).Clear();
            driver.FindElement(inputNameList).SendKeys(expectedResult);
            return this;
        }

        public MyFavorites_POM SaveNameFavoriteListBotton()
        {
            driver.FindElement(saveButton).Click();
            return this;
        }
    }
}
