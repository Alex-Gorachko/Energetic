
using Energetic.Models.Club.Contacts;
using Energetic.Models.Club.Cubs;
using Energetic.Models.Club.Gallery;
using Energetic.Models.Club.History;
using Energetic.Models.Club.MainPhotoUsualInformations;
using Energetic.Models.Club.Matchs;
using Energetic.Models.Club.Personal;
using Energetic.Models.Club.Players;
using Energetic.Models.Club.Stadium;
using Energetic.Models.Club.Table;
using Energetic.Models.Club.Team;
using Energetic.Models.Club.Video;
using Energetic.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

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
        Match ParseMatch(string url);
        List<Contact> GetContacts(int type);
        List<Cub> GetCub();
        List<TurnamentTable> GetTable();
        Matches GetMatches();
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

        public Match ParseMatch(string url)
        {
            WebClient web1 = new WebClient();

            url = Encoding.UTF8.GetString(web1.DownloadData(url));


            Match match = new Match { };

            url = url.Substring(url.IndexOf("table score-table"));
            url = url.Substring(url.IndexOf("<td"));
            url = url.Substring(url.IndexOf(">") + 1);
            match.Tur = url.Substring(0, url.IndexOf("</td"));


            for (int i = 0; i < 5; i++)
            {
                url = url.Substring(url.IndexOf("<td") + 4);
                match.FirstTeam = url.Substring(0, url.IndexOf("</td>"));
                url = url.Substring(url.IndexOf("<td") + 4);
                url = url.Substring(url.IndexOf("<td") + 4);
                match.Score = url.Substring(0, url.IndexOf("<div"));
                url = url.Substring(url.IndexOf(">") + 1);
                match.Date = url.Substring(0, url.IndexOf("</div"));
                url = url.Substring(url.IndexOf("<td") + 4);
                url = url.Substring(url.IndexOf("<td") + 4);
                match.SecondTeam = url.Substring(0, url.IndexOf("</td>"));

                if (match.FirstTeam == "Энергетик-БГАТУ" || match.SecondTeam == "Энергетик-БГАТУ")
                {
                    break;
                }
                url = url.Substring(url.IndexOf("<tr") + 1);
                

            }


            return match;
        }
        public Matches GetMatches() {

            var matches = new Matches { };

            WebClient web1 = new WebClient();
            string data = Encoding.UTF8.GetString(web1.DownloadData("https://championship.abff.by/male/tournaments/1/?tournamentId=69&childTournament=94"));

            data = data.Substring(data.IndexOf("common-tabs-menu"));
            data = data.Substring(data.IndexOf("hidden-mobile")+1);
            data = data.Substring(data.IndexOf("hidden-mobile"));
            data = data.Substring(data.IndexOf("href")+6);
            string url = data.Substring(0, data.IndexOf("="));
            

            data= "https://championship.abff.by"+url+"=94";

            matches.next = ParseMatch(data);


            if (matches.next.Tur == "1 тур") {
                matches.last = new Match
                {
                    FirstTeam = ".",
                    Tur = "Прошлый матч отсутствует",
                    SecondTeam = ".",
                    Score = ".",
                    Date = "."
                };
            }
            else {
                
               data = data.Replace("1", ((int.Parse(matches.next.Tur.Substring(0, matches.next.Tur.IndexOf(" тур")))) -1).ToString()); 
                data += "&match=1";
                matches.last = ParseMatch(data);
            }
            
            return matches;
        }

        public List<TurnamentTable> GetTable()
        {
            List<TurnamentTable> Table = new List<TurnamentTable> { };
            WebClient web1 = new WebClient();

            string turnamentTable = Encoding.UTF8.GetString( web1.DownloadData("https://championship.abff.by/male/tournaments/1/?tournamentId=69&childTournament=94"));

            turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("tab-content active"));
            turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<tbody>") + 7);
            turnamentTable = turnamentTable.Substring(0, turnamentTable.IndexOf("</tbody>"));

            int i = 0;
            int x = -1;
            int count = -1;
            while (i != -1)
            {
                i = turnamentTable.IndexOf("<tr>", x + 1);
                x = i;
                count++;
            }

            turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("tr")+3);
            turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("tr")+3);

            for (int ii = 0; ii < count; ii++)
            {
                string[] mass = new string[8];
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                mass[0]= turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf(">") + 1);
                mass[1] = turnamentTable.Substring(0, turnamentTable.IndexOf("</a>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                mass[2] = turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf(">") + 1);
                mass[3] = turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf(">") + 1);
                mass[4] = turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf(">") + 1);
                mass[5] = turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf(">") + 1);
                mass[6] = turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<td") + 4);
                mass[7] = turnamentTable.Substring(0, turnamentTable.IndexOf("</td>"));

                turnamentTable = turnamentTable.Substring(turnamentTable.IndexOf("<tr") + 4);
                Table.Add(new TurnamentTable { position = mass[0], team = mass[1], playes = mass[2], win = mass[3], draw = mass[4], loose = mass[5], balls = mass[6], points = mass[7] });
            
            }

            return Table;
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
