using BotHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BotHunter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DataRepository _DataRepository;
        public HomeController(DataRepository repository)
        {
            _DataRepository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dialog(Guid? Id = null)
        {
            Dialog dialog = null;
            if (Id != null)
            {
                dialog = _DataRepository.Dialogs.Include(d => d.Creator).FirstOrDefault(d => d.Id == Id.Value);
            }
            if (dialog == null)
            {
                dialog = new Dialog
                {
                    Id = Guid.NewGuid()
                };
            }
            return View(dialog);
        }
        [HttpPost]
        public ActionResult Dialog(Dialog dialog)
        {
            var result = _DataRepository.Dialogs.FirstOrDefault(d => d.Id == dialog.Id);
            if (result == null)
            {
                _DataRepository.Dialogs.Add(dialog);
            }
            else
            {
                result.Name = dialog.Name;
                result.Aiml = dialog.Aiml;
                result.BlocksXml = dialog.BlocksXml;

                _DataRepository.Dialogs.Attach(result);
            }

            _DataRepository.SaveChanges();

            return RedirectToAction("DialogsList");
        }

        public ActionResult DialogsList()
        {
            IList<Dialog> dialogs = _DataRepository.Dialogs.Include(d => d.Creator).ToList();
            return View(dialogs);
        }

        public ActionResult PersonalitiesList()
        {
            IList<Personality> personalities = _DataRepository.Personalities.ToList();
            return View(personalities);
        }
        public ActionResult Personality(Guid? Id = null)
        {
            Personality personality = null;
            if (Id != null)
            {
                personality = _DataRepository.Personalities.FirstOrDefault(d => d.Id == Id.Value);
            }
            if (personality == null)
            {
                personality = new Personality
                {
                    Id = Guid.NewGuid()
                };
            }
            return View(personality);
        }
        [HttpPost]
        public ActionResult Personality(Personality personality)
        {
            var result = _DataRepository.Personalities.FirstOrDefault(d => d.Id == personality.Id);
            if (result == null)
            {
                _DataRepository.Personalities.Add(personality);
            }
            else
            {
                result.Name = personality.Name;
                result.LastName = personality.LastName;
                result.Phone = personality.Phone;
                result.Telegram = personality.Telegram;
                result.Email = personality.Email;

                _DataRepository.Personalities.Attach(result);
            }

            _DataRepository.SaveChanges();

            return RedirectToAction("PersonalitiesList");
        }

        public ActionResult SkillsList()
        {
            IList<Skill> skills = _DataRepository.Skills.ToList();
            return View(skills);
        }
    }


}