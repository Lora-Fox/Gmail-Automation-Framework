using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using UnitTestProject7.Variables;

namespace UnitTestProject7
{
	[TestClass]
	public class UnitTest1Login
	{

		private static readonly CredentialsVariables credentials = new CredentialsVariables();
		private readonly Steps.Steps steps = new Steps.Steps();				
		private readonly string agree = "I agree";

		[TestMethod]
		public void Setup()
		{
			steps.InitApp();
			steps.LoginGmail(credentials.email, credentials.password);			
			Assert.AreEqual(agree, steps.VerifyAcc());
			steps.LoginToAcc();
			steps.CloseApp();
		}						
	}
}

