using System;
using System.Reflection.Metadata;
using HtmlAgilityPack;
using Sports_Result_Notifier.Lawang.Models;

namespace Sports_Result_Notifier.Lawang;

public class WebScrapper
{
    private HtmlDocument? _doc;
    public WebScrapper(string url)
    {
        try
        {
            _doc = new HtmlWeb().Load(url);
        }
        catch(Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }

    public string GetTitle()
    {
        if(_doc == null) return "";

        return _doc.GetElementbyId("content").SelectSingleNode("//h1").InnerText;
    }

    public GameResult GetGameResult()
    {
        var gameResult = new GameResult();
        if(_doc == null) return gameResult;

        List<HtmlNode> tableNodes = _doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[position()<3]").ToList();
        var resultNodes = tableNodes[0].SelectNodes(".//tr").ToList();

        var listOfTeam = GetTeams(resultNodes);

        var quaterNodes = tableNodes[1].SelectNodes(".//tbody/tr").ToList();
        listOfTeam = GetQuaterScores(listOfTeam, quaterNodes);

        if(listOfTeam[0].TotalScore > listOfTeam[1].TotalScore)
        {
            gameResult.Looser = listOfTeam[1];
            gameResult.Winner = listOfTeam[0];
        }
        else
        {
            gameResult.Looser = listOfTeam[0];
            gameResult.Winner = listOfTeam[1];
        }

        return gameResult;
    }

    private List<Team> GetQuaterScores(List<Team> teams, List<HtmlNode> quaterNodes)
    {
        for(int i = 0; i < quaterNodes.Count(); i++)
        {
            var scoreNodes = quaterNodes[i].SelectNodes(".//td[position()>1]");
            teams[i].QuarterScores = ScoreNodes(scoreNodes);
        }
        return teams;
    }

    private List<int> ScoreNodes(HtmlNodeCollection scoreNode)
    {
        List<int> scoreList = new();
        for(int i = 0; i < scoreNode.Count(); i++)
        {
            var score = int.Parse(scoreNode[i].InnerText);
            scoreList.Add(score);
        }
        return scoreList;
    }
    private List<Team> GetTeams(List<HtmlNode> rowNodes)
    {
        var teams = new List<Team>();

        foreach(var node in rowNodes)
        {
           var team = new Team();

           team.TeamName = node.SelectSingleNode(".//td[1]").InnerText;
           team.TotalScore = int.Parse(node.SelectSingleNode(".//td[2]").InnerText);

           teams.Add(team);
        }
        return teams;
    }
}
