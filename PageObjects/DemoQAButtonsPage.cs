namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class DemoQAButtonsPage : BasePage
    {
              
                private readonly By _doubleClickButton = By.XPath("//button[@id='doubleClickBtn']");
                private readonly By _rightClickButton = By.XPath("//button[@id='rightClickBtn']");







        
        public DemoQAButtonsPage(IWebDriver driver) : base(driver)
        {
        }

         public void LoadDemoQAButtonsPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

       

        }
}
