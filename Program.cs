using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Program
    {
        private static Dictionary<string, Team> teams = new Dictionary<string, Team>();
        private static Dictionary<string, Player> players = new Dictionary<string, Player>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Въведете команда:");
                string command = Console.ReadLine();

                if (command.StartsWith("create_team"))
                {
                    CreateTeam(command);
                }
                else if (command.StartsWith("create_player"))
                {
                    CreatePlayer(command);
                }
                else if (command.StartsWith("add_player"))
                {
                    AddPlayerToTeam(command);
                }
                else if (command.StartsWith("remove_player"))
                {
                    RemovePlayerFromTeam(command);
                }
                else if (command.StartsWith("print_team"))
                {
                    PrintTeam(command);
                }
                else if (command.StartsWith("print_log_txt"))
                {
                    PrintLogTxt(command);
                }
                else if (command == "exit")
                {
                    break;
                }
            }
        }

        private static void CreateTeam(string command)
        {
            string teamName = command.Split(' ')[1];
            if (!teams.ContainsKey(teamName))
            {
                teams[teamName] = new Team(teamName);
                Console.WriteLine($"Отборът {teamName} беше създаден.");
            }
            else
            {
                Console.WriteLine("Отборът вече съществува.");
            }
        }

        private static void CreatePlayer(string command)
        {
            string[] parts = command.Split(' ');
            string playerName = parts[1];
            string position = parts[2];

            if (!players.ContainsKey(playerName))
            {
                players[playerName] = new Player(playerName, position);
                Console.WriteLine($"Играчът {playerName} беше създаден.");
            }
            else
            {
                Console.WriteLine("Играчът вече съществува.");
            }
        }

        private static void AddPlayerToTeam(string command)
        {
            string[] parts = command.Split(' ');
            string teamName = parts[1];
            string playerName = parts[2];
            string position = parts[3];

            if (teams.ContainsKey(teamName) && players.ContainsKey(playerName))
            {
                Player player = players[playerName];
                player.Position = position;
                teams[teamName].AddPlayer(player);
                Console.WriteLine($"Играчът {playerName} беше добавен към отбора {teamName}.");
            }
            else
            {
                Console.WriteLine("Отборът или играчът не съществуват.");
            }
        }

        private static void RemovePlayerFromTeam(string command)
        {
            string[] parts = command.Split(' ');
            string teamName = parts[1];
            string playerName = parts[2];

            if (teams.ContainsKey(teamName) && players.ContainsKey(playerName))
            {
                Player player = players[playerName];
                teams[teamName].RemovePlayer(player);
                Console.WriteLine($"Играчът {playerName} беше премахнат от отбора {teamName}.");
            }
            else
            {
                Console.WriteLine("Отборът или играчът не съществуват.");
            }
        }

        private static void PrintTeam(string command)
        {
            string[] parts = command.Split(' ');
            string teamName = parts[1];
            string filePath = parts[2];

            if (teams.ContainsKey(teamName))
            {
                ILog log = new TxtLog(filePath);

                foreach (var record in teams[teamName].History)
                {
                    log.Log(record);
                }
                Console.WriteLine($"Историята на отбора {teamName} е записана в текстов файл.");
            }
            else
            {
                Console.WriteLine("Отборът не съществува.");
            }
        }

        private static void PrintLogTxt(string command)
        {
            string[] parts = command.Split(' ');
            string teamName = parts[1];
            string filePath = parts[2];

            if (teams.ContainsKey(teamName))
            {
                ILog log = new TxtLog(filePath);
                foreach (var record in teams[teamName].History)
                {
                    log.Log(record);
                }
                Console.WriteLine($"Историята на отбора {teamName} е записана в текстов файл.");
            }
            else
            {
                Console.WriteLine("Отборът не съществува.");
            }
        }
    }
}
