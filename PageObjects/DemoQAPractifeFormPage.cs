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
        private readonly By _monthSelect = By.XPath("//select[@class='react-datepicker__month-select']");
        private readonly By __yearSelect = By.XPath("//select[@class='react-datepicker__year-select']");
        private By _daySelect = By.ClassName("react-datepicker__day");
        private readonly By __selectState = By.XPath("//div[text()='Select State']");
        private readonly By __uttarPradesh = By.XPath("//*[@id='react-select-3-option-1']");
        private readonly By __selectCity = By.XPath("//div[@class=' css-1wa3eu0-placeholder']");
        private readonly By __lucklow = By.XPath("//*[@id='react-select-4-option-1']");
        private readonly By __submit = By.XPath("//button[@id='submit']");
        private readonly By __verifySubmitText = By.XPath("//div[text()='Thanks for submitting the form']");
























              
     
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
            ScrollToElement(_firstName);

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
             ScrollToElement(_genderMale);
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

           public void ClickDateBirthButton()
        {
            Click(_dateBirthButton);
            WaitForPageToBeLoaded();
        }
 
           public void SelectByVisibleTextMonth(string text)
        {
                WaitForPageToBeLoaded();
                SelectByVisibleText(_monthSelect,text);
         }

              public void SelectByVisibleTextYear(string text)
        {
                WaitForPageToBeLoaded();
                SelectByVisibleText(__yearSelect,text);
         }

         public void SelectDay(string text)
         {
            List<IWebElement> daysElement = Driver.FindElements(_daySelect).ToList();
            foreach (IWebElement dayElement in daysElement)
            {
                string day = dayElement.Text;
                if (day.Equals(text))
                {
                    dayElement.Click();
                    break;
                }
            }
        }

       public string GetDateOfBirth()
        {
            return Driver.FindElement(_dateBirthButton).GetAttribute("value");
        }

          public void ClickStateButton()
        {
            Click(__selectState);
            WaitForPageToBeLoaded();
        }

           public void ClickDynamicSelectedStateButton()
        {
            Click(__uttarPradesh);
            WaitForPageToBeLoaded();
        }

          public void ClickCityButton()
        {
            Click(__selectCity);
            WaitForPageToBeLoaded();
        }

           public void ClickDynamicSelectedCityButton()
        {
            Click(__lucklow);
            WaitForPageToBeLoaded();
        }
            public void SubmitSubmitButton()
        {
            Submit(__submit);
            WaitForPageToBeLoaded();
        }

        public bool IsThanksMessageDisplayed()
        {
            return IsDisplayed(__verifySubmitText);
        }
        




        }
}
