using OpenQA.Selenium;
using SkyscraperCenter.Automation.PageObjects.PageElements;

namespace SkyscraperCenter.Automation.PageObjects.TallestBuildings
{
    public class TallestBuildingsList : SelectObject
    {
        public TallestBuildingsList(ISearchContext search) : base(search) { }

        public void Show100TallestCompletedBuildingsInTheWorld()
        {
            Select.SelectByValue("tallest100-completed");
        }
    }
}
