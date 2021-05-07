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
        public delegate void MyInvoke(string str);
        public CrawlerForm()
        {
            InitializeComponent();
        }
        public void CrawlerShowResult(string result)
        {
            if (this.textResult.InvokeRequired)
            {
                Action<string> action = this.textResultAddText;
                this.Invoke(action, new object[] { result });
            }
            else
            {
                textResultAddText(result);
            }
        }
        private void textResultAddText(string text)
        {
            textResult.Text += text;
            textResult.Text += "\r\n";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textResult.Text = "";
            String startUrl = textStartUrl.Text;
            Crawler myCrawler = new Crawler { textResult = textResult };
            myCrawler.showResult += CrawlerShowResult;
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
            myCrawler.urls.TryAdd(startUrl, false);
            myCrawler.Crawl();
        }
    }
}
