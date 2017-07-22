using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_s_tournament_parser
{
    public partial class Form1 : Form
    {
        WebSurf webSurf;
        public Form1()
        {
            InitializeComponent();
            webSurf = new WebSurf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webSurf.Navigate(WebSurf.TourType.csgo);
            List<TournamentInfo> tourInfo = webSurf.GetTournamentInfo();
            //IWebElement []iw = webSurf.Loadto();
            richTextBox1.Text = "";
            for (int i = 0; i< tourInfo.Count(); i++)
            {
                /*string []rows = iw[i].Text.Split('\n');
                for(int j = 0; j < rows.Length; j++)
                {
                    int index = rows[j].IndexOf("> = <");
                    if (index>0)
                    {
                        richTextBox1.Text += "\n" + rows[j].Substring(0, index);
                    }
                }*/
                richTextBox1.Text += tourInfo[i].status + " " + tourInfo[i].score + " " + tourInfo[i].url;
                richTextBox1.Text += "\n";
                //if (i == 2) break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            webSurf.Quit();
        }
    }
}
