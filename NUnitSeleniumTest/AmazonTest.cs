using NUnitSeleniumTest.Pages.Impl;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApplication;

public class AmazonTest
{
    private static ChromeDriver driver;
    private const string SearchPhrase = "iphone";

    [OneTimeSetUp]
    public static void SetUpWebDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void CheckAmazonSearch()
    {
        driver.Navigate().GoToUrl("https://amazon.co.uk/");

        var homePage = new HomePage(driver);
        homePage.PerformSearch(SearchPhrase);

        var searchResultsPage = new SearchResultsPage(driver);
        var actualItems = searchResultsPage.GetSearchResultsItemsText();

        var expectedItems = actualItems
            .Where(item => item.Contains(SearchPhrase))
            .ToList();

        Assert.That(expectedItems, Is.EqualTo(actualItems));
    }

    [OneTimeTearDown]
    public static void TearDownWebDriver() => driver.Quit();
}
