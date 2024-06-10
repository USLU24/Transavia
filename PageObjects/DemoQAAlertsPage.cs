using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace Transavia.PageObjects
{
    internal class DemoQAAlertsPage : BasePage
    {
        private readonly By _alertButton = By.XPath("//button[@id='alertButton']");
        private readonly By _timerAlertButton = By.XPath("//button[@id='timerAlertButton']");
        private readonly By _confirmButton = By.XPath("//button[@id='confirmButton']");
        private readonly By _promtButton = By.XPath("//button[@id='promtButton']");
        private readonly By _confirmButtonResult = By.XPath("//span[@id='confirmResult']");


        


         public DemoQAAlertsPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoadDemoQAAlertsPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        }

        public void ClickAlertButton()
        {
            ScrollToElement(_alertButton);
            Click(_alertButton);
            HandleAlertIfPresent();
        }

         public void ClickAlertAfterAppearButton()
        {
            ScrollToElement(_timerAlertButton);
            Click(_timerAlertButton);
            HandleAlertIfPresent();
        }

         public void ClickConfirmButton()
        {
            Click(_confirmButton);
            HandleAlertIfPresent();
        }

        public void ClickConfirmButtonMessage(String message)
        {
            String actualMessage=GetText(_confirmButtonResult);
             AssertElementPresent(_confirmButtonResult);
            Assert.That(actualMessage, Is.EqualTo(message));

        }

         public void ClickPromtButton()
        {
            Click(_promtButton);
            HandleAlertIfPresent();
        }

        public void AlertSendkeysAccept(String text)
        {
            WaitAlertIsPresent();
            SendKeysToAlertAndAccept(text);
            HandleAlertIfPresent();
        }




              
              

                





       

    }
}
