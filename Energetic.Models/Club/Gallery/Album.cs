using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energetic.Models.Club.Gallery
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public List<Photo> Photos { get; set; }

    }
}
