using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;

namespace UnitTestProject7.Steps
{
	public class Steps
	{
		AppiumDriver<AndroidElement> driver;						
		
		public void InitApp()
		{
			driver = Driver.DriverInstance.GetDriverSetup();
		}
		public void OpenApp()
		{			
			driver = Driver.DriverInstance.GetDriverConversation();
		}
		public void CloseApp()
		{
			driver.Quit();
			driver = null;
		}

		public void LoginGmail(string email, string password)
		{
			Pages.LoginPage login = new Pages.LoginPage(driver);
			login.Login(email, password);
		}
		public string VerifyAcc()
		{
			Pages.LoginPage login = new Pages.LoginPage(driver);
			return login.VerifyAccount();

		}
		public void LoginToAcc()
		{
			Pages.LoginPage loginBut = new Pages.LoginPage(driver);
			loginBut.LoginToAccount();

		}
		public void PickAcc()
		{
			Pages.ComposeMail acc = new Pages.ComposeMail(driver);
			acc.PickAccount();
		}
		public void Compose(string addressee)
		{
			Pages.ComposeMail mail = new Pages.ComposeMail(driver);
			mail.Compose(addressee);
		}
		public string VerifySent()
		{
			Pages.ComposeMail sent = new Pages.ComposeMail(driver);
			return sent.VerifySent();
		}
	}
}
