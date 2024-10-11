using System;
using System.Text;
using Sports_Result_Notifier.Lawang.Models;

namespace Sports_Result_Notifier.Lawang;

public static class EmailBuilder
{
    public static string BuildEmail(GameResult? gameResult, string title)
    {
        var content = (gameResult == null) ? "NO GAME PLAYED TODAY" : title;
        var tableData = (gameResult != null) ? SummaryTable(gameResult) : ""; 
        string htmlFormat = 
            @$"
                <!doctype html>
                    <head>
                        <title>{title}</title>
                        <style>
                            table
                            {{
                                font-size: 2 rem;
                                margin: 1 rem;
                                padding: 1 rem;
                                border: 1px solid black;
                            }}
                            td
                            {{
                                padding: 1.5 rem;
                                margin: 2 rem;
                            }}
                            thead
                            {{
                                font-style: italic;
                                width: 50%; 
                            }}
                        </style>
                    </head>
                    <body>

                        <h1>{content}</h1>
                        {tableData}
                    </body>

                </html> 
            ";
        return htmlFormat;
    }

    private static string SummaryTable(GameResult result)
    {
        var cols = new string[] { "Teams", "1", "2", "3", "4", "Total Scores"};

        string tableCols = string.Join("", cols.Select(cols => $"<th>{cols}</th>"));

        return 
            @$"
            <table>
                <thead>
                    {tableCols}
                </thead>
                <tbody>
                    {DataTable(result.Looser)}
                    {DataTable(result.Winner)}
                </tbody>
            </table> 
            ";
    }

    private static string DataTable(Team team)
    {
        string tableData = string.Join("", team.QuarterScores.Select(score => $"<td>{score}</td>"));

        return 
            @$"
            <tr>
                <td>{team.TeamName}</td>
                {tableData}
                <td><b>{team.TotalScore}</b></td>
            </tr>
            ";
    }
}
