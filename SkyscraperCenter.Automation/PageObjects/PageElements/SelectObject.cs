using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SkyscraperCenter.Automation.PageObjects.PageElements
{
    public abstract class SelectObject : PageObject
    {
        public SelectObject(ISearchContext search) : base(search) { }
        protected SelectElement Select => new SelectElement(Search as IWebElement);
    }
}
