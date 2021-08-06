using System;
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
using Energetic.SqlEntities;

namespace Energetic.Repository
{
    public class DataProvider : IDataProvider
    {
        private EnergeticContext _dbContext;

        public DataProvider()
        {
            CreateDbContext();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            _dbContext = new EnergeticContext();
            //_dbContext.Database.Initialize(false);
            // Do NOT enable proxied entities, else serialization fails
            //if false it will not get the associated certification and skills when we get the applicants
            _dbContext.Configuration.ProxyCreationEnabled = true;

            // Load navigation properties explicitly (avoid serialization trouble)
            _dbContext.Configuration.LazyLoadingEnabled = true;

            // Because Web API will perform validation, we don't need/want EF to do so
            _dbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _dbContext?.Dispose();
        }

        #endregion

        #region fields

        private IGenericRepository<Contact> _contacts;
        private IGenericRepository<Cub> _cubs;
        private IGenericRepository<Album> _albums;
        private IGenericRepository<Turnament> _turnaments;
        private IGenericRepository<MainPhotoUsualInformation> _mainPhotoUsualInformations;
        private IGenericRepository<Personal> _personals;
        private IGenericRepository<Player> _players;
        private IGenericRepository<Stadium> _stadiums;
        private IGenericRepository<Team> _teams;
        private IGenericRepository<Video> _videos;
        private IGenericRepository<Photo> _photos;

        #endregion

        #region Repositories

        public IGenericRepository<Contact> Contacts => _contacts ?? (_contacts = new EfGenericRepository<Contact>(_dbContext));
        public IGenericRepository<Cub> Cubs => _cubs ?? (_cubs = new EfGenericRepository<Cub>(_dbContext));
        public IGenericRepository<Album> Albums => _albums ?? (_albums = new EfGenericRepository<Album>(_dbContext));
        public IGenericRepository<Turnament> Turnaments => _turnaments ?? (_turnaments = new EfGenericRepository<Turnament>(_dbContext));
        public IGenericRepository<MainPhotoUsualInformation> MainPhotoUsualInformations => _mainPhotoUsualInformations ?? (_mainPhotoUsualInformations = new EfGenericRepository<MainPhotoUsualInformation>(_dbContext));
        public IGenericRepository<Personal> Personals => _personals ?? (_personals = new EfGenericRepository<Personal>(_dbContext));
        public IGenericRepository<Player> Players => _players ?? (_players = new EfGenericRepository<Player>(_dbContext));
        public IGenericRepository<Stadium> Stadiums => _stadiums ?? (_stadiums = new EfGenericRepository<Stadium>(_dbContext));
        public IGenericRepository<Team> Teams => _teams ?? (_teams = new EfGenericRepository<Team>(_dbContext));
        public IGenericRepository<Video> Videos => _videos ?? (_videos = new EfGenericRepository<Video>(_dbContext));
        public IGenericRepository<Photo> Photos => _photos ?? (_photos = new EfGenericRepository<Photo>(_dbContext));



        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------*/




        #endregion
    }
}
