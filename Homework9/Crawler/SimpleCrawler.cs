using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    class Crawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        public TextBox textResult { get; set; }
        //static void Main(string[] args)
        //{
        //    Crawler myCrawler = new Crawler();
        //    string startUrl = "http://www.cnblogs.com/dstang2000/";
        //    if (args.Length >= 1) startUrl = args[0];
        //    myCrawler.urls.Add(startUrl, false);//加入初始页面
        //    new Thread(myCrawler.Crawl).Start();
        //}

        public void Crawl()
        {
            textResult.Text+="开始爬行了.... \r\n";
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                textResult.Text += "爬行" + current + "页面!\r\n";
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html, current);//解析,并加入新的链接
            }
            textResult.Text += "爬行结束\r\n";
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                textResult.Text += "成功\r\n";
                return html;
            }
            catch (Exception ex)
            {
                textResult.Text += ex.Message;
                textResult.Text += "\r\n";
                return "";
            }
        }

        private void Parse(string html, string current)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(html|aspx|jsp)[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;

                Uri uri = new Uri(current);
                if (strRef.Substring(0,2)== "//")
                {
                    strRef = uri.Scheme + ":" + strRef;
                }
                else if (strRef.Substring(0, 1) == "/")
                {
                    strRef = uri.Scheme + "://" + uri.Host + strRef;
                }
                else if (strRef.Substring(0, 2) == "./")
                {
                    strRef = uri.AbsoluteUri.Substring(0, uri.AbsoluteUri.LastIndexOf('/')) + strRef.Substring(1);
                }
                else if (strRef.Substring(0, 3) == "../")
                {
                    strRef = uri.AbsoluteUri.Substring(0, uri.AbsoluteUri.LastIndexOf('/', uri.AbsoluteUri.LastIndexOf('/')-1)) + strRef.Substring(2);
                }
                else if (strRef.Substring(0, 4) != "http")
                {
                    strRef = uri.AbsoluteUri.Substring(0, uri.AbsoluteUri.LastIndexOf('/')) + +'/' + strRef;
                }
                Uri newUri = new Uri(strRef);
                if (newUri.Host != uri.Host) continue;
                strRef = newUri.AbsoluteUri;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
