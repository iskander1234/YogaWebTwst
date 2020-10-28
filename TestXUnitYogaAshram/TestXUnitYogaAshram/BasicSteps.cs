using System;
using OpenQA.Selenium;
using Xunit;

namespace TestXUnitYogaAshram
{
    public class BasicSteps : IDisposable
    {
        private readonly IWebDriver _driver;
        private const string MainPageUrl = "http://localhost:5000";
        private const string LoginPageUrl = MainPageUrl + "/Account/Login";
        
        
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        public BasicSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void GotoMainPage()
        {
            GoToUrl(MainPageUrl);
        }

        public void GotoLoginPage()
        {
            GoToUrl(LoginPageUrl);
        }

        public void ClickLink(string linkText)
        {
            _driver.FindElement(By.LinkText(linkText))
                .Click();
        }

        public void ClickButton(string caption)
        {
            _driver.FindElement(By.XPath($"//button[contains(text(), '{caption}')]"))
                .Click();
        }

        public void FillTextField(string filedId, string inputText)
        {
            _driver.FindElement(By.Id(filedId))
                .SendKeys(inputText);
        } 
        
        public void FillTextSelector(string filedId, string inputText)
        {
            _driver.FindElement(By.CssSelector(filedId))
                .SendKeys(inputText);
        }
        
        public void FillTextFieClass(string filedClass, string inputText)
        {
            _driver.FindElement(By.ClassName(filedClass))
                .SendKeys(inputText);
        }
        
        public bool IsElementFound(string text)
        {
            var  element =  _driver.FindElement(By.XPath($"//*[contains(text(), '{text}')]"));
            return element != null;
        }

        public void ClickById(string id)
        {
            _driver.FindElement(By.Id(id)).Click();
        }
    }
}