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
        private readonly By _hobbiesSports = By.XPath("//label[@for='hobbies-checkbox-1']");
        private readonly By _hobbiesReading = By.XPath("//label[@for='hobbies-checkbox-2']");
        private readonly By _hobbiesMusic = By.XPath("//label[@for='hobbies-checkbox-3']");
        private readonly By _currentAddress = By.XPath("//textarea[@id='currentAddress']");












              
     
       public DemoQAPractifeFormPage(IWebDriver driver) : base(driver)
        {
        }

         public void LoadDemoQAPractifeFormPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }

        public void EnterFirstName(string user)
        {
            SendText(_firstName,user);
        }

        public void EnterLastName(string user)
        {
            SendText(_lastName,user);
        }

        public void EnterEmail(string mail)
        {
            SendText(_userEmail,mail);
        }

         public void ClickGenderMaleButton()
        {
            Click(_genderMale);
            WaitForPageToBeLoaded();
        }

        public void EnterMobileNumber(string number)
        {
            ScrollToElement(_userNumber);

            SendText(_userNumber,number);
        }

         public void ClickHobbiesSportsButton()
        {
            ScrollToElement(_hobbiesSports);
            Click(_hobbiesSports);
            WaitForPageToBeLoaded();
        }

         public void ClickHobbiesReadingButton()
        {
            Click(_hobbiesReading);
            WaitForPageToBeLoaded();
        }

         public void ClickHobbiesMusicButton()
        {
            Click(_hobbiesMusic);
            WaitForPageToBeLoaded();
        }

        public void EnterCurrentAddress(string address)
        {
            SendText(_currentAddress,address);
        }




        }
}
