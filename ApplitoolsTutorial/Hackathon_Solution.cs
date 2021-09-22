using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using Configuration = Applitools.Selenium.Configuration;
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;

namespace ApplitoolsTutorial
{
	public class HackathonSolution
    {
		public const String ApplifashionV1 = "https://demo.applitools.com/gridHackathonV1.html";
		public const String ApplifashionDev = "https://demo.applitools.com/tlcHackathonDev.html";
		public const String ApplifashionV2 = "https://demo.applitools.com/gridHackathonV2.html";

		//TODO set this to change the env
		public const String envUrl = ApplifashionV1;
		// TODO set this flag to true to simulate dynamic content
		public const Boolean dynamicContent = false;
		// TODO set this flag to enable the Ultrafast Test Cloud!
		public const Boolean ultrafast_Test_Cloud = true;
		
		/**
		 * Useful Selectors for navigating in the exercise.
		 */

		public By blackColorFilter = By.Id("SPAN__checkmark__107");
		public By filterButton = By.Id("filterBtn");
		public By blackShoesImage = By.XPath("/html/body/div[1]/main/div/div/div/div[4]/div[1]/div/figure/a/img");

		public void simulateDynamicContent(ref IWebDriver driver)
		{
			IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

			String jsInjection1 = "document.querySelectorAll('h3').forEach(function(noFade) { noFade.innerHTML = Math.random().toString(36);})";

			executor.ExecuteScript(jsInjection1);
		}

		
		public void Main(string[] args)
		{
			// Create a new chrome web driver
			IWebDriver webDriver = new ChromeDriver();
			//webDriver.Manage.args("--allow-file-access-from-file");
			// Create a runner with concurrency of 1
			VisualGridRunner runner = new VisualGridRunner(new RunnerOptions().TestConcurrency(1));

			// Create Eyes object with the runner, meaning it'll be a Visual Grid eyes.
			Eyes eyes = new Eyes(runner);

			SetUp(eyes);

			try
			{
				// ⭐️ Note to see visual bugs, run the test using the above URL for the 1st run.
				// but then change the above URL to https://demo.applitools.com/index_v2.html
				// (for the 2nd run)
				UltraFastTest(webDriver, eyes);

			}
			finally
			{
				TearDown(webDriver, runner);
			}

		}

		public void SetUp(Eyes eyes)
		{

			// Initialize eyes Configuration
			Configuration config = new Configuration();

			// You can get your api key from the Applitools dashboard
			config.SetApiKey("VJMt4z4djBoqW40fclJgEpLGuwGppgZ98m5wtUuWhru0110");

			// create a new batch info instance and set it to the configuration
			config.SetBatch(new BatchInfo("Support C# Batch"));

			// Add browsers with different viewports
			config.AddBrowser(800, 600, BrowserType.CHROME);
			config.AddBrowser(700, 500, BrowserType.FIREFOX);
			//config.AddBrowser(1600, 1200, BrowserType.IE_11);
			//config.AddBrowser(1024, 768, BrowserType.EDGE_CHROMIUM);
			//config.AddBrowser(800, 600, BrowserType.SAFARI);

			// Add mobile emulation devices in Portrait mode
			//config.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);
			//config.AddDeviceEmulation(DeviceName.Pixel_2, ScreenOrientation.Portrait);

			eyes.SetLogHandler(new FileLogHandler("/Users/casey/Desktop/Selenium_C#/tutorial-selenium-csharp-ultrafastgrid/eyes.log", true, true));

			// Set the configuration object to eyes
			eyes.SetConfiguration(config);

		}

		public void UltraFastTest(IWebDriver driver, Eyes eyes)
		{

			try
			{

				eyes.Open(driver, "Hackathon", "SOLUTION: Applifashion Filter Workflow Test", new Size(1200, 800));

				String environmentUrl;
	

				switch (envUrl)
				{
					case "applifashionv1":
						environmentUrl = ApplifashionV1;
						break;
					case "applifashionv2":
						environmentUrl = ApplifashionV2;
						break;
					case "applifashiondev":
						environmentUrl = ApplifashionDev;
						break;
					default:
						environmentUrl = ApplifashionV1;
						break;
	
				}

				// Navigate the browser to the demo app.
				driver.Url = environmentUrl;

				if (dynamicContent)
				{
					simulateDynamicContent(ref driver);
				}
				eyes.Check(Target.Window().Fully().WithName("Main Page"));

				// Filter by black
				driver.FindElement(blackColorFilter).Click();
				driver.FindElement(filterButton).Click();

				eyes.Check(Target.Window().Fully().WithName("Black Shoes Filter"));

				driver.FindElement(blackShoesImage).Click();

				eyes.Check(Target.Window().Fully().WithName("Air x Night"));

				// End the test.
				eyes.CloseAsync();

			}
			catch (Exception e)
			{
				System.Console.WriteLine("exception in eyes check: " + e.Message);
				eyes.AbortAsync();
			}

		}

		private void TearDown(IWebDriver webDriver, VisualGridRunner runner)
		{
			// Close the browser
			webDriver.Quit();

			// we pass false to this method to suppress the exception that is thrown if we
			// find visual differences
			TestResultsSummary allTestResults = runner.GetAllTestResults(false);
			System.Console.WriteLine(allTestResults);
		}

	}
}
