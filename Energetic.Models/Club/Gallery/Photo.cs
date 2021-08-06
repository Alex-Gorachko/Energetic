using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energetic.Models.Club.Gallery
{
    public class Photo
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Url { get; set; }
        public Album Album { get; set; }
    }
}
