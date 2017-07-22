using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_s_tournament_parser
{
    public class WebSurf
    {
        IWebDriver driver;
        public enum TourType
        {
            csgo, dota2
        }
        public WebSurf()
        {
            driver = new ChromeDriver();
        }
        void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void Navigate(TourType t) {
            switch(t)
            {
                case TourType.csgo:
                    Navigate("http://www.gosugamers.net/counterstrike/gosubet"); break;
                case TourType.dota2:
                    break;
            }
        }
        public IWebElement[] Loadto()
        {
            IWebElement[]iw = driver.FindElements(By.ClassName("box")).ToArray();
            IWebElement[] iw2 = iw[2].FindElements(By.ClassName("spoiler-showall-target")).ToArray();
            Actions actions = new Actions(driver);
            for(int i = 0; i < iw2.Count(); i++)
            {
                actions.MoveToElement(iw2[i]);
                actions.Perform();
                iw2[i].Click();
            }
            return iw;
        }
        public List<TournamentInfo> GetTournamentInfo()
        {
            IWebElement[] iw = driver.FindElements(By.ClassName("box")).ToArray();
            IWebElement[] iw2 = iw[2].FindElements(By.ClassName("spoiler-showall-target")).ToArray();
            Actions actions = new Actions(driver);
            for(int j = 0; j < iw2.Length; j++)
            {
                actions.MoveToElement(iw2[j]);
                actions.Perform();
                iw2[j].Click();
            }

            List<TournamentInfo> tourInfo = new List<TournamentInfo>();
            for(int i = 0; i < iw.Length; i++)
            {
                if (i > 2) break;
                IWebElement[] iw3 = iw[i].FindElements(By.XPath(".//tr/td[1]/a")).ToArray();
                for (int j = 0; j < iw3.Length; j++)
                {
                    string score = "0 - 0";
                    if (i == (int)TournamentStatus.Result && j<iw2.Length)
                    {
                        IWebElement[] iwScore = iw3[j].FindElements(By.XPath(".//../../td[2]/span/span[2]/span")).ToArray();
                        score = iwScore[0].Text + "-" + iwScore[1].Text;
                    }
                    tourInfo.Add(new TournamentInfo {
                        url = iw3[j].GetAttribute("href"),
                        status = (TournamentStatus)i,
                        score = score
                });
                }
            }
            return tourInfo;
        }
        public void Quit()
        {
            driver.Quit();
        }
    }
}
