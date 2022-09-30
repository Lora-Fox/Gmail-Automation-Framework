using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using UnitTestProject7.Variables;


namespace UnitTestProject7
{
	[TestClass]
	public class UnitTest2ComposeMail
	{
		private readonly Steps.Steps steps = new Steps.Steps();
		private static readonly CredentialsVariables credentials = new CredentialsVariables();		
		private readonly string sentText = "Sent";

		[TestMethod]
		public void TestCompose()
		{					
			steps.OpenApp();
			//steps.PickAcc(); //uncomment to navigate in the list of accounts, change coordinates of "y" in Variables.AccountCoordinates.cs 
			steps.Compose(credentials.addressee);
			Assert.AreEqual(sentText, steps.VerifySent());
			steps.CloseApp();			
		}
	}
}
