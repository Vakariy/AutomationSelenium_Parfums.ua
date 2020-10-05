using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class HomePage_POM
    {
        private IWebDriver driver;
        By signInORSignUpButton = By.XPath("//*[@id=\"profile_desktop\"]/button/span");
        By parfumTab = By.XPath("/html/body/header/section[3]/nav/ul/li[1]/a");
        By makeupTab = By.XPath("/html/body/header/section[3]/nav/ul/li[2]/a");
        By hairTab = By.XPath("/html/body/header/section[3]/nav/ul/li[3]/a");
        By faceTab = By.XPath("/html/body/header/section[3]/nav/ul/li[4]/a");
        By dermoTab = By.XPath("/html/body/header/section[3]/nav/ul/li[5]/a");
        By bodyTab = By.XPath("/html/body/header/section[3]/nav/ul/li[6]/a");
        By nailsTab = By.XPath("/html/body/header/section[3]/nav/ul/li[7]/a");
        By forHouse = By.XPath("/html/body/header/section[3]/nav/ul/li[8]/a");
        By kidsAndMoms = By.XPath("/html/body/header/section[3]/nav/ul/li[9]/a");
        By men = By.XPath("/html/body/header/section[3]/nav/ul/li[10]/a");
        By saloonCosmetic = By.XPath("/html/body/header/section[3]/nav/ul/li[11]/a");
        By login = By.XPath("/html/body/header/section[2]/div/div[3]/div[1]/div/button/span");
        By enter = By.XPath("/html/body/div[6]/section/div/button[1]");
        By name = By.XPath("/html/body/header/section[2]/div/div[3]/div[1]");
        By enter2 = By.CssSelector("#login_modal > section > div > button.checkout-button-main-l--login");
        By loginField = By.CssSelector("#login");
        By passwordField = By.CssSelector("#password");
        By personalData = By.XPath("/html/body/header[3]/section[2]/div/div[3]/div[1]/div/div/ul/li[2]/a");
        By father = By.XPath("/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[4]/div/input");
        By changeData = By.XPath("/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[2]/button");
        By findField = By.CssSelector("#search_desktop > div > form > input");
        By findButton = By.CssSelector("#search_desktop > div > form > button");

        public HomePage_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage_POM ParfumTab()
        {
            driver.FindElement(parfumTab).Click();

            return new HomePage_POM(driver);
        }
        public HomePage_POM MakeUpTab()
        {
            driver.FindElement(makeupTab).Click();

            return new HomePage_POM(driver);
        }
        public HomePage_POM HairTab()
        {
            driver.FindElement(hairTab).Click();

            return new HomePage_POM(driver);
        }
        public HomePage_POM FaceTab()
        {
            driver.FindElement(faceTab).Click();

            return new HomePage_POM(driver);
        }
        public HomePage_POM DermoTab()
        {
            driver.FindElement(dermoTab).Click();

            return new HomePage_POM(driver);
        }

        public SignInORSignUp_POM ClickOnSignInORSignUpButton()
        {
            driver.FindElement(signInORSignUpButton).Click();
            return new SignInORSignUp_POM(driver);
        }

        public HomePage_POM ChangeData(string logino, string passwordo, string fathers)
        {
            driver.FindElement(login).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(enter).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(loginField).SendKeys(logino);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(passwordField).SendKeys(passwordo);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(enter2).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    By name = By.XPath("/html/body/header/section[2]/div/div[3]/div[1]");
                    driver.FindElement(name).Click();


                    staleElement = false;

                }
                catch (StaleElementReferenceException e)
                {

                    staleElement = true;

                }

            }
            bool staleElements = true;
            while (staleElements)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    By personalData = By.XPath("/html/body/header/section[2]/div/div[3]/div[1]/div/div/ul/li[2]/a");
                    driver.FindElement(personalData).Click();


                    staleElements = false;

                }
                catch (StaleElementReferenceException e)
                {

                    staleElements = true;

                }
            }

            bool staleElementss = true;
            while (staleElementss)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    By father = By.XPath("/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[4]/div/input");
                    driver.FindElement(father).Click();
                    driver.FindElement(father).SendKeys(fathers);
                    driver.FindElement(changeData).Click();

                    staleElementss = false;

                }
                catch (StaleElementReferenceException e)
                {

                    staleElementss = true;

                }
            }




            return new HomePage_POM(driver);
        }
        public HomePage_POM ChekHistoryOfOrders(string logino, string passwordo, string product)
        {
            driver.FindElement(login).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(enter).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(loginField).SendKeys(logino);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(passwordField).SendKeys(passwordo);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(enter2).Click();
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    By findFieldd = By.XPath("/html/body/header/section[2]/div/div[2]/div/form/input");

                    driver.FindElement(findFieldd).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    driver.FindElement(findFieldd).SendKeys(product);
                    driver.FindElement(findButton).Click();
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
            return new HomePage_POM(driver);
        }
    }
}
