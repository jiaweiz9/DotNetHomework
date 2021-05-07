using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
public class Crawler
{
	public delegate void MessageWrite();
	public event MessageWrite WriteMessageToLabel;

	private Hashtable urls = new Hashtable();
	private int count = 0;
	public string text = "";

	public void StartUrl(string startUrl)
	{
		urls.Add(startUrl, false);
	}
	public Crawler()
	{
	}
	public void Crawl()
	{
		//Console.WriteLine("开始爬行了……");
		text += "开始爬行了……\n";
		WriteMessageToLabel();

		while (true) {
			string current = null;
			foreach (string url in urls.Keys)
			{
				if ((bool)urls[url]) continue;
				current = url;
			}
			if (current == null || count > 10) break;
			//Console.WriteLine("爬行" + current + "页面！");
			text = text + "爬行" + current + "页面！\n";
			WriteMessageToLabel();

			string html = Download(current);

			urls[current] = true;
			count++;

			Parse(html,current);
		}
		//Console.WriteLine("爬行结束");
		text += "爬行结束\n";
		WriteMessageToLabel();
		urls.Clear();
	}

	public string Download(string url)
    {
		try
		{
			WebClient webClient = new WebClient();
			webClient.Encoding = Encoding.UTF8;
			string html = webClient.DownloadString(url);

			string fileName = count.ToString();
			File.WriteAllText(fileName, html, Encoding.UTF8);
			return html;
		}
		catch (Exception ex)
		{
			//Console.WriteLine(ex.Message);
			text += ex.Message+"\n";
			WriteMessageToLabel();
			return "";
		}
	}

	public void Parse(string html,string current) //页面代码，此页面的URL
	{
		
		string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+(.html|.aspx|.jsp)[""']"; ; //匹配对应的链接
		MatchCollection matches = new Regex(strRef).Matches(html);
		foreach (Match match in matches)
		{
			string oneOfStrRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"','\"','#',' ','>');
			//text += oneOfStrRef + '\n';
			//WriteMessageToLabel();

			oneOfStrRef = FixUrl(oneOfStrRef, current);  //修正成绝对路径
			//text += oneOfStrRef + '\n';
			//WriteMessageToLabel();

			if (oneOfStrRef.Length == 0) continue;
			if (urls[oneOfStrRef] == null) urls[oneOfStrRef] = false;
		}
	}
	
	static private string FixUrl(string url, string pageUrl)  //匹配到的URL，和当前页面的绝对地址
	{
		string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
		if (url.Contains("://"))  
		{ 
			return url;
		}
		if (url.StartsWith("//")) 
		{
			Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
			string protocal = urlMatch.Groups["protocal"].Value;
			return protocal + ":" + url;
		}
		if (url.StartsWith("/")) //根目录
		{
			Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
			String site = urlMatch.Groups["site"].Value;
			return site.EndsWith("/") ? site + url.Substring(1) : site + url;
		}

		if (url.StartsWith("../")) //父级目录
		{
			url = url.Substring(3);
			int idx = pageUrl.LastIndexOf('/');
			return FixUrl(url, pageUrl.Substring(0, idx));
		}

		if (url.StartsWith("./")) //同级目录
		{
			return FixUrl(url.Substring(2), pageUrl);
		}
		
		int end = pageUrl.LastIndexOf("/");
		return pageUrl.Substring(0, end) + "/" + url;
	}
}
