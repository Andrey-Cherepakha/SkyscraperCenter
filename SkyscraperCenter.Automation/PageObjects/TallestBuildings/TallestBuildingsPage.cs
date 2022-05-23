using OpenQA.Selenium;
using SkyscraperCenter.Automation.PageObjects.PageElements;

namespace SkyscraperCenter.Automation.PageObjects.TallestBuildings
{
    public class TallestBuildingsPage : PageObject
    {
        public TallestBuildingsPage(ISearchContext search) : base(search) {}

        public TallestBuildingsList TallestBuildingsList => new TallestBuildingsList(TallestBuildingsListElement);
        public TableObject BuildingsTable => new TableObject(BuildingsTableElement);

        private IWebElement TallestBuildingsListElement => Context.FindElement(By.XPath("//select[@name='list']"));
        private IWebElement BuildingsTableElement => Context.FindElement(By.XPath("//table[@id='buildingsTable']"));
    }
}
