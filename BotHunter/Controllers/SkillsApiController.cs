using BotHunter.Models;
using BotHunter.Models.Infrastructure;
using BotHunter.Models.JqGrid;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BotHunter.Controllers
{
    public class SkillsApiController : ApiController
    {
        private DataRepository _DataRepository;
        private IAuthorization _AuthorizeHelper;

        public SkillsApiController(DataRepository dataRepository, IAuthorization authorizeHelper)
        {
            _DataRepository = dataRepository;
            _AuthorizeHelper = authorizeHelper;
        }

        public JqGridResponse GetAll([FromUri]JqGridRequest request)
        {
            var skillType = typeof(Skill);
            IQueryable<Skill> skills = _DataRepository.Skills;

            // поиск
            if (request._search)
            {
                PropertyInfo searchColumn;
                try
                {
                    searchColumn = skillType.GetProperty(request.searchField);
                }
                catch (Exception ex)
                {
                    throw new Exception("Неверное название колонки поиска", ex);
                }

                skills = skills.Where(s => (string)searchColumn.GetValue(s) == request.searchString);
            }

            PropertyInfo orderColumn;
            try
            {
                orderColumn = skillType.GetProperty(request.sidx);
            }
            catch (Exception ex)
            {
                throw new Exception("Неверное название колонки для сортировки", ex);
            }

            // сортировка
            skills = skills.
                OrderBy(s => request.sidx == "CreatedOn" ? s.CreatedOn : s.ChangedOn)
                .Skip((request.page - 1) * request.rows)
                .Take(request.rows);

            // собираем выборку
            var skillsArray = skills
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Creator,
                    s.CreatedOn,
                    s.LastEditor,
                    s.ChangedOn,
                    s.Description
                })
                .ToArray()
                .Select(obj => new
                {
                    obj.Id,
                    cell = new object[]
                    {
                        obj.Name,
                        obj.Creator != null ? (obj.Creator.Name + " " + obj.Creator.LastName) : "",
                        obj.CreatedOn,
                        obj.LastEditor != null ? (obj.LastEditor.Name + " " + obj.LastEditor.LastName) : "",
                        obj.ChangedOn,
                        obj.Description
                    }
                })
                .ToArray();
            return new JqGridResponse
            {
                page = request.page,
                records = skillsArray.Length,
                total = (int)Math.Ceiling((double)_DataRepository.Skills.Count() / request.rows),
                rows = skillsArray
            };
        }



        public object Post([FromBody]Skill value)
        {
            var skill = _DataRepository.Skills.FirstOrDefault(s => s.Id == value.Id);

            if (skill != null)
            {
                skill.ChangedBy(_AuthorizeHelper.CurrentUser);
                skill.Name = value.Name;
                skill.Description = value.Description;

                _DataRepository.Skills.Attach(skill);
                _DataRepository.Entry(skill).State = EntityState.Modified;

            }
            else
            {
                skill = new Skill { Id = Guid.NewGuid() };
                skill.CreatedBy(_AuthorizeHelper.CurrentUser);
                _DataRepository.Skills.Add(skill);
            }
            
            _DataRepository.SaveChanges();

            return new { success = true };
        }

        
        public void Delete(Skill skill)
        {
            _DataRepository.Skills.Attach(skill);
            _DataRepository.Skills.Remove(skill);
            _DataRepository.SaveChanges();
        }
    }
}
