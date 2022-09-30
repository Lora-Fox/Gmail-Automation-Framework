using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UnitTestProject7.Variables;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;

namespace UnitTestProject7.Pages
{
	class ComposeMail
	{
		private readonly By accList = By.XPath("//android.widget.ImageView[@resource-id= 'com.google.android.gm:id/og_apd_ring_view']");
		private readonly By composeButton = By.XPath("//android.widget.Button[@text = 'Compose']");		
		private readonly By toField = By.ClassName("android.widget.EditText");
		private readonly By subjectField = By.XPath("//android.widget.EditText[@text = 'Subject']");
		private readonly By composeEmail = By.Id("com.google.android.gm:id/compose");
		private readonly By composeEmail1 = By.XPath("//android.webkit.WebView[@index='0']/android.widget.EditText");
		private readonly By sendButton = By.Id("com.google.android.gm:id/send");
		private readonly By pickAddressee = By.Id("com.google.android.gm:id/peoplekit_listview_flattened_row");
		private readonly By sentPopup = By.XPath("//android.widget.TextView[@text = 'Sent']");
		

		private readonly AppiumDriver<AndroidElement> driver;
		
		public ComposeMail(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		private static readonly MailVariables mailUtils = new MailVariables();
		private static readonly AccountCoordinates coordinates = new AccountCoordinates();

		public void PickAccount()
		{
			driver.FindElement(accList).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
			ITouchAction touch = new TouchAction(driver);
			touch.Press(coordinates.x, coordinates.y).Tap(coordinates.x, coordinates.y).Perform();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
		}
		public void Compose(string addressee)
		{
			
			driver.FindElement(composeButton).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);						
			driver.FindElement(toField).SendKeys(addressee);
			driver.FindElement(pickAddressee).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
			driver.FindElement(subjectField).SendKeys(mailUtils.subjectText);
			driver.FindElement(composeEmail).Click();
			driver.FindElement(composeEmail);
			driver.FindElement(composeEmail1).SendKeys(mailUtils.emailText);
			driver.FindElement(sendButton).Click();
		}

		public string VerifySent()
		{
			var elementPopup = driver.FindElement(sentPopup);
			string typevalue = elementPopup.Text;
			return typevalue;
		}
	}
}
