﻿using OpenQA.Selenium;

namespace NUnitSeleniumTest.Components;

public class WebComponent
{
    private readonly IWebElement rootElement;

    protected WebComponent(IWebElement rootElement) => this.rootElement = rootElement;

    protected IWebElement FindElement(By selector) => rootElement.FindElement(selector);

    public string Text => rootElement.Text;

    public void SendKeys(string text) => rootElement.SendKeys(text);
}
