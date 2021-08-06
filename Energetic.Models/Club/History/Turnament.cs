using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energetic.Models.Club.History
{
    public class Turnament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Place { get; set; }
        public string Points { get; set; }
        public string Balls { get; set; }
        public int Year { get; set; }
        
    }
}
