using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace Eponuda
{

    [TestFixture]

    class Products : ComonData
    {
        private ITakesScreenshot driver;
        public Products()
        {
            browser.Manage().Window.Maximize();
            browser.Url = "http://www.eponuda.com/";
        }

        [Test]
        [Order(1)]
        public void mouseOver()
        {
            IWebElement menu = browser.FindElement(By.XPath("//*[@id='katMn']/li"));
            IWebElement subMenu = browser.FindElement(By.XPath("//*[@id='katMn']/li/ul/li[9]/a"));

            Actions builder = new Actions(browser);
            Thread.Sleep(1000);
            builder.MoveToElement(menu).Perform();
            Thread.Sleep(1000);
            builder.MoveToElement(subMenu).Click().Perform();
            Thread.Sleep(2000);

            IWebElement text = browser.FindElement(By.CssSelector(".breadcrumbs a[href='/bela-tehnika']"));
            string displayText = text.Text;
            string display = "Bela Tehnika";

            if (displayText == display)
            {
                Assert.Pass("MouseOver works!");
            }
            else
            {
                Assert.Fail("MouseOver doesn't work!");
            }
        }

        [Test]
        [Order(2)]
        public void selectProduct()
        {
            bool clicked = true;
            IWebElement product = browser.FindElement(By.XPath("//*[@id='con']/div[3]/div/div[2]/div[5]/div[1]/h2/a"));
            product.Click();

            if (clicked)
            {
                Assert.Pass("Product clicked!");
            }
            else
            {
                Assert.Fail("Product is not clicked!");

            }
        }

        [Test]
        [Order(3)]
        public void checkBox()
        {

            IWebElement productName = null;

            productName = browser.FindElement(By.XPath("//*[@id='pr_filt']/div[1]/div[2]/div/div[1]/ul/li[7]"));

            if (productName != null)
            {
                productName.Click();
                Assert.Pass("CheckBox checked!");
            }
            else
            {
                Assert.Fail("CheckBox is not checked!");

            }
        }

        [Test]
        [Order(4)]
           public void inputPrice()
        {
            
            IWebElement firstField = browser.FindElement(By.XPath("//*[@id='MNC']"));
            firstField.SendKeys("15000");

            IWebElement secondField = browser.FindElement(By.XPath("//*[@id='MXC']"));
            secondField.SendKeys("60000");

            IWebElement button = null;
            button = browser.FindElement(By.XPath("//*[@id='pronadji']"));
           
            if (button != null)
            {
                button.Click();
                Assert.Pass("Button clicked!");
                
            }
            else
            {
                Assert.Fail("Button is not clicked!");
            }
        }

        [Test]
        [Order(5)]
        public void dropDown()
        {
            string field = "Ceni - rastućoj";
            
            var option = browser.FindElement(By.XPath("//*[@id='uporediPo']"));
            var choice = new SelectElement(option);

            choice.SelectByText("Ceni - rastućoj");
            Assert.Pass("DDL chosen!");
        }

        [Test]
        [Order(6)]
        public void comparePricesbt()
        {
            IWebElement buttonPr = null;
            buttonPr = browser.FindElement(By.XPath("//*[@id='pr_view']/div[16]/div/div[4]/a"));

            if (buttonPr != null)
            {
                buttonPr.Click();
                Assert.Pass("Button clicked!");

            }
            else
            {
                Assert.Fail("Button is not clicked!");
            }

        }

            [Test]
        [Order(7)]
        public void visitWebsite()
        {
            IWebElement[] menus = browser.FindElements(By.XPath("//*[@id='csksv']/div[1]/table/tbody/tr[2]")).ToArray();
          
            for (int i = 0; i < 1; i++)
            {
                IWebElement menu = menus[i].FindElement(By.TagName("span"));
                menu.Click();

                Assert.Pass("Link clicked!");
  
            }
        }     
    }
}
