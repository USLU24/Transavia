namespace Transavia.PageObjects
{
    internal class DemoQAButtonsPage : BasePage
    {
              
                private readonly By _doubleClickButton = By.XPath("//button[@id='doubleClickBtn']");
                private readonly By _rightClickButton = By.XPath("//button[@id='rightClickBtn']");
                private readonly By _doubleClickMessage = By.XPath("//p[@id='doubleClickMessage']");
                private readonly By _rightClickMessage = By.XPath("//p[@id='rightClickMessage']");


                







        
        public DemoQAButtonsPage(IWebDriver driver) : base(driver)
        {
        }

         public void LoadDemoQAButtonsPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

        public void ClickDoubleClickMeButton()
        {
            ScrollDown();
            WaitForPageToBeLoaded();
            DoubleClick(_doubleClickButton);
        }

        public void ClickRightClickMeButton()
        {
            WaitForPageToBeLoaded();
            RightClick(_rightClickButton);
        }

        public void ClickDoubleClickMeButton(String message)
        {
            String actualMessage=GetText(_doubleClickMessage);
             AssertElementPresent(_doubleClickMessage);
            Assert.That(actualMessage, Is.EqualTo(message));

        }

         public void ClickRightClickButton(String message)
        {
            String actualMessage=GetText(_rightClickMessage);
             AssertElementPresent(_rightClickMessage);
            Assert.That(actualMessage, Is.EqualTo(message));

        }



       

        }
}
