using NUnitSeleniumTest.Pages.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApplication;

public class AmazonTest
{
    private const string SearchPhrase = "iphone";

    private static ChromeDriver driver;

    [OneTimeSetUp]
    public static void SetUpWebDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void CheckAmazonSearch()
    {
        driver.Navigate().GoToUrl("https://amazon.co.uk");

        var homePage = new HomePage(driver);
        var searchResultsPage = new SearchResultsPage(driver);

        homePage.SearchComponent.PerformSearch(SearchPhrase);

        var actualItems = searchResultsPage.GetSearchResultsItemsText();
        var expectedItems = actualItems
            .Where(item => item.ToLower().Contains(SearchPhrase))
            .ToList(); ;

        Assert.That(expectedItems, Is.EqualTo(actualItems));
    }

    [OneTimeTearDown]
    public static void TearDownDriver() => driver.Quit();
}
