using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace UnitTestProject7.Pages
{
	class LoginPage
	{
		private readonly By accountSetup = By.Id("com.google.android.gm:id/account_setup_item");
		private readonly By emailField = By.ClassName("android.widget.EditText");
		private readonly By nextButton = By.XPath("//android.widget.Button[@text = 'Next']");
		private readonly By passField = By.ClassName("android.widget.EditText");
		private readonly By agreeButton = By.XPath("//android.widget.Button[@text = 'I agree']");			


		private readonly AppiumDriver<AndroidElement> driver;		
		public LoginPage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;			
			PageFactory.InitElements(driver, this);			
		}		
		public void Login(string email, string password)
		{			
			driver.FindElement(accountSetup).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
			driver.FindElement(emailField).SendKeys(email);
			driver.FindElement(nextButton).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
			driver.FindElement(passField).SendKeys(password);
			driver.FindElement(nextButton).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);			
		}

		public string VerifyAccount()
		{
			var elementBut = driver.FindElement(agreeButton);
			string typevalue = elementBut.Text;
			return typevalue;			
		}

		public void LoginToAccount()
		{
			driver.FindElement(agreeButton).Click();
		}
		
	}
}
