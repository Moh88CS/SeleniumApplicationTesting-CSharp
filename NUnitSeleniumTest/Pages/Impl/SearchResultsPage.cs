using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSeleniumTest.Pages.Impl;

public class SearchResultsPage(ChromeDriver driver) : WebPage(driver)
{
    private static readonly By SearchResultsItemsCss = By.CssSelector("[data-component-type='s-search-results'] h2 .a-link-normal");
    IList<IWebElement> SearchResultsItems => FindElements(SearchResultsItemsCss);

    public IList<string> GetSearchResultsItemsText()
    {
        WaitForElementVisibility(SearchResultsItemsCss);
        return SearchResultsItems
            .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
            .ToList();
    }

}
