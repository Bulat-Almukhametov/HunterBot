using BotHunter.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public abstract class Entity
    {
        [Key, DisplayName("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DisplayName("Создатель")]
        public User Creator { get; set; }
        public Guid? CreatorId { get; set; }
        [DisplayName("Дата создания")]
        public DateTime? CreatedOn { get; set; }
        [DisplayName("Последний редактор")]       
        public Guid? LastEditorId { get; set; }
        public User LastEditor { get; set; }
        [DisplayName("Дата изменения")]
        public DateTime? ChangedOn { get; set; }

        protected static Func<Entity> GetInstance;

        public void CreatedBy(User user)
        {
            this.Id = Guid.NewGuid();
            this.CreatorId = user.Id;
            this.LastEditorId = user.Id;
            this.CreatedOn = DateTime.Now;
            this.ChangedOn = DateTime.Now;
        }
        public static Entity CreateNew(User user)
        {
            if (GetInstance == null)
            {
                throw new Exception("Нет реализации статического конструктора для сущности, которая бы заполняла метод обратного вызова GetInstance");
            }
            else
            {
                Entity entity = GetInstance();
                entity.CreatedBy(user);

                return entity;
            }

        }

        public void ChangedBy(User user)
        {
            LastEditorId = user.Id;
            ChangedOn = DateTime.Now;
        }

    }
}