
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
using System;

namespace Energetic.Repository
{
    public interface IDataProvider : IDisposable
    {
        IGenericRepository<Contact> Contacts { get; }
        IGenericRepository<Cub> Cubs { get; }
        IGenericRepository<Album> Albums { get; }
        IGenericRepository<Turnament> Turnaments { get; }
        IGenericRepository<MainPhotoUsualInformation> MainPhotoUsualInformations { get; }
        IGenericRepository<Personal> Personals { get; }
        IGenericRepository<Player> Players { get; }
        IGenericRepository<Stadium> Stadiums { get; }
        IGenericRepository<Team> Teams { get; }
        IGenericRepository<Video> Videos { get; }
        IGenericRepository<Photo> Photos { get; }


        void Save();
    }
}


