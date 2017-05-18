using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

public class PinterestPage
{
    private IWebDriver driver = null;

    [FindsBy(How = How.CssSelector, Using = "button:contains('Log in')")]
    private IWebElement logInBtn = null;

    [FindsBy(How = How.CssSelector, Using = "input:[placeholder='Email']")]
    private IWebElement emailField = null;

    [FindsBy(How = How.CssSelector, Using = "input:[placeholder='Password']")]
    private IWebElement passwordField = null;

    public PinterestPage()
    {
        var options = new ChromeOptions();

        options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        this.driver = new ChromeDriver(options);
    }

    public void Navigate(string url)
    {
        this.driver.Url = "http://www.pinterest.com";
    }

    public void LogIn(string email, string password)
    {
        emailField.SendKeys(email);
        passwordField.SendKeys(password);
        this.logInBtn.Click();
    }

    
}
