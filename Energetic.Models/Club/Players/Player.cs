using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energetic.Models.Club.Players
{
	public class Player
	{
		public int Id { get; set; }
		public string Photo { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public string Fathersname { get; set; }
		public DateTime Birthday { get; set; }
		public int Number { get; set; }
		public string Position { get; set; }
		public int Goals { get; set; }
		public int Playes { get; set; }
		public int YellowCard { get; set; }
		public int RedCard { get; set; }
		public bool MainSquade { get; set; }

	}
}
