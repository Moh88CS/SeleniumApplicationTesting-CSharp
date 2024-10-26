using NUnitSeleniumTest.Components.Impl;
using NUnitSeleniumTest.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSeleniumTest.Pages.Impl;

public class SearchResultsPage(ChromeDriver driver) : WebPage(driver)
{
    private static readonly By SearchResultsItemsCss = By.CssSelector("[data-component-type='s-search-result']");

    public IList<SearchResultItem> SearchResultsItems => SearchResultItemComponents()
        .Select(component => component.ConvertToSearchResultItem())
        .ToList();

    private IList<SearchResultItemComponent> SearchResultItemComponents()
    {
        WaitForElementVisibility(SearchResultsItemsCss);
        return FindElements(SearchResultsItemsCss)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();
    }
}
