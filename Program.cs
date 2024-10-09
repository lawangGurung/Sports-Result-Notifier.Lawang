using System.Diagnostics;
using HtmlAgilityPack;
using Sports_Result_Notifier.Lawang;

DotNetEnv.Env.Load();

var scrapped = new WebScrapper("https://www.basketball-reference.com/boxscores/");
var title = scrapped.GetTitle();

var result = scrapped.GetGameResult();


// List<HtmlNode> nodes = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[position()<3]").ToList();

// foreach(var node in nodes)
// {
//     var looser = node.SelectSingleNode(".//tr[1]/td[1]/a").InnerText;
//     int looserScore = int.Parse(node.SelectSingleNode(".//tr[1]/td[2]").InnerText); 
//     var winner = node.SelectSingleNode(".//tr[2]/td[1]/a").InnerText;

//     Console.WriteLine($"looser: {looser}");
//     Console.WriteLine($"Score: {looserScore}");

//     Console.WriteLine($"winner: {winner}");
// }

// Console.WriteLine(nodes.Count());

