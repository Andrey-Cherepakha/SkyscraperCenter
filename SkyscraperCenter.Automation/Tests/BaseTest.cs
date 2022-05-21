using NUnit.Framework;
using SkyscraperCenter.Automation.Core;
using SkyscraperCenter.Automation.PageObjects;
using System;

namespace SkyscraperCenter.Automation.Tests
{
    public abstract class BaseTest
    {
        private readonly Selenium selenium = new Selenium();
        private Navigation navigation;
        protected Navigation Navigation => navigation ?? (navigation = new Navigation(selenium.Driver));        
        protected T GetPage<T>() where T : PageObject => Activator.CreateInstance(typeof(T), selenium.Driver) as T;

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            selenium.CloseBrowser();
        }
    }
}
