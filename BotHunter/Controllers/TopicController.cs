using BotHunter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BotHunter.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private DataRepository _DataRepository;

        public TopicController(DataRepository dataRepository)
        {
            _DataRepository = dataRepository;
        }

        [HttpPost]
        public JsonResult All()
        {
            return Json(_DataRepository.Topics.
                // возвращаем конфигурацию элемента для jsTree
                Select(t => new {
                    id = t.Id,
                    text = t.Name,
                    parent = (t.Parent == null ? "#" : t.Parent.Id.ToString()),
                    type = t.Type.ToString(),
                    a_attr = t.Description != null ? new { title = t.Description } : null,
                    data = new
                    {
                        Id = t.Id,
                        ParentName = t.Parent.Name,
                        ParentId = t.ParentId,
                        Name = t.Name,
                        Description = t.Description,
                        Type = (int)t.Type
                    }
                })
                .OrderBy(node => node.text)
                .ToArray());
        }

        public PartialViewResult Display(Guid? id = null)
        {
            DialogTopic topic = null;

            if (id != null)
            {
                topic = _DataRepository.Topics.FirstOrDefault(t => t.Id == id);
            }

            if (topic == null)
            {
                topic = new DialogTopic();
            }
            

            return PartialView(topic);
        }

        [HttpPost]
        public JsonResult Edit(DialogTopic topic)
        {
            try
            {
                var record = _DataRepository.Topics.FirstOrDefault(t => t.Id == topic.Id);
                if (record == null)
                {
                    _DataRepository.Topics.Add(topic);
                }
                else
                {
                    record.Name = topic.Name;
                    record.Type = topic.Type;
                    record.Description = topic.Description;

                    _DataRepository.Topics.Attach(record);
                    _DataRepository.Entry(record).State = EntityState.Modified;
                }
                _DataRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            try
            {
                var topic = new DialogTopic { Id = id };
                _DataRepository.Topics.Attach(topic);
                _DataRepository.Topics.Remove(topic);
                _DataRepository.SaveChanges();
            }
            catch(Exception ex)
            {
                Json(new { success = false, error = ex.Message });
            }

            return Json(new { success = true });
        }
    }
}
