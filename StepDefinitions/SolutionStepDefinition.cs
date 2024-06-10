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
        private readonly DemoQAPractifeFormPage _demoqapractifeformpage;
        private readonly DemoQAAlertsPage _demoqaalertspage;
        private readonly DemoQASliderPage _demoqasliderpage;



        private List<string> _elementTexts;

       

        // Lists to hold product and cart prices for comparison in tests
           // Constructor for the class. It takes ScenarioContext as a parameter and initializes WebDriver and Page Objects
        public SolutionStepDefinition(ScenarioContext scenarioContext)
        {
           
            _driver = scenarioContext["WEBDRIVER"] as IWebDriver;
            _transaviadestions = new TransaviaDestinationsPage(_driver);
            _demoqabuttonspage=new DemoQAButtonsPage(_driver);
            _demoqapractifeformpage=new DemoQAPractifeFormPage(_driver);
            _demoqaalertspage=new DemoQAAlertsPage(_driver);
            _demoqasliderpage=new DemoQASliderPage(_driver);
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
            System.Threading.Thread.Sleep(3000);

            _transaviadestions.ClickBookButton();

            _util.TakeScreenshot(_driver);
        }

    
          [When(@"I click on the doubleclick button")]
        public void IClickDoublecClickButton()
        {
             System.Threading.Thread.Sleep(3000);

            _demoqabuttonspage.ClickDoubleClickMeButton();

            _util.TakeScreenshot(_driver);
        }

          [When(@"I click on the rightclick button")]
        public void IClickRightClickButton()
        {
             System.Threading.Thread.Sleep(3000);

            _demoqabuttonspage.ClickRightClickMeButton();

            _util.TakeScreenshot(_driver);
        }

          

            [When(@"I click on the World Icon button")]
        public void IClickWorldIconButton()
        {
            System.Threading.Thread.Sleep(3000);

            _transaviadestions.ClickBookButton();

            _util.TakeScreenshot(_driver);
        }

         [When("I count the texts of sibling div elements")]
        public void ICountTheTextsOfSiblingDivElements()
        {
            System.Threading.Thread.Sleep(3000);

            _elementTexts = _transaviadestions.WhenICountTheTextsOfSiblingDivElements();

        }

         [Then("I print the count of texts of sibling div elements")]
        public void IPrintTheCountOfTextsOfSiblingDivElements()
        
        {
            System.Threading.Thread.Sleep(3000);

            Console.WriteLine($"Count of texts from sibling div elements: {_elementTexts.Count}");

        }

        [Then(@"Message ""([^""]*)"" from doubleClick")]
        public void VerifyDoubleClickMessage(string message)
        {
            System.Threading.Thread.Sleep(3000);

            _demoqabuttonspage.ClickDoubleClickMeButton(message);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Message ""([^""]*)"" from  rightClick")]
        public void VerifyRightClickMessage(string message)
        {
            System.Threading.Thread.Sleep(3000);

            _demoqabuttonspage.ClickRightClickButton(message);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"Message ""(.*)"" from rightClick")]
        public void ThenMessageFromRightClick(string expectedMessage)
        {
            System.Threading.Thread.Sleep(3000);

           _demoqabuttonspage.ClickRightClickButton(expectedMessage);
           _util.TakeScreenshot(_driver);
        }

           [Given(@"I am on the  DemoQA Practife Form page")]
        public void IAmOnTheDemoQAPractifeFormPage()
        {
            _demoqapractifeformpage.LoadDemoQAPractifeFormPage();

            _util.TakeScreenshot(_driver);
        }

          [When(@"I enter Name as ""([^""]*)"" for Student Registration Form")]
        public void IEnterFirstName(string user)
        {
              System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.EnterFirstName(user);

            _util.TakeScreenshot(_driver);
        }

         [When(@"I enter Surname as ""([^""]*)"" for Student Registration Form")]
        public void IEnterLastName(string user)
        {
            System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.EnterLastName(user);

            _util.TakeScreenshot(_driver);
        }

          [When(@"I enter Mail as ""([^""]*)"" for Student Registration Form")]
        public void IEnterEmail(string mail)
        {
             System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.EnterEmail(mail);

            _util.TakeScreenshot(_driver);
        }

         [When(@"I click Gender Male Button")]
        public void IClickGenderMaleButton()
        {
            System.Threading.Thread.Sleep(3000);

            _demoqapractifeformpage.ClickGenderMaleButton();

            _util.TakeScreenshot(_driver);
        }

         [When(@"I enter Mobile Number as ""([^""]*)"" for Student Registration Form")]
            public void IEnterMobileNumber(string number)
           {
            System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.EnterMobileNumber(number);

            _util.TakeScreenshot(_driver);
        }

         [When(@"I click Hobbies Sports Button")]
        public void IClickHobbiesSportsButton()
        {
             System.Threading.Thread.Sleep(3000);

            _demoqapractifeformpage.ClickHobbiesSportsButton();

            _util.TakeScreenshot(_driver);
        }

        [When(@"I click Hobbies Reading Button")]
        public void IClickHobbiesReadingButton()
        {
            System.Threading.Thread.Sleep(3000);

            _demoqapractifeformpage.ClickHobbiesReadingButton();

            _util.TakeScreenshot(_driver);
        }

        [When(@"I click Hobbies Music Button")]
        public void IClickHobbiesMusicButton()
        {
              System.Threading.Thread.Sleep(3000);

            _demoqapractifeformpage.ClickHobbiesMusicButton();

            _util.TakeScreenshot(_driver);
        }
        
        [When(@"I enter Current Address as ""([^""]*)"" for Student Registration Form")]
        public void IEnterCurrentAddress(string address)
        {
             System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.EnterCurrentAddress(address);

            _util.TakeScreenshot(_driver);
        }

         [When(@"I click Date Of Birth Button")]
        public void IClickDateOfBirth()
        {
            System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.ClickDateBirthButton();

            _util.TakeScreenshot(_driver);
        }

         [When(@"I enter Birth Month as ""([^""]*)"" for Student Registration Form")]
        public void IEnterBirthMonth(string text)
        {
             System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.SelectByVisibleTextMonth(text);

            _util.TakeScreenshot(_driver);
        }

         [When(@"I enter Birth Year as ""([^""]*)"" for Student Registration Form")]
        public void IEnterBirthYear(string text)
        {
              System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.SelectByVisibleTextYear(text);

            _util.TakeScreenshot(_driver);
        }


        [When(@"I enter Select day as ""([^""]*)"" for Student Registration Form")]
        public void IEnterSelectDay(string text)
        {
              System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.SelectDay(text);

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I verify the date of birth is ""([^""]*)""")]
        public void ThenVerifyDateOfBirth(string expectedDate)
        {
            string actualDate = _demoqapractifeformpage.GetDateOfBirth();
            if (actualDate != expectedDate)
            {
                throw new Exception($"Expected date of birth: {expectedDate}, but got: {actualDate}");
            }
        }

         [When(@"I click State  Button")]
        public void IClickStateButton()
        {
             System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.ClickStateButton();

            _util.TakeScreenshot(_driver);
        }

         [When(@"I click Selected State Button")]
        public void IClickSelectedStateButton()
        {
             System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.ClickDynamicSelectedStateButton();

            _util.TakeScreenshot(_driver);
        }

           [When(@"I click City  Button")]
        public void IClickCityButton()
        {
            System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.ClickCityButton();

            _util.TakeScreenshot(_driver);
        }

          [When(@"I click Selected City Button")]
        public void IClickSelectedCityButton()
        {
               System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.ClickDynamicSelectedCityButton();

            _util.TakeScreenshot(_driver);
        }

          [When(@"I submit Submit Button")]
        public void ISubmitSubmitButton()
        {
            System.Threading.Thread.Sleep(3000);

           _demoqapractifeformpage.SubmitSubmitButton();

            _util.TakeScreenshot(_driver);
        }

        [Then(@"I verify that the thanks message is displayed")]
        public void ThenVerifyThanksMessageIsDisplayed()
        {
            System.Threading.Thread.Sleep(3000);

            bool isDisplayed = _demoqapractifeformpage.IsThanksMessageDisplayed();
            if (!isDisplayed)
            {
                throw new Exception("Thanks message is not displayed.");
            }
           _util.TakeScreenshot(_driver);

        }

        [Given(@"I am on the  DemoQA Alerts  page")]
        public void IAmOnTheDemoQAAlertsPage()
        {
            _demoqaalertspage.LoadDemoQAAlertsPage();

            _util.TakeScreenshot(_driver);
        }

         [When(@"I click Click me  Button for Alert")]
        public void IClickMeButtonForAlert()
        {
            _demoqaalertspage.ClickAlertButton();

            _util.TakeScreenshot(_driver);
        }

          [When(@"I click Click me  Button for five seconds after appear Alert")]
        public void IClickMeButtonForFiveSecondsAppearAlert()
        {
            _demoqaalertspage.ClickAlertAfterAppearButton();

            _util.TakeScreenshot(_driver);
        }
           [When(@"I click Confrim button")]
        public void IClickClickConfirmButton()
        {
            _demoqaalertspage.ClickConfirmButton();

            _util.TakeScreenshot(_driver);
        }
        
         [Then(@"Message ""(.*)"" from Confirm Button.")]
        public void VerifyClickConfirmButtonMessage(string expectedMessage)
        {
           _demoqaalertspage.ClickConfirmButtonMessage(expectedMessage);
           _util.TakeScreenshot(_driver);
        }

          [When(@"I click Promt button")]
        public void IClickClickPromtButton()
        {
            _demoqaalertspage.ClickPromtButton();

            _util.TakeScreenshot(_driver);
        }

        [When(@"I send keys to Alert and accept")]
         public void ISendKeysToAlertAndAccept()
          {
        _demoqaalertspage.SendKeysToAlertAndAccept("Neo");
        _demoqaalertspage.HandleAlertIfPresent();
        _util.TakeScreenshot(_driver);
         }

           [Given(@"I navigate to the DemoQA slider page")]
          public void GivenINavigateToTheDemoQASliderPage()
        {
           _demoqasliderpage.LoadDemoQASliderPage();
        }

           [When(@"I drag the slider button to the right")]
          public void WhenIDragTheSliderButtonToTheRight()
        {
            _demoqasliderpage.SliderButtonDrangAndDrop();
        }

          [Then(@"the slider value should match the slider value text")]
         public void ThenTheSliderValueShouldMatchTheSliderValueText()
        {
           bool result = _demoqasliderpage.CompareSliderValues();
            _util.TakeScreenshot(_driver);
        }





                           
        
  

        

        
    
 
         }
}
