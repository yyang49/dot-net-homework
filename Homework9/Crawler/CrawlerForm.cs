using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public partial class CrawlerForm : Form
    {
        Crawler myCrawler = new Crawler();
        public CrawlerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textResult.Text = "";
            String startUrl = textStartUrl.Text;
            Crawler myCrawler = new Crawler { textResult = textResult };
            Uri uri;
            try
            {
                uri = new Uri(startUrl);
            }
            catch (Exception)
            {
                textResult.Text = "无效链接";
                return;
            }
            startUrl = uri.AbsoluteUri;
            myCrawler.urls.Add(startUrl, false);
            myCrawler.Crawl();
        }
    }
}
