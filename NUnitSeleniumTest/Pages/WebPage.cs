using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NUnitSeleniumTest.Pages;

public class WebPage
{
    private readonly ChromeDriver driver;
    private readonly WebDriverWait wait;

    public WebPage(ChromeDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
    }

    protected IWebElement FindElement(By selector) => driver.FindElement(selector); // it causes warning to have children access parent driver

    protected IList<IWebElement> FindElements (By selector) => driver.FindElements(selector);

    protected void WaitForElementVisibility(By selector) // protected vs protected private
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        wait.Until(d => driver.FindElement(selector));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
}
