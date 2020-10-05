using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_ParfumsUA
{
    //Page in the personal account - My data
    public class MyData_POM
    {
        private IWebDriver driver;

        public By userName = By.CssSelector("#profile_form_firstname");
        public By lastName = By.CssSelector("#profile_form_lastname");
        public By otchestvoName = By.CssSelector("#profile_form_middlename");
        By oldPassword = By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[10]/div[2]/input");
        By changePass_inputNew = By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[10]/div[3]/input");
        By changePass_inputNew_repeat = By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[10]/div[4]/input");
        By saveChangesBotton = By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div.profile__index > form > div.info__actions > button");


        public MyData_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MyData_POM InputOldPass(string newPass)
        {
            var element = driver.FindElement(By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[10]/div[2]/input"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

            driver.FindElement(oldPassword).Click();
            driver.FindElement(oldPassword).SendKeys(newPass);
            return this;
        }

        public MyData_POM InputNewPass(string newPass)
        {
            var element = driver.FindElement(By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[10]/div[3]/input"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

            driver.FindElement(changePass_inputNew).Click();
            driver.FindElement(changePass_inputNew).SendKeys(newPass);
            return this;
        }

        public MyData_POM InputNewPassRepeat(string newPass)
        {
            var element = driver.FindElement(By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[1]/div[1]/div[10]/div[4]/input"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

            driver.FindElement(changePass_inputNew_repeat).Click();
            driver.FindElement(changePass_inputNew_repeat).SendKeys(newPass);
            return this;
        }

        public MyData_POM SaveChenges()
        {
            var element = driver.FindElement(By.XPath(@"/html/body/div[2]/section/div/div[3]/div/div[1]/form/div[2]/button"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

            driver.FindElement(saveChangesBotton).Click();
            return this;
        }
    }
}
