using System;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ChromeScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using(ChromeDriver chromeDriver = new ChromeDriver())
            {
                chromeDriver.Url = "https://www.realestate.com.au/buy";
                chromeDriver.Navigate();
                var searchInputElement = chromeDriver.FindElementByCssSelector("input.rui-input.rui-location-box.rui-auto-complete-input");
                searchInputElement.SendKeys("Sunnybank, QLD 4109; ");
                var searchButtonElement = chromeDriver.FindElementByCssSelector("button.rui-search-button");
                searchButtonElement.Click();
                //var mapLink = chromeDriver.FindElementById("mapLink");
                //mapLink.Click();
                var advertisements = chromeDriver.FindElementsByCssSelector("div.listingInfo.rui-clearfix");
                List<string> address = new List<string>();
                foreach(var advertisement in advertisements)
                {
                   var addressElement = advertisement.FindElement(By.CssSelector("div.vcard"));
                    address.Add(addressElement.Text);
                }
                Debugger.Break();
            }
        }
    }
}
