using TechDemoCSharpTranzactv2.PageObjects;

namespace TechDemoCSharpTranzactv2.StepDefinitions
{
    [Binding]
    public sealed class SolutionStepDefinition
    {
        // Private variables to hold instances of WebDriver, Page Objects, and Utilities
        private readonly IWebDriver _driver;
        private readonly Utilities _util = new Utilities();

        // Page Object instances for different pages in the application
        private readonly TransaviaDestinationsPage _transaviadestions;
        private readonly DemoQAButtonsPage _demoqabuttonspage;

        private List<string> _elementTexts;

       

        // Lists to hold product and cart prices for comparison in tests
           // Constructor for the class. It takes ScenarioContext as a parameter and initializes WebDriver and Page Objects
        public SolutionStepDefinition(ScenarioContext scenarioContext)
        {
           
            _driver = scenarioContext["WEBDRIVER"] as IWebDriver;
            _transaviadestions = new TransaviaDestinationsPage(_driver);
            _demoqabuttonspage=new DemoQAButtonsPage(_driver);
        }

        // The rest of the methods in the class are SpecFlow step definitions. Each method corresponds to a step in the Gherkin feature file
        // The [Given], [When], and [Then] attributes denote the type of the step (Given, When, Then)
        // The methods use the Page Object instances to perform actions on the application and make assertions


        [Given(@"I am on the  Transavia page")]
        public void IAmOnTheTransaviaPage()
        {
            _transaviadestions.LoadDestinationPage();

            _util.TakeScreenshot(_driver);
        }

        [Given(@"I am on the  DemoQA Buttons page")]
        public void IAmOnTheDemoQAButtonsPage()
        {
            _demoqabuttonspage.LoadDemoQAButtonsPage();

            _util.TakeScreenshot(_driver);
        }

          [When(@"I click on the Book button")]
        public void IClickOnTheBookButton()
        {
            _transaviadestions.ClickBookButton();

            _util.TakeScreenshot(_driver);
        }

            [When(@"I click on the World Icon button")]
        public void IClickWorldIconButton()
        {
            _transaviadestions.ClickBookButton();

            _util.TakeScreenshot(_driver);
        }

         [When("I count the texts of sibling div elements")]
        public void ICountTheTextsOfSiblingDivElements()
        {
                _elementTexts = _transaviadestions.WhenICountTheTextsOfSiblingDivElements();

        }

         [Then("I print the count of texts of sibling div elements")]
        public void IPrintTheCountOfTextsOfSiblingDivElements()
        {
            Console.WriteLine($"Count of texts from sibling div elements: {_elementTexts.Count}");

        }

        
 
         }
}
