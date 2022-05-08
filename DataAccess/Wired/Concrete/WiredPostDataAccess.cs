using DataAccess.Wired.Abstract;
using Entities.Concrete;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DataAccess.Wired.Concrete;

public class WiredPostDataAccess : IWiredPostDataAccess
{
    public IList<WiredPost> DataAdapter()
    {
        List<WiredPost> list = new List<WiredPost>();
        string data = GetData("https://www.wired.com/search/?q=&sort=publishdate+desc");
        data = HttpUtility.HtmlDecode(data);
        var urls = Regex.Matches(data, @"<a class=""(.*?)"" data-component-type=""(.*?)"" data-recirc-pattern=""summary-item"" href=""(.*?)""><h3 class=""(.*?)"" data-testid=""SummaryItemHed"">(.*?)</h3></a>");
        var categories = Regex.Matches(data, @"<span class=""RubricName(.*?)"">(.*?)</span>");
        int maximumPosts = 5;
        for (int i = 0; i < maximumPosts; i++)
        {
            string category = categories[i].Groups[2].Value.ToLower().ToString();

            if (category != "podcasts" && category != "sponsored content" && category != "buying guide")
            {
                string url = "https://www.wired.com" + urls[i].Groups[3].Value.ToString();
                string postData = GetData(url);
                postData = HttpUtility.HtmlDecode(postData);

                //Title
                string title = Regex.Matches(postData, @"<h1 data-testid=""ContentHeaderHed"" class=""(.*?)"">(.*?)</h1>")[0].Groups[2].Value.ToString();
                title = Regex.Replace(title, @"<(.*?>)", string.Empty);

                //Text
                string text = Regex.Matches(postData, @"<div class=""body__inner-container"">(.*?)</div>")[0].Groups[0].Value.ToString();
                text = Regex.Replace(text, @"<(.*?)>", string.Empty);

                list.Add(new WiredPost
                {
                    Title = title,
                    Text = text,
                });
            }
            else
            {
                maximumPosts++;
            }
        }

        return list;
    }

    public string GetData(string url)
    {
        using var webClient = new WebClient();
        Uri uri = new Uri(url);
        webClient.Encoding = Encoding.UTF8;
        return webClient.DownloadString(url);
    }
}
