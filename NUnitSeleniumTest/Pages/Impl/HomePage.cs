using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSeleniumTest.Pages.Impl;

public class HomePage(ChromeDriver driver) : WebPage(driver) // look here at way to call super constructor
{
    private IWebElement SearchInput => FindElement(By.CssSelector("#twotabsearchtextbox")); // look into =>,, accessed only after constructor (lazy init)

    public void PerformSearch(string searchPhrase)
    {
        SearchInput.SendKeys(searchPhrase);
        SearchInput.SendKeys(Keys.Enter);
    }
}
