// Import necessary namespaces for Selenium WebDriver and browser-specific drivers
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

// Namespace declaration for the project
namespace Transavia.Hooks
{
    // The Binding attribute is used by SpecFlow to identify this class as containing bindings for steps, hooks, etc.
    [Binding]
    public sealed class Hooks
    {
        // ScenarioContext provides a way to share data between bindings within the same scenario.
        private readonly ScenarioContext _scenarioContext;

        // Utilities class instance to access common utility functions such as configuration reading.
        private readonly Utilities _util = new Utilities();

        // Constructor for the Hooks class, which initializes the ScenarioContext.
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        // Method to initialize the WebDriver based on the browser mode specified in the configuration file.
        private IWebDriver DriverMode(string browserName)
        {   
            // Declare a variable to hold the WebDriver instance.
            IWebDriver driver;
            
            // Read the browser mode from the configuration file.
            var browserMode = _util.ReadConfig("BrowserMode", "ConfigFiles/App.config");
            
            if (browserName.Equals("Chrome"))
            {
                switch (browserMode)
                {
                    case "Headless":
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        options.AddArgument("--window-size=2560,1440");
                        driver = new ChromeDriver(options);
                        break;
                    case "Normal":
                        driver = new ChromeDriver();
                        break;
                    default:
                        driver = new ChromeDriver();
                        break;
                }
            }
            else if (browserName.Equals("Firefox"))
            {
                switch (browserMode)
                {   
                    case "Headless":
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArgument("--headless");
                        options.AddArgument("--window-size=1920,1080");
                        driver = new FirefoxDriver(options);
                        break;
                    case "Normal":
                        driver = new FirefoxDriver();
                        break;
                    default:
                        driver = new FirefoxDriver();
                        break;
                }
            }
            else
            {
                switch (browserMode)
                {
                    case "Headless":
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        driver = new ChromeDriver(options);
                        break;
                    case "Normal":
                        driver = new ChromeDriver();
                        break;
                    default:
                        driver = new ChromeDriver();
                        break;
                }
            }
            
            return driver;
        }
        
        // BeforeScenario is a hook that runs before each scenario is executed.
        [BeforeScenario]
        public void BeforeScenario()
        {  
            // Read the browser type from the configuration file.
            var browserType = _util.ReadConfig("Browser", "ConfigFiles/App.config");
            
            // Declare a variable to hold the WebDriver instance.
            IWebDriver driver;
            
            // Switch statement to initialize the WebDriver based on the browser type specified in the config.
            switch (browserType)
            {
                case "Firefox":
                    driver = DriverMode(browserType);
                    break;
                case "Chrome":
                    driver = DriverMode(browserType);
                    break;
                default:
                    driver = DriverMode("");
                    break;
            }
            
            // Store the WebDriver instance in ScenarioContext under the key "WEBDRIVER" for use in other steps.
            _scenarioContext["WEBDRIVER"] = driver;
            
        }

        // AfterScenario is a hook that runs after each scenario is executed.
        [AfterScenario]
        public void AfterScenario()
        {
            // Try to retrieve the WebDriver instance from ScenarioContext.
            if (_scenarioContext.TryGetValue("WEBDRIVER", out IWebDriver driver))
            {
                driver.Quit();  // Quit the driver, closing every associated window.
            }
        }
    }
}
