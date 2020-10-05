using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class RegistrationOnANewAdress_POM
    {
        private IWebDriver driver;
        By inputCityOrder = By.CssSelector("#checkout > div > section > div > div.checkout_left > div > div > div > section:nth-child(2) > section:nth-child(1) > section > div > div > div.css-1hwfws3.select__value-container.select__value-container--has-value > div.css-dvua67-singleValue.select__single-value");
        By inputStreet = By.CssSelector("#street > div > div.css-1hwfws3.select__value-container.select__value-container--has-value");
        By inputNumberHouse = By.CssSelector("#build");
        By inputNumberFlat = By.CssSelector("#checkout > div > section > div > div.checkout_left > div > div > div > section:nth-child(2) > section:nth-child(2) > section:nth-child(2) > div.clearfix > div.checkout-input-container.flat.clearfix.error > label");
        By selectMethodPayment = By.XPath(@"/html/body/div[2]/section/div/div/section/div/div[1]/div/div/div/section[3]/div[2]/div[2]/span");
        By selectThisAdress = By.CssSelector("#checkout > div > section > div > div.checkout_left > div > button");
        By createOrderButton = By.XPath(@"/html/body/div[2]/section/div/div/section/div/div[1]/div/div/section/button");
        By selectDelMeth = By.CssSelector("#checkout > div > section > div > div.checkout_left > div > div > div.new_address_form > section:nth-child(2) > section:nth-child(2) > section.selector > div.css-1pcexqc-container.select-container.select-container-delivery > div > div.css-1wy0on6.select__indicators > div");

        public RegistrationOnANewAdress_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public RegistrationOnANewAdress_POM InputCityOrder(string city)
        {
            driver.FindElement(inputCityOrder).Click();
            driver.FindElement(inputCityOrder).SendKeys(city);
            return this;
        }

        public RegistrationOnANewAdress_POM InputStreetOrder(string street)
        {
            driver.FindElement(inputStreet).Click();
            driver.FindElement(inputStreet).SendKeys(street);
            return this;
        }

        public RegistrationOnANewAdress_POM InputNumberHouse(string numberHouse)
        {
            driver.FindElement(inputNumberHouse).Click();
            driver.FindElement(inputNumberHouse).SendKeys(numberHouse);
            return this;
        }

        public RegistrationOnANewAdress_POM InputNumberFlat(string numberFlat)
        {
            driver.FindElement(inputNumberFlat).Click();
            driver.FindElement(inputNumberFlat).SendKeys(numberFlat);
            return this;
        }

        public RegistrationOnANewAdress_POM SelectPaymentMethodBotton()
        {
            var element = driver.FindElement(By.XPath(@"/html/body/div[2]/section/div/div/section/div/div[1]/div/div/div/section[3]/div[2]/div[2]/span"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

            driver.FindElement(selectMethodPayment).Click();
            return this;
        }

        public RegistrationOnANewAdress_POM SelectThisAdress()
        {
            driver.FindElement(selectThisAdress).Click();
            return this;
        }

        public RegistrationOnANewAdress_POM CreateTheOrder()
        {
            driver.FindElement(createOrderButton).Click();
            return this;
        }

        public RegistrationOnANewAdress_POM SelectDeliveryMethod()
        {
            driver.FindElement(selectDelMeth).Click();
            return this;
        }

    }
}
