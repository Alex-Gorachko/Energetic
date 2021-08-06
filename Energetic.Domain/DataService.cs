
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
using Energetic.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Energetic.Domain
{
    public interface IDataService
    {
        /// <summary>
        ///     Получение контакта
        /// </summary>
        /// <param name="id">id контакта</param>
        /// <returns></returns>
        Contact GetContactByID(int id);
        Cub GetCubByID(int id);
        Album GetAlbumByID(int id);
        Turnament GetTurnamentByID(int id);
        MainPhotoUsualInformation GetMainPhotoUsualInformationByID(int id);
        Personal GetPersonalByID(int id);
        Player GetPlayerByID(int id);
        Stadium GetStadiumByID(int id);
        Team GetTeamByID(int id);
        Video GetVideoByID(int id);

        /// <summary>
        ///     Получение списка контактов
        /// </summary>
        /// <returns></returns>
        List<Contact> GetContacts(int type);
        List<Cub> GetCub();
        List<Album> GetAlbum();
        List<IGrouping<int, Turnament>> GetHistory();
        List<Turnament> GetTurnament();
        List<MainPhotoUsualInformation> GetMainPhotoUsualInformation();
        List<Personal> GetPersonal(int type);
        List<Player> GetPlayer();
        List<Player> GetPlayerByType(string type, bool start);
        List<Stadium> GetStadium();
        List<Team> GetTeam();
        List<Video> GetVideo();

    }

    public class DataService : IDataService
    {
        private readonly IDataProvider _dataProvider;

        public DataService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        /*------------------------------------------------------*/
        public Contact GetContactByID(int id)
        {
            return _dataProvider.Contacts.GetById(id);
        }

        public List<Contact> GetContacts(int type)
        {

            return _dataProvider.Contacts.Filter(obj => obj.Type == type).ToList();


        }
        /*------------------------------------------------------*/
        public Cub GetCubByID(int id) => _dataProvider.Cubs.GetById(id);

        public List<Cub> GetCub() => _dataProvider.Cubs.GetAll().ToList();
        /*------------------------------------------------------*/ 
        public Album GetAlbumByID(int id)
        {
            var album = _dataProvider.Albums.GetById(id);
            album.Photos = _dataProvider.Photos.Filter(p => p.AlbumId == id).ToList();
            return album;
        }

        public List<Album> GetAlbum()
        {
            var albums = _dataProvider.Albums.GetAll().ToList();

            return albums;
        }

        /*------------------------------------------------------*/
        public List<IGrouping<int, Turnament>>  GetHistory()
        {
            var turnaments = _dataProvider.Turnaments.GetAll().GroupBy(p=>p.Year).ToList();

            return turnaments;
        }
        /*------------------------------------------------------*/
        public Turnament GetTurnamentByID(int id)
        {
            return _dataProvider.Turnaments.GetById(id);
        }

        public List<Turnament> GetTurnament()
        {



            return _dataProvider.Turnaments.GetAll().ToList();
        }
        /*------------------------------------------------------*/
        public MainPhotoUsualInformation GetMainPhotoUsualInformationByID(int id)
        {
            return _dataProvider.MainPhotoUsualInformations.GetById(id);
        }

        public List<MainPhotoUsualInformation> GetMainPhotoUsualInformation()
        {



            return _dataProvider.MainPhotoUsualInformations.GetAll().ToList();
        }
        /*------------------------------------------------------*/
        public Personal GetPersonalByID(int id)
        {
            return _dataProvider.Personals.GetById(id);
        }

        public List<Personal> GetPersonal(int type)
        {


            return _dataProvider.Personals.Filter(obj => obj.Type == type).ToList();
        }
        /*------------------------------------------------------*/
        public Player GetPlayerByID(int id)
        {
            return _dataProvider.Players.GetById(id);
        }

        public List<Player> GetPlayer()
        {

            return _dataProvider.Players.GetAll().ToList();
        }

        public List<Player> GetPlayerByType(string type,bool IsStartLine)
        {
            if (IsStartLine) {
                return _dataProvider.Players.Filter(obj => obj.Position == type && obj.MainSquade).ToList();
            }
            return _dataProvider.Players.Filter(obj => obj.Position == type).ToList();
        }
        /*------------------------------------------------------*/
        public Stadium GetStadiumByID(int id)
        {
            return _dataProvider.Stadiums.GetById(id);
        }

        public List<Stadium> GetStadium()
        {



            return _dataProvider.Stadiums.GetAll().ToList();
        }
        /*------------------------------------------------------*/
        public Team GetTeamByID(int id)
        {
            return _dataProvider.Teams.GetById(id);
        }

        public List<Team> GetTeam()
        {



            return _dataProvider.Teams.GetAll().ToList();
        }
        /*------------------------------------------------------*/
        public Video GetVideoByID(int id)
        {
            return _dataProvider.Videos.GetById(id);
        }

        public List<Video> GetVideo()
        {



            return _dataProvider.Videos.GetAll().ToList();
        }

        /*------------------------------------------------------*/
    }
}
