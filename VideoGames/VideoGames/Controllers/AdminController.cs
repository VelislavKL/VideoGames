using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using video_games.Repositories;
using video_games.Models;

namespace video_games.Controllers
{
    public class AdminController : Controller
    {
        private IRepository games;

        public AdminController(IRepository movieRepository)
        {
            this.games = movieRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertData()
        {

            return View();
        }
   
        [HttpPost]
        public IActionResult InsertData(Games game, string command)
        {
            if (Request.Form.ContainsKey("addRequirements"))
            {
                if (game.Requirements == null)
                {
                    game.Requirements = new List<Requirements>();
                }

                game.Requirements.Add(new Requirements());

                return View(game);
            }

            else if (Request.Form.ContainsKey("addContentRating"))
            {
                if (game.ContentRating == null)
                {
                    ViewBag.successMessage = "Success";
                    game.ContentRating= new ContentRating();
                }

                return View(game);
            }
            
            /*
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            */

            // записване в базата от данни
            games.Add(game);

            // записване в xml
            Export(game);

            return RedirectToAction(nameof(Index));
        }

        // изтрива всички записи от базата
        public IActionResult DeleteData()
        {
            games.DeleteAll();

            return RedirectToAction(nameof(Index));
        }   

        // записване в xml
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Export(Games game)
        {
            WriteToXML($"AppData/xml-{game.GameId}.xml", game);
        }

        private void WriteToXML(string fileName, Games game)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CloseOutput = true;
            settings.Indent = true;

            using (XmlWriter xmlWriter = XmlWriter.Create(new FileStream(fileName, FileMode.Create), settings))
            {
                // сериализация
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Games));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "");

                xmlWriter.WriteDocType("Games", null, "VideoGamesDTD.dtd", null);
                xmlSerializer.Serialize(xmlWriter, game, namespaces);
            }
        }

        // записване в базата данни от xml
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Import()
        {
            foreach (string xmlFileName in Directory.GetFiles("AppData", "*.xml"))
            {
                    Games game = ReadFromXml(xmlFileName);

                    games.Add(game);
            }

            return RedirectToAction(nameof(Index));
        }

        private Games ReadFromXml(string fileName)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CloseInput = true;
            settings.DtdProcessing = DtdProcessing.Ignore;

            using (XmlReader xmlReader = XmlReader.Create(new FileStream(fileName, FileMode.Open), settings))
            {
                // десериализация
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Games));
                Games game = (Games)xmlSerializer.Deserialize(xmlReader);

                return game;
            }
        }
        
    }
}
