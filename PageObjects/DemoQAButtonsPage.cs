namespace TechDemoCSharpTranzactv2.PageObjects
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
            DoubleClick(_doubleClickButton);
            WaitForPageToBeLoaded();
        }

        public void ClickRightClickMeButton()
        {
            RightClick(_rightClickButton);
            WaitForPageToBeLoaded();
        }

       

        }
}
