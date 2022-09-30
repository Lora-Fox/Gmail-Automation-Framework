using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;

namespace UnitTestProject7.Driver
{
	class DriverInstance
	{
		private static AppiumDriver<AndroidElement> driver;
		private static readonly DesiredCapabilities caps = new DesiredCapabilities();
		private static readonly string remoteAdress = "http://localhost:4723/wd/hub/";


		private DriverInstance() { }


		public static AppiumDriver<AndroidElement> GetDriverSetup()
		{
			if (driver == null)
			{
				caps.SetCapability("deviceName", "Pixel 3a");
				caps.SetCapability("platformName", "Android");
				caps.SetCapability("platformVersion", "12");
				caps.SetCapability("automationName", "UiAutomator2");
				caps.SetCapability("udid", "enter_your_udid");
				caps.SetCapability("appPackage", "com.google.android.gm");
				caps.SetCapability("appActivity", "com.google.android.gm.setup.AccountSetupFinalGmail");
				caps.SetCapability("noReset", true);
				driver = new AndroidDriver<AndroidElement>(new Uri(remoteAdress), caps);
			}
			return driver;						
		}
		public static AppiumDriver<AndroidElement> GetDriverConversation()
		{
			if (driver == null)
			{
				caps.SetCapability("deviceName", "Pixel 3a");
				caps.SetCapability("platformName", "Android");
				caps.SetCapability("platformVersion", "12");
				caps.SetCapability("automationName", "UiAutomator2");
				caps.SetCapability("udid", "enter_your_udid");
				caps.SetCapability("appPackage", "com.google.android.gm");
				caps.SetCapability("appActivity", "com.google.android.gm.ConversationListActivityGmail");
				caps.SetCapability("noReset", true);
				driver = new AndroidDriver<AndroidElement>(new Uri(remoteAdress), caps);
			}
			return driver;
		}

		public static void CloseApp()
		{
			if (driver != null)
			{
				driver.Quit();
			}
		}

	}
}
