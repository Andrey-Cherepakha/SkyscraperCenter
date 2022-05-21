using OpenQA.Selenium;
using System;

namespace SkyscraperCenter.Automation.Core
{
    public class Navigation
    {
        private readonly IWebDriver driver;

        public Navigation(IWebDriver driver) => this.driver = driver;

        public void OpenPage(Uri url) => driver.Navigate().GoToUrl(url);

        public void OpenTallestBuildingsPage()
        {
            // TODO move URL to configuration file
            OpenPage(new Uri("https://www.skyscrapercenter.com/buildings?list=tallest100-construction"));
        }
    }
}
