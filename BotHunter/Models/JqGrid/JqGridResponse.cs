using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.Models.JqGrid
{
    public class JqGridResponse
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public IEnumerable<object> rows { get; set; }
    }
}