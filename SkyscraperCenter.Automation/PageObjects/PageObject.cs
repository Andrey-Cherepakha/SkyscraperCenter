using OpenQA.Selenium;

namespace SkyscraperCenter.Automation.PageObjects
{
    public abstract class PageObject
    {
        protected readonly ISearchContext Search;

        protected PageObject(ISearchContext search) => Search = search;
    }
}
