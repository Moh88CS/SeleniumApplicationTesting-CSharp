using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApplication;

public class AmazonTest
{
    [Test]
    public void CheckAmazonSearch() 
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://amazon.co.uk/");

        string searchPhrase = "iphone";

        IWebElement searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
        searchInput.Click();
        searchInput.SendKeys(searchPhrase);
        searchInput.SendKeys(Keys.Enter);

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        var actualItems = driver.FindElements(By.CssSelector("[data-component-type='s-search-results'] h2 .a-link-normal"))
            .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
            .ToList();

        var expectedItems = actualItems
            .Where(item => item.Contains(searchPhrase))
            .ToList();

        Assert.That(expectedItems, Is.EqualTo(actualItems));

        driver.Quit();
    }
}
