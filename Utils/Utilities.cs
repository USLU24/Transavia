using Allure.Net.Commons;
using System.Configuration;

namespace TechDemoCSharpTranzactv2.Utils
{
    internal class Utilities
    {
        // This is a public method that returns a string. It can be accessed from any class
        public string RandomAlphanumeric(int length)
        {
            // Path.GetRandomFileName() generates a random 11-character string that can be used as a file name
            // The Replace(".", "") removes any periods from the string
            // The Substring(0, length) returns the first 'length' characters of the string
            // So, this method returns a random alphanumeric string of the specified length
            return Path.GetRandomFileName().Replace(".", "").Substring(0, length);
        }

        public string ReadConfig(string key, string filePath)
        {   
            // Map the path of the config file
            string configFilePath = @filePath;
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = configFilePath;
            // Get the mapped configuration file
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            // Read a specific setting from the configuration file
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;
            string mySetting = settings[key]?.Value ?? "Default Value if Not Found";
            // Print the setting to the console and return it
            Console.WriteLine("Setting " + key + ": " + mySetting);
            return mySetting;
        }

        public string GenerateTimeStamp()
        {   
            // Get the current DateTime
            DateTime now = DateTime.Now;
            // Format the DateTime to include milliseconds
            string timestampWithMilliseconds = now.ToString("yyyy-MM-dd_HH-mm-ss_fff");
            return timestampWithMilliseconds;
        }

        public void TakeScreenshot(IWebDriver _driver)
        {   
            // Generate a timestamp to use as the screenshot name
            string screenshotName = GenerateTimeStamp();
            // Take a screenshot and save it to the specified path, using the _driver object as context
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            // Save the screenshot to a file for later use
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"{screenshotName}.png");
            screenshot.SaveAsFile(path);
            // Add the screenshot to the Allure report
            AllureApi.AddAttachment($"{screenshotName}.png", "image/png", File.ReadAllBytes(path));
        }
    }
}
