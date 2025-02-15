using NUnitSeleniumTest.Entities;
using OpenQA.Selenium;

namespace NUnitSeleniumTest.Components.Impl;

public class SearchResultItemComponent(IWebElement rootElement) : WebComponent(rootElement)
{
    private static readonly By TitleSelector = By.CssSelector(".a-link-normal.s-line-clamp-2");


    public SearchResultItem ConvertToSearchResultItem() =>
        new SearchResultItem(
            RetrieveTitleText(),
            RetrieveTitleHref()
        );

    private string RetrieveTitleText() =>
        FindElement(TitleSelector).Text;

    private string RetrieveTitleHref() =>
        FindElement(TitleSelector).GetAttribute("href");
}
