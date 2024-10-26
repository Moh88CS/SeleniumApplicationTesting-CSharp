using NUnitSeleniumTest.Components.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSeleniumTest.Pages.Impl;

public class HomePage(ChromeDriver driver) : WebPage(driver) // look here at way to call super constructor
{
    private static readonly By SearchComponentSelector = By.CssSelector("#twotabsearchtextbox");
    public SearchComponent SearchComponent => // lazy init
        new SearchComponent(FindElement(SearchComponentSelector));
}
