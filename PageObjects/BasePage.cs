using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;


namespace Transavia.PageObjects
{
    internal class BasePage
    {
        protected IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        

        private readonly Utilities _util = new Utilities();

        private string _currentPage;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90)); 
        }

        public void ClearText(By element)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).Clear();
        }

        public void SendText(By element, string text)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).SendKeys(text);
        }

        public string GetText(By locator)
        {
            WaitWebElementVisibleBy(locator);
            return Driver.FindElement(locator).Text;
        }

        public string GetAttribute(By locator, string attributeName)
        {
           WaitWebElementVisibleBy(locator);
          return Driver.FindElement(locator).GetAttribute(attributeName);
        }

        public List<string> GetTexts(By locator)
        {
            return FindElements(locator).Select(e => e.Text).ToList();
        }

        public void Click(By element)
        {
            WaitWebElementVisibleBy(element);
            WaitWebElementClickableBy(element);
            Driver.FindElement(element).Click();
        }

        public void DoubleClick(By element)
        {
            Actions actions = new Actions(Driver);
            IWebElement webElement = Driver.FindElement(element);
            WaitWebElementVisibleBy(element);
            WaitWebElementClickableBy(element);
            actions.DoubleClick(webElement).Perform();
        }

        public void RightClick(By element)
        {
            Actions actions = new Actions(Driver);
            IWebElement webElement = Driver.FindElement(element);
            WaitWebElementVisibleBy(element);
            WaitWebElementClickableBy(element);
            actions.ContextClick(webElement).Perform();
        }

        public bool IsNotDisplayed(By locator)
        {
            return Driver.FindElements(locator).Count == 0;
        }

        public List<IWebElement> FindElements(By elements)
        {
            WaitWebElementsVisibleBy(elements);
            return Driver.FindElements(elements).ToList();
        }

        public void WaitWebElementClickableBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitWebElementVisibleBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
        
        public void WaitWebElementVisibleBy(By element, TimeSpan timeout)
        {
            new WebDriverWait(Driver, timeout).Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void WaitWebElementsVisibleBy(By elements)
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
        }

        public void WaitAlertIsPresent()
        {
        Wait.Until(ExpectedConditions.AlertIsPresent());
        }
    

        public void AssertElementPresent(By element)
        {
            WaitWebElementVisibleBy(element);
            Assert.That(Driver.FindElement(element).Displayed, Is.EqualTo(true));
        }
        
        public bool AssertElementNotPresent(By element)
        {
            try
            {
                WaitWebElementVisibleBy(element, new TimeSpan(0, 0, 0, 0, 250));
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return true;
            }
        }

        // WaitForPageToBeLoaded waits until the web page is fully loaded.
        public void WaitForPageToBeLoaded()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(driver =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState;").ToString() == "complete");
            AutomationSpeed();
        }

        public void SleepSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void SleepMiliseconds(long millis)
        {
            Thread.Sleep((int)millis);
        }

        public void ScrollDown()
        {
           IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
           js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollToElement(By element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            IWebElement webElement = Driver.FindElement(element);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public void SelectByVisibleText(By element, string visibleText)
        {
            WaitWebElementVisibleBy(element);
             IWebElement dropdown = Driver.FindElement(element);
             SelectElement select = new SelectElement(dropdown);
            select.SelectByText(visibleText);
        }

         public void Submit(By element)
        {
            WaitWebElementVisibleBy(element);
            WaitWebElementClickableBy(element);
            Driver.FindElement(element).Submit();
        }

        public bool IsDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void HandleAlertIfPresent()
        {
        try
        {
            WaitAlertIsPresent();
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }
        catch (NoAlertPresentException)
        {
             Console.WriteLine("No alert present to accept.");
  
        }
        }

         public void SendKeysToAlertAndAccept(string text)
        {
          try
          {
            WaitAlertIsPresent();
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
           }
           catch (NoAlertPresentException)
           {
            Console.WriteLine("No alert present to send keys to and accept.");
           }
            catch (UnhandledAlertException ex)
            {
             Console.WriteLine("Beklenmeyen uyarı: " + ex.Message);
                Driver.SwitchTo().Alert().Dismiss();
            }
        
        }

        public void DragAndDropToOffset(By locator, int xOffset, int yOffset)
        {
           IWebElement sourceElement = Driver.FindElement(locator);
           Actions actions = new Actions(Driver);
           actions.DragAndDropToOffset(sourceElement, xOffset, yOffset).Perform();
         }
        

        

       
        private void AutomationSpeed() 
        {
            var speed = _util.ReadConfig("AutomationSpeed", "ConfigFiles/App.config");
            Console.WriteLine("AutomationSpeed: " + speed);

            switch (speed)
            {
                case "Slow":
                    SleepMiliseconds(500);
                    break;
                case "Slowest":
                    SleepSeconds(1);
                    break;
                case "Normal":
                    break;
                default:
                    ; 
                    break;
            }
        }
    }
}
