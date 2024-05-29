namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class TransaviaDestinationsPage : BasePage
    {
                private readonly By _destinationIcon = By.XPath("(//a[@class='Breadcrumbs_link___lxAf'])[1]");

                private readonly By _destinationLabel = By.XPath("(//a[@class='Breadcrumbs_link___lxAf'])[2]");

                private readonly By _whetherText = By.XPath("//p[@data-testid='country-intro-text']");

                private readonly By _findYourFlight = By.XPath("//p[@data-testid='country-intro-text']");

                private readonly By _bookButton = By.XPath("//button[@data-testid='topnav-submenu-book']");

                private readonly By _worldIconButton = By.XPath("//button[@data-testid='topnav-languageswitch']");
                
                private readonly By _countryText = By.XPath("//p[text()='Recommended for you']/parent::div/div/div/a/div");






        
        public TransaviaDestinationsPage(IWebDriver driver) : base(driver)
        {
        }

         public void LoadDestinationPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.transavia.com/en-EU/home/");
        }

        public void ClickBookButton()
        {
            Click(_bookButton);
            WaitForPageToBeLoaded();
        }

         public void ClickWorldIconButton()
        {
            Click(_worldIconButton);
            WaitForPageToBeLoaded();
        }

        public List<string> WhenICountTheTextsOfSiblingDivElements() 
        {
           return GetTexts(_countryText);
        }

        // Method to click the finish button on the checkout overview page.
        // This method will be used whenever we need to complete the checkout process in our tests.

        }
}
