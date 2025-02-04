using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public List<string> History { get; set; } = new List<string>();

        public Team(string name)
        {
            Name = name;
            History.Add($"Отборът {name} е създаден на {DateTime.Now}");
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            History.Add($"Играч {player.Name} се е присъединил на {DateTime.Now}");
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            History.Add($"Играч {player.Name} е напуснал на {DateTime.Now}");
        }
    }
}
