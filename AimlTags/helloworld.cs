using AIMLbot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimlTags
{
    [CustomTag]
    public class helloworld : AIMLTagHandler
    {
        public helloworld()
        {
            inputString = "helloworld";
        }
        protected override string ProcessChange()
        {
            return "Привет мир, ты сказал: " + this.inputString;
        }
    }
}
