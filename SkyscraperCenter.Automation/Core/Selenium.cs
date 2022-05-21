using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SkyscraperCenter.Automation.Core
{
    public sealed class Selenium
    {
        public IWebDriver Driver => driver.Value;
        
        private Lazy<IWebDriver> driver = new Lazy<IWebDriver>(InitDriver);

        public void CloseBrowser()
        {
            if (!driver.IsValueCreated) return;

            driver.Value.Quit();
            driver.Value.Dispose();
            driver = null;
        }

        private static IWebDriver InitDriver() => new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, GetChromeOptions());

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--no-sandbox");

            return options;
        }
    }
}
