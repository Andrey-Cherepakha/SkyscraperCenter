using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SkyscraperCenter.Automation.PageObjects.PageElements
{
    public class TableObject : PageObject
    {
        public TableObject(ISearchContext search) : base(search) {}

        public IList<string> GetColumnValues(string columnName)
        {
            int i = GetColumnIndex(columnName);
            return GetColumnValues(i);
        }

        // To get a value at specific position in a column we can call GetColumnValues method
        // and then get an item from the list at the specific position.
        // The problem is it can be slow since we will call .Text property for each element in the list.
        // But we need only one value indeed.
        // The following method is a slight optimization. We will call .Text property only once
        public string GetColumnValue(string columnName, int index)
        {
            int i = GetColumnIndex(columnName);
            return GetElementsInTheColumn(i).ElementAt(index).Text;
        }

        public int RowCount => Search.FindElements(By.XPath(".//tbody/tr[@role='row']")).Count;

        private int GetColumnIndex(string columnName)
        {  
            return columnNames.Select(i => i.Text.ToLowerInvariant()).ToList().IndexOf(columnName.ToLowerInvariant()) + 1;
        }

        private IList<string> GetColumnValues(int index)
        {
            return GetElementsInTheColumn(index).Select(i => i.Text).ToList();
        }

        private IReadOnlyCollection<IWebElement> GetElementsInTheColumn(int index)
        {
            return Search.FindElements(By.XPath($".//tbody/tr/td[{index}]"));
        }

        private IReadOnlyCollection<IWebElement> columnNames => Search.FindElements(By.XPath(".//thead//div[@class='flex']/p"));
    }
}
