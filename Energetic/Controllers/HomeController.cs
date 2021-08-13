
using Energetic.Domain;
using Energetic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Energetic.Models.Club.Players;
using Energetic.Models.Club.Index;

namespace Energetic.Controllers
{
    public class HomeController : Controller
    {


        private readonly IDataService _dataService;

        /*------------------------------------*/
        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }
        public ActionResult index()
        {
            Index index = new Index
            {
                Photo = _dataService.GetMainPhotoUsualInformationByID(2),
                Cubs = _dataService.GetCub(),
                Table = _dataService.GetTable(),
                Match = _dataService.GetMatches()

            };

            return View("index", index);
        }

        public ActionResult footer()
        {
            var partners = _dataService.GetContacts(2); 
            return View("footer",partners);
        }


        /*----------------Club----------------*/
        public ActionResult usualInformation()
        {
            var usualInformation = _dataService.GetMainPhotoUsualInformationByID(1);
            return View("Club/usualInformation",usualInformation);
        }
        public ActionResult managment()
        {
            var management = _dataService.GetPersonal(2); 
            return View("Club/managment",management);
        }
        public ActionResult Contacts()
        {
            var contacts = _dataService.GetContacts(1);          
            return View("Club/contacts", contacts);
        }
        public ActionResult stadiums()
        {
            var stadiums = _dataService.GetStadium();
            return View("Club/stadiums",stadiums);
        }
        public ActionResult history()
        {
            var history = _dataService.GetHistory(); 
            return View("Club/history",history);
        }

        /*----------------Team----------------*/
        public ActionResult coachs()
        {
            var coachs = _dataService.GetPersonal(1);
            return View("Team/coachs",coachs);
        }
        public ActionResult legends()
        {
            var legends = _dataService.GetPersonal(3);
            return View("Team/legends",legends);
        }
        public ActionResult mainPlayers()
        {
            ActiveTeam mainPlayers = new ActiveTeam
            {
                Goalkeepers = _dataService.GetPlayerByType("Вратарь",true),
                Defenders = _dataService.GetPlayerByType("Защитник", true),
                Midfielders = _dataService.GetPlayerByType("Полузащитник", true),
                Forwards = _dataService.GetPlayerByType("Нападающий", true)
            };
            return View("Team/mainPlayers",mainPlayers);
        }

        /*----------------Statistic----------------*/
        public ActionResult players()
        {
            ActiveTeam Players = new ActiveTeam
            {
                Goalkeepers = _dataService.GetPlayerByType("Вратарь", false),
                Defenders = _dataService.GetPlayerByType("Защитник", false),
                Midfielders = _dataService.GetPlayerByType("Полузащитник", false),
                Forwards = _dataService.GetPlayerByType("Нападающий", false)
            };
            return View("Statistic/players",Players);
        }
        public ActionResult team()
        {
            var Team = _dataService.GetTeam();
            return View("Statistic/team",Team);
        }

        public ActionResult player(int id)
        {
            var Player = _dataService.GetPlayerByID(id);
            return View("Statistic/player",Player);
        }


        /*----------------Multimedia----------------*/
        public ActionResult albums()
        {
            var Albums = _dataService.GetAlbum();

            return View("Multimedia/albums",Albums);
        }
        public ActionResult video()
        {
            var Video = _dataService.GetVideo();
            return View("Multimedia/video",Video);
        }

        public ActionResult album(int Id)
        {
            var Album = _dataService.GetAlbumByID(Id);
            return View("Multimedia/album",Album);
        }

        /*-------------------------------------*/

    }
}