using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_ParfumsUA
{
    public class SeleniumTests
    {
        IWebDriver chrome = new ChromeDriver(@"C:\Users\ЛордКотДотКом\Desktop\WebdriverChrome");
        HomePage_POM hp_POM;
        SignInORSignUp_POM si_POM;
        HeaderAutorazation_POM ha_POM;
        MyData_POM myDa_POM;
        BinOfProduct_POM binProd_POM;
        RegistrationOnANewAdress_POM regOnANewAdd_POM;
        MyFavorites_POM favoriteList_POM;
        OrdersList_POM orderList_POM;
        Footer_POM footer_POM;
        By krest = By.XPath("/html/body/div[13]/div/span");

        [SetUp]
        public void GoToParfums()
        {
            chrome.Navigate().GoToUrl("https://parfums.ua/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            hp_POM = new HomePage_POM(chrome);
            si_POM = new SignInORSignUp_POM(chrome);
            ha_POM = new HeaderAutorazation_POM(chrome);
            myDa_POM = new MyData_POM(chrome);
            binProd_POM = new BinOfProduct_POM(chrome);
            regOnANewAdd_POM = new RegistrationOnANewAdress_POM(chrome);
            favoriteList_POM = new MyFavorites_POM(chrome);
            orderList_POM = new OrdersList_POM(chrome);
            footer_POM = new Footer_POM(chrome);
            chrome.Manage().Window.Maximize();
        }

        public void LogIn()
        {
            si_POM = hp_POM.ClickOnSignInORSignUpButton();
            si_POM.ClickOnLogInButton();
            si_POM.FillLogInField("+380633223729");
            si_POM.FillPassInField("Test0058597113");
            si_POM.ClickInButtonEnter();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 
        }

        [TestCase(Description = "Проверка успешной авторизации")]
        public void SucsessLogIn()
        {
            si_POM = hp_POM.ClickOnSignInORSignUpButton();
            si_POM.ClickOnLogInButton();
            si_POM.FillLogInField("+380633223729");
            si_POM.FillPassInField("Test0058597113");
            si_POM.ClickInButtonEnter();

            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement userName = chrome.FindElement(By.CssSelector("#profile_desktop > button"));
            Assert.AreEqual("Иван (3%)", userName);
            chrome.Quit();
        }

        [TestCase(Description = "Проверка успешной смены пароля")]
        public void ChangePassword()
        {
            LogIn();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ha_POM = ha_POM.ClickProfileButton();
            ha_POM = ha_POM.ClickMyAccountSettings();
            myDa_POM = myDa_POM.InputOldPass("Test0058597113");
            myDa_POM = myDa_POM.InputNewPass("Test0058597113");
            myDa_POM = myDa_POM.InputNewPassRepeat("Test0058597113");
            myDa_POM = myDa_POM.SaveChenges();
            
            IWebElement success = chrome.FindElement(By.CssSelector("body > div.main_modal.default_modal.js-default_modal.js-modal.show.js-modal-1 > div > div"));
            Assert.AreEqual("Изменения успешно сохранены!", success.Text);
            chrome.Quit();
        }

        [TestCase("Ваш заказ", Description = "Проверка успешного добавления товара в корзину")]
        public void CheckBinOfProduct(string expectedResult)
        {
            LogIn();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ha_POM.GoToBinWithProduct();
            string actualResult = binProd_POM.CheckHasNomenklatura();
            Assert.AreEqual(expectedResult, actualResult);
            chrome.Quit();
        }

        [TestCase("Наконец-то, везите уже :)", Description = "Проверка успешного оформление заказа")]
        public void CheckCreateANewOrder(string expectedResult)
        {
            LogIn();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ha_POM.GoToBinWithProduct();
            binProd_POM.ClickOnDoOrderBotton();
            regOnANewAdd_POM = regOnANewAdd_POM.SelectThisAdress();
            regOnANewAdd_POM = regOnANewAdd_POM.InputCityOrder("Киев");
            regOnANewAdd_POM = regOnANewAdd_POM.InputStreetOrder("проспект Павла Тичины");
            regOnANewAdd_POM = regOnANewAdd_POM.InputNumberHouse("5-A");
            regOnANewAdd_POM = regOnANewAdd_POM.InputNumberFlat("51");
            regOnANewAdd_POM = regOnANewAdd_POM.SelectPaymentMethodBotton();

            IWebElement actualResult = chrome.FindElement(By.CssSelector("#checkout > div > section > div > div.checkout_left > div > div > section > button"));
            Assert.AreEqual(expectedResult, actualResult);
            chrome.Quit();
        }

        [TestCase("Иван Терещенко", Description = "Проверка личной информации в личном кабинете - имя и фамилия")]
        public void CheckPersonalityInfoInMyAccount(string name)
        {
            LogIn();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ha_POM = ha_POM.ClickProfileButton();
            ha_POM = ha_POM.ClickMyAccountSettings();
            IWebElement userNameSite = chrome.FindElement(By.CssSelector("#wrapper > section > div > div.user__bar > div.user__main-info > div > h1"));
            Assert.AreEqual(name, userNameSite.Text);
            chrome.Quit();
        }

        [TestCase("TestEditedName", Description = "Изменить название списка - Мои пожелания")]
        public void EditListMyFavorites(string expectedResult)
        {
            LogIn();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ha_POM.ClickOnTheFavoritesButton();
            favoriteList_POM.EditNameFavoriteListBotton();
            favoriteList_POM.InputNameFavoriteListField(expectedResult);
            favoriteList_POM.SaveNameFavoriteListBotton();
            
            IWebElement actualResult = chrome.FindElement(By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div.favourites__header.js-favourites-list-container > div > select > option"));
            Assert.AreEqual(expectedResult, actualResult.Text);
            chrome.Quit();
        }

        [TestCase("Оплачено", Description = "Проверка статус оплаты, доставленного заказа (Доставлено == Оплачено)")]
        public void CheckPaymentStatusOrder(string expectedResult)
        {
            LogIn();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ha_POM = ha_POM.ClickProfileButton();
            ha_POM = ha_POM.ClickMyAccountSettings();
            ha_POM = ha_POM.ClickOnTheOrdersList();
            orderList_POM = orderList_POM.SelectOrder();
            IWebElement actualResult = chrome.FindElement(By.CssSelector("#wrapper > section > div > div.user__wrap.clearfix > div > div > div > div.detail_header > div.detail_header_block.clearfix > div.detail_header_item.detail_header_item_last > div.detail_header_result.order_payment_status_payed"));
            Assert.AreEqual(expectedResult, actualResult.Text);
        }

        [TestCase("Instagram", "https://www.instagram.com/parfumsua/", Description = "Проверка перехода на ресурс при нажатии на иконку Instagram в подвале сайта parfums.ua")]
        [TestCase("YouTube", "https://www.youtube.com/channel/UCbWtfLGKhP3qogBZatxk61g")]
        [TestCase("Facebook", "https://www.facebook.com/PARFUMS.UA")]
        [TestCase("Telegram", "https://t.me/parfumsua")]
        public void CheckGoToMEssengers(string messenger, string expectedResult)
        {
            string actualResult = footer_POM.CheckGoToMessengers(messenger);
            Assert.AreEqual(expectedResult, actualResult);

            //закрытие вкладки
            var tabs = chrome.WindowHandles;
            if (tabs.Count > 1)
            {
                chrome.SwitchTo().Window(tabs[1]);
                chrome.Close();
                chrome.SwitchTo().Window(tabs[0]);
            }
        }

        ///////////
        ///

        [Test]
        public void SuccessGoToParfumePage()
        {
            hp_POM = hp_POM.ParfumTab();
            IWebElement text = chrome.FindElement(By.XPath(" / html / body / div[3] / section / div[1] / div / div / h1"));
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual("Парфюмерия", text.Text);
        }
        [Test]
        public void SuccessGoToMakeUpPage()
        {
            hp_POM = hp_POM.MakeUpTab();
            IWebElement text = chrome.FindElement(By.CssSelector("#wrapper > section > div.line-title.page-title > div > div > h1"));
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.AreEqual("Декоративная косметика", text.Text);
        }
        [Test]
        public void SuccessGoToHairPage()
        {
            hp_POM = hp_POM.HairTab();
            IWebElement text = chrome.FindElement(By.XPath("/html/body/div[3]/section/div[1]/div/div/h1"));
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.AreEqual("Косметика для волос", text.Text);
        }
        [Test]
        public void SuccessGoToFacePage()
        {
            hp_POM = hp_POM.FaceTab();
            IWebElement text = chrome.FindElement(By.XPath("/html/body/div[3]/section/div[1]/div/div/h1"));
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.AreEqual("Косметика для лица", text.Text);
        }
        [Test]
        public void SuccessGoToDermoPage()
        {
            hp_POM = hp_POM.DermoTab();
            IWebElement text = chrome.FindElement(By.XPath("/html/body/div[3]/section/div[2]/div[1]/h1"));
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.AreEqual("Дерматокосметика", text.Text);
        }



        [Test]
        public void SuccessChangeDatae()
        {
            hp_POM = hp_POM.ChangeData("werswerswerswers@gmail.com", "Test0058597113", "Иванович");
            IWebElement text = chrome.FindElement(By.XPath("/html/body/div[5]/div/div"));
            Assert.AreEqual("Изменения успешно сохранены!", text.Text);

        }

        [Test]
        public void ChekHistory()
        {
            hp_POM = hp_POM.ChekHistoryOfOrders("werswerswerswers@gmail.com", "Test0058597113", "история заказов");
            IWebElement text = chrome.FindElement(By.XPath("/html/body/div[3]/section/div[2]/div/div/div[2]/div[1]/div/div[3]/div/div[2]/div[1]/div/a[2]"));

            Assert.AreEqual("Creed Fleurissimo", text.Text);

        }
    }
}
