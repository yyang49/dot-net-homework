using System;
using System.Collections;
using System.Collections.Concurrent;
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
        public ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();//可由多个线程同时访问
        private int count = 0;
        private Task[] tasks = new Task[10];
        public TextBox textResult { get; set; }
        public delegate void ShowResultDelegate(string result);
        public event ShowResultDelegate showResult;
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
            showResult("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (count >= 10) break;
                if (current == null)
                {
                    bool taskCompeted = true;
                    for (int i = 0; i < count; i++)
                    {
                        if (!tasks[i].IsCompleted) taskCompeted = false;
                    }
                    if (taskCompeted) break;
                }
                else
                {
                    showResult("爬行" + current + "页面!");
                    urls[current] = true;
                    count++;
                    Task task = Task.Run(() =>
                    {
                        string html = DownLoad(current); // 下载
                        Parse(html, current);//解析,并加入新的链接
                    });
                    tasks[count - 1] = task;
                }
            }
            if (count > 10)
            {
                Task.WaitAll(tasks);
            }
            showResult("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = DateTime.Now.ToFileTimeUtc().ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                showResult(url+ex.Message);
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
                urls.TryAdd(strRef, false);
            }
        }
    }
}
