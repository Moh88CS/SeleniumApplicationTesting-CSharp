using NUnitSeleniumTest.Pages.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApplication;

public class AmazonTest
{
    private const string SearchPhrase = "iphone";

    private static ChromeDriver? driver;

    [OneTimeSetUp]
    public static void SetUpWebDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new ChromeOptions();
        options.AddArgument("--disable-blink-features=AutomationControlled");
        options.AddArgument("user-agent=Mozilla/5.0...");
        driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void CheckAmazonSearch()
    {
        driver.Navigate().GoToUrl("https://amazon.co.uk/");

        var homePage = new HomePage(driver);
        var searchResultsPage = new SearchResultsPage(driver);

        homePage.SearchComponent.PerformSearch(SearchPhrase);

        var actualItems = searchResultsPage.SearchResultsItems;
        var expectedItems = actualItems
            .Where(item => item.Title.Contains(SearchPhrase) || item.HrefAttributeValue.Contains(SearchPhrase))
            .ToList();

        Assert.That(expectedItems, Is.EqualTo(actualItems));
    }

    [OneTimeTearDown]
    public static void TearDownDirver()
    {
        driver!.Quit();
        driver.Dispose();
    } 
}
