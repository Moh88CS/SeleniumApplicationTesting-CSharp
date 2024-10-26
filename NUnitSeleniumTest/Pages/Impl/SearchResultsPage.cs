using NUnitSeleniumTest.Components.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSeleniumTest.Pages.Impl;

public class SearchResultsPage(ChromeDriver driver) : WebPage(driver)
{
    private static readonly By SearchResultsItemsCss =
        By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal");

    private IList<SearchResultItemComponent> SearchResultsItems()
    {
        WaitForElementVisibility(SearchResultsItemsCss);
        return FindElements(SearchResultsItemsCss)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();
    }

    public IList<string> GetSearchResultsItemsText() => SearchResultsItems()
        .Select(item => item.Text)
        .ToList();
}
