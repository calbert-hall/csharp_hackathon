# Applitools Hackathon: Java

### READ FIRST: Hackathon Structure 
1. At least **one week before the hackathon**, complete the pre-requisites as well as run the first example to ensure that everything has been installed correctly. 
2. On the day of the hackathon, follow the instructions in the hackathon section. 
3. If you finish the hackathon exercises with extra time available (or want to experiment more after the event), 
   see the "Additional Exercises" below. 

# Pre-requisites

1. Visual Studio installed on your machine. Workload ".NET desktop development" should be installed in Visual Studio too (if      no - add it with Visual Studio Installer)
    * [Install it from here](https://visualstudio.microsoft.com/downloads/)
 2. Chrome browser is installed on your machine.
 
    * [Install Chrome browser](https://support.google.com/chrome/answer/95346?co=GENIE.Platform%3DDesktop&hl=en&oco=0)
 3. Chrome Webdriver is on your machine and is in the PATH. Here are some resources from the internet that'll help you.
    * [Download Chrome Webdriver](https://chromedriver.chromium.org/downloads)
    * https://splinter.readthedocs.io/en/0.1/setup-chrome.html
    * https://stackoverflow.com/questions/38081021/using-selenium-on-mac-chrome
    * https://www.youtube.com/watch?time_continue=182&v=dz59GsdvUF8
 4. Git is installed on your machine.
 
    * [Install git](https://www.atlassian.com/git/tutorials/install-git)
 5. Restart your machine to implement updated  environment variables (need for some OS).

# Steps to run this example
 
 1. Git clone this repo
 
     * `git clone https://github.com/applitools/tutorial-selenium-csharp-ultrafastgrid.git`
 
 2. Get your API key to set it in code (or in the APPLITOOLS_API_KEY environment variable).
 
     * You can get your API key by logging into Applitools > Person Icon > My API Key.
 
 4. Navigate to folder `tutorial-selenium-csharp-ultrafastgrid` and double click the `ApplitoolsTutorial.sln`. This will open the  project in Visual Studio
 
 5. In Visual Studio open file UFGDemo.cs and change the `APPLITOOLS_API_KEY` with your own in code.
    Set your ApiKey in string 'config.SetApiKey("...") ' (or comment the string and set APPLITOOLS_API_KEY environment variable)
 
 6. In Visual Studio open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and enter command      `dotnet restore` in the console. Command execution can take several minutes.
 
 6. Build the solution (Build > Build Solution). It can take several minutes.
 
 7. Run project (Debug > Start Without Debugging). Execution of project can take several minutes.
 
 8. If needed, in case of some problems - update package Eyes.Selenium by NuGet Package Manager -  Tools > NuGet Package Manager   > Manage Nuget Packages for Solution, tab Updates. Select package for update (Eyes.Selenium), select needed version in right      panel and tap Install
 


# Hackathon Exercise!

* In this exercise, you'll be a Test Engineer looking to run tests on an e-commerce site, "Applifashion". 
  You'll be using Applitools to find and report bugs and handle dynamic content using Applitools' visual AI.
  You'll be working in the `Hackathon_Activity` file in `src/test/java/Hackathon`. An example solution is available in the `Hackathon_Solution` file, but don't look unless you're stuck! If you want to see view the expected results, you can run `mvn -D test=Hackathon_Solution test
`.

1. Open up the `Hackathon_Activity` java file. Put your name (or team name) as the Batch name, and be sure to set your API key as you did in the first example. You can run this using `mvn -D test=Hackathon_Activity -D devUrl=applifashionv1 test`.


2. We'll start with a test on [Applifashion V1](https://demo.applitools.com/gridHackathonV1.html). Create an Applitools test that navigates to the main page and takes a full page screenshot. See the first example on how to do this.

   
3. Next, we'll use Selenium webdriver to click the "black" filter button, and then click the filter button. The needed CSS selectors are provided for your use. After filtering, take another screenshot with Applitools. 
   Both of these eyes.check calls should be within the same test.
   

4. Now, you'll use the Selenium webdriver to click the "Appli Air x Night" shoes and take another full page Applitools check. You should have a test with 3 checks. 
 

5. Set the `dynamicContent` boolean to `true`. Re-run your test, and notice that your initial test will fail due to dynamic content. 
Draw a layout region over the area, or set the match level to "Layout" from within the SDK. Once you see that your test now passes, you can delete the region and turn off `dynamicContent`. 
   
 
6. Next, run the same test on the [Applifashion dev site](https://demo.applitools.com/tlcHackathonDev.html). To do this, change the envUrl variable. Note that the main page doesn't have a shoe in the main area. 
   See that the black shoes filtering has a functional bug! Also notice how the "Appli Air x night" has a visual bug. 
   Place a bug region on each of the areas and accept the differences. Snooze failures on the bug regions for 2 weeks.
   

7. Development has made the changes to the bug region, which are on [Applifashion V2](https://demo.applitools.com/gridHackathonV2.html). 
Run your test suite on Applifashion V2  (by changing envUrl) and accept the now-fixed change and delete the bug region. 
   You'll see several unresolved tests; accept them and add or remove regions as needed!
  
 
8. You now want to test your site on multiple browsers and viewport sizes, including mobile viewports. Set the `ulrafast_test_cloud` boolean to true, and find the browser configurations in the setup method. 
Add `iPhone_X` in portrait mode, and FireFox 1200 x 800 as browsers for the Ultrafast test cloud. Run the test to see your test 
   on these configurations!

### Additional Challenges
* Add another check that clicks the "Applifashion" home link in the upper left. What happens on v1 vs the dev environment? 


* Find a selector and apply a [coded region](https://help.applitools.com/hc/en-us/articles/360007188211-Coded-Ignore-Regions) to it. 


* Try testing a different site of your choice. Look for ways to handle dynamic content and get stable tests.  

## Resources
- [Applitools SDK Documentation](https://applitools.com/docs/api/eyes-sdk/index-gen/classindex-selenium-java.html)
- [Applitools Best Practices](https://applitools.com/docs/topics/general-concepts/visual-test-best-practices.html)