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
    public class UFGDemo
    {

		public static void Main(string[] args)
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

		public static void SetUp(Eyes eyes)
		{

			// Initialize eyes Configuration
			Configuration config = new Configuration();


			// You can get your api key from the Applitools dashboard. It's also recommended to set this to an environment variable.
			//TODO set your API key here!
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

		public static void UltraFastTest(IWebDriver webDriver, Eyes eyes)
		{

			try
			{

				// Navigate to the url we want to test
				webDriver.Url = "https://demo.applitools.com/";
				//	"http://google.com//";

				// Call Open on eyes to initialize a test session
				eyes.Open(webDriver, "Support C# App", "Ufg smoke test", new Size(800, 600));

				// check the login page with fluent api, see more info here
				// https://applitools.com/docs/topics/sdk/the-eyes-sdk-check-fluent-api.html
				eyes.Check(Target.Window().Fully().WithName("Basic page"));

				//webDriver.FindElement(By.Id("log-in")).Click();

				// Check the app page
				//eyes.Check(Target.Window().Fully().WithName("App page"));

				// Call Close on eyes to let the server know it should display the results
				eyes.CloseAsync();

			}
			catch (Exception e)
			{
				System.Console.WriteLine("exception in eyes check: " + e.Message);
				eyes.AbortAsync();
			}

		}

		private static void TearDown(IWebDriver webDriver, VisualGridRunner runner)
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
