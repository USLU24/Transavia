namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class DemoQAPractifeFormPage : BasePage
    {
        private readonly By _firstName = By.XPath("//input[@id='firstName']");
        private readonly By _lastName = By.XPath("//input[@id='lastName']");
        private readonly By _userEmail = By.XPath("//input[@id='userEmail']");
        private readonly By _genderMale = By.XPath("//label[@for='gender-radio-1']");
        private readonly By _userNumber = By.XPath("//input[@id='userNumber']");
        private readonly By _dateBirthButton = By.XPath("//input[@id='dateOfBirthInput']");








              
     
       public DemoQAPractifeFormPage(IWebDriver driver) : base(driver)
        {
        }

         public void LoadDemoQAPractifeFormPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }

        public void EnterFirstName(String user)
        {
            SendText(_firstName,user);
        }

        public void EnterLastName(String user)
        {
            SendText(_lastName,user);
        }

        public void EnterEmail(String user)
        {
            SendText(_userEmail,user);
        }

         public void ClickGenderMaleButton()
        {
            Click(_genderMale);
            WaitForPageToBeLoaded();
        }




        }
}
