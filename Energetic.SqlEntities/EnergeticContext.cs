using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Energetic.Models.Club.Contacts;
using Energetic.Models.Club.Cubs;
using Energetic.Models.Club.Gallery;
using Energetic.Models.Club.History;
using Energetic.Models.Club.MainPhotoUsualInformations;
using Energetic.Models.Club.Personal;
using Energetic.Models.Club.Players;
using Energetic.Models.Club.Stadium;
using Energetic.Models.Club.Team;
using Energetic.Models.Club.Video;

namespace Energetic.SqlEntities
{
    public partial class EnergeticContext : DbContext
    {
        public EnergeticContext()
            : base("name=Energetic")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Cub> Cubs { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Turnament> Turnaments { get; set; }
        public virtual DbSet<MainPhotoUsualInformation> MainPhotoUsualInformations { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

    }
}
