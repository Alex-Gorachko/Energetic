using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Energetic.Models.Club.Players
{
    public class ActiveTeam
    {
        public List<Player> Goalkeepers { get; set; }
        public List<Player> Defenders { get; set; }
        public List<Player> Midfielders { get; set; }
        public List<Player> Forwards { get; set; }
    }
}
