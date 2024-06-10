using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace TechDemoCSharpTranzactv2.PageObjects
{
    internal class DemoQASliderPage : BasePage
    {
        private readonly By _sliderButton = By.XPath("//input[@type='range']");
        private readonly By _valueSlider = By.XPath("//input[@class='range-slider range-slider--primary']");
        private readonly By _sliderValueText = By.XPath("//input[@id='sliderValue']");



       public DemoQASliderPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoadDemoQASliderPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/slider");
        }

        public void SliderButtonDrangAndDrop()
        {
          System.Threading.Thread.Sleep(3000);

          DragAndDropToOffset(_sliderButton,20,0);  
        }

        public String SliderValue()
        {
            System.Threading.Thread.Sleep(3000);

            return GetText(_valueSlider);
        }

        public String SliderValueText()
        {
            System.Threading.Thread.Sleep(3000);

            return GetAttribute(_sliderValueText,"value");
        } 

        public bool CompareSliderValues()
        {
           string sliderValue = SliderValue();
           string sliderValueText = SliderValueText();

            System.Threading.Thread.Sleep(3000);


         if (sliderValue == sliderValueText)
          {
            Console.WriteLine($"Values are equal. SliderValue: {sliderValue}, SliderValueText: {sliderValueText}");
            return true;
          }
           else
          {
            Console.WriteLine($"Values are not equal. SliderValue: {sliderValue}, SliderValueText: {sliderValueText}");
             return false;
          }
        }


        

        




    }
}
