using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotHunter.Models.JqGrid
{
    public class JqGridRequest
    {
        /// <summary>
        /// нужно ли выполнять поиск
        /// </summary>
        public bool _search { get; set; }
        public string nd { get; set; }
        /// <summary>
        /// количество строк в таблице
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// текущая страница
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// название колонки сортировки
        /// </summary>
        public string sidx { get; set; }
        /// <summary>
        /// направление сортировки
        /// </summary>
        public string sord { get; set; }
        /// <summary>
        /// колонка сортировки
        /// </summary>
        public string searchField { get; set; }
        /// <summary>
        /// строка для поиска
        /// </summary>
        public string searchString { get; set; }
        public string searchOper { get; set; }
    }
}