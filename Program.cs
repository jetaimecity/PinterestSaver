using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace PinterestSaver
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your pinterest board link: ");
            var boardURL = Console.ReadLine();
            Console.WriteLine("Please enter doc path to save images: (eg. C:\'Users\'Michelle\'Documents\'PinterestTest)");
            var docPath = Console.ReadLine();

            var page = new PinterestPage();
            page.Navigate("http://www.pinterest.com");

            Thread.Sleep(10);
            
            
            logInBtn.Click();
            Thread.Sleep(10);

            logInBtn = driver.FindElement(By.XPath("//button/div[contains(text(),'Log in')]"));
            logInBtn.Click();
            Thread.Sleep(10000);

            driver.Navigate().GoToUrl(boardURL);
            Thread.Sleep(10000);

            IWebElement cntr = driver.FindElement(By.ClassName("belowBoardNameContainer"));
            var spanEl= cntr.FindElement(By.CssSelector("div>span.bold")).Text;
            int loop;
            Int32.TryParse(spanEl, out loop);
            var result = Math.Ceiling((double)loop/(double)25);
            
            
            IWebElement body = driver.FindElement(By.TagName("body"));
            for (int i = 1; i <= result; i++)
            {
                body.SendKeys(Keys.Control + Keys.End);
                Thread.Sleep(1000);
            }
            
            var pinLinks = driver.FindElements(By.CssSelector("a.pinImageWrapper"));

            var imageList = new List<string>();

            foreach (IWebElement l in pinLinks)
            {
                var imgEl = l.FindElement(By.TagName("img"));
                imageList.Add(imgEl.GetAttribute("src"));
            }

            var imageArr = imageList.ToArray();
            var cnt = 0;
            var saver = new Saver();

            foreach (string url in imageList)
            {
                saver.SaveImage(url, string.Format(@"{1}\image00{0}.png", cnt, docPath), ImageFormat.Png);
                cnt++;
            }

            driver.Quit();
        }
    }
}
