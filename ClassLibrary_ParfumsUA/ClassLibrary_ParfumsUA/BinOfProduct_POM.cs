using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    class BinOfProduct_POM
    {
        private IWebDriver driver;
        By DoOrderBotton = By.CssSelector("#process_order");


        public BinOfProduct_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string CheckHasNomenklatura()
        {
            IWebElement myOrder = driver.FindElement(By.XPath(@"/html/body/div[2]/section/div[1]/div[2]/div[1]/div/div[1]"));
            string expectedResult = myOrder.Text;
            return expectedResult;
        }

        public BinOfProduct_POM ClickOnDoOrderBotton()
        {
            driver.FindElement(DoOrderBotton).Click();
            return this;
        }
    }
}
