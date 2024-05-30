using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;


namespace TechDemoCSharpTranzactv2.PageObjects
{
    // BasePage class provides common functions and utilities for all page objects.
    internal class BasePage
    {
        // Protected variables allow access from this class and any class that inherits from it.
        protected IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        

        // Utilities class instance for accessing common utility functions.
        private readonly Utilities _util = new Utilities();

        // Private variable to track the current page URL or identifier.
        private string _currentPage;

        // Constructor initializes the WebDriver and WebDriverWait.
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90)); // Set WebDriverWait to 90 seconds.
        }

        // ClearText method clears text from a web element specified by the 'element' locator.
        public void ClearText(By element)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).Clear();
        }

        // SendText method sends text to a web element specified by the 'element' locator.
        public void SendText(By element, string text)
        {
            WaitWebElementVisibleBy(element);
            Driver.FindElement(element).SendKeys(text);
        }

        // GetText retrieves the text from a web element specified by the 'locator'.
        public string GetText(By locator)
        {
            WaitWebElementVisibleBy(locator);
            return Driver.FindElement(locator).Text;
        }

        // GetTexts retrieves texts from multiple web elements specified by the 'locator'.
        public List<string> GetTexts(By locator)
        {
            return FindElements(locator).Select(e => e.Text).ToList();
        }

        // Click method performs a click action on a web element specified by the 'element' locator.
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

        // IsNotDisplayed checks if a web element specified by the 'locator' is not displayed.
        public bool IsNotDisplayed(By locator)
        {
            return Driver.FindElements(locator).Count == 0;
        }

        // FindElements retrieves multiple web elements specified by the 'elements' locator.
        public List<IWebElement> FindElements(By elements)
        {
            WaitWebElementsVisibleBy(elements);
            return Driver.FindElements(elements).ToList();
        }

        // WaitWebElementClickableBy waits until a web element is clickable.
        public void WaitWebElementClickableBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        // WaitWebElementVisibleBy waits until a web element is visible.
        public void WaitWebElementVisibleBy(By element)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
        
        public void WaitWebElementVisibleBy(By element, TimeSpan timeout)
        {
            new WebDriverWait(Driver, timeout).Until(ExpectedConditions.ElementIsVisible(element));
        }

        // WaitWebElementsVisibleBy waits until all specified web elements are visible.
        public void WaitWebElementsVisibleBy(By elements)
        {
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
        }

        // AssertElementPresent asserts that a web element is present and visible.
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

        // Sleep methods for pausing the execution for a specified amount of time.
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

        

       
        // AutomationSpeed adjusts the speed of automation based on configuration.
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
                    ; // Do nothing
                    break;
            }
        }
    }
}
