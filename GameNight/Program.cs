/*
* Name: Chase McBee
* Course: CSCI 1250, Section 001
* Assignment: Lab 08, Game Night
* Date: November 18, 2026
* Description: Keeps a game night leaderboard in three text files. Shows the
* season so far, records tonight's points, saves the new totals,
* and adds tonight's result to a history that grows every week.
*/

//Part 1: The Standing

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

// Look for the data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

Console.Write("PLAYERS".PadRight(11));
Console.Write("POINTS\n");

string[] players  = File.ReadAllLines(PLAYERS_FILE);
string[] points  = File.ReadAllLines(POINTS_FILE);

static int LeaderIndex(string[] points)
{
    int leaderPoints = 0;
    int leaderPosition = 0;
    // for: need the index of each point so it can remember the leader's position
    for (int i = 0; i < points.Length; i++)
    {
        if (Convert.ToInt32(points[i]) > leaderPoints)
    {
        leaderPoints = Convert.ToInt32(points[i]);
        leaderPosition = i;
    }
    }
    return leaderPosition;
}

// for: the index for players and the index for points are seperate, so we need a way to combine those values
for (int i = 0; i < players.Length; i++)
        {
            Console.WriteLine(players[i].PadRight(11)+points[i]);
        }

Console.WriteLine($"Leader: {players[LeaderIndex(points)]} with {points[LeaderIndex(points)]}");

static int TotalPoints(string[] points)
{
    int totalPoints = 0;
    // foreach: compiles all of the info in the points array rather than a specific value
    foreach (string point in points)
    {
        totalPoints += Convert.ToInt32(point);
    }
    return totalPoints;
}

Console.WriteLine($"Total points: {TotalPoints(points)}");