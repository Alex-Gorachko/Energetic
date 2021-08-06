using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Energetic.Models.Club.MainPhotoUsualInformations;
using Energetic.Models.Club.Cubs;

namespace Energetic.Models.Club.Index
{
    public class Index
    {
        public MainPhotoUsualInformation Photo { get; set; }
        public List<Cub> Cubs { get; set; }
    }
}
