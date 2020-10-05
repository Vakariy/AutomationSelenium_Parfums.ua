using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class OrdersList_POM
    {
        private IWebDriver driver;
        By selectOrder = By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div > div.profile_orders.profile_orders_desktop > div:nth-child(2) > div > div.first_column > div > div.number");
        By statusPayment = By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div > div > div.detail_header > div.detail_header_block.clearfix > div.detail_header_item.detail_header_item_last > div.detail_header_result.order_payment_status_payed");

        public OrdersList_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public OrdersList_POM SelectOrder()
        {
            driver.FindElement(selectOrder).Click();
            return this;
        }
    }
}
