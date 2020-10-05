using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class Footer_POM
    {
        private IWebDriver driver;
        By iconInstagram = By.CssSelector("body > footer > div > section.top_block.clearfix > div.external_links > div.social_networks > div.social_networks_list > a:nth-child(2)");
        By iconTelegram = By.CssSelector("body > footer > div > section.top_block.clearfix > div.external_links > div.social_networks > div.social_networks_list > a:nth-child(4)");
        By iconFacebook = By.CssSelector("body > footer > div > section.top_block.clearfix > div.external_links > div.social_networks > div.social_networks_list > a:nth-child(3)");
        By iconYouTube = By.CssSelector("body > footer > div > section.top_block.clearfix > div.external_links > div.social_networks > div.social_networks_list > a:nth-child(1)");

        public Footer_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string CheckGoToMessengers(string messenger)
        {
            for (; ; )
            {
                if (messenger == "Instagram")
                {
                    driver.FindElement(iconInstagram).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "Telegram")
                {
                    driver.FindElement(iconTelegram).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "Facebook")
                {
                    driver.FindElement(iconFacebook).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
                else if (messenger == "YouTube")
                {
                    driver.FindElement(iconYouTube).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string url = driver.Url;
                    return url;
                }
            }
        }
    }
}

