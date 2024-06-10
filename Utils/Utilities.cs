using Allure.Net.Commons;
using System.Configuration;

namespace Transavia.Utils
{
    internal class Utilities
    {
        public string RandomAlphanumeric(int length)
        {
           
            return Path.GetRandomFileName().Replace(".", "").Substring(0, length);
        }

        public string ReadConfig(string key, string filePath)
        {   
            string configFilePath = @filePath;
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = configFilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;
            string mySetting = settings[key]?.Value ?? "Default Value if Not Found";
            Console.WriteLine("Setting " + key + ": " + mySetting);
            return mySetting;
        }

        public string GenerateTimeStamp()
        {   
            DateTime now = DateTime.Now;
            string timestampWithMilliseconds = now.ToString("yyyy-MM-dd_HH-mm-ss_fff");
            return timestampWithMilliseconds;
        }

        public void TakeScreenshot(IWebDriver _driver)
        {   
            string screenshotName = GenerateTimeStamp();
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"{screenshotName}.png");
            screenshot.SaveAsFile(path);
            AllureApi.AddAttachment($"{screenshotName}.png", "image/png", File.ReadAllBytes(path));
        }
    }
}
