using OpenQA.Selenium;

namespace SkyscraperCenter.Automation.PageObjects
{
    public abstract class PageObject
    {
        protected readonly ISearchContext Context;

        protected PageObject(ISearchContext context) => Context = context;
    }
}
