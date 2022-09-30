using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using SpecFlowProjectGmail.Variables;


namespace SpecFlowProjectGmail.StepDefinitions
{
	[Binding]
	public class GmailStepDefinitions
	{
		private readonly UnitTestProject7.Steps.Steps steps = new UnitTestProject7.Steps.Steps();
		private readonly Credentials credentials = new Credentials();
		private readonly string agree = "I agree";
		private readonly string sentText = "Sent";
		

		[Given(@"Gmail application is installed on device")]
		public void GivenGmailApplicationIsInstalledOnDevice()
		{
			steps.InitApp();
		}

		[When(@"the user enters valid email and password")]
		public void WhenTheUserEntersValidEmailAndPassword()
		{
			steps.LoginGmail(credentials.email, credentials.password);
		}

		[Then(@"the user is logged in to account")]
		public void ThenTheUserIsLoggedInToAccount()
		{
			Assert.AreEqual(agree, steps.VerifyAcc());
			steps.LoginToAcc();
			steps.CloseApp();
		}

		[Given(@"the user is logged in Gmail")]
		public void GivenTheUserIsLoggedInGmail()
		{
			steps.OpenApp();
			//steps.PickAcc(); //uncomment to navigate in the list of accounts, change coordinates of "y" in Variables.Credentials.cs 
		}

		[When(@"the user composes and sends the email")]
		public void WhenTheUserComposesAndSendsTheEmail()
		{
			steps.Compose(credentials.addressee);
		}

		[Then(@"email is sent")]
		public void ThenEmailIsSent()
		{
			Assert.AreEqual(sentText, steps.VerifySent());
			steps.CloseApp();
		}
	}
}


