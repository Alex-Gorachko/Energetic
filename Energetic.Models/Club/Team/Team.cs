using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energetic.Models.Club.Team
{
	public class Team
    {
		public int Id { get; set; }
		public int Year { get; set; }
		public int Game { get; set; }
		public int Win { get; set; }
		public int Drow { get; set; }
		public int Loose { get; set; }
		public string Goals { get; set; }
		public int Points { get; set; }
		public int Place { get; set; }
		public string Forward { get; set; }

	}
}
